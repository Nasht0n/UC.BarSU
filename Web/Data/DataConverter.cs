using Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Web.ViewModels;
using Web.ViewModels.BY;
using Web.ViewModels.IA.Research;
using Web.ViewModels.IA.Students;

namespace Web.Data
{
    public static class DataConverter
    {
        public static class ScienceProjectModel
        {
            public static ScienceProjectViewModel GetScienceProject(ScienceProject data)
            {
                ScienceProjectViewModel model = new ScienceProjectViewModel()
                {
                    Id = data.Id,
                    UserId = data.UserId,
                    SelectedDepartment = data.DepartmentId,
                    SelectedFaculty = data.Department.FacultyId,
                    StateId = data.StateId,
                    Name = data.Name,
                    Program = data.Program,
                    OrderNumber = data.OrderNumber,
                    OrderDate = data.OrderDate,
                    RegistrationNumber = data.RegistrationNumber,
                    RegistrationDate = data.RegistrationDate,
                    Price = data.Price,
                    StartDate = data.StartDate,
                    EndDate = data.EndDate,
                    Casts = data.Casts.ToList()
                };
                return model;
            }

            public static List<ScienceProjectViewModel> GetScienceProjects(List<ScienceProject> projects)
            {
                List<ScienceProjectViewModel> list = new List<ScienceProjectViewModel>();
                foreach(var project in projects)
                {
                    var item = GetScienceProject(project);
                    list.Add(item);
                }
                return list;
            }
        }

        public static class StudentActModel
        {
            public static List<IAStudentViewModel> GetActs(List<ImplementationStudentAct> acts)
            {
                List<IAStudentViewModel> list = new List<IAStudentViewModel>();
                foreach (var act in acts)
                {
                    var item = GetAct(act);
                    list.Add(item);
                }
                return list;
            }

            public static IAStudentViewModel GetAct(ImplementationStudentAct act)
            {
                IAStudentViewModel model = new IAStudentViewModel
                {
                    Id = act.Id,
                    Author = act.Author,
                    Department = act.Department,
                    EconomicEfficiency = act.EconomicEfficiency,
                    PracticalTasks = act.PracticalTasks,
                    ProjectName = act.ProjectName,
                    ProtocolDate = act.ProtocolDate,
                    ProtocolNumber = act.ProtocolNumber,
                    RegisterDate = act.RegisterDate,
                    Result = act.Result,
                    Scope = act.Scope,
                    UserId = act.UserId,
                    Commission = act.Comissions.ToList()                    
                };
                return model;
            }
        }

        public static class ResearchActModel
        {
            public static List<IAResearchViewModel> GetActs(List<ImplementationResearchAct> acts)
            {
                List<IAResearchViewModel> list = new List<IAResearchViewModel>();
                foreach (var act in acts)
                {
                    var item = GetAct(act);
                    list.Add(item);
                }
                return list;
            }

            public static IAResearchViewModel GetAct(ImplementationResearchAct act)
            {
                IAResearchViewModel model = new IAResearchViewModel
                {
                    Id = act.Id,
                    Characteristic = act.Characteristic,
                    FeasibilityOfIntroducing = act.FeasibilityOfIntroducing,
                    HeadUnit = act.HeadUnit,
                    ImplementationForm = act.ImplementationForm,
                    ImplementingResult = act.ImplementingResult,
                    Process = act.Process,
                    UserId = act.UserId,
                    UnitUsing = act.UnitUsing,
                    ProjectName = act.ProjectName,
                    Employees = act.Employees,
                    Authors = act.Authors
                };                
                return model;
            }
        }

        public static class BankYouthModel
        {
            public static List<BankYouthViewModel> GetBankYouths(List<BankYouth> bankYouths)
            {
                List<BankYouthViewModel> list = new List<BankYouthViewModel>();
                foreach(var bankYouth in bankYouths)
                {
                    var item = GetBankYouth(bankYouth);
                    list.Add(item);
                }
                return list;
            }

            public static BankYouthViewModel GetBankYouth(BankYouth bankYouth)
            {
                BankYouthViewModel model = new BankYouthViewModel
                {
                    Id = bankYouth.Id,
                    AcademicDegree = bankYouth.AcademicDegree,
                    AcademicStatus = bankYouth.AcademicStatus,
                    Area = bankYouth.Area,
                    AverageBall = bankYouth.AverageBall,
                    DateOfBirthday = bankYouth.DateOfBirthday,
                    District = bankYouth.District,
                    Email = bankYouth.Email,
                    Firstname = bankYouth.Firstname,
                    Fullname = bankYouth.Fullname,
                    Incentives = bankYouth.Incentives,
                    IsExcellentStudent = bankYouth.IsExcellentStudent,
                    Merit = bankYouth.Merit,
                    MobilePhone = bankYouth.MobilePhone,
                    Patronymic = bankYouth.Patronymic,
                    Post = bankYouth.Post,
                    ProtocolDate = bankYouth.ProtocolDate,
                    ProtocolNumber = bankYouth.ProtocolNumber,
                    Qualification = bankYouth.Qualification,
                    Settlement = bankYouth.Settlement,
                    Speciality = bankYouth.Speciality,
                    Surname = bankYouth.Surname,
                    UserId = bankYouth.UserId,
                    YearOfAddmission = bankYouth.YearOfAddmission,
                    YearOfInclusion = bankYouth.YearOfInclusion,
                    CreateDate = bankYouth.CreateDate,
                    EditDate = bankYouth.EditDate
                };
                return model;
            }
        }
    }
}