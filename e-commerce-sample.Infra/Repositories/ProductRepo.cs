using e_commerce_sample.Core.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce_sample.Infra.Repositories
{
    public class ProductRepo<T> : IProduct<T> where T : class
    {
        private readonly DBContext.DBContext dBContext;

        public ProductRepo(DBContext.DBContext _dBContext)
        {
            this.dBContext = _dBContext;
        }

        public Task<T> GetProductItem(int id)
        {
            if (id == 0)
                return null;
            var obj = dBContext.Products.Single(product => product.Id.Equals(id));
            return Task.FromResult(obj as T);
        }

        public Task<List<T>> GetProductItems()
        {
            List<T> ResultList = dBContext.Products.Include(p=>p.Category).ToList() as List<T>;

            return Task.FromResult(ResultList);
        }
    }
}
