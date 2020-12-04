using Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    public interface IImplementationResearchActRepository
    {
        ImplementationResearchAct Save(ImplementationResearchAct act);
        Task<ImplementationResearchAct> SaveAsync(ImplementationResearchAct act);

        void Delete(ImplementationResearchAct act);
        Task DeleteAsync(ImplementationResearchAct act);

        ImplementationResearchAct GetAct(int id);
        Task<ImplementationResearchAct> GetActAsync(int id);

        List<ImplementationResearchAct> GetActs();
        Task<List<ImplementationResearchAct>> GetActsAsync();

        List<ImplementationResearchAct> GetActs(AppUser user);
        Task<List<ImplementationResearchAct>> GetActsAsync(AppUser user);
    }
}
