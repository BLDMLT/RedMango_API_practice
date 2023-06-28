using System.ComponentModel.DataAnnotations.Schema;

namespace RedMango_API_practice.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public string UserId { get; set; }

        public ICollection<CartItem> CartItems { get; set; }

     
        // property in the model but not in the data base
        [NotMapped]
        public double CartTotal { get; set; }
        [NotMapped]
        public string ClientSecret { get; set; }
        [NotMapped]
        public string StripePaymentIntentId { get; set; }
    }
}
