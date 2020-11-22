using Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    public interface IScienceProjectReportRepository
    {
        ScienceProjectReport Save(ScienceProjectReport report);
        Task<ScienceProjectReport> SaveAsync(ScienceProjectReport report);
        void Delete(ScienceProjectReport report);
        Task DeleteAsync(ScienceProjectReport report);
        ScienceProjectReport GetReport(int id);
        Task<ScienceProjectReport> GetReportAsync(int id);
        List<ScienceProjectReport> GetReports();
        Task<List<ScienceProjectReport>> GetReportsAsync();
        List<ScienceProjectReport> GetReports(Stage stage);
        Task<List<ScienceProjectReport>> GetReportsAsync(Stage stage);
    }
}
