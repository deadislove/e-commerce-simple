using e_commerce_sample.Core.Entity;
using e_commerce_sample.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace e_commerce_sample.Infra.Repositories
{
    public class UserRepo : IUsers
    {

        private readonly DBContext.DBContext dBContext;

        public UserRepo(DBContext.DBContext _dBContext)
        {
            this.dBContext = _dBContext;
        }

        public Task<bool> ChangePassword<T2>(T2 t2,int Id) where T2 : ChangePasswordModel
        {
            var Check = dBContext.Users.SingleOrDefault(s => s.Id.Equals(Id) && s.Password.Equals(t2.OldPassword));
            if (Check == null)
                return Task.FromResult(false);
            else
            {
                var UpdData = new RegisterModel() {
                    Id = Check.Id,
                    UserName = Check.UserName,
                    Email = Check.Email,
                    Password = GetMD5(t2.NewPassword)

                };
                dBContext.Entry(UpdData).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                dBContext.SaveChanges();

                return Task.FromResult(true);
            }
        }

        public Task<Tuple<bool,RegisterModel>> Login(string UserName, string Password)
        {
            string f_password = GetMD5(Password);
            var Check = dBContext.Users.SingleOrDefault(s => s.UserName == UserName && s.Password == f_password);

            if (Check == null)
                return Task.FromResult(new Tuple<bool,RegisterModel>(false, null));
            else
            {
                return Task.FromResult(new Tuple<bool, RegisterModel>(true, Check));
            }
        }

        public Task<bool> Register<T1>(T1 t1) where T1 : RegisterModel
        {
            var Check = dBContext.Users.SingleOrDefault(s => s.Email == t1.Email && s.UserName == t1.UserName);

            if (Check == null)
            {
                t1.Password = GetMD5(t1.Password);
                dBContext.Users.Add(t1);
                dBContext.SaveChanges();
                return Task.FromResult(true);
            }
            else
                return Task.FromResult(false);
        }

        private static string GetMD5(string str)
        {
            MD5 mD5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = mD5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }
    }
}
