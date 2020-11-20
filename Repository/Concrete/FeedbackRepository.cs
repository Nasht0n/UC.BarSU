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
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly UCContext context;

        public FeedbackRepository(UCContext context)
        {
            this.context = context;
        }

        public void Delete(AppFeedback feedback)
        {
            try
            {
                var deleted = context.Feedbacks.Single(f => f.Id == feedback.Id);
                if(deleted != null)
                {
                    context.Feedbacks.Remove(deleted);
                    context.SaveChanges();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Delete error: "+ex.InnerException.Message);
            }
        }

        public async Task DeleteAsync(AppFeedback feedback)
        {
            try
            {
                var deleted = await context.Feedbacks.SingleAsync(f => f.Id == feedback.Id);
                if (deleted != null)
                {
                    context.Feedbacks.Remove(deleted);
                    await context.SaveChangesAsync();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Delete error: " + ex.InnerException.Message);
            }
        }

        public AppFeedback GetFeedback(int id)
        {
            try
            {
                return context.Feedbacks.Single(f => f.Id == id);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetFeedback error: "+ex.InnerException.Message);
                return null;
            }
        }

        public async Task<AppFeedback> GetFeedbackAsync(int id)
        {
            try
            {
                return await context.Feedbacks.SingleAsync(f => f.Id == id);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetFeedbackAsync error: "+ex.InnerException.Message);
                return null;
            }
        }

        public List<AppFeedback> GetFeedbacks()
        {
            try
            {
                return context.Feedbacks.ToList();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetFeedbacks error: "+ex.InnerException.Message);
                return null;
            }
        }

        public async Task<List<AppFeedback>> GetFeedbacksAsync()
        {
            try
            {
                return await context.Feedbacks.ToListAsync();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetFeedbacksAsync error: "+ex.InnerException.Message);
                return null;
            }
        }

        public AppFeedback Save(AppFeedback feedback)
        {
            try
            {
                var saved = context.Feedbacks.Single(f => f.Id == feedback.Id);
                if (saved != null)
                {
                    saved.Name = feedback.Name;
                    saved.Message = feedback.Message;
                    saved.Title = feedback.Title;
                    saved.Email = feedback.Email;
                }
                else
                {
                    saved = context.Feedbacks.Add(feedback);
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

        public async Task<AppFeedback> SaveAsync(AppFeedback feedback)
        {
            try
            {
                var saved = await context.Feedbacks.SingleAsync(f => f.Id == feedback.Id);
                if (saved != null)
                {
                    saved.Name = feedback.Name;
                    saved.Message = feedback.Message;
                    saved.Title = feedback.Title;
                    saved.Email = feedback.Email;
                }
                else
                {
                    saved = context.Feedbacks.Add(feedback);
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
