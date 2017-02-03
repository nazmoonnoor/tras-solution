using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tras.Core.Domain.Common;
using Tras.Core.Domain.Employee;
using Tras.Services.Configuration;
using Tras.Services.Employee;
using Tras.Web.Extensions;
using Tras.Web.Models.Employee;

namespace Tras.Web.Controllers.Employee
{
    [RoutePrefix("battalionprofile")]
    [Route("{action}")]
    public class BattalionPersonController : BaseController
    {
        private readonly IPersonService _personService;
        private readonly ILookupService _lookupService;
        private readonly IRankService _rankService;
        private readonly IUnitService _unitService;
        private readonly IStationService _stationService;

        public BattalionPersonController(IPersonService personService,
            ILookupService lookupService,
            IRankService rankService,
            IUnitService unitService,
            IStationService stationService)
        {
            _personService = personService;
            _lookupService = lookupService;
            _rankService = rankService;
            _unitService = unitService;
            _stationService = stationService;
            base.PageTitle = "Profiles";
        }

        [NonAction]
        private void FillDropdowns(BattalionProfileViewModel viewModel)
        {

            ViewBag.Station = _stationService.GetSelectList(viewModel.StationId);
            ViewBag.Rank = _rankService.GetSelectList(viewModel.RankId);
            ViewBag.Unit = _unitService.GetSelectList(viewModel.UnitId);
            ViewBag.JobType = _lookupService.GetSelectList(AppConstant.LookupType.Job_Type, viewModel.JobTypeKey);
            ViewBag.Gender = _lookupService.GetSelectList(AppConstant.LookupType.Gender, viewModel.GenderKey);
        }
        
        [Route("")]
        public ActionResult Index()
        {
            PageActionType = AppConstant.PageAction.List;
            SetPageInfo();
            var dataModel = _personService.GetPeople(6, 1, ""); //AppConstant.PageSize
            var viewModel = dataModel.ToMappedPagedList<Person, BattalionProfileViewModel>();
            ViewBag.PageCount = dataModel.PageCount;
            return View("Index", viewModel.ToList());
        }

        [Route("loadbattalionprofiles/{pageIndex}")]
        public ActionResult LoadProfiles(int pageIndex, string searchText)
        {
            var dataModel = _personService.GetPeople(6, pageIndex, searchText); //AppConstant.PageSize
            var viewModel = dataModel.ToMappedPagedList<Person, BattalionProfileViewModel>();

            return PartialView("_ProfileList", viewModel.ToList());
        }

        [Route("create")]
        public ActionResult Create()
        {
            PageActionType = AppConstant.PageAction.Create;
            SetPageInfo();

            var model = new BattalionProfileViewModel
            {
                UnitId = 0
            };

            FillDropdowns(model);

            return View("Save", model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public JsonResult CreateProfile([Bind(Exclude = "PersonId")] BattalionProfileViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var data = viewModel.ToEntity();

                data.DirectorId = 1;
                var person = _personService.InsertPerson(data);
                return Json(new { result = "success", personId = person.PersonId }, JsonRequestBehavior.AllowGet);
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

            var model = data.ToModelBatttalion();
            FillDropdowns(model);
            return View("Save", model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult EditProfile(BattalionProfileViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var data = viewModel.ToEntity();
                _personService.UpdatePerson(data);
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
            if (data == null)
            {
                return Json(new { result = "error" }, JsonRequestBehavior.AllowGet);
            }

            _personService.DeletePerson(data);
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