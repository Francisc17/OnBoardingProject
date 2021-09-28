using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnBoardingProject.Repositories.Interfaces;

namespace OnBoardingProject.Repositories.RepoImplementation
{
    public class CommonRepository : ICommonRepository
    {
        public async Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
