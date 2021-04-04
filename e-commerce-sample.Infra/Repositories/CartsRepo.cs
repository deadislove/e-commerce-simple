using e_commerce_sample.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using e_commerce_sample.Infra.DBContext;
using e_commerce_sample.Core.Entity;

namespace e_commerce_sample.Infra.Repositories
{
    public class CartsRepo<T> : ICarts<T> where T :class
    {
        private readonly DBContext.DBContext dBContext;

        public CartsRepo(DBContext.DBContext _dBContext)
        {
            this.dBContext = _dBContext;
        }

        public Task MigrateCart(string userName, string ShoppingCartId)
        {
            var shoppingCart = dBContext.Carts.Where(c => c.CartId == ShoppingCartId);
            foreach (Cart item in shoppingCart)
            {
                item.CartId = userName;
            }

            dBContext.SaveChanges();

            return Task.CompletedTask;
        }

        public Task<decimal> GetTotal(string ShoppingCartId) 
        {
            decimal? total = (from cartItems in dBContext.Carts
                              where cartItems.CartId == ShoppingCartId
                              select (int?)cartItems.Count * cartItems.Product.Price
                               ).Sum();
            return Task.Run(() => total ?? decimal.Zero);
        }

        public Task<int> GetCount(string ShoppingCartId) 
        {
            int? count = (from cartItems in dBContext.Carts
                          where cartItems.CartId == ShoppingCartId
                          select (int?)cartItems.Count
                          ).Sum();
            return Task.Run(() => count ?? 0);
        }

        public Task<List<T>> GetCartItems(string ShoppingCartId)
        {            
            var obj = dBContext.Carts
                .Where(cart => cart.CartId == ShoppingCartId).ToList();
            return Task.Run(() => obj as List<T>);
        }

        public Task EmptyCart(string ShoppingCartId) 
        {
            var cartItems = dBContext.Carts
                .Where(cart => cart.CartId == ShoppingCartId);
            foreach (var cartItem in cartItems)
            {
                dBContext.Carts.Remove(cartItem);
            }
            dBContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task<int> RemoveFromCart(int id, string ShoppingCartId) 
        {
            var cartItemCount = dBContext.Carts.SingleOrDefault(cart => cart.CartId == ShoppingCartId && cart.ProductId == id);
            int itemCount = 0;

            if (cartItemCount != null) {
                if (cartItemCount.Count > 1)
                {
                    cartItemCount.Count--;
                    itemCount = cartItemCount.Count;
                }
                else
                    dBContext.Carts.Remove(cartItemCount);

                dBContext.SaveChanges();
            }

            return Task.Run(() => itemCount);
        }

        public Task AddToCart<T1>(T1 t1, string ShoppingCartId) where T1 : Product
        {
            var varItem = dBContext.Carts
                .SingleOrDefault(c => c.CartId == ShoppingCartId && c.ProductId == t1.Id);
            if (varItem == null)
            {
                varItem = new Cart
                {
                    ProductId = t1.Id,
                    CartId = ShoppingCartId,
                    Count = 1,
                    DateCreated = DateTime.Now
                };

                dBContext.Carts.Add(varItem);
            }
            else
                varItem.Count++;

            dBContext.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
