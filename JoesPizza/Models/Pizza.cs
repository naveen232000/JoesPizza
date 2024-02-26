using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JoesPizza.Models
{
    [Table("Piza")]
    public class Pizza
    {
        [Key] public int ItemId { get; set; }
        [Required] public string ItemName { get; set; }
        [Required] public string Title { get; set; }
        [Required] public string Description { get; set; }
        [Required] public double Price { get; set; }
        public byte[] Image { get; set; }
    }
}
