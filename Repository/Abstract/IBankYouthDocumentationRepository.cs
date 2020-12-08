using Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    public interface IBankYouthDocumentationRepository
    {
        BankYouthDocumentation Save(BankYouthDocumentation documentation);
        Task<BankYouthDocumentation> SaveAsync(BankYouthDocumentation documentation);

        void Delete(BankYouthDocumentation documentation);
        Task DeleteAsync(BankYouthDocumentation documentation);

        BankYouthDocumentation GetDocumentation(int id);
        Task<BankYouthDocumentation> GetDocumentationAsync(int id);

        List<BankYouthDocumentation> GetDocumentations(BankYouth bankYouth);
        Task<List<BankYouthDocumentation>> GetDocumentationsAsync(BankYouth bankYouth);
    }
}
