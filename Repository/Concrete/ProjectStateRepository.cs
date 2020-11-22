using Common;
using Common.Entities;
using Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Concrete
{
    public class ProjectStateRepository : IProjectStateRepository
    {
        private readonly UCContext context;

        public ProjectStateRepository(UCContext context)
        {
            this.context = context;
        }

        public void Delete(ProjectState state)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(ProjectState state)
        {
            throw new NotImplementedException();
        }

        public ProjectState GetState(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProjectState> GetStateAsync(int id)
        {
            throw new NotImplementedException();
        }

        public List<ProjectState> GetStates()
        {
            throw new NotImplementedException();
        }

        public Task<List<ProjectState>> GetStatesAsync()
        {
            throw new NotImplementedException();
        }

        public ProjectState Save(ProjectState state)
        {
            throw new NotImplementedException();
        }

        public Task<ProjectState> SaveAsync(ProjectState state)
        {
            throw new NotImplementedException();
        }
    }
}
