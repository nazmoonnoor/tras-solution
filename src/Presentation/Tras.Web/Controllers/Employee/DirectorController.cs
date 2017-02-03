using System.Net;
using System.Web.Mvc;
using Tras.Core.Domain.Common;
using Tras.Core.Domain.Employee;
using Tras.Services.Employee;
using Tras.Web.Extensions;
using Tras.Web.Models.Employee;

namespace Tras.Web.Controllers.Employee
{
    [RoutePrefix("director")]
    [Route("{action}")]
    public class DirectorController : BaseController
    {
        private readonly IDirectorService _directorService;
        public DirectorController(IDirectorService directorService)
        {
            _directorService = directorService;
            base.PageTitle = "Director";
        }

        [Route("")]
        public ActionResult Index()
        {
            PageActionType = AppConstant.PageAction.List;
            SetPageInfo();

            var dataModel = _directorService.GetDirectors(20, 1);
            var viewModel = dataModel.ToMappedPagedList<Director, DirectorModel>();
            return View(viewModel);
        }

        [Route("create")]
        public ActionResult Create()
        {
            PageActionType = AppConstant.PageAction.Create;
            SetPageInfo();
            var model = new DirectorModel();
            return View("Save", model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(DirectorModel model)
        {
            PageActionType = AppConstant.PageAction.Create;
            SetPageInfo();
            if (model != null)
            {
                var data = model.ToEntity();
                _directorService.InsertDirectory(data);
                return RedirectToAction("Index");

            }
            return View("Save", model);
        }

        [Route("edit")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var data = _directorService.GetDirectorById(id.GetValueOrDefault());

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
        public ActionResult Edit(DirectorModel model)
        {
            PageActionType = AppConstant.PageAction.Edit;
            SetPageInfo();
            if (ModelState.IsValid)
            {
                var data = model.ToEntity();
                _directorService.UpdateDirector(data);
                return RedirectToAction("Index");
            }
            return View("Save", model);
        }
    }
}
