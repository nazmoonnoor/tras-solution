using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Tras.Core.Domain.Common;
using Tras.Core.Domain.Configuration;
using Tras.Core.Helpers;
using Tras.Services.Configuration;
using Tras.Web.Extensions;
using Tras.Web.Models;
using Tras.Web.Models.Configuration;

namespace Tras.Web.Controllers.Config
{
    [RoutePrefix("lookup")]
    [Route("{action}")]
    public class LookupController : BaseController
    {
        private readonly ILookupService _lookupService;

        public LookupController(ILookupService lookupService)
        {
            _lookupService = lookupService;
            base.PageTitle = "Lookup Table";
        }

        [NonAction]
        private void FillDropdowns(LookupViewModel viewModel)
        {
            string selectedId = viewModel.LookupType;
            var enumItems = EnumUtil.GetValues<AppConstant.LookupType>();
            var lookupTypes = enumItems.Select(item => new SelectListItem()
            {
                Value = item.ConvertToString().ToUpper(), 
                Text = item.ConvertToString().ToUpper(),
                Selected = selectedId != null && item.ConvertToString().ToUpper() == selectedId.ToUpper()
            }).ToList();
            lookupTypes.Insert(0, new SelectListItem { Value = "", Text = "Please select..." });

            ViewBag.LookupTypes = lookupTypes;
        }

        [Route("")]
        public ActionResult Index()
        {
            PageActionType = AppConstant.PageAction.List;
            SetPageInfo();

            var dataList = _lookupService.GetLookupList();
            var modelList = dataList.ToList().ToMappedList<Lookup, LookupViewModel>();
            return View(modelList);
        }

        [Route("list")]
        public ActionResult List()
        {
            PageActionType = AppConstant.PageAction.List;
            SetPageInfo();

            return View(new LookupViewModel());
        }

        [Route("load")]
        public JsonResult Load(DTParameters param)
        {
            int pageIndex = (param.Start + param.Length) / param.Length;
            var dataList = _lookupService.GetLookupList(param.Length, pageIndex, param.Search.Value, param.SortOrder);
            var modelList = dataList.ToMappedPagedList<Lookup, LookupViewModel>();

            DTResult<LookupViewModel> result = new DTResult<LookupViewModel>
            {
                draw = param.Draw,
                data = modelList.ToList(),
                recordsFiltered = modelList.TotalItemCount,
                recordsTotal = modelList.TotalItemCount
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [Route("create")]
        public ActionResult Create()
        {
            PageActionType = AppConstant.PageAction.Create;
            SetPageInfo();
            var viewModel = new LookupViewModel();
            FillDropdowns(viewModel);
            return PartialView("SaveModal", viewModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public JsonResult CreateLookup(LookupViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var data = viewModel.ToEntity();
                _lookupService.InsertLookup(data);
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
            var dataModel = _lookupService.GetLookupById(id.GetValueOrDefault());

            if (dataModel == null)
            {
                return HttpNotFound();
            }
            PageActionType = AppConstant.PageAction.Edit;
            SetPageInfo();
            var viewModel = dataModel.ToModel();
            FillDropdowns(viewModel);
            return PartialView("SaveModal", viewModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult EditLookup(LookupViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var dataModel = viewModel.ToEntity();
                _lookupService.UpdateLookup(dataModel);
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

            var data = _lookupService.GetLookupById(id.GetValueOrDefault());
            if (data == null)
            {
                return Json(new { result = "error" }, JsonRequestBehavior.AllowGet);
            }

            _lookupService.DeleteLookup(data);
            return Json(new { result = "success" }, JsonRequestBehavior.AllowGet);
        }
    }
}