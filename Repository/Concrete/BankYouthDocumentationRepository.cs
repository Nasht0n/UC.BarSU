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
    public class BankYouthDocumentationRepository : IBankYouthDocumentationRepository
    {
        private readonly UCContext context;

        public BankYouthDocumentationRepository(UCContext context)
        {
            this.context = context;
        }

        public void Delete(BankYouthDocumentation documentation)
        {
            try
            {
                var deleted = context.Documentations.SingleOrDefault(d => d.Id == documentation.Id);
                if(deleted != null)
                {
                    context.Documentations.Remove(deleted);
                    context.SaveChanges();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Delete error: "+ex.InnerException.Message);                
            }
        }

        public async Task DeleteAsync(BankYouthDocumentation documentation)
        {
            try
            {
                var deleted = await context.Documentations.SingleOrDefaultAsync(d => d.Id == documentation.Id);
                if (deleted != null)
                {
                    context.Documentations.Remove(deleted);
                    await context.SaveChangesAsync();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("DeleteAsync error: " + ex.InnerException.Message);
            }
        }

        public BankYouthDocumentation GetDocumentation(int id)
        {
            try
            {
                return context.Documentations.Include(d => d.BankYouth).SingleOrDefault(d => d.Id == id);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetDocumentation error: "+ex.InnerException.Message);
                return null;
            }
        }

        public async Task<BankYouthDocumentation> GetDocumentationAsync(int id)
        {
            try
            {
                return await context.Documentations.Include(d => d.BankYouth).SingleOrDefaultAsync(d => d.Id == id);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetDocumentationAsync error: " + ex.InnerException.Message);
                return null;
            }
        }

        public List<BankYouthDocumentation> GetDocumentations(BankYouth bankYouth)
        {
            try
            {
                return context.Documentations.Include(d => d.BankYouth).Where(d => d.BankYouthId == bankYouth.Id).ToList();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetDocumentations error: "+ex.InnerException.Message);
                return null;
            }
        }

        public async Task<List<BankYouthDocumentation>> GetDocumentationsAsync(BankYouth bankYouth)
        {
            try
            {
                return await context.Documentations.Include(d => d.BankYouth).Where(d => d.BankYouthId == bankYouth.Id).ToListAsync();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetDocumentationsAsync error: " + ex.InnerException.Message);
                return null;
            }
        }

        public BankYouthDocumentation Save(BankYouthDocumentation documentation)
        {
            try
            {
                var saved = context.Documentations.SingleOrDefault(d=>d.Id == documentation.Id);
                if(saved != null)
                {
                    saved.BankYouthId = documentation.BankYouthId;
                    saved.Description = documentation.Description;
                    saved.Filename = documentation.Filename;
                    saved.Path = documentation.Path;
                    saved.RegDate = documentation.RegDate;
                    saved.RegNumber = documentation.RegNumber;
                }
                else
                {
                    saved = context.Documentations.Add(documentation);
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

        public async Task<BankYouthDocumentation> SaveAsync(BankYouthDocumentation documentation)
        {
            try
            {
                var saved = await context.Documentations.SingleOrDefaultAsync(d => d.Id == documentation.Id);
                if (saved != null)
                {
                    saved.BankYouthId = documentation.BankYouthId;
                    saved.Description = documentation.Description;
                    saved.Filename = documentation.Filename;
                    saved.Path = documentation.Path;
                    saved.RegDate = documentation.RegDate;
                    saved.RegNumber = documentation.RegNumber;
                }
                else
                {
                    saved = context.Documentations.Add(documentation);
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
