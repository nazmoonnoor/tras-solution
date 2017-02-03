using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Tras.Web.Framework.UIHelper
{
    public static class HtmlWrapperHelpers
    {
        public static HtmlWrapperContent BeginWapperContent(this HtmlHelper htmlHelper, String title, String description, Int32 columnWidth = 12)
        {
            return new HtmlWrapperContent(htmlHelper.ViewContext, title, description, columnWidth);
        }
        public static HtmlWrapperContent BeginWapperContent(this HtmlHelper htmlHelper,Int32 columnWidth = 12)
        {
            return new HtmlWrapperContent(htmlHelper.ViewContext, null, null, columnWidth);
        }
    }
}
