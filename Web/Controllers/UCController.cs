using Common.Entities;
using Microsoft.Owin.Security;
using Repository.Abstract;
using System.Collections.Generic;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Web.Data;
using Web.Models.Enum;
using Web.ViewModels;

namespace Web.Controllers
{
    public class UCController : Controller
    {
        private readonly IFeedbackRepository feedbackRepository;
        private readonly IPermissionRepository permissionRepository;
        private readonly IUserPermissionsRepository userPermissionsRepository;
        private readonly IUserRepository userRepository;

        private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;


        public UCController(IFeedbackRepository feedbackRepository, IPermissionRepository permissionRepository, IUserPermissionsRepository userPermissionsRepository, IUserRepository userRepository)
        {
            this.feedbackRepository = feedbackRepository;
            this.permissionRepository = permissionRepository;
            this.userPermissionsRepository = userPermissionsRepository;
            this.userRepository = userRepository;
        }

        public ActionResult Index(int feedbackCode = 0, bool? accessCode = null)
        {
            ViewBag.FeedbackCode = feedbackCode;
            ViewBag.AccessCode = accessCode;
            return View();
        }

        [HttpPost]
        public ActionResult Feedback(FeedbackViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppFeedback newFeedback = ModelConverter.FeedbackModel.GetFeedback(model);
                feedbackRepository.Save(newFeedback);
                return RedirectToAction("Index", "UC", new { feedbackCode = 1 });
            }
            return View();
        }

        public ActionResult SignIn()
        {
            AuthenticationManager.SignOut();
            LoginViewModel model = new LoginViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult SignIn(LoginViewModel model)
        {            
            if (ModelState.IsValid)
            {
                AppUser user = userRepository.GetUser(model.Username, model.Password);
                if (user == null)
                {
                    ModelState.AddModelError("", "Неверный логин или пароль");
                }
                else if (!user.IsEnabled)
                {
                    ModelState.AddModelError("", "Учетная запись заблокирована");
                }
                else
                {
                    ClaimsIdentity claim = new ClaimsIdentity("ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
                    claim.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString(), ClaimValueTypes.String));
                    claim.AddClaim(new Claim(ClaimsIdentity.DefaultNameClaimType, user.Username, ClaimValueTypes.String));
                    claim.AddClaim(new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "OWIN Provider", ClaimValueTypes.String));
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);

                    List<AppUserPermissions> userPermissions = userPermissionsRepository.GetUserPermissions(user);
                    foreach (var permission in userPermissions)
                    {
                        switch (permission.PermissionId)
                        {
                            case (int)PermissionType.SP_ACCESS:
                                {
                                    return RedirectToAction("Index", "SP");
                                }
                            case (int)PermissionType.IA_ACCESS:
                                {
                                    return RedirectToAction("Index", "IA");
                                }
                            case (int)PermissionType.BY_ACCESS:
                                {
                                    return RedirectToAction("Index", "BY");
                                }
                        }
                    }
                    
                    return RedirectToAction("Index", "UC", new { accessCode = false });
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "UC");
        }
    }
}