using e_commerce_sample.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce_sample.Core.Interface
{
    public interface ICarts<T> where T : class
    {
        Task MigrateCart(string userName, string ShoppingCartId);
        Task<decimal> GetTotal(string ShoppingCartId);
        Task<int> GetCount(string ShoppingCartId);
        Task<List<T>> GetCartItems(string ShoppingCartId);
        Task EmptyCart(string ShoppingCartId);
        Task<int> RemoveFromCart(int id, string ShoppingCartId);
        Task AddToCart<T1>(T1 t1, string ShoppingCartId) where T1 : Product;
    }
}
