using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlocityClothingStore.Server.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name  { get; set; }
        public string Description { get; set; }
        public double Price  { get; set; }
        [ForeignKey(nameof(Product))]
        public int CategoryId { get; set; }
        public string Size { get; set; }


        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
     
    }
}
