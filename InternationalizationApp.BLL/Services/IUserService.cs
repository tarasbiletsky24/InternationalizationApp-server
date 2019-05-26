using InternationalizationApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalizationApp.BLL.Services
{
    public interface IUserService
    {
        Task<User> GetUserAsync(int id);

        Task<User> AddUserAsync(User user);

        Task<User> GetUserByLogin(string login);
    }
}
