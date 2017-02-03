using System.Linq;
using System.Net;
using System.Web.Mvc;
using Tras.Core.Domain.Common;
using Tras.Core.Domain.Residence;
using Tras.Services.Residence;
using Tras.Web.Extensions;
using Tras.Web.Models.Residence;

namespace Tras.Web.Controllers.Residence
{
    [RoutePrefix("mess")]
    [Route("{action}")]
    public class MessController : BaseController
    {
        private readonly IMessService _messService;

        public MessController(IMessService messService)
        {
            _messService = messService;
            base.PageTitle = "Mess";
        }

        [Route("")]
        public ActionResult Index()
        {
            PageActionType=AppConstant.PageAction.List;
            SetPageInfo();
            var dataModel = _messService.GetMesses(AppConstant.PageSize, 1);
            var viewModel = dataModel.ToMappedPagedList<Mess, MessViewModel>();
            return View("Index",viewModel.ToList());
        }

        [Route("create")]
        public ActionResult Create()
        {
            PageActionType = AppConstant.PageAction.Create;
            SetPageInfo();
            var model = new MessViewModel();
            return View("Save",model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(MessViewModel viewModel)
        {
            PageActionType = AppConstant.PageAction.Create;
            SetPageInfo();
            if (viewModel != null)
            {
                var data = viewModel.ToEntity();
                _messService.InsertMess(data);
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
            var data = _messService.GetMessById(id.GetValueOrDefault());

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
        public ActionResult Edit(MessViewModel viewModel)
        {
            PageActionType = AppConstant.PageAction.Edit;
            SetPageInfo();
            if (ModelState.IsValid)
            {
                var data = viewModel.ToEntity();
                _messService.UpdateMess(data);
                return RedirectToAction("Index");
            }
            return View("Save", viewModel);
        }
	}
}