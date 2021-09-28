﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardingProject.Repositories.Interfaces
{
    public interface ICommonRepository
    {
        Task<bool> SaveChangesAsync();
    }
}
