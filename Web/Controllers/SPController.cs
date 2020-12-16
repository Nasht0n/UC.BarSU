using Common.Entities;
using Microsoft.Owin.Security;
using Repository.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Data;
using Web.Models.Enum;
using Web.ViewModels;

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
        private readonly ICastRepository castRepository;
        private readonly SelectListHelper helper;

        private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;

        public SPController(IUserRepository userRepository, IUserPermissionsRepository userPermissionsRepository, IFacultyRepository facultyRepository,
                            IDepartmentRepository departmentRepository, IScienceProjectRepository projectRepository, IStageRepository stageRepository,
                            IScienceProjectReportRepository reportRepository, IStageTypeRepository stageTypeRepository, ICastRepository castRepository)
        {
            this.userRepository = userRepository;
            this.userPermissionsRepository = userPermissionsRepository;
            this.facultyRepository = facultyRepository;
            this.departmentRepository = departmentRepository;
            this.projectRepository = projectRepository;
            this.stageRepository = stageRepository;
            this.reportRepository = reportRepository;
            this.stageTypeRepository = stageTypeRepository;
            this.castRepository = castRepository;
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
            var all = permissions.Any(p => p.PermissionId == (int)PermissionTypes.SP_PROJECTLISTVIEW_ALL);
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
            ScienceProjectViewModel model = new ScienceProjectViewModel() { OrderDate = DateTime.Now, RegistrationDate = DateTime.Now, StartDate = DateTime.Now, EndDate = DateTime.Now };
            InitSelectList(model);
            return View(model);
        }

        public JsonResult AddScienceProject(ScienceProjectViewModel model)
        {
            var user = GetUserInfo();
            if (model.StateId == 0)
            {
                model.UserId = user.Id;
                model.StateId = (int)ProjectStates.JustCreated;
            }

            if (model.Id != 0)
            {
                var project = projectRepository.GetProject(model.Id);
                foreach (var item in project.Casts)
                {
                    castRepository.Delete(item);
                }
            }

            var saved = ModelConverter.ScienceProjectModel.GetScienceProject(model);
            projectRepository.Save(saved);

            if (model.Id != 0)
            {
                foreach (var item in saved.Casts)
                {
                    castRepository.Save(new Cast { Degree = item.Degree, Fullname = item.Fullname, IsManager = item.IsManager, Post = item.Post, ProjectId = saved.Id, Status = item.Status });
                }
            }
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
            ViewBag.UserID = user.Id;
            InitializePermissionsViewBags(user);
        }

        private void InitializePermissionsViewBags(AppUser user)
        {
            List<AppUserPermissions> userPermissions = userPermissionsRepository.GetUserPermissions(user);
            foreach (var permission in userPermissions)
            {
                switch (permission.PermissionId)
                {
                    case (int)PermissionTypes.SP_ACCESS:
                        {
                            ViewBag.SP_ACCESS = true;
                            break;
                        }
                    case (int)PermissionTypes.IA_ACCESS:
                        {
                            ViewBag.IA_ACCESS = true;
                            break;
                        }
                    case (int)PermissionTypes.BY_ACCESS:
                        {
                            ViewBag.BY_ACCESS = true;
                            break;
                        }
                    case (int)PermissionTypes.SP_PROJECTLISTVIEW_ALL:
                        {
                            ViewBag.SP_PROJECTLISTVIEW_ALL = true;
                            break;
                        }
                    case (int)PermissionTypes.SP_CAN_APPROVED:
                        {
                            ViewBag.SP_CAN_APPROVED = true;
                            break;
                        }
                    case (int)PermissionTypes.SP_CAN_EDIT_ALL:
                        {
                            ViewBag.SP_CAN_EDIT_ALL = true;
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

        public ActionResult ApproveProject(int id)
        {
            var project = projectRepository.GetProject(id);
            project.StateId = (int)ProjectStates.Approved;
            projectRepository.Save(project);
            return RedirectToAction("Details", "SP", new { id = project.Id });
        }

        public ActionResult Edit(int id)
        {
            var project = projectRepository.GetProject(id);
            ScienceProjectViewModel model = new ScienceProjectViewModel();
            model = DataConverter.ScienceProjectModel.GetScienceProject(project);
            model.Faculties = helper.GetFaculties(facultyRepository);
            model.Departments = helper.GetDepartments(project.Department.FacultyId.ToString(), departmentRepository);
            model.Casts = model.Casts.OrderByDescending(c => c.IsManager).ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(ScienceProjectViewModel model)
        {
            var project = ModelConverter.ScienceProjectModel.GetScienceProject(model);
            projectRepository.Save(project);

            var casts = castRepository.GetCasts(project);
            foreach (var item in casts)
            {
                castRepository.Delete(item);
            }

            foreach (var item in model.Casts)
            {
                var cast = new Cast { Degree = item.Degree, Status = item.Status, Fullname = item.Fullname, Post = item.Post, IsManager = item.IsManager };
                cast.ProjectId = project.Id;
                castRepository.Save(cast);
            }

            return Json("OK", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddStage(SPDetailsViewModel model)
        {
            Stage stage = new Stage
            {
                ProjectId = model.Project.Id,
                StageTypeId = model.SelectedStageType
            };
            stage = stageRepository.Save(stage);
            // путь к сохранению файлов
            string uploadPath = Server.MapPath("~/Files/SP/") + $"{model.Project.Id}";
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }
            foreach (var file in model.Files)
            {
                // получаем имя файла
                string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                // получаем расширение файла
                string fileExtension = Path.GetExtension(file.FileName);
                // получение полного пути к файлу
                var filePath = uploadPath + fileName.Trim() + "_" + stage.Id + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + fileExtension;
                file.SaveAs(filePath);

                ScienceProjectReport report = new ScienceProjectReport
                {
                    Filename = fileName,
                    Path = filePath,
                    StageId = stage.Id,
                    UploadDate = DateTime.Now
                };
                reportRepository.Save(report);
            }

            if (stage.StageTypeId == (int)StageTypes.Final)
            {
                var project = projectRepository.GetProject(model.Project.Id);
                project.StateId = (int)ProjectStates.Finished;
                projectRepository.Save(project);
            }

            return RedirectToAction("Details", "SP", new { id = model.Project.Id });
        }

        public FileResult DownloadFile(int id)
        {
            // получение данных о прикрепленном файле
            var file = reportRepository.GetReport(id);
            // инициализация наименование файла
            string filename = file.Filename + Path.GetExtension(file.Path);
            // получение типа файла
            string file_type = MimeMapping.GetMimeMapping(filename);
            // скачиваем выбранный файл с сервера
            return File(file.Path, file_type, filename);
        }

    }
}