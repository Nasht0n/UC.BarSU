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
    public class ProjectStateRepository : IProjectStateRepository
    {
        private readonly UCContext context;

        public ProjectStateRepository(UCContext context)
        {
            this.context = context;
        }

        public void Delete(ProjectState state)
        {
            try
            {
                var deleted = context.ProjectStates.SingleOrDefault(s=>s.Id == state.Id);
                if (deleted != null)
                {
                    context.ProjectStates.Remove(state);
                    context.SaveChanges();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Delete error: "+ex.InnerException.Message);
            }
        }

        public async Task DeleteAsync(ProjectState state)
        {
            try
            {
                var deleted = await context.ProjectStates.SingleOrDefaultAsync(s => s.Id == state.Id);
                if (deleted != null)
                {
                    context.ProjectStates.Remove(state);
                    await context.SaveChangesAsync();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("DeleteAsync error: " + ex.InnerException.Message);
            }
        }

        public ProjectState GetState(int id)
        {
            try
            {
                return context.ProjectStates.SingleOrDefault(s=>s.Id == id);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetState error: " + ex.InnerException.Message);
                return null;
            }
        }

        public async Task<ProjectState> GetStateAsync(int id)
        {
            try
            {
                return await context.ProjectStates.SingleOrDefaultAsync(s => s.Id == id);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetStateAsync error: " + ex.InnerException.Message);
                return null;
            }
        }

        public List<ProjectState> GetStates()
        {
            try
            {
                return context.ProjectStates.ToList();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetStates error: " + ex.InnerException.Message);
                return null;
            }
        }

        public async Task<List<ProjectState>> GetStatesAsync()
        {
            try
            {
                return await context.ProjectStates.ToListAsync();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetStatesAsync error: " + ex.InnerException.Message);
                return null;
            }
        }

        public ProjectState Save(ProjectState state)
        {
            try
            {
                var saved = context.ProjectStates.SingleOrDefault(s => s.Id == state.Id);
                if(saved != null)
                {
                    saved.Name = state.Name;
                }
                else
                {
                    saved = context.ProjectStates.Add(state);
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

        public async Task<ProjectState> SaveAsync(ProjectState state)
        {
            try
            {
                var saved = await context.ProjectStates.SingleOrDefaultAsync(s => s.Id == state.Id);
                if (saved != null)
                {
                    saved.Name = state.Name;
                }
                else
                {
                    saved = context.ProjectStates.Add(state);
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
