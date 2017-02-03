using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Tras.Web.Framework.UIHelper
{
    public static class ButtonHelpers
    {
        public static MvcHtmlString Button(this HtmlHelper helper,
                                     string id, string innerHtml,
                                     object htmlAttributes)
        {
            return Button(helper, id, innerHtml,
                          HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes = null)
            );
        }

        public static MvcHtmlString Button(this HtmlHelper helper,
                                           string id, string innerHtml,
                                           IDictionary<string, object> htmlAttributes = null)
        {
            var builder = new TagBuilder("button");
            builder.Attributes["id"] = id;
            builder.InnerHtml = innerHtml;
            builder.MergeAttributes(htmlAttributes);
            return MvcHtmlString.Create(builder.ToString());
        }

        public static MvcHtmlString SubmitInput(this HtmlHelper helper, string value,
                              string @class, IDictionary<string, object> htmlAttributes = null)
        {
            var input = new TagBuilder("input");
            input.Attributes.Add("type", "submit");
            input.Attributes.Add("value", value);
            input.Attributes.Add("class", @class);
            input.MergeAttributes(htmlAttributes);

            return MvcHtmlString.Create(input.ToString());
        }

        public static MvcHtmlString SubmitButton(this HtmlHelper helper, string value,
                              string @class, string innerHtml = "", IDictionary<string, object> htmlAttributes = null)
        {
            var input = new TagBuilder("button");
            input.Attributes.Add("type", "submit");
            input.Attributes.Add("value", value);
            input.InnerHtml = innerHtml;
            input.Attributes.Add("class", @class);
            input.MergeAttributes(htmlAttributes);

            return MvcHtmlString.Create(input.ToString());
        }

        public static string ActionButton(this HtmlHelper helper, string value,
                              string action, string controller, object routeValues = null)
        {
            var a = (new UrlHelper(helper.ViewContext.RequestContext))
                        .Action(action, controller, routeValues);

            var form = new TagBuilder("form");
            form.Attributes.Add("method", "get");
            form.Attributes.Add("action", a);

            var input = new TagBuilder("input");
            input.Attributes.Add("type", "submit");
            input.Attributes.Add("value", value);

            form.InnerHtml = input.ToString(TagRenderMode.SelfClosing);

            return form.ToString(TagRenderMode.Normal);
        }

        public static MvcHtmlString ActionLinkHtml(this HtmlHelper helper, string action, string controller, string innerHtml, 
                            object routeValues = null, IDictionary<string, object> htmlAttributes = null)
        {
            var a = (new UrlHelper(helper.ViewContext.RequestContext))
                        .Action(action, controller, routeValues);
            var tag = new TagBuilder("a");
            tag.MergeAttribute("href", a);
            tag.InnerHtml = innerHtml;
            tag.MergeAttributes(htmlAttributes);
            return new MvcHtmlString(tag.ToString(TagRenderMode.Normal));
        }
    }
}
