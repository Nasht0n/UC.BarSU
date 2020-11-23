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
    public class StageRepository : IStageRepository
    {
        private readonly UCContext context;

        public StageRepository(UCContext context)
        {
            this.context = context;
        }

        public void Delete(Stage stage)
        {
            try
            {
                var deleted = context.Stages.SingleOrDefault(s=>s.Id == stage.Id);
                if (deleted != null)
                {
                    context.Stages.Remove(stage);
                    context.SaveChanges();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Delete error: "+ex.InnerException.Message);
            }
        }

        public async Task DeleteAsync(Stage stage)
        {
            try
            {
                var deleted = await context.Stages.SingleOrDefaultAsync(s => s.Id == stage.Id);
                if (deleted != null)
                {
                    context.Stages.Remove(stage);
                    await context.SaveChangesAsync();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("DeleteAsync error: " + ex.InnerException.Message);
            }
        }

        public Stage GetStage(int id)
        {
            try
            {
                return context.Stages
                    .Include(s=>s.Project)
                    .Include(s=>s.StageType)
                    .SingleOrDefault(s=> s.Id == id);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetStage error: "+ex.InnerException.Message);
                return null;
            }
        }

        public async Task<Stage> GetStageAsync(int id)
        {
            try
            {
                return await context.Stages
                    .Include(s => s.Project)
                    .Include(s => s.StageType)
                    .SingleOrDefaultAsync(s => s.Id == id);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetStageAsync error: "+ex.InnerException.Message);
                return null;
            }
        }

        public List<Stage> GetStages(ScienceProject project)
        {
            try
            {
                return context.Stages
                    .Include(s => s.Project)
                    .Include(s => s.StageType)
                    .Where(s => s.ProjectId == project.Id).ToList();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetStage error: " + ex.InnerException.Message);
                return null;
            }
        }

        public async Task<List<Stage>> GetStagesAsync(ScienceProject project)
        {
            try
            {
                return await context.Stages
                    .Include(s => s.Project)
                    .Include(s => s.StageType)
                    .Where(s => s.ProjectId == project.Id).ToListAsync();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetStagesAsync error: " + ex.InnerException.Message);
                return null;
            }
        }

        public Stage Save(Stage stage)
        {
            try
            {
                var saved = context.Stages.SingleOrDefault(s => s.ProjectId == stage.ProjectId && s.StageTypeId == stage.StageTypeId);
                if (saved != null)
                {
                    saved.ProjectId = stage.ProjectId;
                    saved.StageTypeId = stage.StageTypeId;
                }
                else
                {
                    saved = context.Stages.Add(stage);
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

        public async Task<Stage> SaveAsync(Stage stage)
        {
            try
            {
                var saved = await context.Stages.SingleOrDefaultAsync(s => s.ProjectId == stage.ProjectId && s.StageTypeId == stage.StageTypeId);
                if (saved != null)
                {
                    saved.ProjectId = stage.ProjectId;
                    saved.StageTypeId = stage.StageTypeId;
                }
                else
                {
                    saved = context.Stages.Add(stage);
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
