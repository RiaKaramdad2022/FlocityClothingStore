using System.ComponentModel.DataAnnotations;

namespace FlocityClothingStore.Server.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }

        // //Making virtual list to make a junction table for a many to many relationship between the Customer and Transactions Table
        public virtual List<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
