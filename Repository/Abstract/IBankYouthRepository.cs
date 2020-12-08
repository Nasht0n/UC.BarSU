using Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    public interface IBankYouthRepository
    {
        BankYouth Save(BankYouth youth);
        Task<BankYouth> SaveAsync(BankYouth youth);

        BankYouth GetBankYouth(int id);
        Task<BankYouth> GetBankYouthAsync(int id);

        void Delete(BankYouth youth);
        Task DeleteAsync(BankYouth youth);

        List<BankYouth> GetBankYouths();
        Task<List<BankYouth>> GetBankYouthsAsync();

        List<BankYouth> GetBankYouths(AppUser user);
        Task<List<BankYouth>> GetBankYouthsAsync(AppUser user);
    }
}
