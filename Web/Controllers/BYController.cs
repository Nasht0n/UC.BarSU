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
using Web.ViewModels.BY;

namespace Web.Controllers
{
    [Authorize]
    public class BYController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly IUserPermissionsRepository userPermissionsRepository;
        private readonly IBankYouthRepository bankYouthRepository;
        private readonly IBankYouthAwardRepository awardRepository;
        private readonly IBankYouthDocumentationRepository documentationRepository;
        private readonly IBankYouthPublicationRepository publicationRepository;

        private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;

        public BYController(IUserRepository userRepository, IUserPermissionsRepository userPermissionsRepository, IBankYouthRepository bankYouthRepository,
                            IBankYouthAwardRepository awardRepository, IBankYouthDocumentationRepository documentationRepository, IBankYouthPublicationRepository publicationRepository)
        {
            this.userRepository = userRepository;
            this.userPermissionsRepository = userPermissionsRepository;
            this.bankYouthRepository = bankYouthRepository;
            this.awardRepository = awardRepository;
            this.documentationRepository = documentationRepository;
            this.publicationRepository = publicationRepository;
        }

        public ActionResult Index()
        {
            AppUser user = GetUserInfo();
            SetViewBags(user);
            BankYouthListViewModel model = new BankYouthListViewModel();
            List<BankYouth> bankYouths = GetList(user);
            model.BankYouthModels = DataConverter.BankYouthModel.GetBankYouths(bankYouths);

            return View(model);
        }

        public ActionResult Details(int id)
        {
            AppUser user = GetUserInfo();
            SetViewBags(user);
            BYDetailsViewModel model = new BYDetailsViewModel();
            model.User = user;
            model.BankYouth = bankYouthRepository.GetBankYouth(id);
            model.Awards = awardRepository.GetAwards(model.BankYouth);
            model.Documentations = documentationRepository.GetDocumentations(model.BankYouth);
            model.Publications = publicationRepository.GetPublications(model.BankYouth);
            return View(model);
        }

        public ActionResult Create()
        {
            AppUser user = GetUserInfo();
            SetViewBags(user);
            BankYouthViewModel model = new BankYouthViewModel() { DateOfBirthday = DateTime.Now, ProtocolDate = DateTime.Now, YearOfAddmission = DateTime.Now.Year, YearOfInclusion = DateTime.Now.Year };
            SelectList list = new SelectList(
                 new List<SelectListItem> {
                     new SelectListItem { Text = "Да", Value = "True"},
                     new SelectListItem { Text = "Нет", Value = "False"},
                    }, "Value", "Text");
            model.ExcellentStudentList = list;
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(BankYouthViewModel model)
        {
            AppUser user = GetUserInfo();
            if (ModelState.IsValid)
            {
                BankYouth bankYouth = ModelConverter.BankYouthModel.GetBankYouth(model);
                bankYouth.UserId = user.Id;
                bankYouthRepository.Save(bankYouth);
                return RedirectToAction("Details", "BY", new { id = bankYouth.Id });
            }
            return View();
        }

        [HttpPost]
        public JsonResult SaveAct(BankYouthViewModel model)
        {
            AppUser user = GetUserInfo();
            if (ModelState.IsValid)
            {
                model.UserId = user.Id;
                if (model.Id != 0)
                {
                    var bankYouth = bankYouthRepository.GetBankYouth(model.Id);
                    foreach (var item in bankYouth.Awards)
                    {
                        awardRepository.Delete(item);
                    }
                    foreach (var item in bankYouth.Documentations)
                    {
                        documentationRepository.Delete(item);
                    }
                    foreach (var item in bankYouth.Publications)
                    {
                        publicationRepository.Delete(item);
                    }
                }
                var saved = ModelConverter.BankYouthModel.GetBankYouth(model);
                bankYouthRepository.Save(saved);
                foreach (var item in saved.Awards)
                {
                    awardRepository.Save(new BankYouthAward { BankYouthId = item.BankYouthId, Date = item.Date, Description = item.Description, Filename = item.Filename, Path = item.Filename });
                }

                foreach (var item in saved.Documentations)
                {
                    documentationRepository.Save(new BankYouthDocumentation { BankYouthId = item.BankYouthId, Description = item.Description, Filename = item.Filename, Path = item.Path, RegDate = item.RegDate, RegNumber = item.RegNumber });
                }

                foreach (var item in saved.Publications)
                {
                    publicationRepository.Save(new BankYouthPublication { BankYouthId = item.BankYouthId, Description = item.Description, Filename = item.Filename, Path = item.Path });
                }
            }
            return Json("OK", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(int id)
        {
            AppUser user = GetUserInfo();
            SetViewBags(user);
            var bankYouth = bankYouthRepository.GetBankYouth(id);
            BankYouthViewModel model = DataConverter.BankYouthModel.GetBankYouth(bankYouth);
            return View(model);
        }

        #region Help methods
        private List<BankYouth> GetList(AppUser user)
        {
            List<BankYouth> result = new List<BankYouth>();
            var permissions = userPermissionsRepository.GetUserPermissions(user);
            var all = permissions.Any(p => p.PermissionId == (int)PermissionTypes.IAS_LISTVIEW_ALL);
            if (all) result = bankYouthRepository.GetBankYouths();
            else result = bankYouthRepository.GetBankYouths(user);
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