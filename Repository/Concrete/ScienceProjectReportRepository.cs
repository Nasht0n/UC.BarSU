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
    public class ScienceProjectReportRepository : IScienceProjectReportRepository
    {
        private readonly UCContext context;

        public ScienceProjectReportRepository(UCContext context)
        {
            this.context = context;
        }

        public void Delete(ScienceProjectReport report)
        {
            try
            {
                var deleted = context.ScienceProjectReports.SingleOrDefault(r => r.Id == report.Id);
                if (deleted != null)
                {
                    context.ScienceProjectReports.Remove(report);
                    context.SaveChanges();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Delete error: "+ex.InnerException.Message);
            }
        }

        public async Task DeleteAsync(ScienceProjectReport report)
        {
            try
            {
                var deleted = await context.ScienceProjectReports.SingleOrDefaultAsync(r => r.Id == report.Id);
                if (deleted != null)
                {
                    context.ScienceProjectReports.Remove(report);
                    await context.SaveChangesAsync();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Delete error: " + ex.InnerException.Message);
            }
        }

        public ScienceProjectReport GetReport(int id)
        {
            try
            {
                return context.ScienceProjectReports.Include(r => r.Stage).SingleOrDefault(r => r.Id == id);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetReport error: "+ex.InnerException.Message);
                return null;
            }
        }

        public async Task<ScienceProjectReport> GetReportAsync(int id)
        {
            try
            {
                return await context.ScienceProjectReports.Include(r => r.Stage).SingleOrDefaultAsync(r => r.Id == id);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetReportAsync error: " + ex.InnerException.Message);
                return null;
            }
        }

        public List<ScienceProjectReport> GetReports()
        {
            try
            {
                return context.ScienceProjectReports.Include(r => r.Stage).ToList();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetReports error: "+ex.InnerException.Message);
                return null;
            }
        }

        public List<ScienceProjectReport> GetReports(ScienceProject project)
        {
            try
            {
                return context.ScienceProjectReports.Include(r=>r.Stage).Where(r => r.Stage.ProjectId == project.Id).ToList();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetReports by stage error: "+ex.InnerException.Message);
                return null;
            }
        }

        public async Task<List<ScienceProjectReport>> GetReportsAsync()
        {
            try
            {
                return await context.ScienceProjectReports.Include(r => r.Stage).ToListAsync();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetReports error: " + ex.InnerException.Message);
                return null;
            }
        }

        public async Task<List<ScienceProjectReport>> GetReportsAsync(ScienceProject project)
        {
            try
            {
                return await context.ScienceProjectReports.Include(r => r.Stage).Where(r => r.Stage.ProjectId == project.Id).ToListAsync();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetReports by stage error: " + ex.InnerException.Message);
                return null;
            }
        }

        public ScienceProjectReport Save(ScienceProjectReport report)
        {
            try
            {
                var saved = context.ScienceProjectReports.SingleOrDefault(r=>r.Id == report.Id);
                if (saved != null)
                {
                    saved.Filename = report.Filename;
                    saved.Path = report.Path;
                    saved.StageId = report.StageId;
                    saved.UploadDate = report.UploadDate;
                }
                else
                {
                    saved = context.ScienceProjectReports.Add(report);
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

        public async Task<ScienceProjectReport> SaveAsync(ScienceProjectReport report)
        {
            try
            {
                var saved = await context.ScienceProjectReports.SingleOrDefaultAsync(r => r.Id == report.Id);
                if (saved != null)
                {
                    saved.Filename = report.Filename;
                    saved.Path = report.Path;
                    saved.StageId = report.StageId;
                    saved.UploadDate = report.UploadDate;
                }
                else
                {
                    saved = context.ScienceProjectReports.Add(report);
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
