using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce_sample.Core.Interface
{
    public interface ICustomerOrder<T> where T: class
    {
        Task Add(T t);
        Task<bool> Complete(int id,string CustomerUserName);
    }
}
