using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tras.Core.Domain.Common;
using Tras.Core.Domain.Ration;
using Tras.Services.Configuration;
using Tras.Services.Ration;
using Tras.Web.Extensions;
using Tras.Web.Models.Ration;

namespace Tras.Web.Controllers.Ration
{
    [RoutePrefix("rationsubhead")]
    [Route("{action}")]
    public class RationSubHeadController : BaseController
    {
        private readonly IRationSubHeadService _rationSubHeadService;
        private readonly IRationHeadService _rationHeadService;


        public RationSubHeadController(IRationSubHeadService rationSubHeadService,IRationHeadService rationHeadService)
        {
            _rationSubHeadService = rationSubHeadService;
            _rationHeadService = rationHeadService;
            PageTitle = "Sub Heads";
        }
        [NonAction]
        private void FillDropdowns(RationSubHeadViewModel viewModel)
        {
            ViewBag.RationHeads = _rationHeadService.GetSelectList(viewModel.HeadId);
        }


        [Route("")]
        public ActionResult Index()
        {
            PageActionType = AppConstant.PageAction.List;
            SetPageInfo();
            var dataModel = _rationSubHeadService.GetSubHeads(20, 1);
            var viewModel = dataModel.ToMappedPagedList<RationSubHead, RationSubHeadViewModel>();
            return View(viewModel);
        }

        [Route("create")]
        public ActionResult Create()
        {
            PageActionType = AppConstant.PageAction.Create;
            SetPageInfo();
            var model = new RationSubHeadViewModel();
            FillDropdowns(model);
            return View("Save", model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(RationSubHeadViewModel viewModel)
        {
            PageActionType = AppConstant.PageAction.Create;
            SetPageInfo();
            if (viewModel != null)
            {
                var data = viewModel.ToEntity();
                _rationSubHeadService.InsertSubHead(data);
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
            var data = _rationSubHeadService.GetSubHeadById(id.GetValueOrDefault());

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
        public ActionResult Edit(RationSubHeadViewModel viewModel)
        {
            PageActionType = AppConstant.PageAction.Edit;
            SetPageInfo();
            if (ModelState.IsValid)
            {
                var data = viewModel.ToEntity();
                _rationSubHeadService.UpdateSubHead(data);
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

            RationSubHead data = _rationSubHeadService.GetSubHeadById(id.GetValueOrDefault());
            if (data == null)
            {
                return HttpNotFound();
            }

            _rationSubHeadService.DeleteSubHead(data);

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
	}
}