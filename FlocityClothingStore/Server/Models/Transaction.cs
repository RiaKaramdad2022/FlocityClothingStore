using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlocityClothingStore.Server.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }
        [ForeignKey(nameof(Cart))]
        public int CartId { get; set; }
        public int Quantity { get; set; }
        public DateTime DateOfTransaction { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
        public virtual Cart Cart { get; set; }
    }
}
