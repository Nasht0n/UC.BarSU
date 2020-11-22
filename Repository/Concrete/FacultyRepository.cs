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
    public class FacultyRepository : IFacultyRepository
    {
        private readonly UCContext context;

        public FacultyRepository(UCContext context)
        {
            this.context = context;
        }

        public void Delete(Faculty faculty)
        {
            try
            {
                var deleted = context.Faculties.SingleOrDefault(d => d.Id == faculty.Id);
                if (deleted != null)
                {
                    context.Faculties.Remove(deleted);
                    context.SaveChanges();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Delete error: " + ex.InnerException.Message);
            }
        }

        public async Task DeleteAsync(Faculty faculty)
        {
            try
            {
                var deleted = await context.Faculties.SingleOrDefaultAsync(d => d.Id == faculty.Id);
                if (deleted != null)
                {
                    context.Faculties.Remove(deleted);
                    await context.SaveChangesAsync();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Delete error: " + ex.InnerException.Message);
            }
        }

        public List<Faculty> GetFaculties()
        {
            try
            {
                return context.Faculties.ToList();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetFaculties error: " + ex.InnerException.Message);
                return null;
            }
        }

        public async Task<List<Faculty>> GetFacultiesAsync()
        {
            try
            {
                return await context.Faculties.ToListAsync();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetFacultiesAsync error: " + ex.InnerException.Message);
                return null;
            }
        }

        public Faculty GetFaculty(int id)
        {
            try
            {
                return context.Faculties.SingleOrDefault(f => f.Id == id);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetFaculty error: " + ex.InnerException.Message);
                return null;
            }
        }

        public async Task<Faculty> GetFacultyAsync(int id)
        {
            try
            {
                return await context.Faculties.SingleOrDefaultAsync(f => f.Id == id);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetFacultyAsync error: " + ex.InnerException.Message);
                return null;
            }
        }

        public Faculty Save(Faculty faculty)
        {
            try
            {
                var saved = context.Faculties.SingleOrDefault(f => f.Id == faculty.Id);
                if (saved != null)
                {
                    saved.Fullname = faculty.Fullname;
                    saved.Shortname = faculty.Shortname;
                }
                else
                {
                    saved = context.Faculties.Add(faculty);
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

        public async Task<Faculty> SaveAsync(Faculty faculty)
        {
            try
            {
                var saved = await context.Faculties.SingleOrDefaultAsync(f => f.Id == faculty.Id);
                if (saved != null)
                {
                    saved.Fullname = faculty.Fullname;
                    saved.Shortname = faculty.Shortname;
                }
                else
                {
                    saved = context.Faculties.Add(faculty);
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
