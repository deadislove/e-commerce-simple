using e_commerce_sample.Context;
using e_commerce_sample.Core.Entity;
using e_commerce_sample.Core.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_commerce_sample.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly ICustomerOrder<CustomerOrder> iCustomerOrder;
        private readonly IOrder iOrder;

        const string PromoCode = "FREE";

        public CheckoutController(
            ICustomerOrder<CustomerOrder> _iCustomerOrder,
            IOrder _iOrder
            )
        {
            this.iCustomerOrder = _iCustomerOrder;
            this.iOrder = _iOrder;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddressAndPayment()
        {
            return View();
        }

        [HttpPost,AutoValidateAntiforgeryToken]
        public IActionResult AddressAndPayment(IFormCollection values)
        {
            var Order = new CustomerOrder();
            TryUpdateModelAsync(Order);
            try 
            {
                if (string.Equals(values["PromoCode"], PromoCode, StringComparison.OrdinalIgnoreCase))
                    return View(Order);
                else
                {
                    Order.CustomerUserName = User.Identity.Name ?? values["FirstName"] + values["LastName"];
                    HttpContext.Session.SetString("CustomerUserName", values["FirstName"] + values["LastName"]);
                    Order.DateCreated = DateTime.Now;

                    iCustomerOrder.Add(Order);

                    var Cart = ShoppingCart.GetCart(this.HttpContext);
                    iOrder.CreateOrder<CustomerOrder>(Order, Cart.ShoppingCartId);

                    return RedirectToAction("Complete", new { id = Order.Id });
                }
            }
            catch (Exception ex)
            {
                ex.InnerException.ToString();
                return View(Order);
            }
        }

        public IActionResult Complete(int id)
        {
            var UserName = User.Identity.Name ?? HttpContext.Session.GetString("CustomerUserName").ToString(); ;
            bool isValid = iCustomerOrder.Complete(id, UserName).Result;
            if (isValid)
            {
                return View(id);
            }
            else
            {
                return View("Error");
            }            
        }
    }
}
