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
    public class StageTypeRepository : IStageTypeRepository
    {
        private readonly UCContext context;

        public StageTypeRepository(UCContext context)
        {
            this.context = context;
        }

        public void Delete(StageType type)
        {
            try
            {
                var deleted = context.StageTypes.SingleOrDefault(t=>t.Id == type.Id);
                if (deleted != null)
                {
                    context.StageTypes.Remove(type);
                    context.SaveChanges();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Delete error: "+ex.InnerException.Message);
            }
        }

        public async Task DeleteAsync(StageType type)
        {
            try
            {
                var deleted = await context.StageTypes.SingleOrDefaultAsync(t => t.Id == type.Id);
                if (deleted != null)
                {
                    context.StageTypes.Remove(type);
                    await context.SaveChangesAsync();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Delete error: " + ex.InnerException.Message);
            }
        }

        public StageType GetStageType(int id)
        {
            try
            {
                return context.StageTypes.SingleOrDefault(t => t.Id == id);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetStageType error: "+ex.InnerException.Message);
                return null;
            }
        }

        public async Task<StageType> GetStageTypeAsync(int id)
        {
            try
            {
                return await context.StageTypes.SingleOrDefaultAsync(t => t.Id == id);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetStageTypeAsync error: " + ex.InnerException.Message);
                return null;
            }
        }

        public List<StageType> GetStageTypes()
        {
            try
            {
                return context.StageTypes.ToList();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetStageTypes error: " + ex.InnerException.Message);
                return null;
            }
        }

        public async Task<List<StageType>> GetStageTypesAsync()
        {
            try
            {
                return await context.StageTypes.ToListAsync();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetStageTypesAsync error: " + ex.InnerException.Message);
                return null;
            }
        }

        public StageType Save(StageType type)
        {
            try
            {
                var saved = context.StageTypes.SingleOrDefault(t=>t.Id == type.Id);
                if(saved != null)
                {
                    saved.Name = type.Name;
                }
                else
                {
                    saved = context.StageTypes.Add(type);
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

        public async Task<StageType> SaveAsync(StageType type)
        {
            try
            {
                var saved = await context.StageTypes.SingleOrDefaultAsync(t => t.Id == type.Id);
                if (saved != null)
                {
                    saved.Name = type.Name;
                }
                else
                {
                    saved = context.StageTypes.Add(type);
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
