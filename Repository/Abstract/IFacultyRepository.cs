using Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    public interface IFacultyRepository
    {
        Faculty Save(Faculty faculty);
        Task<Faculty> SaveAsync(Faculty faculty);
        void Delete(Faculty faculty);
        Task DeleteAsync(Faculty faculty);
        Faculty GetFaculty(int id);
        Task<Faculty> GetFacultyAsync(int id);
        List<Faculty> GetFaculties();
        Task<List<Faculty>> GetFacultiesAsync();
    }
}
