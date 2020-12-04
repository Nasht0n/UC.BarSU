using Common.Entities;
using Repository.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Web.Data;
using Web.Models.Enum;
using Web.ViewModels.IA.Research;

namespace Web.Controllers
{
    [Authorize]
    public class IARController : Controller
    {
        private readonly IImplementationResearchActRepository actRepository;
        private readonly IUserPermissionsRepository userPermissionsRepository;
        private readonly IUserRepository userRepository;

        public IARController(IImplementationResearchActRepository actRepository, IUserPermissionsRepository userPermissionsRepository, IUserRepository userRepository)
        {
            this.actRepository = actRepository;
            this.userPermissionsRepository = userPermissionsRepository;
            this.userRepository = userRepository;
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