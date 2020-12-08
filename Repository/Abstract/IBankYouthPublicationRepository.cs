using Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    public interface IBankYouthPublicationRepository
    {
        BankYouthPublication Save(BankYouthPublication publication);
        Task<BankYouthPublication> SaveAsync(BankYouthPublication publication);

        void Delete(BankYouthPublication publication);
        Task DeleteAsync(BankYouthPublication publication);

        BankYouthPublication GetPublication(int id);
        Task<BankYouthPublication> GetPublicationAsync(int id);

        List<BankYouthPublication> GetPublications(BankYouth bankYouth);
        Task<List<BankYouthPublication>> GetPublicationsAsync(BankYouth bankYouth);
    }
}
