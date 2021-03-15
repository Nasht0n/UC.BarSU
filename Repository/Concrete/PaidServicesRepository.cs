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
    public class PaidServicesRepository : IPaidServicesRepository
    {
        private readonly UCContext context;

        public PaidServicesRepository(UCContext context)
        {
            this.context = context;
        }

        public void Delete(PaidServices paidService)
        {
            try
            {
                var deleted = context.PaidServices.SingleOrDefault(p => p.Id == paidService.Id);
                if (deleted != null)
                {
                    context.PaidServices.Remove(paidService);
                    context.SaveChanges();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Delete error: " + ex.InnerException.Message);
            }
        }

        public async Task DeleteAsync(PaidServices paidService)
        {
            try
            {
                var deleted = await context.PaidServices.SingleOrDefaultAsync(p => p.Id == paidService.Id);
                if (deleted != null)
                {
                    context.PaidServices.Remove(paidService);
                    await context.SaveChangesAsync();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Delete error: " + ex.InnerException.Message);
            }
        }

        public PaidServices GetPaidService(int id)
        {
            try
            {
                return context.PaidServices
                    .Include(ps=>ps.User)
                    .SingleOrDefault(p => p.Id == id);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetPaidService error: " + ex.InnerException.Message);
                return null;
            }
        }

        public async Task<PaidServices> GetPaidServiceAsync(int id)
        {
            try
            {
                return await context.PaidServices
                    .Include(ps => ps.User)
                    .SingleOrDefaultAsync(p => p.Id == id);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetPaidServiceAsync error: " + ex.InnerException.Message);
                return null;
            }
        }

        public List<PaidServices> GetPaidServices()
        {
            try
            {
                return context.PaidServices.Include(ps => ps.User).ToList();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetPaidServices error: " + ex.InnerException.Message);
                return null;
            }
        }

        public List<PaidServices> GetPaidServices(AppUser user)
        {
            try
            {
                return context.PaidServices.Include(ps => ps.User).Where(ps=>ps.UserId == user.Id).ToList();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetPaidServices error: " + ex.InnerException.Message);
                return null;
            }
        }

        public async Task<List<PaidServices>> GetPaidServicesAsync()
        {
            try
            {
                return await context.PaidServices.Include(ps => ps.User).ToListAsync();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetPaidServicesAsync error: " + ex.InnerException.Message);
                return null;
            }
        }

        public async Task<List<PaidServices>> GetPaidServicesAsync(AppUser user)
        {
            try
            {
                return await context.PaidServices.Include(ps => ps.User).Where(ps => ps.UserId == user.Id).ToListAsync();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetPaidServices error: " + ex.InnerException.Message);
                return null;
            }
        }

        public PaidServices Save(PaidServices paidService)
        {
            try
            {
                var saved = context.PaidServices.SingleOrDefault(p => p.Id == paidService.Id);
                if (saved != null)
                {                    
                    saved.Address = paidService.Address;
                    saved.Degree = paidService.Degree;
                    saved.Fullname = paidService.Fullname;
                    saved.Name = paidService.Name;
                    saved.OrderDate = paidService.OrderDate;
                    saved.OrderNumber = paidService.OrderNumber;
                    saved.PeriodOfExecution = paidService.PeriodOfExecution;
                    saved.Post = paidService.Post;
                    saved.ServiceName = paidService.ServiceName;
                    saved.Status = paidService.Status;
                    saved.TotalCost = paidService.TotalCost;
                }
                else
                {
                    saved = context.PaidServices.Add(paidService);
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

        public async Task<PaidServices> SaveAsync(PaidServices paidService)
        {
            try
            {
                var saved = await context.PaidServices.SingleOrDefaultAsync(p => p.Id == paidService.Id);
                if (saved != null)
                {
                    saved.Address = paidService.Address;
                    saved.Degree = paidService.Degree;
                    saved.Fullname = paidService.Fullname;
                    saved.Name = paidService.Name;
                    saved.OrderDate = paidService.OrderDate;
                    saved.OrderNumber = paidService.OrderNumber;
                    saved.PeriodOfExecution = paidService.PeriodOfExecution;
                    saved.Post = paidService.Post;
                    saved.ServiceName = paidService.ServiceName;
                    saved.Status = paidService.Status;
                    saved.TotalCost = paidService.TotalCost;
                }
                else
                {
                    saved = context.PaidServices.Add(paidService);
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
