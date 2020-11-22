using Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    public interface IProjectStateRepository
    {
        ProjectState Save(ProjectState state);
        Task<ProjectState> SaveAsync(ProjectState state);
        void Delete(ProjectState state);
        Task DeleteAsync(ProjectState state);
        ProjectState GetState(int id);
        Task<ProjectState> GetStateAsync(int id);
        List<ProjectState> GetStates();
        Task<List<ProjectState>> GetStatesAsync();
    }
}
