using FlocityClothingStore.Shared.Models.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlocityClothingStore.Shared.Models.Cart
{
    public class CartEdit
    {
        public int Id { get; set; }
        [Required]
        public int CustomerId { get; set; }

    }
}
