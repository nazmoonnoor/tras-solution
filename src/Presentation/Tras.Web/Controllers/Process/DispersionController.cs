using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Tras.Core.Domain.Common;
using Tras.Core.Domain.Distribution;
using Tras.Core.Helpers;
using Tras.Services.Configuration;
using Tras.Services.Employee;
using Tras.Services.Process;
using Tras.Services.Process.Dispersion;
using Tras.Services.Ration;
using Tras.Services.Distribution;
using Tras.Services.Report;
using Tras.Web.Extensions;
using Tras.Web.Models.Process.Dispersion;
using Tras.Web.Reports;

namespace Tras.Web.Controllers.Process
{
    [RoutePrefix("dispersion")]
    [Route("{action}")]
    public class DispersionController : BaseController
    {
        private readonly IPersonService _personService;
        private readonly ILookupService _lookupService;
        private readonly IDispersionService _dispersionService;
        private readonly IDispersionRecordService _dispersionRecordService;

        public DispersionController(IPersonService personService, 
            ILookupService lookupService, 
            IDispersionService dispersionService, 
            IDispersionRecordService dispersionRecordService)
        {
            _personService = personService;
            _dispersionService = dispersionService;
            _dispersionRecordService = dispersionRecordService;
            _lookupService = lookupService;
        }

        private void FillRadioButton()
        {
            ViewBag.MonthRange = _lookupService.GetSelectList(AppConstant.LookupType.Month_Range, "1", false);
        }

        [Route("")]
        public ActionResult Index()
        {
            FillRadioButton();
            var model = new DispersionPersonViewModel
            {
                FromMonth = DateTime.Now.ToString("MM-yyyy")//,
                //ToMonth = DateTime.Now.ToString("MM-yyyy")
            };
            return View(model);
        }

        [HttpPost]
        [Route("persondetail")]
        public ActionResult PersonDetail(string personalNo)
        {
            var dataModel = _personService.GetPersonByNo(personalNo);
            if (dataModel == null)
            {
                return Content("<div class='no-profile'>No profile found</div>");
            }
            var viewModel = dataModel.ToModel();
            return PartialView("_Profile", viewModel);
        }

        [HttpPost]
        [Route("packagedetail")]
        public ActionResult PackageDetail(DispersionPersonViewModel dispersion)
        {
            Session[typeof (DispersionViewModel).Name] = null;

            string[] fromMonth = !string.IsNullOrWhiteSpace(dispersion.FromMonth) ? dispersion.FromMonth.Split('-') : new List<string>().ToArray();
            string[] toMonth = !string.IsNullOrWhiteSpace(dispersion.ToMonth) ? dispersion.ToMonth.Split('-') : new List<string>().ToArray();

            DateTime fromDate = DateTime.MinValue;
            DateTime toDate = DateTime.MinValue;

            var rationMonths = new List<RationMonth>();

            if (fromMonth.Length == 2)
            {
                fromDate = new DateTime(fromMonth[1].ToInt(), fromMonth[0].ToInt(), 1);
            }

            if (toMonth.Length == 2)
            {
                toDate = new DateTime(toMonth[1].ToInt(), toMonth[0].ToInt(), 1).AddMonths(1).AddDays(-1);
            }
            else
            {
                toDate = fromDate.AddMonths(1).AddDays(-1);
            }

            var totalDays = (toDate - fromDate).TotalDays + 1;

            var dataModel = _dispersionService.CalculateByItems(dispersion.PersonId, (int)totalDays);
            if (dataModel == null)
            {
                return Json("");
            }

            var viewModel = new DispersionViewModel
            {
                Person = dataModel.Person.ToModel(),
                Package = dataModel.Package.ToModel(),
                FoodItems = dataModel.FoodItems,
                GrossPrice = dataModel.GrossPrice
            };

            Session[typeof(DispersionViewModel).Name] = viewModel;
            return PartialView("_PackageInfo", viewModel);
        }

        [HttpPost]
        [Route("finalizedispersion")]
        public ActionResult FinalizeDispersion(int personId)
        {
            var dispersionModel = Session[typeof(DispersionViewModel).Name] as DispersionViewModel;

            if (dispersionModel != null && personId == dispersionModel.Person.PersonId)
            {
                //TODO: must be changed by user Id after integration user identity 
                var gg = DateTime.Now.ToString("mm-yyyy");
                var dispersionRecode = new DispersionRecord
                {
                    PersonId = personId,
                    TransactionType = (int)AppConstant.TransactionType.RationHandOut,
                    InvoiceNo = personId + '-' + DateTime.Now.ToString("mm-yyyy"),
                    InvoiceDate = DateTime.Now,
                    InvoiceCreatedBy = personId,
                    FromDate = DateTime.Now,
                    ToDate = DateTime.Now,
                    Deleted = false,
                    DeliveredDate = DateTime.Now
                };

                var itemList = dispersionModel.FoodItems.Select(i => new DispersionItemRecord
                {
                    ItemId = i.ItemId,
                    Quantity = (double)i.TotalQuantityInKg,
                    Price = (double)i.TotalPrice
                });
                
                _dispersionRecordService.ExecuteCommandScope(dispersionRecode, itemList);

                Session[typeof(DispersionViewModel).Name] = null;

                return Json(new { result = "success" }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { result = "error" }, JsonRequestBehavior.AllowGet);
        }

    }
}