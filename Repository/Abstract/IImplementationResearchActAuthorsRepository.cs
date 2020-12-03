using Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    public interface IImplementationResearchActAuthorsRepository
    {
        ImplementationResearchActAuthors Save(ImplementationResearchActAuthors author);
        Task<ImplementationResearchActAuthors> SaveAsync(ImplementationResearchActAuthors authors);

        void Delete(ImplementationResearchActAuthors author);
        Task DeleteAsync(ImplementationResearchActAuthors author);

        ImplementationResearchActAuthors GetAuthor(int id);
        Task<ImplementationResearchActAuthors> GetAuthorAsync(int id);

        List<ImplementationResearchActAuthors> GetAuthors();
        Task<List<ImplementationResearchActAuthors>> GetAuthorsAsync();
    }
}
