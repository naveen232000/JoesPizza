using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JoesPizza.Data;
using JoesPizza.Models;
using JoesPizza.Migrations;
using System.Text;

namespace JoesPizza.Controllers
{
    public class OrderDetailsController : Controller
    {
        private readonly JoesPizzaContext _context;

        public OrderDetailsController(JoesPizzaContext context)
        {
            _context = context;
        }

        // GET: OrderDetails
        public async Task<IActionResult> Index()
        {
              return _context.OrderDetails != null ? 
                          View(await _context.OrderDetails.ToListAsync()) :
                          Problem("Entity set 'JoesPizzaContext.OrderDetails'  is null.");
        }

        // GET: OrderDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OrderDetails == null)
            {
                return NotFound();
            }

            var orderDetails = await _context.OrderDetails
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (orderDetails == null)
            {
                return NotFound();
            }

            return View(orderDetails);
        }

        // GET: OrderDetails/Create
        public IActionResult Create()
        {
           
            return View();
        }

        // POST: OrderDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,ItemId,Qyt,DeliveryAddress,pincode,PaymentType,CustomerName,CustomerEmail,MobileNum")] OrderDetails orderDetails)
        {
            Console.WriteLine("begin cr");
            orderDetails.ItemId = Convert.ToInt32(TempData["IteamId"]);
            orderDetails.TotalAmt = Convert.ToDouble(TempData["Price"]) * orderDetails.Qyt;
            orderDetails.PaymentStatus = "Pending";
            orderDetails.OdredDate = DateTime.Today;
            orderDetails.DeliveryDate = DateTime.Today.AddDays(7);
            orderDetails.iteamImage = Encoding.UTF8.GetBytes(TempData["Image"].ToString());

            if (!ModelState.IsValid)
            {
                try {
                    Console.WriteLine(orderDetails.OrderId);
                    Console.WriteLine(orderDetails.ItemId);
                    Console.WriteLine(orderDetails.CustomerName);
                    Console.WriteLine(orderDetails.CustomerEmail);
                    Console.WriteLine(orderDetails.PaymentType);
                    Console.WriteLine(orderDetails.MobileNum);
                    Console.WriteLine(orderDetails.PaymentStatus);
                    Console.WriteLine(orderDetails.TotalAmt);
                    Console.WriteLine(orderDetails.DeliveryAddress);
                    Console.WriteLine(orderDetails.Qyt);
                    Console.WriteLine(orderDetails.pincode);
                    Console.WriteLine(orderDetails.OdredDate);
                    Console.WriteLine(orderDetails.DeliveryDate);
                    _context.Add(orderDetails);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Details", new { id = orderDetails.OrderId });
                } catch (Exception ex) { Console.WriteLine(ex.Message); }
                
            }
            return View(orderDetails);
        }

        // GET: OrderDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OrderDetails == null)
            {
                return NotFound();
            }

            var orderDetails = await _context.OrderDetails.FindAsync(id);
            if (orderDetails == null)
            {
                return NotFound();
            }
            return View(orderDetails);
        }

        // POST: OrderDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,ItemId,Qyt,DeliveryAddress,pincode,TotalAmt,PaymentStatus,PaymentType,OdredDate")] OrderDetails orderDetails)
        {
            if (id != orderDetails.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderDetailsExists(orderDetails.OrderId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(orderDetails);
        }

        // GET: OrderDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.OrderDetails == null)
            {
                return NotFound();
            }

            var orderDetails = await _context.OrderDetails
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (orderDetails == null)
            {
                return NotFound();
            }

            return View(orderDetails);
        }

        // POST: OrderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OrderDetails == null)
            {
                return Problem("Entity set 'JoesPizzaContext.OrderDetails'  is null.");
            }
            var orderDetails = await _context.OrderDetails.FindAsync(id);
            if (orderDetails != null)
            {
                _context.OrderDetails.Remove(orderDetails);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderDetailsExists(int id)
        {
          return (_context.OrderDetails?.Any(e => e.OrderId == id)).GetValueOrDefault();
        }
    }
}
