using Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    public interface IImplementationStudentActComissionRepository
    {
        ImplementationStudentActComission Save(ImplementationStudentActComission comission);
        Task<ImplementationStudentActComission> SaveAsync(ImplementationStudentActComission comission);

        void Delete(ImplementationStudentActComission comission);
        Task DeleteAsync(ImplementationStudentActComission comission);

        ImplementationStudentActComission GetComission(int id);
        Task<ImplementationStudentActComission> GetComissionAsync(int id);

        List<ImplementationStudentActComission> GetComissions(ImplementationStudentAct act);
        Task<List<ImplementationStudentActComission>> GetComissionsAsync(ImplementationStudentAct act);
    }
}
