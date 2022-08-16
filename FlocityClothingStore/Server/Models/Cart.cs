namespace FlocityClothingStore.Server.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Size { get; set; }
    }
}
