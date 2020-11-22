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
    public class CastRepository : ICastRepository
    {
        private readonly UCContext context;

        public CastRepository(UCContext context)
        {
            this.context = context;
        }

        public void Delete(Cast cast)
        {
            try
            {
                var deleted = context.Casts.SingleOrDefault(c => c.Id == cast.Id);
                if (deleted != null)
                {
                    context.Casts.Remove(deleted);
                    context.SaveChanges();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Delete error: " + ex.InnerException.Message);
            }
        }

        public async Task DeleteAsync(Cast cast)
        {
            try
            {
                var deleted = await context.Casts.SingleOrDefaultAsync(c => c.Id == cast.Id);
                if (deleted != null)
                {
                    context.Casts.Remove(deleted);
                    await context.SaveChangesAsync();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Delete error: " + ex.InnerException.Message);
            }
        }

        public Cast GetCast(int id)
        {
            try
            {
                return context.Casts.Include(c=>c.Project).SingleOrDefault(c => c.Id == id);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetCast error: " + ex.InnerException.Message);
                return null;
            }
        }

        public async Task<Cast> GetCastAsync(int id)
        {
            try
            {
                return await context.Casts.Include(c => c.Project).SingleOrDefaultAsync(c => c.Id == id);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetCastAsync error: " + ex.InnerException.Message);
                return null;
            }
        }

        public List<Cast> GetCasts()
        {
            try
            {
                return context.Casts.Include(c => c.Project).ToList();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetCasts error: " + ex.InnerException.Message);
                return null;
            }
        }

        public List<Cast> GetCasts(ScienceProject project)
        {
            try
            {
                return context.Casts.Include(c => c.Project).Where(c=>c.ProjectId == project.Id).ToList();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetCasts error: " + ex.InnerException.Message);
                return null;
            }
        }

        public Task<List<Cast>> GetCastsAsync()
        {
            try
            {
                return context.Casts.Include(c => c.Project).ToListAsync();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetCastsAsync error: " + ex.InnerException.Message);
                return null;
            }
        }

        public Task<List<Cast>> GetCastsAsync(ScienceProject project)
        {
            try
            {
                return context.Casts.Include(c => c.Project).Where(c => c.ProjectId == project.Id).ToListAsync();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetCastsAsync error: " + ex.InnerException.Message);
                return null;
            }
        }

        public Cast Save(Cast cast)
        {
            try
            {
                var saved = context.Casts.SingleOrDefault(c => c.Id == cast.Id);
                if (saved != null)
                {
                    saved.Degree = cast.Degree;
                    saved.Fullname = cast.Fullname;
                    saved.Post = cast.Post;
                    saved.IsManager = cast.IsManager;
                    saved.Status = cast.Status;
                    saved.ProjectId = cast.ProjectId;
                }
                else
                {
                    saved = context.Casts.Add(cast);
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

        public async Task<Cast> SaveAsync(Cast cast)
        {
            try
            {
                var saved = await context.Casts.SingleOrDefaultAsync(c => c.Id == cast.Id);
                if (saved != null)
                {
                    saved.Degree = cast.Degree;
                    saved.Fullname = cast.Fullname;
                    saved.Post = cast.Post;
                    saved.IsManager = cast.IsManager;
                    saved.Status = cast.Status;
                    saved.ProjectId = cast.ProjectId;
                }
                else
                {
                    saved = context.Casts.Add(cast);
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
