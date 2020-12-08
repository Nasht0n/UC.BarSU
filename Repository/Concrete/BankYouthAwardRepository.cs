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
    public class BankYouthAwardRepository : IBankYouthAwardRepository
    {
        private readonly UCContext context;

        public BankYouthAwardRepository(UCContext context)
        {
            this.context = context;
        }

        public void Delete(BankYouthAward award)
        {
            try
            {
                var deleted = context.Awards.SingleOrDefault(by => by.Id == award.Id);
                if (deleted != null)
                {
                    context.Awards.Remove(deleted);
                    context.SaveChanges();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Delete error: "+ex.InnerException.Message);
            }
        }

        public async Task DeleteAsync(BankYouthAward award)
        {
            try
            {
                var deleted = await context.Awards.SingleOrDefaultAsync(by => by.Id == award.Id);
                if (deleted != null)
                {
                    context.Awards.Remove(deleted);
                    await context.SaveChangesAsync();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("DeleteAsync error: " + ex.InnerException.Message);
            }
        }

        public BankYouthAward GetAward(int id)
        {
            try
            {
                return context.Awards.SingleOrDefault(a => a.Id == id);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetAward error: "+ex.InnerException.Message);
                return null;
            }
        }

        public async Task<BankYouthAward> GetAwardAsync(int id)
        {
            try
            {
                return await context.Awards.SingleOrDefaultAsync(a => a.Id == id);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetAwardAsync error: " + ex.InnerException.Message);
                return null;
            }
        }

        public List<BankYouthAward> GetAwards(BankYouth bankYouth)
        {
            try
            {
                return context.Awards.Include(a => a.BankYouth).Where(a => a.BankYouthId == bankYouth.Id).ToList();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetAwards error: "+ex.InnerException.Message);
                return null;
            }
        }

        public async Task<List<BankYouthAward>> GetAwardsAsync(BankYouth bankYouth)
        {
            try
            {
                return await context.Awards.Include(a => a.BankYouth).Where(a => a.BankYouthId == bankYouth.Id).ToListAsync();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetAwardsAsync error: " + ex.InnerException.Message);
                return null;
            }
        }

        public BankYouthAward Save(BankYouthAward award)
        {
            try
            {
                var saved = context.Awards.SingleOrDefault(a=>a.Id == award.Id);
                if (saved != null)
                {
                    saved.BankYouthId = award.BankYouthId;
                    saved.Date = award.Date;
                    saved.Description = award.Description;
                    saved.Filename = award.Filename;
                    saved.Path = award.Path;
                }
                else
                {
                    saved = context.Awards.Add(award);
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

        public async Task<BankYouthAward> SaveAsync(BankYouthAward award)
        {
            try
            {
                var saved = await context.Awards.SingleOrDefaultAsync(a => a.Id == award.Id);
                if (saved != null)
                {
                    saved.BankYouthId = award.BankYouthId;
                    saved.Date = award.Date;
                    saved.Description = award.Description;
                    saved.Filename = award.Filename;
                    saved.Path = award.Path;
                }
                else
                {
                    saved = context.Awards.Add(award);
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
