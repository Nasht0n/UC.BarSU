using Common;
using Common.Entities;
using Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Concrete
{
    public class UserPermissionRepository : IUserPermissionsRepository
    {
        private readonly UCContext context;

        public UserPermissionRepository(UCContext context)
        {
            this.context = context;
        }

        public void Delete(AppUserPermissions userPermission)
        {
            try
            {
                var deleted = context.UserPermissions.Single(up => up.UserId == userPermission.UserId && up.PermissionId == userPermission.PermissionId);
                if (deleted != null)
                {
                    context.UserPermissions.Remove(userPermission);
                    context.SaveChanges();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Delete error: " + ex.InnerException.Message);
            }
        }

        public async Task DeleteAsync(AppUserPermissions userPermission)
        {
            try
            {
                var deleted = await context.UserPermissions.SingleAsync(up => up.UserId == userPermission.UserId && up.PermissionId == userPermission.PermissionId);
                if (deleted != null)
                {
                    context.UserPermissions.Remove(userPermission);
                    await context.SaveChangesAsync();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("DeleteAsync error: " + ex.InnerException.Message);
            }
        }

        public AppUserPermissions GetUserPermission(AppUser user, AppPermission permission)
        {
            try
            {
                return context.UserPermissions.Single(up => up.UserId == user.Id && up.PermissionId == permission.Id);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetUserPermission error: " + ex.InnerException.Message);
                return null;
            }
        }

        public async Task<AppUserPermissions> GetUserPermissionAsync(AppUser user, AppPermission permission)
        {
            try
            {
                return await context.UserPermissions.SingleAsync(up => up.UserId == user.Id && up.PermissionId == permission.Id);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetUserPermissionAsync error: " + ex.InnerException.Message);
                return null;
            }
        }

        public List<AppUserPermissions> GetUserPermissions(AppUser user)
        {
            try
            {
                return context.UserPermissions.Where(up => up.UserId == user.Id).ToList();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetUserPermissions error: " + ex.InnerException.Message);
                return null;
            }
        }

        public async Task<List<AppUserPermissions>> GetUserPermissionsAsync(AppUser user)
        {
            try
            {
                return await context.UserPermissions.Where(up => up.UserId == user.Id).ToListAsync();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetUserPermissionsAsync error: " + ex.InnerException.Message);
                return null;
            }
        }

        public AppUserPermissions Save(AppUserPermissions userPermission)
        {
            try
            {
                var saved = context.UserPermissions.Single(up => up.UserId == userPermission.UserId && up.PermissionId == userPermission.PermissionId);
                if (saved != null)
                {
                    saved.UserId = userPermission.UserId;
                    saved.PermissionId = userPermission.PermissionId;
                }
                else
                {
                    saved = context.UserPermissions.Add(userPermission);
                }
                context.SaveChanges();
                return saved;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Save error: " + ex.InnerException.Message);
                return null;
            }
        }

        public async Task<AppUserPermissions> SaveAsync(AppUserPermissions userPermission)
        {
            try
            {
                var saved = await context.UserPermissions.SingleAsync(up => up.UserId == userPermission.UserId && up.PermissionId == userPermission.PermissionId);
                if (saved != null)
                {
                    saved.UserId = userPermission.UserId;
                    saved.PermissionId = userPermission.PermissionId;
                }
                else
                {
                    saved = context.UserPermissions.Add(userPermission);
                }
                await context.SaveChangesAsync();
                return saved;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Save error: " + ex.InnerException.Message);
                return null;
            }
        }
    }
}
