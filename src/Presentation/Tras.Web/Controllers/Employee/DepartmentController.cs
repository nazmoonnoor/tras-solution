using System.Net;
using System.Web.Mvc;
using Tras.Core.Domain.Common;
using Tras.Core.Domain.Employee;
using Tras.Services.Employee;
using Tras.Web.Extensions;
using Tras.Web.Models.Employee;

namespace Tras.Web.Controllers.Employee
{
    [RoutePrefix("department")]
    [Route("{action}")]
    public class DepartmentController : BaseController
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
            base.PageTitle = "Department";
        }
        [Route("")]
        public ActionResult Index()
        {
            PageActionType = AppConstant.PageAction.List;
            SetPageInfo();

            var dataList = _departmentService.GetDepartments(AppConstant.PageSize, 1);
            var modelList = dataList.ToMappedPagedList<Department, DepartmentViewModel>();
            return View(modelList);
        }

        [Route("create")]
        public ActionResult Create()
        {
            PageActionType = AppConstant.PageAction.Create;
            SetPageInfo();
            var model = new DepartmentViewModel();
            return View("Save", model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(DepartmentViewModel viewModel)
        {
            PageActionType = AppConstant.PageAction.Create;
            SetPageInfo();
            if (viewModel != null)
            {
                var data = viewModel.ToEntity();
                _departmentService.InsertDepartment(data);
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
            var data = _departmentService.GetDepartmentById(id.GetValueOrDefault());

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
        public ActionResult Edit(DepartmentViewModel viewModel)
        {
            PageActionType = AppConstant.PageAction.Edit;
            SetPageInfo();
            if (ModelState.IsValid)
            {
                var data = viewModel.ToEntity();
                _departmentService.UpdateDepartment(data);
                return RedirectToAction("Index");
            }
            return View("Save", viewModel);
        }
    }
}
