using System.ComponentModel.DataAnnotations.Schema;

namespace FlocityClothingStore.Server.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }

        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }

        public string Quantity { get; set; }


    }

}
