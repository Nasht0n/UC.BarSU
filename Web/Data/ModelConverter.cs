using Web.ViewModels;
using Common.Entities;
using Web.ViewModels.IA.Students;

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
    }
}