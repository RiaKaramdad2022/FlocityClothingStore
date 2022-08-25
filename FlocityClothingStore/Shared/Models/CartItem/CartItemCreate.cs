using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlocityClothingStore.Shared.Models.CartItem
{
    public class CartItemCreate
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public string Quantity { get; set; }
        public string Size { get; set; }
    }
}
