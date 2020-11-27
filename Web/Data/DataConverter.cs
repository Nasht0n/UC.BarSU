using Common.Entities;
using System.Collections.Generic;
using System.Linq;
using Web.ViewModels;

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
    }
}