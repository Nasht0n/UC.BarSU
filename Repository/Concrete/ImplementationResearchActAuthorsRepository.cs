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
    public class ImplementationResearchActAuthorsRepository : IImplementationResearchActAuthorsRepository
    {
        private readonly UCContext context;

        public ImplementationResearchActAuthorsRepository(UCContext context)
        {
            this.context = context;
        }

        public void Delete(ImplementationResearchActAuthors author)
        {
            try
            {
                var deleted = context.ResearchActAuthors.SingleOrDefault(a => a.Id == author.Id);
                if (deleted != null)
                {
                    context.ResearchActAuthors.Remove(deleted);
                    context.SaveChanges();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Delete error: "+ ex.InnerException.Message);
            }
        }

        public async Task DeleteAsync(ImplementationResearchActAuthors author)
        {
            try
            {
                var deleted = await context.ResearchActAuthors.SingleOrDefaultAsync(a => a.Id == author.Id);
                if (deleted != null)
                {
                    context.ResearchActAuthors.Remove(deleted);
                    await context.SaveChangesAsync();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("DeleteAsync error: " + ex.InnerException.Message);
            }
        }

        public ImplementationResearchActAuthors GetAuthor(int id)
        {
            try
            {
                return context.ResearchActAuthors.Include(a=>a.Act).SingleOrDefault(a => a.Id == id);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetAuthor error: "+ex.InnerException.Message);
                return null;
            }
        }

        public async Task<ImplementationResearchActAuthors> GetAuthorAsync(int id)
        {
            try
            {
                return await context.ResearchActAuthors.Include(a => a.Act).SingleOrDefaultAsync(a => a.Id == id);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetAuthorAsync error: " + ex.InnerException.Message);
                return null;
            }
        }

        public List<ImplementationResearchActAuthors> GetAuthors()
        {
            try
            {
                return context.ResearchActAuthors.Include(a => a.Act).ToList();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetAuthors error: " + ex.InnerException.Message);
                return null;
            }
        }

        public List<ImplementationResearchActAuthors> GetAuthors(ImplementationResearchAct act)
        {
            try
            {
                return context.ResearchActAuthors.Include(a => a.Act).Where(a=>a.ActId == act.Id).ToList();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetAuthors error: " + ex.InnerException.Message);
                return null;
            }
        }

        public async Task<List<ImplementationResearchActAuthors>> GetAuthorsAsync()
        {
            try
            {
                return await context.ResearchActAuthors.Include(a => a.Act).ToListAsync();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetAuthorsAsync error: " + ex.InnerException.Message);
                return null;
            }
        }

        public async Task<List<ImplementationResearchActAuthors>> GetAuthorsAsync(ImplementationResearchAct act)
        {
            try
            {
                return await context.ResearchActAuthors.Include(a => a.Act).Where(a=>a.ActId == act.Id).ToListAsync();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetAuthorsAsync error: " + ex.InnerException.Message);
                return null;
            }
        }

        public ImplementationResearchActAuthors Save(ImplementationResearchActAuthors author)
        {
            try
            {
                var saved = context.ResearchActAuthors.SingleOrDefault(a => a.Id == author.Id);
                if(saved != null)
                {
                    saved.AcademicDegree = author.AcademicDegree;
                    saved.AcademicStatus = author.AcademicStatus;
                    saved.ActId = author.ActId;
                    saved.Fullname = author.Fullname;
                    saved.Post = author.Post;
                }
                else
                {
                    saved = context.ResearchActAuthors.Add(author);
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

        public async Task<ImplementationResearchActAuthors> SaveAsync(ImplementationResearchActAuthors author)
        {
            try
            {
                var saved = await context.ResearchActAuthors.SingleOrDefaultAsync(a => a.Id == author.Id);
                if (saved != null)
                {
                    saved.AcademicDegree = author.AcademicDegree;
                    saved.AcademicStatus = author.AcademicStatus;
                    saved.ActId = author.ActId;
                    saved.Fullname = author.Fullname;
                    saved.Post = author.Post;
                }
                else
                {
                    saved = context.ResearchActAuthors.Add(author);
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
