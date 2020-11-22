using Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    public interface IDepartmentRepository
    {
        Department Save(Department department);
        Task<Department> SaveAsync(Department department);
        void Delete(Department department);
        Task DeleteAsync(Department department);
        Department GetDepartment(int id);
        Task<Department> GetDepartmentAsync(int id);
        List<Department> GetDepartments();
        Task<List<Department>> GetDepartmentsAsync();
        List<Department> GetDepartments(Faculty faculty);
        Task<List<Department>> GetDepartmentsAsync(Faculty faculty);
    }
}
