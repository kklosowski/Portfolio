using System.Collections;
using System.Collections.Generic;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public interface IProjectRepository
    {
        IEnumerable<Project> GetAllProjects();
        Project GetProjectById(int projectId);
        bool HasProjectWithId(int projectId);
        void AddProject(Project project);
        void UpdateProject(Project project);
    }
}