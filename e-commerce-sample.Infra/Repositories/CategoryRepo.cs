using e_commerce_sample.Core.Entity;
using e_commerce_sample.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce_sample.Infra.Repositories
{
    public class CategoryRepo<T> : ICategory<T> where T : class
    {
        private readonly DBContext.DBContext dBContext;

        public CategoryRepo(DBContext.DBContext _dBContext)
        {
            this.dBContext = _dBContext;
        }

        public Task<T> FindObj(int id)
        {
            Category obj = dBContext.Categories.Find(id);
            obj.Products = dBContext.Products.Where(s => s.CategoryId.Equals(id)).ToList();

            return Task.FromResult(obj as T);
        }
    }
}
