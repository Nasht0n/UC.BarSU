using Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    public interface IFeedbackRepository
    {
        AppFeedback Save(AppFeedback feedback);
        Task<AppFeedback> SaveAsync(AppFeedback feedback);

        void Delete(AppFeedback feedback);
        Task DeleteAsync(AppFeedback feedback);

        AppFeedback GetFeedback(int id);
        Task<AppFeedback> GetFeedbackAsync(int id);

        List<AppFeedback> GetFeedbacks();
        Task<List<AppFeedback>> GetFeedbacksAsync();
    }
}
