using e_commerce_sample.Core.Entity;
using e_commerce_sample.Core.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_commerce_sample.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProduct<Product> iProduct;

        public ProductController(IProduct<Product> _iProduct) 
        {
            this.iProduct = _iProduct;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return new NotFoundResult();

            Product product = iProduct.GetProductItem(id.Value).Result;

            if (product == null)
                return new NotFoundResult();

            return View(product);
        }
    }
}
