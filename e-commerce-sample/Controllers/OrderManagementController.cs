using e_commerce_sample.Core.Interface;
using e_commerce_sample.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_commerce_sample.Controllers
{
    public class OrderManagementController : Controller
    {
        private readonly IOrderManagement iOrderManagement;

        public OrderManagementController(IOrderManagement _iOrderManagement)
        {
            this.iOrderManagement = _iOrderManagement;
        }

        public IActionResult Index()
        {
            var obj = iOrderManagement.AllOrderManagement(0).Result;
            return View(obj);
        }
    }
}
