using Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    public interface IStageRepository
    {
        Stage Save(Stage stage);
        Task<Stage> SaveAsync(Stage stage);
        void Delete(Stage stage);
        Task DeleteAsync(Stage stage);
        Stage GetStage(ScienceProject project, StageType type);
        Task<Stage> GetStageAsync(ScienceProject project, StageType type);
        List<Stage> GetStages(ScienceProject project);
        Task<List<Stage>> GetStagesAsync(ScienceProject project);
    }
}
