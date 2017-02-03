using System.Web.Mvc;
using AutoMapper;
using Tras.Core.Domain.Configuration;
using Tras.Services.Configuration;
using Tras.Web.Extensions;
using Tras.Web.Models;
using Tras.Web.Models.Configuration;

namespace Tras.Web.Controllers
{
    [RoutePrefix("lookup")]
    [Route("{action=index}")]
    public class Lookup2Controller : Controller
    {
        private readonly ILookupService _lookupService;

        public Lookup2Controller(ILookupService lookupService)
        {
            _lookupService = lookupService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [Route("getbyid/{lookupId}")]
        public JsonResult GetById(int lookupId)
        {
            var lookup = _lookupService.GetLookupById(lookupId);
            var model = lookup.MapTo<Lookup, LookupModel>();
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [Route("getlookups/{pageIndex?}/{searchKey?}")]
        public JsonResult GetLookups(int pageIndex, string searchKey="")
        {
            var lookups = _lookupService.GetAllLookups(6, pageIndex);
            var models = lookups.ToMappedPagedList<Lookup, LookupModel>();
            return Json(models, JsonRequestBehavior.AllowGet);
        }

        [Route("addnew")]
        public JsonResult AddNew(LookupModel lookupModel)
        {
            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
            }

            Mapper.CreateMap<LookupModel, Lookup>();
            var lookup = lookupModel.MapTo<LookupModel, Lookup>();
            _lookupService.InsertLookup(lookup);
            
            return Json(new{id=lookupModel.LookupId}, JsonRequestBehavior.AllowGet);
        }

        [Route("edit/{id}")]
        public JsonResult Edit(int id, LookupModel lookupModel)
        {
            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
            }
            if (id != lookupModel.LookupId)
            {
                //return BadRequest();
            }
            var lookup = _lookupService.GetLookupById(id);
            Mapper.CreateMap<LookupModel, Lookup>();
            lookupModel.MapTo<LookupModel, Lookup>(lookup);
            _lookupService.UpdateLookup(lookup);

            return Json(new { id = lookupModel.LookupId }, JsonRequestBehavior.AllowGet);
        }

        [Route("delete/{id}")]
        public JsonResult Delete(int id)
        {
            var lookup = _lookupService.GetLookupById(id);
            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
            }
            if (id != lookup.LookupId)
            {
                //return BadRequest();
            }
            
            _lookupService.DeleteLookup(lookup);

            return Json(new { id = lookup.LookupId }, JsonRequestBehavior.AllowGet);
        }
    }
}