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
using Web.Report;
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
            model.PublicationModel = new BankYouthPublicationViewModel();
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
                bankYouth.CreateDate = DateTime.Now;
                bankYouth.EditDate = DateTime.Now;
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
            SelectList list = new SelectList(
                 new List<SelectListItem> {
                     new SelectListItem { Text = "Да", Value = "True"},
                     new SelectListItem { Text = "Нет", Value = "False"},
                    }, "Value", "Text", model.IsExcellentStudent.ToString() );
            model.ExcellentStudentList = list;
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(BankYouthViewModel model)
        {
            AppUser user = GetUserInfo();
            if (ModelState.IsValid)
            {
                BankYouth bankYouth = ModelConverter.BankYouthModel.GetBankYouth(model);
                bankYouth.UserId = user.Id;
                bankYouth.EditDate = DateTime.Now;
                bankYouthRepository.Save(bankYouth);
                return RedirectToAction("Details", "BY", new { id = bankYouth.Id });
            }
            return View();
        }

        [HttpPost]
        public ActionResult AttachPublication(BYDetailsViewModel model)
        {
            // путь к сохранению файлов
            string uploadPath = Server.MapPath("~/Files/BY/") + $"{model.BankYouth.Id}";
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            foreach (var file in model.PublicationModel.PublicationFiles)
            {
                // получаем имя файла
                string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                // получаем расширение файла
                string fileExtension = Path.GetExtension(file.FileName);
                // получение полного пути к файлу
                var filePath = uploadPath + "\\" + fileName.Trim() + "_" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + fileExtension;
                file.SaveAs(filePath);

                BankYouthPublication publication = new BankYouthPublication
                {
                    Filename = fileName,
                    Path = filePath,
                    BankYouthId = model.BankYouth.Id,
                    Description = model.PublicationModel.Description
                };

                publicationRepository.Save(publication);
            }
            return RedirectToAction("Details", "BY", new { id = model.BankYouth.Id });
        }

        public FileResult DownloadPublication(int id)
        {
            // получение данных о прикрепленном файле
            var file = publicationRepository.GetPublication(id);
            // инициализация наименование файла
            string filename = file.Filename + Path.GetExtension(file.Path);
            // получение типа файла
            string file_type = MimeMapping.GetMimeMapping(filename);
            // скачиваем выбранный файл с сервера
            return File(file.Path, file_type, filename);
        }

        public ActionResult DeletePublication(int id)
        {
            var file = publicationRepository.GetPublication(id);
            publicationRepository.Delete(file);
            return RedirectToAction("Details", "BY", new { id = file.BankYouthId });
        }

        [HttpPost]
        public ActionResult AttachDocumentation(BYDetailsViewModel model)
        {
            // путь к сохранению файлов
            string uploadPath = Server.MapPath("~/Files/BY/") + $"{model.BankYouth.Id}";
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            foreach (var file in model.DocumentationModel.DocumentationFiles)
            {
                // получаем имя файла
                string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                // получаем расширение файла
                string fileExtension = Path.GetExtension(file.FileName);
                // получение полного пути к файлу
                var filePath = uploadPath + "\\" + fileName.Trim() + "_" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + fileExtension;
                file.SaveAs(filePath);

                BankYouthDocumentation documentation = new BankYouthDocumentation
                {
                    Filename = fileName,
                    Path = filePath,
                    BankYouthId = model.BankYouth.Id,
                    Description = model.DocumentationModel.Description,
                    RegDate = model.DocumentationModel.RegDate,
                    RegNumber = model.DocumentationModel.RegNumber
                };

                documentationRepository.Save(documentation);
            }
            return RedirectToAction("Details", "BY", new { id = model.BankYouth.Id });
        }

        public FileResult DownloadDocumentation(int id)
        {
            // получение данных о прикрепленном файле
            var file = documentationRepository.GetDocumentation(id);
            // инициализация наименование файла
            string filename = file.Filename + Path.GetExtension(file.Path);
            // получение типа файла
            string file_type = MimeMapping.GetMimeMapping(filename);
            // скачиваем выбранный файл с сервера
            return File(file.Path, file_type, filename);
        }

        public ActionResult DeleteDocumentation(int id)
        {
            var file = documentationRepository.GetDocumentation(id);
            documentationRepository.Delete(file);
            return RedirectToAction("Details", "BY", new { id = file.BankYouthId });
        }

        [HttpPost]
        public ActionResult AttachAward(BYDetailsViewModel model)
        {
            // путь к сохранению файлов
            string uploadPath = Server.MapPath("~/Files/BY/") + $"{model.BankYouth.Id}";
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            foreach (var file in model.AwardModel.AwardFiles)
            {
                // получаем имя файла
                string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                // получаем расширение файла
                string fileExtension = Path.GetExtension(file.FileName);
                // получение полного пути к файлу
                var filePath = uploadPath + "\\" + fileName.Trim() + "_" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + fileExtension;
                file.SaveAs(filePath);

                BankYouthAward award = new BankYouthAward
                {
                    Filename = fileName,
                    Path = filePath,
                    BankYouthId = model.BankYouth.Id,
                    Description = model.AwardModel.Description,
                    Date = model.AwardModel.Date
                };

                awardRepository.Save(award);
            }
            return RedirectToAction("Details", "BY", new { id = model.BankYouth.Id });
        }

        public FileResult DownloadAward(int id)
        {
            // получение данных о прикрепленном файле
            var file = awardRepository.GetAward(id);
            // инициализация наименование файла
            string filename = file.Filename + Path.GetExtension(file.Path);
            // получение типа файла
            string file_type = MimeMapping.GetMimeMapping(filename);
            // скачиваем выбранный файл с сервера
            return File(file.Path, file_type, filename);
        }

        public ActionResult DeleteAward(int id)
        {
            var file = awardRepository.GetAward(id);
            awardRepository.Delete(file);
            return RedirectToAction("Details", "BY", new { id = file.BankYouthId });
        }

        public FileResult Print(int id)
        {
            string template = Server.MapPath("~/Files/Templates/TBY.docx");
            string outputFolder = Server.MapPath("~/Files/BY/");
            var bankYouth = bankYouthRepository.GetBankYouth(id);
            string outputPath = ReportManager.GenerateBYBlank(template, outputFolder, bankYouth);
            string filename = $"BY-{bankYouth.Surname}-{bankYouth.YearOfInclusion}.docx";
            string file_type = MimeMapping.GetMimeMapping(filename);
            return File(outputPath, file_type, filename);
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