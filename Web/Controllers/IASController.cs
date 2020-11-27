using Common.Entities;
using Microsoft.Owin.Security;
using Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Web.Data;
using Web.Models.Enum;
using Web.ViewModels.IA.Students;

namespace Web.Controllers
{
    [Authorize]
    public class IASController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly IUserPermissionsRepository userPermissionsRepository;

        private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;

        public IASController(IUserRepository userRepository, IUserPermissionsRepository userPermissionsRepository)
        {
            this.userRepository = userRepository;
            this.userPermissionsRepository = userPermissionsRepository;
        }

        public ActionResult Index()
        {
            AppUser user = GetUserInfo();
            SetViewBags(user);
            IAStudentListViewModel model = new IAStudentListViewModel();
            model.StudentActs = new List<IAStudentViewModel>();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            AppUser user = GetUserInfo();
            SetViewBags(user);
            IAStudentDetailsViewModel model = new IAStudentDetailsViewModel();

            return View(model);
        }

        public ActionResult Create()
        {
            AppUser user = GetUserInfo();
            SetViewBags(user);
            IAStudentViewModel model = new IAStudentViewModel() { 
                ProtocolDate = DateTime.Now,
                RegisterDate = DateTime.Now
            };
            return View(model);
        }
        [HttpPost]
        public JsonResult Create(IAStudentViewModel model)
        {
            return Json("OK", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit()
        {
            AppUser user = GetUserInfo();
            SetViewBags(user);
            IAStudentViewModel model = new IAStudentViewModel();
            return View(model);
        }
        [HttpPost]
        public JsonResult Edit(IAStudentViewModel model)
        {
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