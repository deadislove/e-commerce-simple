using e_commerce_sample.Core.Entity;
using e_commerce_sample.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce_sample.Infra.Repositories
{
    public class OrderRepo : IOrder
    {
        private readonly DBContext.DBContext dBContext;
        private ICarts<Cart> carts;

        public OrderRepo(DBContext.DBContext _dBContext, ICarts<Cart> _carts)
        {
            this.dBContext = _dBContext;
            this.carts = _carts;
        }

        public Task<int> CreateOrder<T1>(T1 t1, string ShoppingCartId) where T1 : CustomerOrder
        {
            decimal orderTotal = 0;
            var cartItems = carts.GetCartItems(ShoppingCartId);

            foreach (var item in cartItems.Result)
            {
                var orderProduct = new OrderedProduct
                {
                    ProductId = item.ProductId,
                    CustomerOrderId = t1.Id,
                    Quantity = item.Count
                };

                orderTotal += (item.Count * item.Product.Price);

                dBContext.Orderedproducts.Add(orderProduct);
            }

            t1.Amount = orderTotal;
            dBContext.Entry(t1).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            dBContext.SaveChanges();

            this.carts.EmptyCart(ShoppingCartId);

            return Task.Run(() => t1.Id);
        }
    }
}
