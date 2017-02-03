using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tras.Core.Domain.Common;
using Tras.Core.Domain.Configuration;

namespace Tras.Web.Controllers
{
    public class BaseController : Controller
    {
        public string PageTitle { get; set; }
        public string PageAction { get; set; }
        public AppConstant.PageAction PageActionType { get; set; }

        public PageInfo GetPageInfo()
        {
            switch (PageActionType)
            {
                case AppConstant.PageAction.Create:
                    PageAction = "Add New";
                    break;

                case AppConstant.PageAction.Edit:
                    PageAction = "Edit";
                    break;

                case AppConstant.PageAction.List:
                    PageAction = "List";
                    break;

                case AppConstant.PageAction.Detail:
                    PageAction = "Detail";
                    break;
            }
            return new PageInfo
            {
                Title = string.Format("{0} | {1}", PageAction, PageTitle),
                PageTitle = PageTitle,
                PageAction = PageAction
            };
        }

        public void SetPageInfo()
        {
            var pageInfo = GetPageInfo();
            ViewBag.PageInfo = pageInfo;
            ViewBag.Title = pageInfo.Title;
            ViewBag.PageAction = PageActionType;
        }

    }
}