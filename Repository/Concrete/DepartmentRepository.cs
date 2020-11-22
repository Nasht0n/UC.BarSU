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
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly UCContext context;

        public DepartmentRepository(UCContext context)
        {
            this.context = context;
        }

        public void Delete(Department department)
        {
            try
            {
                var deleted = context.Departments.SingleOrDefault(d => d.Id == department.Id);
                if (deleted != null)
                {
                    context.Departments.Remove(deleted);
                    context.SaveChanges();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Delete error: " + ex.InnerException.Message);
            }
        }

        public async Task DeleteAsync(Department department)
        {
            try
            {
                var deleted = await context.Departments.SingleOrDefaultAsync(d => d.Id == department.Id);
                if (deleted != null)
                {
                    context.Departments.Remove(deleted);
                    await context.SaveChangesAsync();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Delete error: " + ex.InnerException.Message);
            }
        }

        public Department GetDepartment(int id)
        {
            try
            {
                return context.Departments.Include(d=>d.Faculty).SingleOrDefault(d => d.Id == id);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetDepartment error: " + ex.InnerException.Message);
                return null;
            }
        }

        public async Task<Department> GetDepartmentAsync(int id)
        {
            try
            {
                return await context.Departments.Include(d => d.Faculty).SingleOrDefaultAsync(d => d.Id == id);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetDepartmentAsync error: " + ex.InnerException.Message);
                return null;
            }
        }

        public List<Department> GetDepartments()
        {
            try
            {
                return context.Departments.Include(d => d.Faculty).ToList();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetDepartments error: " + ex.InnerException.Message);
                return null;
            }
        }

        public List<Department> GetDepartments(Faculty faculty)
        {
            try
            {
                return context.Departments.Include(d => d.Faculty).Where(d=>d.FacultyId == faculty.Id).ToList();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetDepartments error: " + ex.InnerException.Message);
                return null;
            }
        }

        public Task<List<Department>> GetDepartmentsAsync()
        {
            try
            {
                return context.Departments.Include(d => d.Faculty).ToListAsync();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetDepartmentsAsync error: " + ex.InnerException.Message);
                return null;
            }
        }

        public async Task<List<Department>> GetDepartmentsAsync(Faculty faculty)
        {
            try
            {
                return await context.Departments.Include(d => d.Faculty).Where(d => d.FacultyId == faculty.Id).ToListAsync();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetDepartmentsAsync error: " + ex.InnerException.Message);
                return null;
            }
        }

        public Department Save(Department department)
        {
            try
            {
                var saved = context.Departments.SingleOrDefault(d => d.Id == department.Id);
                if (saved != null)
                {
                    saved.FacultyId = department.FacultyId;
                    saved.Fullname = department.Fullname;
                    saved.Shortname = department.Shortname;
                }
                else
                {
                    saved = context.Departments.Add(department);
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

        public async Task<Department> SaveAsync(Department department)
        {
            try
            {
                var saved = await context.Departments.SingleOrDefaultAsync(d => d.Id == department.Id);
                if (saved != null)
                {
                    saved.FacultyId = department.FacultyId;
                    saved.Fullname = department.Fullname;
                    saved.Shortname = department.Shortname;
                }
                else
                {
                    saved = context.Departments.Add(department);
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
