using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlocityClothingStore.Shared.Models.Product
{
    public class ProductCreate
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        [Required]
        public string Size { get; set; }
        public int CategoryId { get; set; }
    }
}
