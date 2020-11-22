using Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    public interface IStageTypeRepository
    {
        StageType Save(StageType type);
        Task<StageType> SaveAsync(StageType type);
        void Delete(StageType type);
        Task DeleteAsync(StageType type);
        StageType GetStageType(int id);
        Task<StageType> GetStageTypeAsync(int id);
        List<StageType> GetStageTypes();
        Task<List<StageType>> GetStageTypesAsync();
    }
}
