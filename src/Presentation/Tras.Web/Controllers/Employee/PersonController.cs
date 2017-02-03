using System.Linq;
using System.Net;
using System.Web.Mvc;
using Tras.Core.Domain.Common;
using Tras.Core.Domain.Employee;
using Tras.Services.Configuration;
using Tras.Services.Employee;
using Tras.Services.Ration;
using Tras.Web.Extensions;
using Tras.Web.Models.Employee;

namespace Tras.Web.Controllers.Employee
{
    [RoutePrefix("profiles")]
    [Route("{action}")]
    public class PersonController : BaseController
    {
        private readonly IPersonService _personService;
        private readonly IFamilyInfoService _familyInfoService;
        private readonly ILookupService _lookupService;
        private readonly IDepartmentService _departmentService;
        private readonly IDirectorService _directorService;
        private readonly IUnitService _unitService;
        private readonly IRankService _rankService;
        private readonly IPersonPackageService _personPackageService;
        private readonly IPackageService _packageService;

        public PersonController(IPersonService personService,
            IFamilyInfoService familyInfoService,
            ILookupService lookupService,
            IDepartmentService departmentService,
            IDirectorService directorService,
            IUnitService unitService,
            IRankService rankService,
            IPersonPackageService personPackageService,
            IPackageService packageService)
        {
            _personService = personService;
            _familyInfoService = familyInfoService;
            _departmentService = departmentService;
            _directorService = directorService;
            _unitService = unitService;
            _rankService = rankService;
            _personPackageService = personPackageService;
            _packageService = packageService;
            _lookupService = lookupService;
            base.PageTitle = "Profiles";
        }

        [NonAction]
        private void FillDropdowns(PersonViewModel viewModel)
        {
            ViewBag.PeopleTypes = _lookupService.GetSelectList(AppConstant.LookupType.Person_Type, viewModel.PersonTypeKey);
            ViewBag.Category = _lookupService.GetSelectList(AppConstant.LookupType.Category, viewModel.CategoryKey);
            ViewBag.Department = _departmentService.GetSelectList(viewModel.DepartmentId);
            ViewBag.Rank = _rankService.GetSelectList(viewModel.RankId);
            ViewBag.Director = _directorService.GetSelectList(viewModel.DirectorId);
            ViewBag.FamilyType = _lookupService.GetSelectList(AppConstant.LookupType.Family_Type, viewModel.FamilyTypeKey);
            ViewBag.Gender = _lookupService.GetSelectList(AppConstant.LookupType.Gender, viewModel.GenderKey);
            ViewBag.MaritalStatus = _lookupService.GetSelectList(AppConstant.LookupType.Marital_Status, viewModel.MaritalStatusKey);
            ViewBag.Unit = _unitService.GetSelectList(viewModel.UnitId);
            ViewBag.JobType = _lookupService.GetSelectList(AppConstant.LookupType.Job_Type, viewModel.JobTypeKey);
            ViewBag.AssignPackage = _packageService.GetSelectList(viewModel.PersonPackageViewModel.PackageId);
        }

        [Route("")]
        public ActionResult Index()
        {
            PageActionType = AppConstant.PageAction.List;
            SetPageInfo();

            var dataModel = _personService.GetPeople(6, 1, ""); //AppConstant.PageSize
            var viewModel = dataModel.ToMappedPagedList<Person, PersonViewModel>();
            ViewBag.PageCount = dataModel.PageCount;

            return View("Index", viewModel.ToList());
        } 
        [Route("loadprofiles/{pageIndex}")]
        public ActionResult LoadProfiles(int pageIndex, string searchText)
        {
            var dataModel = _personService.GetPeople(6, pageIndex, searchText); //AppConstant.PageSize
                var viewModel = dataModel.ToMappedPagedList<Person, PersonViewModel>();

            return PartialView("_ProfileList", viewModel.ToList());
        }

        [Route("create")]
        public ActionResult Create()
        {
            PageActionType = AppConstant.PageAction.Create;
            SetPageInfo();

            var model = new PersonViewModel
            {
                DepartmentId = 0,
                UnitId = 0,
                FamilyInfoViewModel = new FamilyInfoViewModel(),
                PersonPackageViewModel = new PersonPackageViewModel()
            };

            FillDropdowns(model);

            return View("Save", model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public JsonResult CreateProfile([Bind(Exclude = "PersonId")] PersonViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var data = viewModel.ToEntity();
                var person = _personService.InsertPerson(data);
                return Json(new { result = "success", personId = person.PersonId }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { result = "error" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult CreateFamily(FamilyInfoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var data = viewModel.ToEntity();
                _familyInfoService.InsertFamilyInfo(data);
                return Json(new { result = "success" }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { result = "error" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CreateAssignPackage(PersonPackageViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var data = viewModel.ToEntity();
                _personPackageService.InsertPersonPackage(data);
                return Json(new { result = "success" }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { result = "error" }, JsonRequestBehavior.AllowGet);
        }

        [Route("edit")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var data = _personService.GetPersonById(id.GetValueOrDefault());
            if (data == null)
            {
                return HttpNotFound();
            }

            PageActionType = AppConstant.PageAction.Edit;
            SetPageInfo();

            var model = data.ToModel();
            var familyInfo = _familyInfoService.GetFamilyInfoByPersonId(id.GetValueOrDefault());
            model.FamilyInfoViewModel = familyInfo != null ? familyInfo.ToModel() : new FamilyInfoViewModel();
            var personPackage = _personPackageService.GetPackageByPersonId(id.GetValueOrDefault());
            model.PersonPackageViewModel = personPackage != null ? personPackage.ToModel() : new PersonPackageViewModel();
           
            FillDropdowns(model);
            return View("Save", model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult EditProfile(PersonViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var data = viewModel.ToEntity();
                _personService.UpdatePerson(data);
                return Json(new { result = "success" }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { result = "error" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult EditFamily(FamilyInfoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var data = viewModel.ToEntity();
                _familyInfoService.UpdateFamilyInfo(data);
                return Json(new { result = "success" }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { result = "error" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EditAssignPackage(PersonPackageViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var data = viewModel.ToEntity();
                _personPackageService.UpdatePersonPackage(data);
                return Json(new { result = "success" }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { result = "error" }, JsonRequestBehavior.AllowGet);
        }
        [Route("delete")]
        [HttpPost]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var data = _personService.GetPersonById(id.GetValueOrDefault());
            var familyInfo = _familyInfoService.GetFamilyInfoByPersonId(id.GetValueOrDefault());
            if (data == null)
            {
                return Json(new {result = "error"}, JsonRequestBehavior.AllowGet);
            }

            _personService.DeletePerson(data);
            if (familyInfo != null)
            {
                _familyInfoService.DeleteFamilyInfo(familyInfo);
            }
            return Json(new { result = "success" }, JsonRequestBehavior.AllowGet);
        }

        [Route("details")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person data = _personService.GetPersonById(id.GetValueOrDefault());
            if (data == null)
            {
                return HttpNotFound();
            }

            PageActionType = AppConstant.PageAction.Detail;
            SetPageInfo();

            var model = data.ToModel();

            return View("_Profile", model);
        }
    }
}