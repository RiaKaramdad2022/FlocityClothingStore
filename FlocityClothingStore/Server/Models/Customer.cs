namespace FlocityClothingStore.Server.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
