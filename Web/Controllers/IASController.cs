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
using Web.ViewModels.IA.Students;

namespace Web.Controllers
{
    [Authorize]
    public class IASController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly IUserPermissionsRepository userPermissionsRepository;
        private readonly IImplementationStudentActRepository actRepository;
        private readonly IImplementationStudentActLifeCycleRepository lifeCycleRepository;
        private readonly IImplementationStudentActComissionRepository comissionRepository;

        private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;

        public IASController(IUserRepository userRepository, IUserPermissionsRepository userPermissionsRepository, IImplementationStudentActRepository actRepository,
                             IImplementationStudentActLifeCycleRepository lifeCycleRepository, IImplementationStudentActComissionRepository comissionRepository)
        {
            this.userRepository = userRepository;
            this.userPermissionsRepository = userPermissionsRepository;
            this.actRepository = actRepository;
            this.lifeCycleRepository = lifeCycleRepository;
            this.comissionRepository = comissionRepository;
        }

        public ActionResult Index()
        {
            AppUser user = GetUserInfo();
            SetViewBags(user);
            IAStudentListViewModel model = new IAStudentListViewModel();
            List<ImplementationStudentAct> acts = GetActs(user);
            model.StudentActs = DataConverter.StudentActModel.GetActs(acts);
            return View(model);
        }

        private List<ImplementationStudentAct> GetActs(AppUser user)
        {
            List<ImplementationStudentAct> result = new List<ImplementationStudentAct>();
            var permissions = userPermissionsRepository.GetUserPermissions(user);
            var all = permissions.Any(p => p.PermissionId == (int)PermissionTypes.IAS_LISTVIEW_ALL);
            if (all) result = actRepository.GetActs();
            else result = actRepository.GetActs(user);
            return result;
        }

        public ActionResult Details(int id)
        {
            AppUser user = GetUserInfo();
            SetViewBags(user);
            IAStudentDetailsViewModel model = new IAStudentDetailsViewModel();
            model.User = user;
            model.Act = actRepository.GetAct(id);
            model.Comissions = comissionRepository.GetComissions(model.Act);
            model.LifeCycles = lifeCycleRepository.GetLifeCycles(model.Act);
            return View(model);
        }

        public ActionResult Create()
        {
            AppUser user = GetUserInfo();
            SetViewBags(user);
            IAStudentViewModel model = new IAStudentViewModel()
            {
                ProtocolDate = DateTime.Now,
                RegisterDate = DateTime.Now
            };
            return View(model);
        }
        [HttpPost]
        public JsonResult SaveAct(IAStudentViewModel model)
        {
            AppUser user = GetUserInfo();
            if (ModelState.IsValid)
            {
                model.UserId = user.Id;
                if (model.Id != 0)
                {
                    var act = actRepository.GetAct(model.Id);
                    foreach (var item in act.Comissions)
                    {
                        comissionRepository.Delete(item);
                    }
                }

                var saved = ModelConverter.ImplementationStudentActModel.GetAct(model);
                actRepository.Save(saved);

                foreach (var item in saved.Comissions)
                {
                    comissionRepository.Save(new ImplementationStudentActComission { ActId = saved.Id, Fullname = item.Fullname, Post = item.Post });
                }

                var lifeCycles = lifeCycleRepository.GetLifeCycles(saved);
                if (lifeCycles.Count == 0) lifeCycleRepository.Save(new ImplementationStudentActLifeCycle { ActId = saved.Id, Date = DateTime.Now, Title = "Создание акта внедрения", Message = $"Научный проект студента успешно внедрен в производство." });
            }
            return Json("OK", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(int id)
        {
            AppUser user = GetUserInfo();
            SetViewBags(user);
            var act = actRepository.GetAct(id);
            IAStudentViewModel model = DataConverter.StudentActModel.GetAct(act);
            return View(model);
        }

        public FileResult Print(int id)
        {
            string template = Server.MapPath("~/Files/Templates/TIAS.docx");
            string outputFolder = Server.MapPath("~/Files/IAS/");
            var act = actRepository.GetAct(id);
            string outputPath = ReportManager.GenerateStudentAct(template, outputFolder, act);
            string filename = $"IAS-{act.ProjectName}.docx";
            string file_type = MimeMapping.GetMimeMapping(filename);
            return File(outputPath, file_type, filename);
        }

        public JsonResult AddLifeCycleMessage(IAStudentDetailsViewModel model)
        {
            return Json("OK", JsonRequestBehavior.AllowGet);
        }

        public JsonResult Message(LifeCycleMessageModel model)
        {
            if (ModelState.IsValid)
            {
                lifeCycleRepository.Save(new ImplementationStudentActLifeCycle { ActId = model.ActId, Date = DateTime.Now, Title = model.Title, Message = model.Message });
            }
            return Json("OK", JsonRequestBehavior.AllowGet);
        }

        #region Help methods
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