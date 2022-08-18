using FlocityClothingStore.Shared.Models.Cart;
using FlocityClothingStore.Shared.Models.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlocityClothingStore.Shared.Models.Customer
{
    public class CustomerDetail
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }

        public virtual List<TransactionListItem> Transactions { get; set; } = new();
        public virtual CartDetail Cart { get; set; }
    }
}
