using System.Linq;
using System.Net;
using System.Web.Mvc;
using Tras.Core.Domain.Common;
using Tras.Core.Domain.Ration;
using Tras.Services.Ration;
using Tras.Web.Extensions;
using Tras.Web.Models.Ration;

namespace Tras.Web.Controllers.Ration
{

    [RoutePrefix("rationhead")]
    [Route("{action}")]
    public class RationHeadController : BaseController
    {
        private readonly IRationHeadService _rationHeadService;

        public RationHeadController(IRationHeadService rationHeadService)
        {
            _rationHeadService = rationHeadService;
            PageTitle = "Ration Heads";
        }
       

        [Route("")]
        public ActionResult Index()
        {
            PageActionType = AppConstant.PageAction.List;
            SetPageInfo();

            var dataList = _rationHeadService.GetHeads();
            var modelList = dataList.ToList().ToMappedList<RationHead, RationHeadViewModel>();
            return View(modelList);
        }

        [Route("create")]
        public ActionResult Create()
        {
            PageActionType = AppConstant.PageAction.Create;
            SetPageInfo();
            var model = new RationHeadViewModel();
            return View("Save", model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(RationHeadViewModel viewModel)
        {
            PageActionType = AppConstant.PageAction.Create;
            SetPageInfo();
            if (viewModel != null)
            {
                var data = viewModel.ToEntity();
                _rationHeadService.InsertHead(data);
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
            var data = _rationHeadService.GetHeadById(id.GetValueOrDefault());

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
        public ActionResult Edit(RationHeadViewModel viewModel)
        {
            PageActionType = AppConstant.PageAction.Edit;
            SetPageInfo();
            if (ModelState.IsValid)
            {
                var data = viewModel.ToEntity();
                _rationHeadService.UpdateHead(data);
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

            RationHead data = _rationHeadService.GetHeadById(id.GetValueOrDefault());
            if (data == null)
            {
                return HttpNotFound();
            }

            _rationHeadService.DeleteHead(data);

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
	}
}