using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnBoardingProject.Data.Entities;

namespace OnBoardingProject.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<OnBoardingDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "OnBoardingProject.Data.DbContext";
        }

    }
}
