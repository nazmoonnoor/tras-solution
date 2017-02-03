using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tras.Services.Configuration;
using Tras.Services.Distribution;
using Tras.Services.Employee;
using Tras.Services.Process;
using Tras.Web.Models.Process.MessDispersion;

namespace Tras.Web.Controllers.Process
{
    [RoutePrefix("mess-dispersion")]
    [Route("{action}")]
    public class MessDispersionController : Controller
    {
        private readonly IPersonService _personService;
        private readonly ILookupService _lookupService;
        private readonly IDispersionService _dispersionService;
        private readonly IDispersionRecordService _dispersionRecordService;

        public MessDispersionController(IPersonService personService, 
            ILookupService lookupService, 
            IDispersionService dispersionService, 
            IDispersionRecordService dispersionRecordService)
        {
            _personService = personService;
            _dispersionService = dispersionService;
            _dispersionRecordService = dispersionRecordService;
            _lookupService = lookupService;
        }

        [Route("")]
        public ActionResult Index()
        {
            var viewModel = new MessDispersionUIViewModel();

            return View(viewModel);
        }
    }
}