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
    public class ImplementationStudentActComissionRepository : IImplementationStudentActComissionRepository
    {
        private readonly UCContext context;

        public ImplementationStudentActComissionRepository(UCContext context)
        {
            this.context = context;
        }

        public void Delete(ImplementationStudentActComission comission)
        {
            try
            {
                var deleted = context.StudentActComissions.SingleOrDefault(c => c.Id == comission.Id);
                if (deleted != null)
                {
                    context.StudentActComissions.Remove(deleted);
                    context.SaveChanges();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Delete error: " + ex.InnerException.Message);
            }
        }

        public async Task DeleteAsync(ImplementationStudentActComission comission)
        {
            try
            {
                var deleted = await context.StudentActComissions.SingleOrDefaultAsync(c => c.Id == comission.Id);
                if (deleted != null)
                {
                    context.StudentActComissions.Remove(comission);
                    await context.SaveChangesAsync();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("DeleteAsync error: " + ex.InnerException.Message);
            }
        }

        public ImplementationStudentActComission GetComission(int id)
        {
            try
            {
                return context.StudentActComissions.Include(c => c.Act).SingleOrDefault(c=>c.Id == id);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetComission error: "+ex.InnerException.Message);
                return null;
            }
        }

        public async Task<ImplementationStudentActComission> GetComissionAsync(int id)
        {
            try
            {
                return await context.StudentActComissions.Include(c => c.Act).SingleOrDefaultAsync(c => c.Id == id);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetComissionAsync error: " + ex.InnerException.Message);
                return null;
            }
        }

        public List<ImplementationStudentActComission> GetComissions(ImplementationStudentAct act)
        {
            try
            {
                return context.StudentActComissions.Include(c => c.Act).Where(c=>c.ActId == act.Id).ToList();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetComissions error: "+ex.InnerException.Message);
                return null;
            }
        }

        public async Task<List<ImplementationStudentActComission>> GetComissionsAsync(ImplementationStudentAct act)
        {
            try
            {
                return await context.StudentActComissions
                    .Include(c=>c.Act)
                    .Where(c => c.ActId == act.Id).ToListAsync();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetComissionsAsync error: "+ex.InnerException.Message);
                return null;
            }
        }

        public ImplementationStudentActComission Save(ImplementationStudentActComission comission)
        {
            try
            {
                var saved = context.StudentActComissions.SingleOrDefault(c => c.Id == comission.Id);
                if (saved != null)
                {
                    saved.ActId = comission.ActId;
                    saved.Fullname = comission.Fullname;
                    saved.Post = comission.Post;
                }
                else 
                {
                    saved = context.StudentActComissions.Add(comission);
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

        public async Task<ImplementationStudentActComission> SaveAsync(ImplementationStudentActComission comission)
        {
            try
            {
                var saved = await context.StudentActComissions.SingleOrDefaultAsync(c => c.Id == comission.Id);
                if (saved != null)
                {
                    saved.ActId = comission.ActId;
                    saved.Fullname = comission.Fullname;
                    saved.Post = comission.Post;
                }
                else
                {
                    saved = context.StudentActComissions.Add(comission);
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
