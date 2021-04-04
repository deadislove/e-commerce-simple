using e_commerce_sample.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce_sample.Core.Interface
{
    public interface IUsers
    {
        Task<bool> Register<T1>(T1 t1) where T1 : RegisterModel;
        Task<Tuple<bool, RegisterModel>> Login(string UserName, string Password);
        Task<bool> ChangePassword<T2>(T2 t2, int Id) where T2 : ChangePasswordModel;
    }
}
