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
    public class ImplementationResearchActEmployeesRepository : IImplementationResearchActEmployeesRepository
    {
        private readonly UCContext context;

        public ImplementationResearchActEmployeesRepository(UCContext context)
        {
            this.context = context;
        }

        public void Delete(ImplementationResearchActEmployees employee)
        {
            try
            {
                var deleted = context.ResearchActEmployees.SingleOrDefault(e => e.Id == employee.Id);
                if (deleted != null)
                {
                    context.ResearchActEmployees.Remove(deleted);
                    context.SaveChanges();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Delete error: "+ex.InnerException.Message);
            }
        }

        public async Task DeleteAsync(ImplementationResearchActEmployees employee)
        {
            try
            {
                var deleted = await context.ResearchActEmployees.SingleOrDefaultAsync(e => e.Id == employee.Id);
                if (deleted != null)
                {
                    context.ResearchActEmployees.Remove(deleted);
                    await context.SaveChangesAsync();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("DeleteAsync error: " + ex.InnerException.Message);
            }
        }

        public ImplementationResearchActEmployees GetEmployee(int id)
        {
            try
            {
                return context.ResearchActEmployees.Include(e=>e.Act).SingleOrDefault(e => e.Id == id);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetEmployee error: "+ex.InnerException.Message);
                return null;
            }
        }

        public async Task<ImplementationResearchActEmployees> GetEmployeeAsync(int id)
        {
            try
            {
                return await context.ResearchActEmployees.Include(e => e.Act).SingleOrDefaultAsync(e => e.Id == id);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetEmployeeAsync error: " + ex.InnerException.Message);
                return null;
            }
        }

        public List<ImplementationResearchActEmployees> GetEmployees()
        {
            try
            {
                return context.ResearchActEmployees.Include(e => e.Act).ToList();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetEmployee error: " + ex.InnerException.Message);
                return null;
            }
        }

        public List<ImplementationResearchActEmployees> GetEmployees(ImplementationResearchAct act)
        {
            try
            {
                return context.ResearchActEmployees.Include(e => e.Act).Where(e=>e.ActId == act.Id).ToList();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetEmployee error: " + ex.InnerException.Message);
                return null;
            }
        }

        public async Task<List<ImplementationResearchActEmployees>> GetEmployeesAsync()
        {
            try
            {
                return await context.ResearchActEmployees.Include(e => e.Act).ToListAsync();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetEmployeesAsync error: " + ex.InnerException.Message);
                return null;
            }
        }

        public async Task<List<ImplementationResearchActEmployees>> GetEmployeesAsync(ImplementationResearchAct act)
        {
            try
            {
                return await context.ResearchActEmployees.Include(e => e.Act).Where(e => e.ActId == act.Id).ToListAsync();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetEmployeesAsync error: " + ex.InnerException.Message);
                return null;
            }
        }

        public ImplementationResearchActEmployees Save(ImplementationResearchActEmployees employee)
        {
            try
            {
                var saved = context.ResearchActEmployees.SingleOrDefault(e => e.Id == employee.Id);
                if(saved != null)
                {
                    saved.ActId = employee.ActId;
                    saved.Fullname = employee.Fullname;
                    saved.Post = employee.Post;
                }
                else
                {
                    saved = context.ResearchActEmployees.Add(employee);
                }
                context.SaveChanges();
                return saved;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Save error: "+ex.InnerException.Message);
                return null;
            }
        }

        public async Task<ImplementationResearchActEmployees> SaveAsync(ImplementationResearchActEmployees employee)
        {
            try
            {
                var saved = await context.ResearchActEmployees.SingleOrDefaultAsync(e => e.Id == employee.Id);
                if (saved != null)
                {
                    saved.ActId = employee.ActId;
                    saved.Fullname = employee.Fullname;
                    saved.Post = employee.Post;
                }
                else
                {
                    saved = context.ResearchActEmployees.Add(employee);
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
