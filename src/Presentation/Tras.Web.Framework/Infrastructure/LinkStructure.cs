using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;

namespace Tras.Web.Framework.Infrastructure
{
    public class LinkStructure
    {
        public string LinkText { get; set; }
        public string InnerHtml { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public object RouteValue { get; set; }
        public object HtmlAttributesObject { get; set; }
        public IDictionary<string, object> HtmlAttributes { get; set; }

        public LinkStructure(string linkText, string actionName, string controllerName, object routeValue, object htmlAttributes)
        {
            LinkText = linkText;
            ActionName = actionName;
            ControllerName = controllerName;
            RouteValue = routeValue;
            HtmlAttributesObject = htmlAttributes;
        }

        public LinkStructure(string actionName, string controllerName, string innerHtml, object routeValue, IDictionary<string, object> htmlAttributes)
        {
            ActionName = actionName;
            ControllerName = controllerName;
            InnerHtml = innerHtml;
            RouteValue = routeValue;
            HtmlAttributes = htmlAttributes;
        }
    }
}
