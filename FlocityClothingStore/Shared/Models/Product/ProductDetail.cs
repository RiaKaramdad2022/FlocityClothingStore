using FlocityClothingStore.Shared.Models.Cart;
using FlocityClothingStore.Shared.Models.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlocityClothingStore.Shared.Models.Product
{
    public class ProductDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Quantity { get; set; }

        public virtual List<TransactionListItem> Transactions{ get; set; } = new();
        public virtual List<CartListItem> Carts { get; set; } = new();

    }
}
