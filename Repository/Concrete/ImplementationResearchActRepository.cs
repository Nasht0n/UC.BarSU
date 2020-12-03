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
    public class ImplementationResearchActRepository : IImplementationResearchActRepository
    {
        private readonly UCContext context;

        public ImplementationResearchActRepository(UCContext context)
        {
            this.context = context;
        }

        public void Delete(ImplementationResearchAct act)
        {
            try
            {
                var deleted = context.ResearchActs.SingleOrDefault(a => a.Id == act.Id);
                if (deleted != null)
                {
                    context.ResearchActs.Remove(deleted);
                    context.SaveChanges();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Delete error: " + ex.InnerException.Message);
            }
        }

        public async Task DeleteAsync(ImplementationResearchAct act)
        {
            try
            {
                var deleted = await context.ResearchActs.SingleOrDefaultAsync(a => a.Id == act.Id);
                if (deleted != null)
                {
                    context.ResearchActs.Remove(deleted);
                    await context.SaveChangesAsync();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("DeleteAsync error: " + ex.InnerException.Message);
            }
        }

        public ImplementationResearchAct GetAct(int id)
        {
            try
            {
                return context.ResearchActs.SingleOrDefault(a => a.Id == id);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetAct error: " + ex.InnerException.Message);
                return null;
            }
        }

        public async Task<ImplementationResearchAct> GetActAsync(int id)
        {
            try
            {
                return await context.ResearchActs.SingleOrDefaultAsync(a => a.Id == id);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetActAsync error: " + ex.InnerException.Message);
                return null;
            }
        }

        public List<ImplementationResearchAct> GetActs()
        {
            try
            {
                return context.ResearchActs.Include(a => a.Authors).Include(a => a.Employees).Include(a => a.LifeCycles).Include(a => a.User).ToList();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetActs error: " + ex.InnerException.Message);
                return null;
            }
        }

        public async Task<List<ImplementationResearchAct>> GetActsAsync()
        {
            try
            {
                return await context.ResearchActs.Include(a => a.Authors).Include(a => a.Employees).Include(a => a.LifeCycles).Include(a => a.User).ToListAsync();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetActsAsync error: " + ex.InnerException.Message);
                return null;
            }
        }

        public ImplementationResearchAct Save(ImplementationResearchAct act)
        {
            try
            {
                var saved = context.ResearchActs.SingleOrDefault(a=>a.Id == act.Id);
                if (saved != null)
                {
                    saved.UserId = act.UserId;
                    saved.ImplementingResult = act.ImplementingResult;
                    saved.Process = act.Process;
                    saved.Characteristic = act.Characteristic;
                    saved.ImplementationForm = act.ImplementationForm;
                    saved.UnitUsing = act.UnitUsing;
                    saved.FeasibilityOfIntroducing = act.FeasibilityOfIntroducing;
                    saved.HeadUnit = act.HeadUnit;
                }
                else
                {
                    saved = context.ResearchActs.Add(act);
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

        public async Task<ImplementationResearchAct> SaveAsync(ImplementationResearchAct act)
        {
            try
            {
                var saved = await context.ResearchActs.SingleOrDefaultAsync(a => a.Id == act.Id);
                if (saved != null)
                {
                    saved.UserId = act.UserId;
                    saved.ImplementingResult = act.ImplementingResult;
                    saved.Process = act.Process;
                    saved.Characteristic = act.Characteristic;
                    saved.ImplementationForm = act.ImplementationForm;
                    saved.UnitUsing = act.UnitUsing;
                    saved.FeasibilityOfIntroducing = act.FeasibilityOfIntroducing;
                    saved.HeadUnit = act.HeadUnit;
                }
                else
                {
                    saved = context.ResearchActs.Add(act);
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
