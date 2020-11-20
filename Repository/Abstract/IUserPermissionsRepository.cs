using Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    public interface IUserPermissionsRepository
    {
        AppUserPermissions Save(AppUserPermissions userPermission);
        Task<AppUserPermissions> SaveAsync(AppUserPermissions userPermission);

        void Delete(AppUserPermissions userPermission);
        Task DeleteAsync(AppUserPermissions userPermission);

        AppUserPermissions GetUserPermission(AppUser user, AppPermission permission);
        Task<AppUserPermissions> GetUserPermissionAsync(AppUser user, AppPermission permission);

        List<AppUserPermissions> GetUserPermissions(AppUser user);
        Task<List<AppUserPermissions>> GetUserPermissionsAsync(AppUser user);
    }
}
