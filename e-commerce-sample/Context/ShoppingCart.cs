using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace e_commerce_sample.Context
{
    public partial class ShoppingCart
    {
        public string ShoppingCartId { get; set; }
        public const string CartSessionKey = "cartId";

        public static ShoppingCart GetCart(HttpContext context) 
        {
            var cart = new ShoppingCart();
            cart.ShoppingCartId = cart.GetCartId(context);
            return cart;
        }

        public string GetCartId(HttpContext context) {
            if (context.Session.GetString(CartSessionKey) == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session.SetString(CartSessionKey, context.User.Identity.Name);
                }
                else
                {
                    Guid guid = Guid.NewGuid();
                    context.Session.SetString(CartSessionKey, guid.ToString());
                }
            }
            return context.Session.GetString(CartSessionKey).ToString();
        }
    }
}
