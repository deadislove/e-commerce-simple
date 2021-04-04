using e_commerce_sample.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce_sample.Core.Interface
{
    public interface IOrderManagement
    {
        Task AllOrderManagement(int? id);
        Task AddOrderManagementItem<T>(T t) where T : OrderManagement;
    }
}
