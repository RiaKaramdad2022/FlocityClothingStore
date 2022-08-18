using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlocityClothingStore.Shared.Models.Cart
{
    public class CartCreate
    {
        [Required]
        public int CustomerId { get; set; }
  

    }
}
