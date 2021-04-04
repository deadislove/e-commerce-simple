using e_commerce_sample.Core.Entity;
using e_commerce_sample.Core.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace e_commerce_sample.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategory<Category> iCategory;

        public CategoryController(ICategory<Category> _iCategory) {
            this.iCategory = _iCategory;
        }

        public IActionResult Index(int? Id)
        {            
            if (Id == null)
                return new NotFoundResult();

            var obj = iCategory.FindObj(Id.Value).Result;
            if (obj == null)
                return new NotFoundResult();

            return View(obj);
        }
    }
}
