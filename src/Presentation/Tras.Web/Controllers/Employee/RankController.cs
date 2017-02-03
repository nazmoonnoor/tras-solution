using System.Net;
using System.Web.Mvc;
using Tras.Core.Domain.Common;
using Tras.Core.Domain.Employee;
using Tras.Services.Employee;
using Tras.Web.Extensions;
using Tras.Web.Models.Employee;

namespace Tras.Web.Controllers.Employee
{
    [RoutePrefix("rank")]
    [Route("{action}")]
    public class RankController : BaseController
    {
        private readonly IRankService _rankService;

        public RankController(IRankService rankService)
        {
            _rankService = rankService;
            base.PageTitle = "Rank";
        }

        // GET: /Rank/
        public ActionResult Index()
        {
            PageActionType = AppConstant.PageAction.List;
            SetPageInfo();
            var dataModel = _rankService.GetRanks(20, 1);
            var viewModel = dataModel.ToMappedPagedList<Rank, RankViewModel>();

            return View(viewModel);
        }

        [Route("create")]
        public ActionResult Create()
        {
            PageActionType = AppConstant.PageAction.Create;
            SetPageInfo();
            var model = new RankViewModel();
            return View("Save", model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(RankViewModel viewModel)
        {
            PageActionType = AppConstant.PageAction.Create;
            SetPageInfo();
            if (viewModel != null)
            {
                var data = viewModel.ToEntity();
                _rankService.InsertRank(data);
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
            var data = _rankService.GetRankById(id.GetValueOrDefault());

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
        public ActionResult Edit(RankViewModel viewModel)
        {
            PageActionType = AppConstant.PageAction.Edit;
            SetPageInfo();
            if (ModelState.IsValid)
            {
                var data = viewModel.ToEntity();
                _rankService.UpdateRank(data);
                return RedirectToAction("Index");
            }
            return View("Save", viewModel);
        }
    }
}
