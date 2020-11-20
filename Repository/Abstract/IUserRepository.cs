using Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    public interface IUserRepository
    {
        AppUser Save(AppUser user);
        Task<AppUser> SaveAsync(AppUser user);

        void Delete(AppUser user);
        Task DeleteAsync(AppUser user);

        AppUser GetUser(int id);
        Task<AppUser> GetUserAsync(int id);

        AppUser GetUser(string username, string password);
        Task<AppUser> GetUserAsync(string username, string password);

        List<AppUser> GetUsers();
        Task<List<AppUser>> GetUsersAsync();
    }
}
