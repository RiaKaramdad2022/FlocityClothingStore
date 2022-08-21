using FlocityClothingStore.Shared.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlocityClothingStore.Shared.Models.Category
{
    public class CategoryDetail
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
    

        public List<ProductListItem> Products { get; set; } = new List<ProductListItem>();

    }
}
