using InternationalizationApp.DAL;
using InternationalizationApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalizationApp.BLL.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(IUnitOfWork db) : base(db)
        {
        }
        public async Task<User> GetUserAsync(int id)
        {
            return await db.Users.GetAsyncById(id);
        }

        public async Task<User> AddUserAsync(User user)
        {
            db.Users.AddUserAsync(user);
            db.Save();
            return user;
        }

        public async Task<User> GetUserByLogin(string login)
        {
            return await db.Users.GetUserByLogin(login);
        }
    }
}
