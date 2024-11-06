using System.ComponentModel.DataAnnotations;

namespace TutorialEx.Models
{
    public class ShoppingCart
    {
        [Key]
        public int Id { get; set; }
        public List<CartItem> Items { get; set; }
    }
    public class CartItem
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
