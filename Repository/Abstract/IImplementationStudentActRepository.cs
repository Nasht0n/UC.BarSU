using Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    public interface IImplementationStudentActRepository
    {
        ImplementationStudentAct Save(ImplementationStudentAct act);
        Task<ImplementationStudentAct> SaveAsync(ImplementationStudentAct act);

        void Delete(ImplementationStudentAct act);
        Task DeleteAsync(ImplementationStudentAct act);

        ImplementationStudentAct GetAct(int id);
        Task<ImplementationStudentAct> GetActAsync(int id);

        List<ImplementationStudentAct> GetActs();
        Task<List<ImplementationStudentAct>> GetActsAsync();

        List<ImplementationStudentAct> GetActs(AppUser user);
        Task<List<ImplementationStudentAct>> GetActsAsync(AppUser user);
    }
}
