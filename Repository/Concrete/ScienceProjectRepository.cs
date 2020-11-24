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
    public class ScienceProjectRepository : IScienceProjectRepository
    {
        private readonly UCContext context;

        public ScienceProjectRepository(UCContext context)
        {
            this.context = context;
        }

        public void Delete(ScienceProject project)
        {
            try
            {
                var deleted = context.ScienceProjects.SingleOrDefault(p=>p.Id == project.Id);
                if (deleted != null)
                {
                    context.ScienceProjects.Remove(project);
                    context.SaveChanges();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Delete error: "+ex.InnerException.Message);
            }
        }

        public async Task DeleteAsync(ScienceProject project)
        {
            try
            {
                var deleted = await context.ScienceProjects.SingleOrDefaultAsync(p => p.Id == project.Id);
                if (deleted != null)
                {
                    context.ScienceProjects.Remove(project);
                    await context.SaveChangesAsync();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("DeleteAsync error: " + ex.InnerException.Message);
            }
        }

        public ScienceProject GetProject(int id)
        {
            try
            {
                return context.ScienceProjects
                    .Include(p=>p.Department)
                    .Include(p=>p.Department.Faculty)
                    .Include(p=>p.ProjectState)
                    .Include(p=>p.User)
                    .SingleOrDefault(p => p.Id == id);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetProject error: "+ex.InnerException.Message);
                return null;
            }
        }

        public async Task<ScienceProject> GetProjectAsync(int id)
        {
            try
            {
                return await context.ScienceProjects
                    .Include(p => p.Department)
                    .Include(p => p.Department.Faculty)
                    .Include(p => p.ProjectState)
                    .Include(p => p.User)
                    .SingleOrDefaultAsync(p => p.Id == id);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetProjectAsync error: " + ex.InnerException.Message);
                return null;
            }
        }

        public List<ScienceProject> GetProjects()
        {
            try
            {
                return context.ScienceProjects
                    .Include(p => p.Department)
                    .Include(p => p.Department.Faculty)
                    .Include(p => p.ProjectState)
                    .Include(p => p.User)
                    .ToList();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetProjects error: " + ex.InnerException.Message);
                return null;
            }
        }

        public List<ScienceProject> GetProjects(ProjectState state)
        {
            try
            {
                return context.ScienceProjects
                    .Include(p => p.Department)
                    .Include(p => p.Department.Faculty)
                    .Include(p => p.ProjectState)
                    .Include(p => p.User)
                    .Where(p=>p.StateId == state.Id).ToList();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetProjects by state error: " + ex.InnerException.Message);
                return null;
            }
        }

        public List<ScienceProject> GetProjects(Department department)
        {
            try
            {
                return context.ScienceProjects
                    .Include(p => p.Department)
                    .Include(p => p.Department.Faculty)
                    .Include(p => p.ProjectState)
                    .Include(p => p.User)
                    .Where(p => p.DepartmentId == department.Id).ToList();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetProjects by department error: " + ex.InnerException.Message);
                return null;
            }
        }

        public List<ScienceProject> GetProjects(DateTime start, DateTime end)
        {
            try
            {
                return context.ScienceProjects
                    .Include(p => p.Department)
                    .Include(p => p.Department.Faculty)
                    .Include(p => p.ProjectState)
                    .Include(p => p.User)
                    .Where(p => p.StartDate >= start && p.EndDate<=end).ToList();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetProjects between date error: " + ex.InnerException.Message);
                return null;
            }
        }

        public List<ScienceProject> GetProjects(AppUser user)
        {
            try
            {
                return context.ScienceProjects
                    .Include(p => p.Department)
                    .Include(p => p.Department.Faculty)
                    .Include(p => p.ProjectState)
                    .Include(p => p.User)
                    .Where(p => p.UserId == user.Id).ToList();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetProjects by user error: " + ex.InnerException.Message);
                return null;
            }
        }

        public async Task<List<ScienceProject>> GetProjectsAsync()
        {
            try
            {
                return await context.ScienceProjects
                    .Include(p => p.Department)
                    .Include(p => p.Department.Faculty)
                    .Include(p => p.ProjectState)
                    .Include(p => p.User)
                    .ToListAsync();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetProjects error: " + ex.InnerException.Message);
                return null;
            }
        }

        public async Task<List<ScienceProject>> GetProjectsAsync(ProjectState state)
        {
            try
            {
                return await context.ScienceProjects
                    .Include(p => p.Department)
                    .Include(p => p.Department.Faculty)
                    .Include(p => p.ProjectState)
                    .Include(p => p.User)
                    .Where(p => p.StateId == state.Id).ToListAsync();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetProjects by state error: " + ex.InnerException.Message);
                return null;
            }
        }

        public async Task<List<ScienceProject>> GetProjectsAsync(Department department)
        {
            try
            {
                return await context.ScienceProjects
                    .Include(p => p.Department)
                    .Include(p => p.Department.Faculty)
                    .Include(p => p.ProjectState)
                    .Include(p => p.User)
                    .Where(p => p.DepartmentId == department.Id).ToListAsync();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetProjects by department error: " + ex.InnerException.Message);
                return null;
            }
        }

        public async Task<List<ScienceProject>> GetProjectsAsync(DateTime start, DateTime end)
        {
            try
            {
                return await context.ScienceProjects
                    .Include(p => p.Department)
                    .Include(p => p.Department.Faculty)
                    .Include(p => p.ProjectState)
                    .Include(p => p.User)
                    .Where(p => p.StartDate >= start && p.EndDate <= end).ToListAsync();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetProjects between date error: " + ex.InnerException.Message);
                return null;
            }
        }

        public async Task<List<ScienceProject>> GetProjectsAsync(AppUser user)
        {
            try
            {
                return await context.ScienceProjects
                    .Include(p => p.Department)
                    .Include(p => p.Department.Faculty)
                    .Include(p => p.ProjectState)
                    .Include(p => p.User)
                    .Where(p => p.UserId == user.Id).ToListAsync();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetProjectsAsync by user error: " + ex.InnerException.Message);
                return null;
            }
        }

        public ScienceProject Save(ScienceProject project)
        {
            try
            {
                var saved = context.ScienceProjects.SingleOrDefault(p=>p.Id == project.Id);
                if (saved != null)
                {
                    saved.DepartmentId = project.DepartmentId;
                    saved.StateId = project.StateId;
                    saved.UserId = project.UserId;
                    saved.Name = project.Name;
                    saved.Program = project.Program;
                    saved.OrderNumber = project.OrderNumber;
                    saved.OrderDate = project.OrderDate;
                    saved.RegistrationNumber = project.RegistrationNumber;
                    saved.RegistrationDate = project.RegistrationDate;
                    saved.Price = project.Price;
                    saved.StartDate = project.StartDate;
                    saved.EndDate = project.EndDate;
                }
                else
                {
                    saved = context.ScienceProjects.Add(project);
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

        public async Task<ScienceProject> SaveAsync(ScienceProject project)
        {
            try
            {
                var saved = await context.ScienceProjects.SingleOrDefaultAsync(p => p.Id == project.Id);
                if (saved != null)
                {
                    saved.DepartmentId = project.DepartmentId;
                    saved.StateId = project.StateId;
                    saved.UserId = project.UserId;
                    saved.Name = project.Name;
                    saved.Program = project.Program;
                    saved.OrderNumber = project.OrderNumber;
                    saved.OrderDate = project.OrderDate;
                    saved.RegistrationNumber = project.RegistrationNumber;
                    saved.RegistrationDate = project.RegistrationDate;
                    saved.Price = project.Price;
                    saved.StartDate = project.StartDate;
                    saved.EndDate = project.EndDate;
                }
                else
                {
                    saved = context.ScienceProjects.Add(project);
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
