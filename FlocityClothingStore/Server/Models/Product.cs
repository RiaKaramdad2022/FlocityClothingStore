using System.ComponentModel.DataAnnotations;

namespace FlocityClothingStore.Server.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name  { get; set; }
        public string Description { get; set; }
        public double Price  { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
