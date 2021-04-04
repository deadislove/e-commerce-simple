using e_commerce_sample.Core.Entity;
using e_commerce_sample.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce_sample.Infra.Repositories
{
    public class OrderManagementRepo : IOrderManagement
    {
        private readonly DBContext.DBContext dBContext;

        public OrderManagementRepo(DBContext.DBContext _dBContext)
        {
            this.dBContext = _dBContext;
        }

        public Task AddOrderManagementItem<T>(T t) where T : OrderManagement
        {
            dBContext.OrderManagements.Add(t as OrderManagement);
            dBContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task<List<OrderManagementList>> AllOrderManagement(int? id)
        {
            if (id == null || id.Value == 0)
            {
                List<OrderManagementList> obj = (from p in dBContext.CustomerOrders
                                                 join q in dBContext.OrderManagements on p.Id equals q.OrderId
                                                 select new OrderManagementList
                                                 {
                                                    OrderId = p.Id,
                                                    CustomerName = p.FirstName + p.LastName,
                                                    Address = p.Address,
                                                    PaymentStatus = q.Status == true ? "OK" : "non-payment"
                                                }).ToList();
                return Task.FromResult(obj);
            }
            else
            {
                var obj = (from p in dBContext.CustomerOrders
                           join q in dBContext.OrderManagements on p.Id equals q.OrderId
                           where q.OrderId == id
                           select new
                           {
                               OrderId = p.Id,
                               CustomerName = p.FirstName + p.LastName,
                               p.Address,
                               PaymentStatus = q.Status == true ? "OK" : "Non-payment"
                           }).Cast<OrderManagementList>().ToList();
                return Task.FromResult(obj);
            }

            throw new NotImplementedException();
        }
    }
}
