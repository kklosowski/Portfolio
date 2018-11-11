using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Portfolio.Controllers;
using Portfolio.Models;

namespace Portfolio.Data
{
    public class ProjectRepository: IProjectRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ProjectRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IEnumerable<Project> GetAllProjects()
        {
            return _applicationDbContext.Projects;
        }

        public Project GetProjectById(int projectId)
        {
            return _applicationDbContext.Projects.FirstOrDefault(x => x.Id == projectId);
        }
    }
}
