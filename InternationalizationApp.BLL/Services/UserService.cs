using InternationalizationApp.DAL;
using InternationalizationApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalizationApp.BLL.Services
{
    class UserService : BaseService, IUserService
    {
        public UserService(UnitOfWork db) : base(db)
        {
        }
        public async Task<User> GetUserAsync(int id)
        {
            return await db.Users.GetAsyncById(id);
        }

        public async Task<User> AddUserAsync(User user)
        {
            return db.Users.AddUserAsync(user);
        }

        public async Task<User> GetUserByLogin(string login)
        {
            return await db.Users.GetUserByLogin(login);
        }
    }
}
