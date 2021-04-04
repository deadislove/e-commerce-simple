using e_commerce_sample.Context;
using e_commerce_sample.Core.Entity;
using e_commerce_sample.Core.Interface;
using e_commerce_sample.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e_commerce_sample.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ICarts<Cart> iCarts;
        private readonly IProduct<Product> iProduct;

        public ShoppingCartController(ICarts<Cart> _iCarts, IProduct<Product> _iProduct)
        {
            this.iCarts = _iCarts;
            this.iProduct = _iProduct;
        }

        public IActionResult Index()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            var viewModel = new ShoppingCartVM
            {
                CartItems = iCarts.GetCartItems(cart.ShoppingCartId).Result,
                CartTotal = iCarts.GetTotal(cart.ShoppingCartId).Result
            };
            return View(viewModel);
        }

        public IActionResult AddToCart(int id)
        {
            var addObj = iProduct.GetProductItem(id).Result;
            var cart = ShoppingCart.GetCart(this.HttpContext);
            var Result = iCarts.AddToCart<Product>(addObj, cart.ShoppingCartId);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
            string ShoppingCartId = HttpContext.Session.GetString("cartId").ToString() ?? string.Empty;

            if (!string.IsNullOrEmpty(ShoppingCartId))
            {
                string ProductName = iProduct.GetProductItem(id).Result.Name;
                int ItemCount = iCarts.RemoveFromCart(id, ShoppingCartId).Result;

                var Result = new ShoppingCartRemoveVM
                {
                    Message = ProductName + "has been removed from your shopping cart.",
                    CartTotal = iCarts.GetTotal(ShoppingCartId).Result,
                    CartCount = iCarts.GetCount(ShoppingCartId).Result,
                    ItemCount = ItemCount,
                    DeleteId = id
                };

                return Json(Result);
            }
            else
                return Json(null);
        }

        public ActionResult CartSummary()
        {
            string ShoppingCartId = HttpContext.Session.GetString("cartId").ToString() ?? string.Empty;
            var CartCount = iCarts.GetCount(ShoppingCartId).Result;

            ViewData["CartCount"] = CartCount;
            return PartialView("CartSummary");
        }
    }
}
