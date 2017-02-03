using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tras.Core.Domain.Common;
using Tras.Core.Domain.Ration;
using Tras.Services.Ration;
using Tras.Web.Extensions;
using Tras.Web.Models.Ration;

namespace Tras.Web.Controllers.Ration
{
    [RoutePrefix("package")]
    [Route("{action}")]
    public class PackageController : BaseController
    {
        private readonly IPackageService _packageService;
        private readonly IRationSubHeadService _rationSubHeadService;
        private readonly IPackageItemService _packageItemService;


        public PackageController(IPackageService packageService, IRationSubHeadService rationSubHeadService, IPackageItemService packageItemService)
        {
            _packageService = packageService;
            _rationSubHeadService = rationSubHeadService;
            _packageItemService = packageItemService;
            PageTitle = "Ration Package";
        }
        [NonAction]
        private void FillDropdowns(PackageViewModel viewModel)
        {
            ViewBag.RationSubHeads = _rationSubHeadService.GetSelectList(viewModel.SubHeadId);
        }
        [Route("")]
        public ActionResult Index()
        {
            PageActionType = AppConstant.PageAction.List;
            SetPageInfo();
            var dataModel = _packageService.GetPackages(20, 1);
            var viewModel = dataModel.ToMappedPagedList<Package, PackageViewModel>();
            return View(viewModel);
        }

        [Route("details")]
        public ActionResult Details(int id)
        {
            if (id < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PageActionType = AppConstant.PageAction.Detail;
            SetPageInfo();
            var dataModel = _packageService.GetPackageById(id);
            var viewModel = dataModel.MapTo<Package, PackageDetailsViewModel>();

            return View("DetailsView",viewModel);
        }


        [Route("create")]
        public ActionResult Create()
        {
            PageActionType = AppConstant.PageAction.Create;
            SetPageInfo();
            var model = new PackageViewModel();
            FillDropdowns(model);
            return PartialView("Save", model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public JsonResult Create(PackageViewModel viewModel)
        {
            PageActionType = AppConstant.PageAction.Create;
            SetPageInfo();
            if (viewModel != null)
            {
                var data = viewModel.ToEntity();
                _packageService.InsertPackage(data);
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
            var data = _packageService.GetPackageById(id.GetValueOrDefault());

            if (data == null)
            {
                return HttpNotFound();
            }
            PageActionType = AppConstant.PageAction.Edit;
            SetPageInfo();
            var model = data.ToModel();
            FillDropdowns(model);
            return PartialView("Save", model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public JsonResult Edit(PackageViewModel viewModel)
        {
            PageActionType = AppConstant.PageAction.Edit;
            SetPageInfo();
            if (ModelState.IsValid)
            {
                var data = viewModel.ToEntity();
                _packageService.UpdatePackage(data);
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

            Package data = _packageService.GetPackageById(id.GetValueOrDefault());
            if (data == null)
            {
                return Json(new { result = "error" }, JsonRequestBehavior.AllowGet);
            }
            _packageService.DeletePackage(data);
            return Json(new { result = "success" }, JsonRequestBehavior.AllowGet);
        }
	}
}