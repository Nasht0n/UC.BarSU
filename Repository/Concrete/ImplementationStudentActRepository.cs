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
    public class ImplementationStudentActRepository : IImplementationStudentActRepository
    {
        private readonly UCContext context;

        public ImplementationStudentActRepository(UCContext context)
        {
            this.context = context;
        }

        public void Delete(ImplementationStudentAct act)
        {
            try
            {
                var deleted = context.StudentActs.SingleOrDefault(a => a.Id == act.Id);
                if (deleted != null)
                {
                    context.StudentActs.Remove(act);
                    context.SaveChanges();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Delete error: " + ex.InnerException.Message);
            }
        }

        public async Task DeleteAsync(ImplementationStudentAct act)
        {
            try
            {
                var deleted = await context.StudentActs.SingleOrDefaultAsync(a => a.Id == act.Id);
                if (deleted != null)
                {
                    context.StudentActs.Remove(act);
                    await context.SaveChangesAsync();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Delete error: " + ex.InnerException.Message);
            }
        }

        public ImplementationStudentAct GetAct(int id)
        {
            try
            {
                return context.StudentActs
                    .Include(a => a.Comissions)
                    .Include(a => a.LifeCycles)
                    .SingleOrDefault(a => a.Id == id);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Get Act error: " + ex.InnerException.Message);
                return null;
            }
        }

        public async Task<ImplementationStudentAct> GetActAsync(int id)
        {
            try
            {
                return await context.StudentActs
                    .Include(a => a.Comissions)
                    .Include(a => a.LifeCycles)
                    .SingleOrDefaultAsync(s => s.Id == id);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetActAsync error: " + ex.InnerException.Message);
                return null;
            }
        }

        public List<ImplementationStudentAct> GetActs()
        {
            try
            {
                return context.StudentActs
                    .Include(a => a.Comissions)
                    .Include(a => a.LifeCycles)
                    .ToList();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetActs error: " + ex.InnerException.Message);
                return null;
            }
        }

        public List<ImplementationStudentAct> GetActs(AppUser user)
        {
            try
            {
                return context.StudentActs
                    .Include(a => a.Comissions)
                    .Include(a => a.LifeCycles)
                    .Where(a => a.UserId == user.Id)
                    .ToList();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetActs by user error: " + ex.InnerException.Message);
                return null;
            }
        }

        public async Task<List<ImplementationStudentAct>> GetActsAsync()
        {
            try
            {
                return await context.StudentActs
                    .Include(a => a.Comissions)
                    .Include(a => a.LifeCycles)
                    .ToListAsync();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetActsAsync error: " + ex.InnerException.Message);
                return null;
            }
        }

        public async Task<List<ImplementationStudentAct>> GetActsAsync(AppUser user)
        {
            try
            {
                return await context.StudentActs
                    .Include(a => a.Comissions)
                    .Include(a => a.LifeCycles)
                    .Where(a => a.UserId == user.Id)
                    .ToListAsync();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetActsAsync by user error: " + ex.InnerException.Message);
                return null;
            }
        }

        public ImplementationStudentAct Save(ImplementationStudentAct act)
        {
            try
            {
                var saved = context.StudentActs.SingleOrDefault(a => a.Id == act.Id);
                if (saved != null)
                {
                    saved.UserId = act.UserId;
                    saved.Scope = act.Scope;
                    saved.Department = act.Department;
                    saved.Result = act.Result;
                    saved.Author = act.Author;
                    saved.ProjectName = act.ProjectName;
                    saved.PracticalTasks = act.PracticalTasks;
                    saved.EconomicEfficiency = act.EconomicEfficiency;
                    saved.ProtocolDate = act.ProtocolDate;
                    saved.ProtocolNumber = act.ProtocolNumber;
                    saved.RegisterDate = act.RegisterDate;
                }
                else
                {
                    saved = context.StudentActs.Add(act);
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

        public async Task<ImplementationStudentAct> SaveAsync(ImplementationStudentAct act)
        {
            try
            {
                var saved = await context.StudentActs.SingleOrDefaultAsync(a => a.Id == act.Id);
                if (saved != null)
                {
                    saved.UserId = act.UserId;
                    saved.Scope = act.Scope;
                    saved.Department = act.Department;
                    saved.Result = act.Result;
                    saved.Author = act.Author;
                    saved.ProjectName = act.ProjectName;
                    saved.PracticalTasks = act.PracticalTasks;
                    saved.EconomicEfficiency = act.EconomicEfficiency;
                    saved.ProtocolDate = act.ProtocolDate;
                    saved.ProtocolNumber = act.ProtocolNumber;
                    saved.RegisterDate = act.RegisterDate;
                }
                else
                {
                    saved = context.StudentActs.Add(act);
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
