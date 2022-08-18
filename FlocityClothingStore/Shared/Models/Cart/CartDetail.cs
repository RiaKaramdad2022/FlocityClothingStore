using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlocityClothingStore.Shared.Models.Product;


namespace FlocityClothingStore.Shared.Models.Cart
{
    public class CartDetail
    {
        public int Id { get; set; }
        
        public int CustomerId { get; set; }
        public  List<ProductListItem> Products { get; set; } = new List<ProductListItem>();
        public  string CustomerFullName { get; set; }
        public string CustomerEmail { get; set; }

    }
}
