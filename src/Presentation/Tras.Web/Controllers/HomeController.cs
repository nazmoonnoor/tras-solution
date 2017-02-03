using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tras.Data;
using Tras.Services.Report;
using Tras.Web.Reports;

namespace Tras.Web.Controllers
{
    [RoutePrefix("")]
    [Route("{action}")]
    public class HomeController : Controller
    {
        [Route("")]
        [Route("index")]
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            var ctx = new TrasObjectContext();
           var categories = ctx.RationItemCategories.ToList();
            return View();
        }

        [Route("csssample")]
        public ActionResult CssSample()
        {
            ViewBag.Title = "Css Sample";
            return View();
        }

        [Route("notfound")]
        public ActionResult NotFound()
        {
            return View();
        }
        [Route("invoice")]
        public ActionResult InvoiceMemo()
        {
            var memoService = new InvoiceMemoService();
            var data = memoService.PaymentRationInvoice(1, "4604-2015");
            var reportBuilder = new ReportBuilder();
            var fileNmae = "~/Reports/RptFiles/Invoice.rpt";
            var report = reportBuilder.GetReportObject(data,fileNmae);
            var rr = report.RenderReport();
            var rootPath = HttpContext.Request.PhysicalApplicationPath;

            using (var memoryStream = new MemoryStream())
            {
                rr.CopyTo(memoryStream);
                var rr1 = memoryStream.ToArray();
                
                ViewData["PDF"] = rr;
            }



            return View("PDFView");
        }
    }
}
