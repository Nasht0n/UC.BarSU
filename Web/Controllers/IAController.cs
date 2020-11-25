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
    public class IAController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly IUserPermissionsRepository userPermissionsRepository;

        private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;

        public IAController(IUserRepository userRepository, IUserPermissionsRepository userPermissionsRepository)
        {
            this.userRepository = userRepository;
            this.userPermissionsRepository = userPermissionsRepository;
        }

        #region Student implementation acts

        public ActionResult StudentActs()
        {
            AppUser user = GetUserInfo();
            SetViewBags(user);
            IAStudentListViewModel model = new IAStudentListViewModel();

            return View(model);
        }


        

        #endregion


        #region Research work acts
        public ActionResult ResearchActs()
        {
            return View();
        }
        #endregion


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
                    case (int)PermissionTypes.SP_PROJECTLISTVIEW_OWN:
                        {
                            ViewBag.SP_PROJECTLISTVIEW_OWN = true;
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