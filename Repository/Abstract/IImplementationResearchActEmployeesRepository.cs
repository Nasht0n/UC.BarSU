using Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    public interface IImplementationResearchActEmployeesRepository
    {
        ImplementationResearchActEmployees Save(ImplementationResearchActEmployees employee);
        Task<ImplementationResearchActEmployees> SaveAsync(ImplementationResearchActEmployees employee);

        void Delete(ImplementationResearchActEmployees employee);
        Task DeleteAsync(ImplementationResearchActEmployees employee);

        ImplementationResearchActEmployees GetEmployee(int id);
        Task<ImplementationResearchActEmployees> GetEmployeeAsync(int id);

        List<ImplementationResearchActEmployees> GetEmployees();
        Task<List<ImplementationResearchActEmployees>> GetEmployeesAsync();
    }
}
