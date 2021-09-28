using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardingProject.Repositories.Interfaces
{
    /**
     * Interface that define common methods for all the repositories
     * It will be implemented by a CommonRepository as well
     */
    public interface ICommonRepository
    {
        Task<bool> SaveChangesAsync();
    }
}
