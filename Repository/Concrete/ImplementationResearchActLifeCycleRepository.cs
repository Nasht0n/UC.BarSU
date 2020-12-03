using Common;
using Common.Entities;
using Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Concrete
{
    public class ImplementationResearchActLifeCycleRepository : IImplementationResearchActLifeCycleRepository
    {
        private readonly UCContext context;

        public ImplementationResearchActLifeCycleRepository(UCContext context)
        {
            this.context = context;
        }

        public void Delete(ImplementationResearchActLifeCycle lifeCycle)
        {
            try
            {
                var deleted = context.ResearchActLifeCycles.SingleOrDefault(lc => lc.Id == lifeCycle.Id);
                if(deleted!= null)
                {
                    context.ResearchActLifeCycles.Remove(deleted);
                    context.SaveChanges();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Delete error: "+ex.InnerException.Message);
            }
        }

        public async Task DeleteAsync(ImplementationResearchActLifeCycle lifeCycle)
        {
            try
            {
                var deleted = await context.ResearchActLifeCycles.SingleOrDefaultAsync(lc => lc.Id == lifeCycle.Id);
                if (deleted != null)
                {
                    context.ResearchActLifeCycles.Remove(deleted);
                    await context.SaveChangesAsync();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("DeleteAsync error: " + ex.InnerException.Message);
            }
        }

        public ImplementationResearchActLifeCycle GetLifeCycle(int id)
        {
            try
            {
                return context.ResearchActLifeCycles.Include(lc=>lc.Act).SingleOrDefault(lc => lc.Id == id);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetLifeCycle error: "+ex.InnerException.Message);
                return null;
            }
        }

        public async Task<ImplementationResearchActLifeCycle> GetLifeCycleAsync(int id)
        {
            try
            {
                return await context.ResearchActLifeCycles.Include(lc => lc.Act).SingleOrDefaultAsync(lc => lc.Id == id);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetLifeCycleAsync error: " + ex.InnerException.Message);
                return null;
            }
        }

        public List<ImplementationResearchActLifeCycle> GetLifeCycles()
        {
            try
            {
                return context.ResearchActLifeCycles.Include(lc => lc.Act).ToList();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetLifeCycles error: " + ex.InnerException.Message);
                return null;
            }
        }

        public async Task<List<ImplementationResearchActLifeCycle>> GetLifeCyclesAsync()
        {
            try
            {
                return await context.ResearchActLifeCycles.Include(lc => lc.Act).ToListAsync();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetLifeCyclesAsync error: " + ex.InnerException.Message);
                return null;
            }
        }

        public ImplementationResearchActLifeCycle Save(ImplementationResearchActLifeCycle lifeCycle)
        {
            try
            {
                var saved = context.ResearchActLifeCycles.SingleOrDefault(lc => lc.Id == lifeCycle.Id);
                if(saved != null)
                {
                    saved.ActId = lifeCycle.ActId;
                    saved.Date = lifeCycle.Date;
                    saved.Message = lifeCycle.Message;
                    saved.Title = lifeCycle.Title;
                }
                else
                {
                    saved = context.ResearchActLifeCycles.Add(lifeCycle);
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

        public async Task<ImplementationResearchActLifeCycle> SaveAsync(ImplementationResearchActLifeCycle lifeCycle)
        {
            try
            {
                var saved = await context.ResearchActLifeCycles.SingleOrDefaultAsync(lc => lc.Id == lifeCycle.Id);
                if (saved != null)
                {
                    saved.ActId = lifeCycle.ActId;
                    saved.Date = lifeCycle.Date;
                    saved.Message = lifeCycle.Message;
                    saved.Title = lifeCycle.Title;
                }
                else
                {
                    saved = context.ResearchActLifeCycles.Add(lifeCycle);
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
