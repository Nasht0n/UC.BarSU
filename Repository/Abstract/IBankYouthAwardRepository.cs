using Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    public interface IBankYouthAwardRepository
    {
        BankYouthAward Save(BankYouthAward award);
        Task<BankYouthAward> SaveAsync(BankYouthAward award);

        void Delete(BankYouthAward award);
        Task DeleteAsync(BankYouthAward award);

        BankYouthAward GetAward(int id);
        Task<BankYouthAward> GetAwardAsync(int id);

        List<BankYouthAward> GetAwards(BankYouth bankYouth);
        Task<List<BankYouthAward>> GetAwardsAsync(BankYouth bankYouth);
    }
}
