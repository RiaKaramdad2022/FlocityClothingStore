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

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
