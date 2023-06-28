using System.ComponentModel.DataAnnotations.Schema;

namespace RedMango_API_practice.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int MenuItemId { get; set; }

        // foreginkey link two tables
        [ForeignKey("MenuItemId")]
        public MenuItem MenuItem { get; set; } = new();
        public int Quantity { get; set; }
        public int ShoppingCartId { get; set; }
    }
}
