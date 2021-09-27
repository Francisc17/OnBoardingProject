using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnBoardingProject.Data.Migrations;

namespace OnBoardingProject.Data.Entities
{
    public class OnBoardingDbContext : DbContext
    {
        public OnBoardingDbContext() : base("OnBoardingConnectionString")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<OnBoardingDbContext, Configuration>());
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Project> Projects { get; set; }
    }
}
