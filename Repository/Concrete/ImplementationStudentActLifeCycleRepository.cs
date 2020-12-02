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
    public class ImplementationStudentActLifeCycleRepository : IImplementationStudentActLifeCycleRepository
    {
        private readonly UCContext context;

        public ImplementationStudentActLifeCycleRepository(UCContext context)
        {
            this.context = context;
        }

        public void Delete(ImplementationStudentActLifeCycle lifeCycle)
        {
            try
            {
                var deleted = context.StudentActLifeCycles.SingleOrDefault(lc => lc.Id == lifeCycle.Id);
                if (deleted != null)
                {
                    context.StudentActLifeCycles.Remove(lifeCycle);
                    context.SaveChanges();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Delete error: " + ex.InnerException.Message);
            }
        }

        public async Task DeleteAsync(ImplementationStudentActLifeCycle lifeCycle)
        {
            try
            {
                var deleted = await context.StudentActLifeCycles.SingleOrDefaultAsync(lc => lc.Id == lifeCycle.Id);
                if (deleted != null)
                {
                    context.StudentActLifeCycles.Remove(lifeCycle);
                    await context.SaveChangesAsync();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Delete error: " + ex.InnerException.Message);
            }
        }

        public ImplementationStudentActLifeCycle GetLifeCycle(int id)
        {
            try
            {
                return context.StudentActLifeCycles
                    .Include(lc => lc.Act)
                    .SingleOrDefault(lc => lc.Id == id);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetLifeCycle error: " + ex.InnerException.Message);
                return null;
            }
        }

        public async Task<ImplementationStudentActLifeCycle> GetLifeCycleAsync(int id)
        {
            try
            {
                return await context.StudentActLifeCycles
                    .Include(lc => lc.Act)
                    .SingleOrDefaultAsync(lc => lc.Id == id);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetLifeCycleAsync error: " + ex.InnerException.Message);
                return null;
            }
        }

        public List<ImplementationStudentActLifeCycle> GetLifeCycles(ImplementationStudentAct act)
        {
            try
            {
                return context.StudentActLifeCycles
                    .Include(lc => lc.Act)
                    .Where(lc => lc.ActId == act.Id)
                    .ToList();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetLifeCycles error: " + ex.InnerException.Message);
                return null;
            }
        }

        public async Task<List<ImplementationStudentActLifeCycle>> GetLifeCyclesAsync(ImplementationStudentAct act)
        {
            try
            {
                return await context.StudentActLifeCycles
                    .Include(lc => lc.Act)
                    .Where(lc => lc.ActId == act.Id)
                    .ToListAsync();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetLifeCyclesAsync error: " + ex.InnerException.Message);
                return null;
            }
        }

        public ImplementationStudentActLifeCycle Save(ImplementationStudentActLifeCycle lifeCycle)
        {
            try
            {
                var saved = context.StudentActLifeCycles.SingleOrDefault(lc=>lc.Id == lifeCycle.Id);
                if (saved != null)
                {
                    saved.ActId = lifeCycle.ActId;
                    saved.Date = lifeCycle.Date;
                    saved.Title = lifeCycle.Title;
                    saved.Message = lifeCycle.Message;
                }
                else
                {
                    saved = context.StudentActLifeCycles.Add(lifeCycle);
                }
                context.SaveChanges();
                return saved;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Save error: "+ ex.InnerException.Message);
                return null;
            }
        }

        public async Task<ImplementationStudentActLifeCycle> SaveAsync(ImplementationStudentActLifeCycle lifeCycle)
        {
            try
            {
                var saved = await context.StudentActLifeCycles.SingleOrDefaultAsync(lc => lc.Id == lifeCycle.Id);
                if (saved != null)
                {
                    saved.ActId = lifeCycle.ActId;
                    saved.Date = lifeCycle.Date;
                    saved.Title = lifeCycle.Title;
                    saved.Message = lifeCycle.Message;
                }
                else
                {
                    saved = context.StudentActLifeCycles.Add(lifeCycle);
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
