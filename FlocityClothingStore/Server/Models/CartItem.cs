using System.ComponentModel.DataAnnotations.Schema;

namespace FlocityClothingStore.Server.Models
{
    public class CartItem
    {
        public int Id { get; set; }
  
        [ForeignKey(nameof(Cart))]
        public int CartId { get; set; }

        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string Size { get; set; }
        
        //Many to many relationship
        public virtual Cart Cart { get; set; }
        public virtual Product Product { get; set; } 

    }

}
