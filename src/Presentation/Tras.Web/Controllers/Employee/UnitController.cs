using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tras.Core.Domain.Common;
using Tras.Core.Domain.Employee;
using Tras.Data;
using Tras.Services.Employee;
using Tras.Web.Extensions;
using Tras.Web.Models.Employee;

namespace Tras.Web.Controllers.Employee
{
    [RoutePrefix("unit")]
    [Route("{action}")]
    public class UnitController : BaseController
    {
        private readonly IUnitService _unitService;

        public UnitController(IUnitService unitService)
        {
            _unitService = unitService;
            base.PageTitle = "Unit";
        }
        [Route("")]
        public ActionResult Index()
        {
            PageActionType = AppConstant.PageAction.List;
            SetPageInfo();
            var dataModel = _unitService.Getunits(20, 1);
            var viewModel = dataModel.ToMappedPagedList<Unit, UnitViewModel>();
            return View(viewModel);

        }

        [Route("create")]
        public ActionResult Create()
        {
            PageActionType = AppConstant.PageAction.Create;
            SetPageInfo();
            var model = new UnitViewModel();
            return View("Save", model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(UnitViewModel viewModel)
        {
            PageActionType = AppConstant.PageAction.Create;
            SetPageInfo();
            if (viewModel != null)
            {
                var data = viewModel.ToEntity();
                _unitService.InsertUnit(data);
                return RedirectToAction("Index");

            }
            return View("Save", viewModel);
        }
        [Route("edit")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var data = _unitService.GetunitById(id.GetValueOrDefault());

            if (data == null)
            {
                return HttpNotFound();
            }
            PageActionType = AppConstant.PageAction.Edit;
            SetPageInfo();
            var model = data.ToModel();
            return View("Save", model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(UnitViewModel viewModel)
        {
            PageActionType = AppConstant.PageAction.Edit;
            SetPageInfo();
            if (ModelState.IsValid)
            {
                var data = viewModel.ToEntity();
                _unitService.Updateunit(data);
                return RedirectToAction("Index");
            }
            return View("Save", viewModel);
        }
    }
}
