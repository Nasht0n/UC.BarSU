using Common.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    public interface IScienceProjectRepository
    {
        ScienceProject Save(ScienceProject project);
        Task<ScienceProject> SaveAsync(ScienceProject project);
        void Delete(ScienceProject project);
        Task DeleteAsync(ScienceProject project);
        ScienceProject GetProject(int id);
        Task<ScienceProject> GetProjectAsync(int id);
        List<ScienceProject> GetProjects();
        Task<List<ScienceProject>> GetProjectsAsync();
        List<ScienceProject> GetProjects(ProjectState state);
        Task<List<ScienceProject>> GetProjectsAsync(ProjectState state);
        List<ScienceProject> GetProjects(Department department);
        Task<List<ScienceProject>> GetProjectsAsync(Department department);
        List<ScienceProject> GetProjects(DateTime start, DateTime end);
        Task<List<ScienceProject>> GetProjectsAsync(DateTime start, DateTime end);
    }
}
