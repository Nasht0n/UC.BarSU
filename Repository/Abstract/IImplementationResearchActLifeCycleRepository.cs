using Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    public interface IImplementationResearchActLifeCycleRepository
    {
        ImplementationResearchActLifeCycle Save(ImplementationResearchActLifeCycle lifeCycle);
        Task<ImplementationResearchActLifeCycle> SaveAsync(ImplementationResearchActLifeCycle lifeCycle);

        void Delete(ImplementationResearchActLifeCycle lifeCycle);
        Task DeleteAsync(ImplementationResearchActLifeCycle lifeCycle);

        ImplementationResearchActLifeCycle GetLifeCycle(int id);
        Task<ImplementationResearchActLifeCycle> GetLifeCycleAsync(int id);

        List<ImplementationResearchActLifeCycle> GetLifeCycles();
        Task<List<ImplementationResearchActLifeCycle>> GetLifeCyclesAsync();
        List<ImplementationResearchActLifeCycle> GetLifeCycles(ImplementationResearchAct act);
        Task<List<ImplementationResearchActLifeCycle>> GetLifeCyclesAsync(ImplementationResearchAct act);
    }
}
