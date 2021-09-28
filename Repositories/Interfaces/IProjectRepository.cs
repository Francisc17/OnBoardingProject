using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnBoardingProject.Data.Entities;

namespace OnBoardingProject.Repositories.Interfaces
{
    public interface IProjectRepository : ICommonRepository
    {
        void AddProject(Project project);
        void DeleteProject(Project project);
        Task<Project[]> GetAllUserProjectsAsync(int id, bool includeTasks = false);
        Task<Project> GetUserProjectAsync(int id, int projectId, bool includeTasks = false);

        //TODO: Add the remain methods
    }
}
