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

namespace Web.Controllers
{
    [Authorize]
    public class SPController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly IUserPermissionsRepository userPermissionsRepository;

        private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;

        public SPController(IUserRepository userRepository, IUserPermissionsRepository userPermissionsRepository)
        {
            this.userRepository = userRepository;
            this.userPermissionsRepository = userPermissionsRepository;
        }

        public ActionResult Index()
        {   
            SetViewBags();
            return View();
        }

        public ActionResult Projects()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        private void SetViewBags()
        {
            InitializeNavMenuViewBags();
        }
        private void InitializeNavMenuViewBags()
        {
            AppUser user = GetUserInfo();
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