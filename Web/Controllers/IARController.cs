using Common.Entities;
using Microsoft.Owin.Security;
using Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Data;
using Web.Models.Enum;
using Web.Report;
using Web.ViewModels;
using Web.ViewModels.IA.Research;

namespace Web.Controllers
{
    [Authorize]
    public class IARController : Controller
    {
        private readonly IImplementationResearchActRepository actRepository;
        private readonly IUserPermissionsRepository userPermissionsRepository;
        private readonly IUserRepository userRepository;
        private readonly IImplementationResearchActAuthorsRepository authorsRepository;
        private readonly IImplementationResearchActEmployeesRepository employeesRepository;
        private readonly IImplementationResearchActLifeCycleRepository lifeCycleRepository;

        private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;
        public IARController(IImplementationResearchActRepository actRepository, IUserPermissionsRepository userPermissionsRepository, IUserRepository userRepository,
                             IImplementationResearchActAuthorsRepository authorsRepository, IImplementationResearchActEmployeesRepository employeesRepository,
                             IImplementationResearchActLifeCycleRepository lifeCycleRepository)
        {
            this.actRepository = actRepository;
            this.userPermissionsRepository = userPermissionsRepository;
            this.userRepository = userRepository;
            this.authorsRepository = authorsRepository;
            this.employeesRepository = employeesRepository;
            this.lifeCycleRepository = lifeCycleRepository;
        }

        public ActionResult Index()
        {
            AppUser user = GetUserInfo();
            SetViewBags(user);
            IAResearchListViewModel model = new IAResearchListViewModel();
            List<ImplementationResearchAct> acts = GetActs(user);
            model.ResearchActs = DataConverter.ResearchActModel.GetActs(acts);
            return View(model);
        }

        public ActionResult Details(int id)
        {
            AppUser user = GetUserInfo();
            SetViewBags(user);
            IAResearchDetailsViewModel model = new IAResearchDetailsViewModel();
            model.User = user;
            model.Act = actRepository.GetAct(id);
            model.Employees = employeesRepository.GetEmployees(model.Act);
            model.Authors = authorsRepository.GetAuthors(model.Act);
            model.LifeCycles = lifeCycleRepository.GetLifeCycles(model.Act);
            return View(model);
        }

        public ActionResult Create()
        {
            AppUser user = GetUserInfo();
            SetViewBags(user);
            IAResearchViewModel model = new IAResearchViewModel();
            return View(model);
        }

        [HttpPost]
        public JsonResult SaveAct(IAResearchViewModel model)
        {
            AppUser user = GetUserInfo();
            if (ModelState.IsValid)
            {
                model.UserId = user.Id;
                if (model.Id != 0)
                {
                    var act = actRepository.GetAct(model.Id);
                    foreach (var item in act.Authors)
                    {
                        authorsRepository.Delete(item);
                    }

                    foreach (var item in act.Employees)
                    {
                        employeesRepository.Delete(item);
                    }
                }
                var saved = ModelConverter.ImplementationResearchActModel.GetAct(model);
                actRepository.Save(saved);

                foreach (var item in saved.Authors)
                {
                    authorsRepository.Save(new ImplementationResearchActAuthors { ActId = saved.Id, Fullname = item.Fullname, Post = item.Post, AcademicDegree = item.AcademicDegree, AcademicStatus = item.AcademicStatus });
                }

                foreach (var item in saved.Employees)
                {
                    employeesRepository.Save(new ImplementationResearchActEmployees { ActId = saved.Id, Fullname = item.Fullname, Post = item.Post });
                }

                var lifeCycles = lifeCycleRepository.GetLifeCycles(saved);
                if (lifeCycles.Count == 0) lifeCycleRepository.Save(new ImplementationResearchActLifeCycle { ActId = saved.Id, Date = DateTime.Now, Title = "Создание акта внедрения", Message = $"Научный проект студента успешно внедрен в производство." });
            }
            return Json("OK", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(int id)
        {
            AppUser user = GetUserInfo();
            SetViewBags(user);
            var act = actRepository.GetAct(id);
            IAResearchViewModel model = DataConverter.ResearchActModel.GetAct(act);
            return View(model);
        }

        public JsonResult Message(LifeCycleMessageModel model)
        {
            if (ModelState.IsValid)
            {
                lifeCycleRepository.Save(new ImplementationResearchActLifeCycle { ActId = model.ActId, Date = DateTime.Now, Title = model.Title, Message = model.Message });
            }
            return Json("OK", JsonRequestBehavior.AllowGet);
        }

        public FileResult Print(int id)
        {
            string template = Server.MapPath("~/Files/Templates/TIAR.docx");
            string outputFolder = Server.MapPath("~/Files/IAR/");
            var act = actRepository.GetAct(id);
            string outputPath = ReportManager.GenerateResearchAct(template, outputFolder, act);
            string filename = $"IAR-{act.ProjectName}.docx";
            string file_type = MimeMapping.GetMimeMapping(filename);
            return File(outputPath, file_type, filename);
        }

        #region Help methods
        private List<ImplementationResearchAct> GetActs(AppUser user)
        {
            List<ImplementationResearchAct> result = new List<ImplementationResearchAct>();
            var permissions = userPermissionsRepository.GetUserPermissions(user);
            var all = permissions.Any(p => p.PermissionId == (int)PermissionTypes.IAS_LISTVIEW_ALL);
            if (all) result = actRepository.GetActs();
            else result = actRepository.GetActs(user);
            return result;
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

        #endregion
    }
}