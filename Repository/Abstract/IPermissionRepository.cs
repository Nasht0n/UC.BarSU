using Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    public interface IPermissionRepository
    {
        AppPermission Save(AppPermission permission);
        Task<AppPermission> SaveAsync(AppPermission permission);

        void Delete(AppPermission permission);
        Task DeleteAsync(AppPermission permission);

        AppPermission GetPermission(int id);
        Task<AppPermission> GetPermissionAsync(int id);

        AppPermission GetPermission(string title);
        Task<AppPermission> GetPermissionAsync(string title);

        List<AppPermission> GetPermissions();
        Task<List<AppPermission>> GetPermissionsAsync();
    }
}
