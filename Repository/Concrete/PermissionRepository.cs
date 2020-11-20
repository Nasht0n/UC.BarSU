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
    public class PermissionRepository : IPermissionRepository
    {
        private readonly UCContext context;

        public PermissionRepository(UCContext context)
        {
            this.context = context;
        }

        public void Delete(AppPermission permission)
        {
            try
            {
                var deleted = context.Permissions.Single(p => p.Id == permission.Id);
                if (deleted != null)
                {
                    context.Permissions.Remove(permission);
                    context.SaveChanges();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Delete error: "+ex.InnerException.Message);
            }
        }

        public async Task DeleteAsync(AppPermission permission)
        {
            try
            {
                var deleted = await context.Permissions.SingleAsync(p => p.Id == permission.Id);
                if (deleted != null)
                {
                    context.Permissions.Remove(permission);
                    await context.SaveChangesAsync();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("DeleteAsync error: " + ex.InnerException.Message);
            }
        }

        public AppPermission GetPermission(int id)
        {
            try
            {
                return context.Permissions.Single(p => p.Id == id);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetPermission by Id error: "+ex.InnerException.Message);
                return null;
            }
        }

        public AppPermission GetPermission(string title)
        {
            try
            {
                return context.Permissions.Single(p => p.Title == title);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetPermission by Title error: " + ex.InnerException.Message);
                return null;
            }
        }

        public async Task<AppPermission> GetPermissionAsync(int id)
        {
            try
            {
                return await context.Permissions.SingleAsync(p => p.Id == id);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetPermissionAsync by Id error: " + ex.InnerException.Message);
                return null;
            }
        }

        public async Task<AppPermission> GetPermissionAsync(string title)
        {
            try
            {
                return await context.Permissions.SingleAsync(p => p.Title == title);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetPermissionAsync by Title error: " + ex.InnerException.Message);
                return null;
            }
        }

        public List<AppPermission> GetPermissions()
        {
            try
            {
                return context.Permissions.ToList();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetPermissions error: "+ex.InnerException.Message);
                return null;
            }
        }

        public async Task<List<AppPermission>> GetPermissionsAsync()
        {
            try
            {
                return await context.Permissions.ToListAsync();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetPermissionsAsync error: " + ex.InnerException.Message);
                return null;
            }
        }

        public AppPermission Save(AppPermission permission)
        {
            try
            {
                var saved = context.Permissions.Single(p=>p.Id == permission.Id);
                if(saved != null)
                {
                    saved.Title = permission.Title;
                    saved.Description = permission.Description;
                }
                else
                {
                    saved = context.Permissions.Add(permission);
                }
                context.SaveChanges();
                return saved;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Save permission error: "+ex.InnerException.Message);
                return null;
            }
        }

        public async Task<AppPermission> SaveAsync(AppPermission permission)
        {
            try
            {
                var saved = await context.Permissions.SingleAsync(p => p.Id == permission.Id);
                if (saved != null)
                {
                    saved.Title = permission.Title;
                    saved.Description = permission.Description;
                }
                else
                {
                    saved = context.Permissions.Add(permission);
                }
                await context.SaveChangesAsync();
                return saved;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SaveAsync permission error: " + ex.InnerException.Message);
                return null;
            }
        }
    }
}
