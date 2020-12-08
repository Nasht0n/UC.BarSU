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
    public class BankYouthPublicationRepository : IBankYouthPublicationRepository
    {
        private readonly UCContext context;

        public BankYouthPublicationRepository(UCContext context)
        {
            this.context = context;
        }

        public void Delete(BankYouthPublication publication)
        {
            try
            {
                var deleted = context.Publications.SingleOrDefault(p => p.Id == publication.Id);
                if(deleted != null)
                {
                    context.Publications.Remove(deleted);
                    context.SaveChanges();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Delete error: "+ex.InnerException.Message);
            }
        }

        public async Task DeleteAsync(BankYouthPublication publication)
        {
            try
            {
                var deleted = await context.Publications.SingleOrDefaultAsync(p => p.Id == publication.Id);
                if (deleted != null)
                {
                    context.Publications.Remove(deleted);
                    await context.SaveChangesAsync();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("DeleteAsync error: " + ex.InnerException.Message);
            }
        }

        public BankYouthPublication GetPublication(int id)
        {
            try
            {
                return context.Publications.Include(p=>p.BankYouth).SingleOrDefault(p => p.Id == id);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetPublication error: "+ex.InnerException.Message);
                return null;
            }
        }

        public async Task<BankYouthPublication> GetPublicationAsync(int id)
        {
            try
            {
                return await context.Publications.Include(p => p.BankYouth).SingleOrDefaultAsync(p => p.Id == id);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetPublicationAsync error: " + ex.InnerException.Message);
                return null;
            }
        }

        public List<BankYouthPublication> GetPublications(BankYouth bankYouth)
        {
            try
            {
                return context.Publications.Include(p=>p.BankYouth).Where(p=>p.BankYouthId == bankYouth.Id).ToList();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetPublications error: "+ex.InnerException.Message);
                return null;
            }
        }

        public async Task<List<BankYouthPublication>> GetPublicationsAsync(BankYouth bankYouth)
        {
            try
            {
                return await context.Publications.Include(p => p.BankYouth).Where(p => p.BankYouthId == bankYouth.Id).ToListAsync();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetPublicationsAsync error: " + ex.InnerException.Message);
                return null;
            }
        }

        public BankYouthPublication Save(BankYouthPublication publication)
        {
            try
            {
                var saved = context.Publications.SingleOrDefault(p => p.Id == publication.Id);
                if (saved != null) 
                {
                    saved.BankYouthId = publication.BankYouthId;
                    saved.Description = publication.Description;
                    saved.Filename = publication.Filename;
                    saved.Path = publication.Path;
                } 
                else
                {
                    saved = context.Publications.Add(publication);
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

        public async Task<BankYouthPublication> SaveAsync(BankYouthPublication publication)
        {
            try
            {
                var saved = await context.Publications.SingleOrDefaultAsync(p => p.Id == publication.Id);
                if (saved != null)
                {
                    saved.BankYouthId = publication.BankYouthId;
                    saved.Description = publication.Description;
                    saved.Filename = publication.Filename;
                    saved.Path = publication.Path;
                }
                else
                {
                    saved = context.Publications.Add(publication);
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
