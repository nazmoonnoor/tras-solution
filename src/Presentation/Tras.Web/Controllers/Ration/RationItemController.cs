using System.Net;
using System.Web.Mvc;
using Tras.Core.Domain.Common;
using Tras.Core.Domain.Ration;
using Tras.Services.Ration;
using Tras.Web.Extensions;
using Tras.Web.Models.Ration;

namespace Tras.Web.Controllers.Ration
{
    [RoutePrefix("rationitem")]
    [Route("{action}")]
    public class RationItemController : BaseController
    {
        
        private readonly IRationItemService _rationItemService;
        private readonly IRationItemCategoryService _rationItemCategoryService;


        public RationItemController(IRationItemService rationItemService, IRationItemCategoryService rationItemCategoryService)
        {
            _rationItemService = rationItemService;
            _rationItemCategoryService = rationItemCategoryService;
            PageTitle = "Ration Item";
        }
        [NonAction]
        private void FillDropdowns(RationItemViewModel viewModel)
        {
            ViewBag.RationItemCategory = _rationItemCategoryService.GetSelectList(viewModel.CategoryId);
           
        }


        [Route("")]
        public ActionResult Index()
        {
            PageActionType = AppConstant.PageAction.List;
            SetPageInfo();
            var dataModel = _rationItemService.GetRationItems(20, 1);
            var viewModel = dataModel.ToMappedPagedList<RationItem, RationItemViewModel>();
            return View(viewModel);
        }

        [Route("create")]
        public ActionResult Create()
        {
            PageActionType = AppConstant.PageAction.Create;
            SetPageInfo();
            var model = new RationItemViewModel();
            FillDropdowns(model);
            return View("Save", model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(RationItemViewModel viewModel)
        {
            PageActionType = AppConstant.PageAction.Create;
            SetPageInfo();
            if (viewModel != null)
            {
                var data = viewModel.ToEntity();
                _rationItemService.InsertRationItem(data);
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
            var data = _rationItemService.GetRationItemById(id.GetValueOrDefault());

            if (data == null)
            {
                return HttpNotFound();
            }
            PageActionType = AppConstant.PageAction.Edit;
            SetPageInfo();
            var model = data.ToModel();
            FillDropdowns(model);
            return View("Save", model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(RationItemViewModel viewModel)
        {
            PageActionType = AppConstant.PageAction.Edit;
            SetPageInfo();
            if (ModelState.IsValid)
            {
                var data = viewModel.ToEntity();
                _rationItemService.UpdateRationItem(data);
                return RedirectToAction("Index");
            }
            return View("Save", viewModel);
        }

        [Route("delete")]
        [HttpPost]
        public HttpStatusCodeResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            RationItem data = _rationItemService.GetRationItemById(id.GetValueOrDefault());
            if (data == null)
            {
                return HttpNotFound();
            }

            _rationItemService.DeleteRationItem(data);

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
	}
}