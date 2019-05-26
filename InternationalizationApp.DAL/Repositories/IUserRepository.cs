using InternationalizationApp.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InternationalizationApp.DAL.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetAsyncById(int id);

        User AddUserAsync(User user);

        User RemoveUser(User user);

        Task<User> GetUserByLogin(string login);
    }
}

