using Repository.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Web.Data
{
    public class SelectListHelper
    {
        public IEnumerable<SelectListItem> GetFaculties(IFacultyRepository facultyRepository)
        {
            List<SelectListItem> countries = facultyRepository.GetFaculties()
                .OrderBy(n => n.Fullname)
                    .Select(n =>
                    new SelectListItem
                    {
                        Value = n.Id.ToString(),
                        Text = n.Fullname
                    }).ToList();
            var countrytip = new SelectListItem()
            {
                Value = null,
                Text = "--- Выберите факультет ---"
            };
            countries.Insert(0, countrytip);
            return new SelectList(countries, "Value", "Text");
        }

        public IEnumerable<SelectListItem> GetStageTypes(IStageTypeRepository stageTypeRepository)
        {
            List<SelectListItem> types = stageTypeRepository.GetStageTypes().OrderByDescending(t => t.Name)
                .Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.Name
                }).ToList();
            var typeTip = new SelectListItem()
            {
                Value = null,
                Text = "--- Выберите тип этапа ---"
            };
            types.Insert(0, typeTip);
            return new SelectList(types, "Value", "Text");
        }

        public IEnumerable<SelectListItem> GetDepartments()
        {
            List<SelectListItem> regions = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Value = null,
                    Text = "--- Выберите кафедру ---"
                }
            };
            return regions;
        }

        public IEnumerable<SelectListItem> GetDepartments(string faculty, IDepartmentRepository departmentRepository)
        {
            if (!string.IsNullOrWhiteSpace(faculty))
            {
                List<SelectListItem> departments = departmentRepository.GetDepartments()
                    .OrderBy(n => n.Fullname)
                    .Where(n => n.FacultyId.ToString() == faculty)
                    .Select(n =>
                       new SelectListItem
                       {
                           Value = n.Id.ToString(),
                           Text = n.Fullname
                       }).ToList();
                return new SelectList(departments, "Value", "Text");
            }
            return null;
        }
    }
}