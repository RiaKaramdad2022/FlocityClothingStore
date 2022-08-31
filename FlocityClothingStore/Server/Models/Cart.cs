using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlocityClothingStore.Server.Models
{
    public class Cart
    {
        public int Id { get; set; }
        //one-to-one relationship.
        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }

        //Making virtual list to make a junction table for a many to many relationship between the Cart and CartItems Table
        public virtual List<CartItem> CartItems { get; set; } = new List<CartItem>();
        public virtual Customer Customer { get; set; }

    }
}
