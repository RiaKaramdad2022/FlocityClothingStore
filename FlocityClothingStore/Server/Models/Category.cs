using System.ComponentModel.DataAnnotations.Schema;

namespace FlocityClothingStore.Server.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public virtual List<Product> Products { get; set; } = new List<Product>();
    }
}
