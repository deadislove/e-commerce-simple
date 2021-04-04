using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security;
using e_commerce_sample.Core.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using e_commerce_sample.Core.Interface;

namespace e_commerce_sample.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IUsers iUser;
        public AccountsController(IUsers _iUser) {
            this.iUser = _iUser;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return RedirectToAction("LogIn");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }            
        }

        public IActionResult Register() => View();
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var Result = iUser.Register<RegisterModel>(model).Result;

                if (Result.Equals(true))
                    return RedirectToAction("LogIn");
                else
                {
                    ViewBag.error = "Email already exists";
                    return View();
                }    
            }
            return View();
        }

        public IActionResult LogIn() => View();

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Login(string UserName, string Password)
        {
            if (ModelState.IsValid)
            {
                Tuple<bool, RegisterModel> tupleResult = iUser.Login(UserName, Password).Result;

                if (tupleResult.Item1.Equals(true))
                {
                    HttpContext.Session.SetString("UserName", tupleResult.Item2.UserName);
                    HttpContext.Session.SetString("Id", tupleResult.Item2.Id.ToString());

                    return RedirectToAction("Index","Accounts");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return View("Login");
                }
            }
            return View();
        }
    }
}
