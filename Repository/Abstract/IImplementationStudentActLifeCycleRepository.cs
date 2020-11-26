using Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    public interface IImplementationStudentActLifeCycleRepository
    {
        ImplementationStudentActLifeCycle Save(ImplementationStudentActLifeCycle lifeCycle);
        Task<ImplementationStudentActLifeCycle> SaveAsync(ImplementationStudentActLifeCycle lifeCycle);

        void Delete(ImplementationStudentActLifeCycle lifeCycle);
        Task DeleteAsync(ImplementationStudentActLifeCycle lifeCycle);

        ImplementationStudentActLifeCycle GetLifeCycle(int id);
        Task<ImplementationStudentActLifeCycle> GetLifeCycleAsync(int id);
    }
}
