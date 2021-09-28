using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnBoardingProject.Data.Entities;

namespace OnBoardingProject.Repositories.RepoImplementation
{
    public class UserRepository : CommonRepository, IUserRepository
    {

        /*
         *  New keyword is doing nothing, just suppress the compiler warning for hide
         *  inheritance member (because this field has tha same name of the field
         *  inherated from base class).
         *  https://www.demo2s.com/csharp/csharp-hiding-inherited-members.html
         */
        private new readonly OnBoardingDbContext _context;

        public UserRepository(OnBoardingDbContext context) : base(context)
        {
            _context = context;
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
        }

        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);
        }

        // TODO: Implement this method. 
        public Task<User> GetUserAsync(string email)
        {
            throw new NotImplementedException();
        }
    }
}
