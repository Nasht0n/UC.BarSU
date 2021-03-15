using Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    public interface IPaidServicesRepository
    {
        PaidServices Save(PaidServices paidService);
        Task<PaidServices> SaveAsync(PaidServices paidService);

        void Delete(PaidServices paidService);
        Task DeleteAsync(PaidServices paidService);

        PaidServices GetPaidService(int id);
        Task<PaidServices> GetPaidServiceAsync(int id);

        List<PaidServices> GetPaidServices();
        Task<List<PaidServices>> GetPaidServicesAsync();

        List<PaidServices> GetPaidServices(AppUser user);
        Task<List<PaidServices>> GetPaidServicesAsync(AppUser user);
    }
}
