using Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    public interface ICastRepository
    {
        Cast Save(Cast cast);
        Task<Cast> SaveAsync(Cast cast);
        void Delete(Cast cast);
        Task DeleteAsync(Cast cast);
        Cast GetCast(int id);
        Task<Cast> GetCastAsync(int id);
        List<Cast> GetCasts();
        Task<List<Cast>> GetCastsAsync();
        List<Cast> GetCasts(ScienceProject project);
        Task<List<Cast>> GetCastsAsync(ScienceProject project);
    }
}
