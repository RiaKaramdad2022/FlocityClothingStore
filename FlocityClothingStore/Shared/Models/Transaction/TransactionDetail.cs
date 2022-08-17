using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlocityClothingStore.Shared.Models.Customer;
using FlocityClothingStore.Shared.Models.Product;



namespace FlocityClothingStore.Shared.Models.Transaction
{
    public class TransactionDetail
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int Quantity { get; set; }
        public DateTime DateOfTransaction { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
        
    }
}
