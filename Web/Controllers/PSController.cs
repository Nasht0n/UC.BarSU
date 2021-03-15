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
using Web.ViewModels.PS;

namespace Web.Controllers
{
    [Authorize]
    public class PSController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly IUserPermissionsRepository userPermissionsRepository;
        private readonly IPaidServicesRepository paidServicesRepository;

        private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;

        public PSController(IUserRepository userRepository, IUserPermissionsRepository userPermissionsRepository, IPaidServicesRepository paidServicesRepository)
        {
            this.userRepository = userRepository;
            this.userPermissionsRepository = userPermissionsRepository;
            this.paidServicesRepository = paidServicesRepository;
        }

        // Index
        public ActionResult Index()
        {
            AppUser user = GetUserInfo();
            SetViewBags(user);
            PaidServiceListViewModel model = new PaidServiceListViewModel();
            List<PaidServices> paidServices = GetServicesList(user);
            model.PaidServices = DataConverter.PaidServiceModel.GetPaidServices(paidServices);
            return View(model);
        }
        // Details
        public ActionResult Details(int id)
        {
            AppUser user = GetUserInfo();
            SetViewBags(user);
            var paidService = paidServicesRepository.GetPaidService(id);
            PaidServiceViewModel model = DataConverter.PaidServiceModel.GetPaidService(paidService);
            return View(model);
        }
        // Get: Create 
        public ActionResult Create()
        {
            AppUser user = GetUserInfo();
            SetViewBags(user);
            PaidServiceViewModel model = new PaidServiceViewModel() { OrderDate = DateTime.Now };
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(PaidServiceViewModel model)
        {
            GetUserInfo();
            if (ModelState.IsValid)
            {
                PaidServices paidService = ModelConverter.PaidServiceModel.GetPaidService(model);
                paidServicesRepository.Save(paidService);
                return RedirectToAction("Details", "PS", new { id = paidService.Id });
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            AppUser user = GetUserInfo();
            SetViewBags(user);
            var paidService = paidServicesRepository.GetPaidService(id);
            PaidServiceViewModel model = DataConverter.PaidServiceModel.GetPaidService(paidService);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(PaidServiceViewModel model)
        {
            AppUser user = GetUserInfo();
            if (ModelState.IsValid)
            {
                PaidServices paidService = ModelConverter.PaidServiceModel.GetPaidService(model);
                paidService.UserId = user.Id;
                paidServicesRepository.Save(paidService);
                return RedirectToAction("Details", "PS", new { id = paidService.Id });
            }
            return View();
        }

        private List<PaidServices> GetServicesList(AppUser user)
        {
            List<PaidServices> result = new List<PaidServices>();
            var permissions = userPermissionsRepository.GetUserPermissions(user);
            var all = permissions.Any(p => p.PermissionId == (int)PermissionTypes.PS_LISTVIEW_ALL);
            if (all) result = paidServicesRepository.GetPaidServices();
            else result = paidServicesRepository.GetPaidServices(user);
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
                    case (int)PermissionTypes.PS_ACCESS:
                        {
                            ViewBag.PS_ACCESS = true;
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