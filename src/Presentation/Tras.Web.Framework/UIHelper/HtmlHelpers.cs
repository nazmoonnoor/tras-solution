using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Tras.Core.Helpers;

namespace Tras.Web.Framework.UIHelper
{
    public static class HtmlHelpers
    {
        private static readonly IObjectExtender Extender = new ObjectExtender();

        public static MvcHtmlString EditorContainerFor<TModel, TValue>(this HtmlHelper<TModel> html,
            Expression<Func<TModel, TValue>> propertyExpression, string templateName = "", string htmlFieldName = "",
            object additionalViewData = null, IDictionary<string, object> htmlAttributes = null)
        {
            var metadata = ModelMetadata.FromLambdaExpression(propertyExpression, html.ViewData);
            
            if (string.IsNullOrWhiteSpace(templateName))
            {
                if (!string.IsNullOrWhiteSpace(metadata.TemplateHint))
                {
                    templateName = metadata.TemplateHint;
                }
                else if (metadata.ModelType.FullName.Contains("System.DateTime"))
                {
                    templateName = "DateTime";
                }
                else if (metadata.ModelType.FullName.Contains("System.String"))
                {
                    templateName = "String";
                }
                else if (metadata.ModelType.FullName.Contains("System.Int32")
                    || metadata.ModelType.FullName.Contains("System.Float")
                    || metadata.ModelType.FullName.Contains("System.Decimal"))
                {
                    templateName = "Number";
                }
            }

            var propertyName = html.NameFor(propertyExpression).ToString();
            var editorAttributes = html.GetUnobtrusiveValidationAttributes(propertyName, metadata);

            editorAttributes.Merge(htmlAttributes);
            
            var extendedViewData = Extender.Extend(additionalViewData, new { htmlAttributes = editorAttributes });


            return html.EditorFor(propertyExpression, templateName, htmlFieldName, extendedViewData);
        }

        
    }
}
