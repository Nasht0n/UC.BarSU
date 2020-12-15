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
    public class BankYouthRepository : IBankYouthRepository
    {
        private readonly UCContext context;

        public BankYouthRepository(UCContext context)
        {
            this.context = context;
        }

        public void Delete(BankYouth youth)
        {
            try
            {
                var deleted = context.BankYouths.SingleOrDefault(by => by.Id == youth.Id);
                if (deleted != null)
                {
                    context.BankYouths.Remove(deleted);
                    context.SaveChanges();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Delete error: " + ex.InnerException.Message);
            }
        }

        public async Task DeleteAsync(BankYouth youth)
        {
            try
            {
                var deleted = await context.BankYouths.SingleOrDefaultAsync(by => by.Id == youth.Id);
                if (deleted != null)
                {
                    context.BankYouths.Remove(deleted);
                    await context.SaveChangesAsync();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Delete error: " + ex.InnerException.Message);
            }
        }

        public BankYouth GetBankYouth(int id)
        {
            try
            {
                return context.BankYouths
                              .Include(by => by.Awards)
                              .Include(by => by.Documentations)
                              .Include(by => by.Publications)
                              .SingleOrDefault(by => by.Id == id);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetBankYouth error: " + ex.InnerException.Message);
                return null;
            }
        }

        public async Task<BankYouth> GetBankYouthAsync(int id)
        {
            try
            {
                return await context.BankYouths
                                    .Include(by => by.Awards)
                                    .Include(by => by.Documentations)
                                    .Include(by => by.Publications)
                                    .SingleOrDefaultAsync(by => by.Id == id);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetBankYouthAsync error: " + ex.InnerException.Message);
                return null;
            }
        }

        public List<BankYouth> GetBankYouths()
        {
            try
            {
                return context.BankYouths
                              .Include(by => by.Awards)
                              .Include(by => by.Documentations)
                              .Include(by => by.Publications)
                              .ToList();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetBankYouths error: " + ex.InnerException.Message);
                return null;
            }
        }

        public List<BankYouth> GetBankYouths(AppUser user)
        {
            try
            {
                return context.BankYouths
                              .Include(by => by.Awards)
                              .Include(by => by.Documentations)
                              .Include(by => by.Publications)
                              .Where(by=>by.UserId == user.Id)
                              .ToList();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetBankYouths error: " + ex.InnerException.Message);
                return null;
            }
        }

        public async Task<List<BankYouth>> GetBankYouthsAsync()
        {
            try
            {
                return await context.BankYouths
                              .Include(by => by.Awards)
                              .Include(by => by.Documentations)
                              .Include(by => by.Publications)
                              .ToListAsync();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetBankYouthsAsync error: " + ex.InnerException.Message);
                return null;
            }
        }

        public async Task<List<BankYouth>> GetBankYouthsAsync(AppUser user)
        {
            try
            {
                return await context.BankYouths
                              .Include(by => by.Awards)
                              .Include(by => by.Documentations)
                              .Include(by => by.Publications)
                              .Where(by => by.UserId == user.Id)
                              .ToListAsync();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("GetBankYouthsAsync error: " + ex.InnerException.Message);
                return null;
            }
        }

        public BankYouth Save(BankYouth youth)
        {
            try
            {
                var saved = context.BankYouths.SingleOrDefault(by => by.Id == youth.Id);
                if (saved != null)
                {
                    saved.AcademicDegree = youth.AcademicDegree;
                    saved.AcademicStatus = youth.AcademicStatus;
                    saved.Area = youth.Area;
                    saved.AverageBall = youth.AverageBall;
                    saved.DateOfBirthday = youth.DateOfBirthday;
                    saved.District = youth.District;
                    saved.Email = youth.Email;
                    saved.Firstname = youth.Firstname;
                    saved.Fullname = youth.Fullname;
                    saved.Incentives = youth.Incentives;
                    saved.IsExcellentStudent = youth.IsExcellentStudent;
                    saved.Merit = youth.Merit;
                    saved.MobilePhone = youth.MobilePhone;
                    saved.Patronymic = youth.Patronymic;
                    saved.Post = youth.Post;
                    saved.ProtocolDate = youth.ProtocolDate;
                    saved.ProtocolNumber = youth.ProtocolNumber;
                    saved.Qualification = youth.Qualification;
                    saved.Settlement = youth.Settlement;
                    saved.Speciality = youth.Speciality;
                    saved.Surname = youth.Surname;
                    saved.UserId = youth.UserId;
                    saved.YearOfAddmission = youth.YearOfAddmission;
                    saved.YearOfInclusion = youth.YearOfInclusion;
                    saved.CreateDate = youth.CreateDate;
                    saved.EditDate = youth.EditDate;
                }
                else
                {
                    saved = context.BankYouths.Add(youth);
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

        public async Task<BankYouth> SaveAsync(BankYouth youth)
        {
            try
            {
                var saved = await context.BankYouths.SingleOrDefaultAsync(by => by.Id == youth.Id);
                if (saved != null)
                {
                    saved.AcademicDegree = youth.AcademicDegree;
                    saved.AcademicStatus = youth.AcademicStatus;
                    saved.Area = youth.Area;
                    saved.AverageBall = youth.AverageBall;
                    saved.DateOfBirthday = youth.DateOfBirthday;
                    saved.District = youth.District;
                    saved.Email = youth.Email;
                    saved.Firstname = youth.Firstname;
                    saved.Fullname = youth.Fullname;
                    saved.Incentives = youth.Incentives;
                    saved.IsExcellentStudent = youth.IsExcellentStudent;
                    saved.Merit = youth.Merit;
                    saved.MobilePhone = youth.MobilePhone;
                    saved.Patronymic = youth.Patronymic;
                    saved.Post = youth.Post;
                    saved.ProtocolDate = youth.ProtocolDate;
                    saved.ProtocolNumber = youth.ProtocolNumber;
                    saved.Qualification = youth.Qualification;
                    saved.Settlement = youth.Settlement;
                    saved.Speciality = youth.Speciality;
                    saved.Surname = youth.Surname;
                    saved.UserId = youth.UserId;
                    saved.YearOfAddmission = youth.YearOfAddmission;
                    saved.YearOfInclusion = youth.YearOfInclusion;
                    saved.CreateDate = youth.CreateDate;
                    saved.EditDate = youth.EditDate;
                }
                else
                {
                    saved = context.BankYouths.Add(youth);
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
