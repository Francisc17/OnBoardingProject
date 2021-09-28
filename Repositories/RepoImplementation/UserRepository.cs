using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnBoardingProject.Data.Entities;

namespace OnBoardingProject.Repositories.RepoImplementation
{
    public class UserRepository : CommonRepository, IUserRepository
    {

        /*
         *  New keyword is "doing nothing", just suppress the compiler warning for hide
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

        //Maybe it won´t be used
        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            IQueryable<User> query = _context.Users;

            query = query.Where(u => u.Email == email);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            IQueryable<User> query = _context.Users;

            query = query.Where(u => u.Id == id);

            return await query.FirstOrDefaultAsync();
        }
    }
}
