using Web.ViewModels;
using Common.Entities;
using Web.ViewModels.IA.Students;
using Web.ViewModels.IA.Research;
using Web.ViewModels.BY;
using System.Linq;

namespace Web.Data
{
    public static class ModelConverter
    {
        public static class FeedbackModel
        {
            public static AppFeedback GetFeedback(FeedbackViewModel model)
            {
                return new AppFeedback { Name = model.Name, Email = model.Email, Title = model.Title, Message = model.Message };
            }
        }

        public static class ScienceProjectModel
        {
            public static ScienceProject GetScienceProject(ScienceProjectViewModel model)
            {
                ScienceProject result = new ScienceProject
                {
                    Id = model.Id,
                    UserId = model.UserId,
                    DepartmentId = model.SelectedDepartment,
                    StateId = model.StateId,
                    Name = model.Name,
                    Program = model.Program,
                    OrderNumber = model.OrderNumber,
                    OrderDate = model.OrderDate,
                    RegistrationNumber = model.RegistrationNumber,
                    RegistrationDate = model.RegistrationDate,
                    Price = model.Price,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate
                };

                if (model.Casts.Count != 0) result.Casts = model.Casts;
                return result;
            }
        }

        public static class ImplementationStudentActModel
        {
            public static ImplementationStudentAct GetAct(IAStudentViewModel model)
            {
                ImplementationStudentAct result = new ImplementationStudentAct
                {
                    Id = model.Id,
                    Author = model.Author,
                    Department = model.Department,
                    EconomicEfficiency = model.EconomicEfficiency,
                    PracticalTasks = model.PracticalTasks,
                    ProjectName = model.ProjectName,
                    ProtocolDate = model.ProtocolDate,
                    ProtocolNumber = model.ProtocolNumber,
                    RegisterDate = model.RegisterDate,
                    Result = model.Result,
                    Scope = model.Scope,
                    UserId = model.UserId                    
                };
                if (model.Commission.Count != 0) result.Comissions = model.Commission;
                return result;
            }
        }

        public static class ImplementationResearchActModel
        {
            public static ImplementationResearchAct GetAct(IAResearchViewModel model)
            {
                ImplementationResearchAct result = new ImplementationResearchAct
                {
                    Id = model.Id,
                    Characteristic = model.Characteristic,
                    FeasibilityOfIntroducing = model.FeasibilityOfIntroducing,
                    HeadUnit = model.HeadUnit,
                    ImplementationForm = model.ImplementationForm,
                    ImplementingResult = model.ImplementingResult,
                    Process = model.Process,
                    UnitUsing = model.UnitUsing,
                    UserId = model.UserId,
                    ProjectName = model.ProjectName
                };
                if (model.Authors.Count != 0) result.Authors = model.Authors;
                if (model.Employees.Count != 0) result.Employees = model.Employees;
                return result;
            }
        }

        public static class BankYouthModel
        {
            public static BankYouth GetBankYouth(BankYouthViewModel model)
            {
                BankYouth result = new BankYouth
                {
                    AcademicDegree = model.AcademicDegree,
                    AcademicStatus = model.AcademicStatus,
                    Area = model.Area,
                    AverageBall = model.AverageBall,
                    DateOfBirthday = model.DateOfBirthday,
                    District = model.District,
                    Email = model.Email,
                    Firstname = model.Firstname,
                    Fullname = model.Fullname,
                    Incentives = model.Incentives,
                    IsExcellentStudent = model.IsExcellentStudent,
                    Merit = model.Merit,
                    MobilePhone = model.MobilePhone,
                    Patronymic = model.Patronymic,
                    ProtocolDate = model.ProtocolDate,
                    ProtocolNumber = model.ProtocolNumber,
                    Post = model.Post,
                    Qualification = model.Qualification,
                    Settlement = model.Settlement,
                    Speciality = model.Speciality,
                    Surname = model.Surname,
                    UserId = model.UserId,
                    YearOfAddmission = model.YearOfAddmission,
                    YearOfInclusion = model.YearOfInclusion
                };
                if (model.Awards.Count != 0) result.Awards = model.Awards.ToList();
                if (model.Documentations.Count != 0) result.Documentations = model.Documentations.ToList();
                if (model.Publications.Count != 0) result.Publications = model.Publications.ToList();
                return result;
            }
        }
    }
}