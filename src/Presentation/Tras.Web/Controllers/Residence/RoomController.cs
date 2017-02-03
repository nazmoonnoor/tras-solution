using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tras.Core.Domain.Common;
using Tras.Core.Domain.Residence;
using Tras.Services.Residence;
using Tras.Web.Extensions;
using Tras.Web.Models.Ration;
using Tras.Web.Models.Residence;

namespace Tras.Web.Controllers.Residence
{
    [RoutePrefix("room")]
    [Route("{action}")]
    public class RoomController : BaseController
    {
        private readonly IRoomService _roomService;
        private readonly IMessService _messService;

        public RoomController( IRoomService roomService,IMessService messService)
        {
            _roomService = roomService;
            _messService = messService;
            base.PageTitle = "Room";
        }

        [NonAction]
        private void FillDropdowns(RoomViewModel viewModel)
        {
            ViewBag.Messes = _messService.GetSelectList(viewModel.MessId);
        }
        [Route("")]
        public ActionResult Index()
        {
            PageActionType = AppConstant.PageAction.List;
            SetPageInfo();
            var dataModel = _roomService.GetRooms(AppConstant.PageSize, 1);
            var viewModel = dataModel.ToMappedPagedList<Room, RoomViewModel>();
            return View(viewModel.ToList());

        }

       

        [Route("create")]
        public ActionResult Create()
        {
            PageActionType = AppConstant.PageAction.Create;
            SetPageInfo();
            var model = new RoomViewModel();
            FillDropdowns(model);
            return View("Save", model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(RoomViewModel viewModel)
        {
            PageActionType = AppConstant.PageAction.Create;
            SetPageInfo();
            if (viewModel != null)
            {
                var data = viewModel.ToEntity();
                _roomService.InsertRoom(data);
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
            var data = _roomService.GetRoomById(id.GetValueOrDefault());

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
        public ActionResult Edit(RoomViewModel viewModel)
        {
            PageActionType = AppConstant.PageAction.Edit;
            SetPageInfo();
            if (ModelState.IsValid)
            {
                var data = viewModel.ToEntity();
                _roomService.UpdateRoom(data);
                return RedirectToAction("Index");
            }

            return View("Save", viewModel);
        }
	}
}