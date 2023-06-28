using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RedMango_API_practice.Data;
using RedMango_API_practice.Models;
using Stripe;
using System.Net;

namespace RedMango_API_practice.Controllers
{
    // google search payment intents strip
    // https://stripe.com/docs/api/payment_intents/create?lang=dotnet
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        protected ApiResponse _response;
        private readonly IConfiguration _congifuration;
        private readonly ApplicationDbContext _db;
        public PaymentController(IConfiguration configuration, ApplicationDbContext db)
        {
            _congifuration = configuration;
            _db = db;
            _response = new();
        }
        [HttpPost]
        public async Task<ActionResult<ApiResponse>> MakePayment(string userId)
        {
            ShoppingCart shoppingCart = _db.ShoppingCarts
                .Include(u => u.CartItems)
                .ThenInclude(u => u.MenuItem).FirstOrDefault(u => u.UserId == userId);

            if (shoppingCart == null || shoppingCart.CartItems == null || shoppingCart.CartItems.Count() == 0)
            {
                _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                return BadRequest(_response);
            }

            #region Create Payment Intent

            StripeConfiguration.ApiKey = _congifuration["StripeSettings:SecretKey"];
            //double cartTotal = shoppingCart.CartItems.Sum(u=> u.Quantity * u.MenuItem.Price);
            shoppingCart.CartTotal = shoppingCart.CartItems.Sum(u => u.Quantity * u.MenuItem.Price);

            PaymentIntentCreateOptions options = new()
            {
                // money by cents
                Amount = (int)(shoppingCart.CartTotal * 100),
                Currency = "usd",
                PaymentMethodTypes = new List<string>
                  {
                    "card",
                  },
            };
            PaymentIntentService service = new();
            PaymentIntent response = service.Create(options);
            shoppingCart.StripePaymentIntentId = response.Id;
            // make the actrual payment
            shoppingCart.ClientSecret = response.ClientSecret;


            #endregion

            _response.Result = shoppingCart;
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }
    }
}
