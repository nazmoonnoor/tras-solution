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
    [RoutePrefix("rationitemcategory")]
    [Route("{action}")]
    public class RationItemCategoryController : BaseController
    {
        
        private readonly IRationItemCategoryService _rationItemCategoryService;

        public RationItemCategoryController(IRationItemCategoryService rationItemCategoryService)
        {
            _rationItemCategoryService = rationItemCategoryService;
            PageTitle = "Ration Item Category";
        }
       

        [Route("")]
        public ActionResult Index()
        {
            PageActionType = AppConstant.PageAction.List;
            SetPageInfo();
            var dataModel = _rationItemCategoryService.GetRationItemCategories(20, 1);
            var viewModel = dataModel.ToMappedPagedList<RationItemCategory, RationItemCategoryViewModel>();
            return View(viewModel);
        }


        [Route("create")]
        public ActionResult Create()
        {
            PageActionType = AppConstant.PageAction.Create;
            SetPageInfo();
            var model = new RationItemCategoryViewModel();
            return View("Save", model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(RationItemCategoryViewModel viewModel)
        {
            PageActionType = AppConstant.PageAction.Create;
            SetPageInfo();
            if (viewModel != null)
            {
                var data = viewModel.ToEntity();
                _rationItemCategoryService.InsertRationItemCategory(data);
                return RedirectToAction("Index");

            }
            return View("Save", null);
        }
        [Route("edit")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var data = _rationItemCategoryService.GetRationItemCategoryById(id.GetValueOrDefault());

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
        public ActionResult Edit(RationItemCategoryViewModel viewModel)
        {
            PageActionType = AppConstant.PageAction.Edit;
            SetPageInfo();
            if (ModelState.IsValid)
            {
                var data = viewModel.ToEntity();
                _rationItemCategoryService.UpdateRationItemCategory(data);
                return RedirectToAction("Index");
            }
            return View("Save", null);
        }


        [Route("delete")]
        [HttpPost]
        public HttpStatusCodeResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            RationItemCategory data = _rationItemCategoryService.GetRationItemCategoryById(id.GetValueOrDefault());
            if (data == null)
            {
                return HttpNotFound();
            }
            _rationItemCategoryService.DeleteRationItemCategory(data);

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
	}
}