using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JoesPizza.Data;
using JoesPizza.Models;

namespace JoesPizza.Controllers
{
    public class PizzasController : Controller
    {
        private readonly JoesPizzaContext _context;

        public PizzasController(JoesPizzaContext context)
        {
            _context = context;
        }

        // GET: Pizzas
        public async Task<IActionResult> Index()
        {
              return _context.Pizza != null ? 
                          View(await _context.Pizza.ToListAsync()) :
                          Problem("Entity set 'JoesPizzaContext.Pizza'  is null.");
        }

        // GET: Pizzas/Details/5
        public async Task<IActionResult> Placeorder(int id)
        {

            var pizza = await _context.Pizza
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (pizza == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
               
                    TempData["IteamId"] = pizza.ItemId.ToString();
                    TempData["Price"] = pizza.Price.ToString();
            
                TempData["Image"] = pizza.Image.ToString();
            }
                return RedirectToAction("Create", "OrderDetails");
         


        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pizza == null)
            {
                return NotFound();
            }

            var pizza = await _context.Pizza
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (pizza == null)
            {
                return NotFound();
            }


            return View(pizza);

        }

        // GET: Pizzas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pizzas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemId,ItemName,Title,Description,Price,Image")] Pizza pizza)
        {
            if (!ModelState.IsValid)
            {
                var files = Request.Form.Files;

                if (files.Count > 0)
                {

                    using (var filestream = files[0].OpenReadStream())
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            filestream.CopyTo(memoryStream);
                            pizza.Image = memoryStream.ToArray();
                        }
                    }
                }
                try
                {
                    _context.Add(pizza);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error occurred while saving data: " + ex.Message);
                    // Log the exception for debugging purposes
                }

                return RedirectToAction(nameof(Index));

            }
            return View(pizza);
        }

        // GET: Pizzas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pizza == null)
            {
                return NotFound();
            }

            var pizza = await _context.Pizza.FindAsync(id);
            if (pizza == null)
            {
                return NotFound();
            }
            return View(pizza);
        }

        // POST: Pizzas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemId,ItemName,Title,Description,Price,Image")] Pizza pizza)
        {
            if (id != pizza.ItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pizza);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PizzaExists(pizza.ItemId))
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
            return View(pizza);
        }

        // GET: Pizzas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pizza == null)
            {
                return NotFound();
            }

            var pizza = await _context.Pizza
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (pizza == null)
            {
                return NotFound();
            }
           

            return View(pizza);
        }

        // POST: Pizzas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pizza == null)
            {
                return Problem("Entity set 'JoesPizzaContext.Pizza'  is null.");
            }
            var pizza = await _context.Pizza.FindAsync(id);
            if (pizza != null)
            {
                _context.Pizza.Remove(pizza);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PizzaExists(int id)
        {
          return (_context.Pizza?.Any(e => e.ItemId == id)).GetValueOrDefault();
        }

        
    }
}
