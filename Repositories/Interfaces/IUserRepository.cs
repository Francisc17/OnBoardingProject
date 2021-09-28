using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnBoardingProject.Data.Entities;
using OnBoardingProject.Repositories.Interfaces;

namespace OnBoardingProject.Repositories
{
    public interface IUserRepository : ICommonRepository
    {
        void AddUser(User user);
        void DeleteUser(User user);
        Task<User> GetUserAsync(string email);
    }
}
