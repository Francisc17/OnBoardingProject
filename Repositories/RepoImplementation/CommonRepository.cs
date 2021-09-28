using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnBoardingProject.Data.Entities;
using OnBoardingProject.Repositories.Interfaces;

namespace OnBoardingProject.Repositories.RepoImplementation
{
    public class CommonRepository : ICommonRepository
    {
        protected readonly OnBoardingDbContext _context;

        public CommonRepository(OnBoardingDbContext context)
        {
            _context = context;
        }

        public async Task<bool> SaveChangesAsync()
        {
                // Only return success if at least one row was changed
                return (await _context.SaveChangesAsync()) > 0;    
        }
    }
}
