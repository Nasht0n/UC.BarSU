using Common.Entities;
using Microsoft.Owin.Security;
using Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Web.Data;
using Web.Models.Enum;
using Web.ViewModels;
using ProjectState = Web.Models.Enum.ProjectState;

namespace Web.Controllers
{
    [Authorize]
    public class SPController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly IUserPermissionsRepository userPermissionsRepository;
        private readonly IFacultyRepository facultyRepository;
        private readonly IDepartmentRepository departmentRepository;
        private readonly IScienceProjectRepository projectRepository;
        private readonly IStageRepository stageRepository;
        private readonly IScienceProjectReportRepository reportRepository;
        private readonly IStageTypeRepository stageTypeRepository;
        private readonly SelectListHelper helper;

        private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;

        public SPController(IUserRepository userRepository, IUserPermissionsRepository userPermissionsRepository, IFacultyRepository facultyRepository,
                            IDepartmentRepository departmentRepository, IScienceProjectRepository projectRepository, IStageRepository stageRepository,
                            IScienceProjectReportRepository reportRepository, IStageTypeRepository stageTypeRepository)
        {
            this.userRepository = userRepository;
            this.userPermissionsRepository = userPermissionsRepository;
            this.facultyRepository = facultyRepository;
            this.departmentRepository = departmentRepository;
            this.projectRepository = projectRepository;
            this.stageRepository = stageRepository;
            this.reportRepository = reportRepository;
            this.stageTypeRepository = stageTypeRepository;
            helper = new SelectListHelper();
        }

        public ActionResult Index()
        {
            AppUser user = GetUserInfo();
            SetViewBags(user);                       
            ScienceProjectListViewModel model = new ScienceProjectListViewModel();
            List<ScienceProject> scienceProjects = GetProjectList(user);
            model.ScienceProjects = DataConverter.ScienceProjectModel.GetScienceProjects(scienceProjects);
            return View(model);
        }

        private List<ScienceProject> GetProjectList(AppUser user)
        {
            List<ScienceProject> result = new List<ScienceProject>();
            var permissions = userPermissionsRepository.GetUserPermissions(user);            
            var all = permissions.Any(p => p.PermissionId == (int)PermissionType.SP_PROJECTLISTVIEW_ALL);
            if (all) result = projectRepository.GetProjects();
            else result = projectRepository.GetProjects(user);
            return result;
        }

        public ActionResult Details(int id)
        {
            AppUser user = GetUserInfo();
            SetViewBags(user);
            
            SPDetailsViewModel model = new SPDetailsViewModel();
            model.Project = projectRepository.GetProject(id);
            model.Stages = stageRepository.GetStages(model.Project);
            model.Reports = reportRepository.GetReports(model.Project);
            model.User = user;
            model.StageTypes = helper.GetStageTypes(stageTypeRepository);

            return View(model);
        }

        public ActionResult Create()
        {
            AppUser user = GetUserInfo();
            SetViewBags(user);
            ScienceProjectViewModel model = new ScienceProjectViewModel() { OrderDate = DateTime.Now, RegistrationDate = DateTime.Now, StartDate = DateTime.Now, EndDate=DateTime.Now };
            InitSelectList(model);
            return View(model);
        }

        public JsonResult AddScienceProject(ScienceProjectViewModel model)
        {
            var user = GetUserInfo();
            model.UserId = user.Id;
            model.StateId = (int)ProjectState.JustCreated;
            var project = ModelConverter.ScienceProjectModel.GetScienceProject(model);
            projectRepository.Save(project);
            return Json("OK", JsonRequestBehavior.AllowGet);
        }

        private void InitSelectList(ScienceProjectViewModel model)
        {
            model.Faculties = helper.GetFaculties(facultyRepository);
            model.Departments = helper.GetDepartments();
        }

        [HttpGet]
        public ActionResult GetDepartments(string faculty)
        {            
            IEnumerable<SelectListItem> departments = helper.GetDepartments(faculty, departmentRepository);
            return Json(departments, JsonRequestBehavior.AllowGet);
        }

        private void SetViewBags(AppUser user)
        {
            InitializeNavMenuViewBags(user);
        }
        private void InitializeNavMenuViewBags(AppUser user)
        {
            List<AppUserPermissions> userPermissions = userPermissionsRepository.GetUserPermissions(user);
            foreach (var permission in userPermissions)
            {
                switch (permission.PermissionId)
                {
                    case (int)PermissionType.SP_ACCESS:
                        {
                            ViewBag.SP_ACCESS = true;
                            break;
                        }
                    case (int)PermissionType.IA_ACCESS:
                        {
                            ViewBag.IA_ACCESS = true;
                            break;
                        }
                    case (int)PermissionType.BY_ACCESS:
                        {
                            ViewBag.BY_ACCESS = true;
                            break;
                        }
                }
            }
        }
        private AppUser GetUserInfo()
        {
            int userId = User.Identity.GetUserId<int>();
            return userRepository.GetUser(userId);
        }
    }
}