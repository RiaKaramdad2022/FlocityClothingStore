using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlocityClothingStore.Shared.Models.CartItem
{
    public class CartItemDetail
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public string Quantity { get; set; }
        public string Size { get; set; }

        public string ProductName { get; set; }
        public double Price { get; set; }
    }
}
