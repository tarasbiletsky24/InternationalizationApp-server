using InternationalizationApp.DAL.Models;
using LearnWithMentorDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalizationApp.DAL.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(Context context) : base(context)
        {

        }

        public Task<User> GetAsyncById(int id)
        {
            return Context.Users.FirstOrDefaultAsync(u => u.UserId == id);
        }

        public User AddUserAsync(User user)
        {
            Context.Users.Add(user);
            return user;
        }

        public User RemoveUser(User user)
        {
            Context.Users.Remove(user);
            return user;
        }

        public Task<User> GetUserByLogin(string login)
        {
            return Context.Users.FirstOrDefaultAsync(u => u.Login == login);
        }
    }
}
