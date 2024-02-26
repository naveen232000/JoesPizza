using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JoesPizza.Models
{
    [Table("OrderDetails")]
    public class OrderDetails
    {
        [Key]
        public int OrderId { get; set; }
        public int ItemId { get; set; }
    
        public int Qyt { get; set; }
        public string CustomerName {  get; set; }   
        public string CustomerEmail { get; set; }
        public string MobileNum { get; set; }
        public string DeliveryAddress { get; set; }
        public string pincode  { get; set; }
        public double TotalAmt { get; set; }
        public string PaymentStatus { get; set; }
        public string PaymentType { get; set; }
        public DateTime OdredDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public byte[] iteamImage { get; set; }

    }
}
