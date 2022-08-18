using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FlocityClothingStore.Shared.Models.Category
{
    public class CategoryCreate
    {
        [Required]
        public string CategoryName{ get; set; }
        [Required]
        public int ProductId { get; set; }
        
    }
}
