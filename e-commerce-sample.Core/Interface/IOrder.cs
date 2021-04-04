using e_commerce_sample.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce_sample.Core.Interface
{
    public interface IOrder
    {
        Task<int> CreateOrder<T1>(T1 t1, string ShoppingCartId) where T1 : CustomerOrder;
    }
}
