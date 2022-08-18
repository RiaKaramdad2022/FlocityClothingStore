﻿using System.ComponentModel.DataAnnotations.Schema;

namespace FlocityClothingStore.Server.Models
{
    public class Cart
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }

        public virtual List<Product> Products { get; set; } = new List<Product>();
        public virtual Customer Customer { get; set; } 
        
    }
}
