using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlocityClothingStore.Shared.Models.Cart
{
    public class CartListItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Size { get; set; }

    }
}
