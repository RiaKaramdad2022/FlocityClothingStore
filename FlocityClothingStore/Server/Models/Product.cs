using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlocityClothingStore.Server.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name  { get; set; }
        public string Description { get; set; }
        public double Price  { get; set; }
        public string Size { get; set; }
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        //public string ImageUrl { get; set; }

        //Making virtual list to make a junction table for a many to many relationship between the Product and Transactions Table
        public virtual List<Transaction> Transactions { get; set; } = new List<Transaction>();

        public virtual Category Category { get; set; }


    }
}
