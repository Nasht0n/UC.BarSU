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
    public class UserRepository : IUserRepository
    {
        private readonly UCContext context;

        public UserRepository(UCContext context)
        {
            this.context = context;
        }

        public void Delete(AppUser user)
        {
            try
            {
                var deleted = context.Users.Single(u => u.Id == user.Id);
                if (deleted != null)
                {
                    context.Users.Remove(user);
                    context.SaveChanges();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Delete error: " + ex.InnerException.Message);
            }
        }

        public async Task DeleteAsync(AppUser user)
        {
            try
            {
                var deleted = await context.Users.SingleAsync(u => u.Id == user.Id);
                if (deleted != null)
                {
                    context.Users.Remove(user);
                    await context.SaveChangesAsync();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("DeleteAsync error: " + ex.InnerException.Message);
            }
        }

        public AppUser GetUser(int id)
        {
            try
            {
                return context.Users.Single(u => u.Id == id);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetUser by Id error: " + ex.InnerException.Message);
                return null;
            }
        }

        public AppUser GetUser(string username, string password)
        {
            try
            {
                return context.Users.Single(u => u.Username == username && u.Password == password);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetUser by Username&Password error: " + ex.InnerException.Message);
                return null;
            }
        }

        public async Task<AppUser> GetUserAsync(int id)
        {
            try
            {
                return await context.Users.SingleAsync(u => u.Id == id);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetUserAsync by Id error: " + ex.InnerException.Message);
                return null;
            }
        }

        public async Task<AppUser> GetUserAsync(string username, string password)
        {
            try
            {
                return await context.Users.SingleAsync(u => u.Username == username && u.Password == password);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetUserAsync by Username&Password error: " + ex.InnerException.Message);
                return null;
            }
        }

        public List<AppUser> GetUsers()
        {
            try
            {
                return context.Users.ToList();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetUsers error: " + ex.InnerException.Message);
                return null;
            }
        }

        public async Task<List<AppUser>> GetUsersAsync()
        {
            try
            {
                return await context.Users.ToListAsync();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetUsersAsync error: " + ex.InnerException.Message);
                return null;
            }
        }

        public AppUser Save(AppUser user)
        {
            try
            {
                var saved = context.Users.Single(u => u.Id == user.Id);
                if (saved != null)
                {
                    saved.Username = user.Username;
                    saved.Password = user.Password;
                    saved.Fullname = user.Fullname;
                    saved.IsEnabled = user.IsEnabled;
                }
                else
                {
                    saved = context.Users.Add(user);
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

        public async Task<AppUser> SaveAsync(AppUser user)
        {
            try
            {
                var saved = await context.Users.SingleAsync(u => u.Id == user.Id);
                if (saved != null)
                {
                    saved.Username = user.Username;
                    saved.Password = user.Password;
                    saved.Fullname = user.Fullname;
                    saved.IsEnabled = user.IsEnabled;
                }
                else
                {
                    saved = context.Users.Add(user);
                }
                await context.SaveChangesAsync();
                return saved;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SaveAsync error: " + ex.InnerException.Message);
                return null;
            }
        }
    }
}
