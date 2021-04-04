using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce_sample.Core.Interface
{
    public interface IProduct<T> where T : class
    {
        Task<T> GetProductItem(int id);
    }
}
