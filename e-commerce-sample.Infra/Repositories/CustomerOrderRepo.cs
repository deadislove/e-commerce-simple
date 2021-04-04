using e_commerce_sample.Core.Entity;
using e_commerce_sample.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce_sample.Infra.Repositories
{
    public class CustomerOrderRepo<T> : ICustomerOrder<T> where T : class
    {
        private readonly DBContext.DBContext dBContext;

        public CustomerOrderRepo(DBContext.DBContext _dBContext)
        {
            this.dBContext = _dBContext;
        }

        public Task Add(T t)
        {
            dBContext.CustomerOrders.Add(t as CustomerOrder);
            dBContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task<bool> Complete(int id,string CustomerUserName)
        {
            bool isValid = dBContext.CustomerOrders.Any(
                o=> o.Id == id &&
                    o.CustomerUserName == CustomerUserName
                );
            return Task.FromResult(isValid);
        }
    }
}
