using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnBoardingProject.Data.Entities;
using OnBoardingProject.Repositories.Interfaces;

namespace OnBoardingProject.Repositories.RepoImplementation
{
    public class ProjectRepository :CommonRepository, IProjectRepository
    {
        private new readonly OnBoardingDbContext _context;

        public ProjectRepository(OnBoardingDbContext context) : base(context)
        {
            _context = context;
        }
        public void AddProject(Project project)
        {
            _context.Projects.Add(project);
        }

        public void DeleteProject(Project project)
        {
            _context.Projects.Remove(project);
        }


        public async Task<Project[]> GetAllUserProjectsAsync(int id, bool includeTasks = false)
        {
            IQueryable<Project> query = _context.Projects;
            //.Include(p => p.ProjectManager) -> concat projetct manager info if needed

            if (includeTasks)
            {
              query = query.Include(p => p.Tasks.Select(r => r.TaskResponsible));
            }

            query = query.Where(p => p.ProjectManager.Id == id);

            return await query.ToArrayAsync();
        }

        public async Task<Project> GetUserProjectAsync(int id, int projectId, bool includeTasks = false)
        {
            IQueryable<Project> query = _context.Projects;

            if (includeTasks)
            {
                query = query.Include(p => p.Tasks.Select(r => r.TaskResponsible));
            }

            //this way we can only obtain project if the user is the manager of it.
            query = query.Where(p => p.ProjectManager.Id == id && p.Id == projectId);

            return await query.FirstOrDefaultAsync();
        }
    }
}
