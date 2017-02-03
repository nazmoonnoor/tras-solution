using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Tras.Services.Process;
using Tras.Services.Ration;

namespace Tras.Web.Controllers.Ration
{
    [RoutePrefix("packageitem")]
    [Route("{action}")]
    public class PackageItemController : BaseController
    {
        private readonly IPackageItemService _packageItemService;
        private readonly IPackageService _packageService;
        private readonly IRationDemandService _rationDemandService;

        public PackageItemController(IPackageItemService packageItemService,IPackageService packageService,IRationDemandService rationDemandService)
        {
            _packageItemService = packageItemService;
            _packageService = packageService;
            _rationDemandService = rationDemandService;
            PageTitle = "Package Item ";
        }

        [Route("")]
        public ActionResult Index()
        {
            //input
            //ration subHead 
            //ration item category
            
            //return View();

            //Find out person family information for each package 
            //var abc = _rationDemandService.CalculateByItems(4,1,7);

            return null;
        }
	}
}