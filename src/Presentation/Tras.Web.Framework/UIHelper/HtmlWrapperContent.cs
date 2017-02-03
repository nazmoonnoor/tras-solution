using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Tras.Web.Framework.UIHelper
{
    /// <summary>
    /// Wrapper container
    /// </summary>
    /// <remarks>
    /// We make it IDIsposable so we can use it like Html.BeginForm and when the @using(){} block has ended,
    /// the end of the widget's content is output.
    /// </remarks>
    public class HtmlWrapperContent : IDisposable
    {
        #region CTor

        // store some references for ease of use
        private readonly ViewContext _viewContext;
        private readonly System.IO.TextWriter _textWriter;
        private bool _hasTitle;
        /// <summary>
        /// Initialize the box by passing it the view context (so we can
        /// reference the stream writer) Then call the BeginWrapper method
        /// to begin the output of the wrapper
        /// </summary>
        /// <param name="viewContext">Reference to the viewcontext</param>
        /// <param name="title">Title of the wrapper</param>
        /// <param name="description">Description of the wrapper</param>
        /// <param name="columnWidth">Width of the wrapper (column layout)</param>
        public HtmlWrapperContent(ViewContext viewContext, String title, String description, Int32 columnWidth)
        {
            if (viewContext == null)
                throw new ArgumentNullException("viewContext");
            if (columnWidth < 1 || columnWidth > 12)
                throw new ArgumentOutOfRangeException("columnWidth", "Value must be from 1-12");

            this._viewContext = viewContext;
            this._textWriter = this._viewContext.Writer;
            
            this.BeginWrapper(title, description, columnWidth);
        }

        #endregion

        #region Wrapper rendering

        /// <summary>
        /// Outputs the opening HTML for the wrapper
        /// </summary>
        /// <param name="title">Title of the wrapper</param>
        /// <param name="description">Title of the wrapper</param>
        /// <param name="columnWidth">Wrapper width (columns layout)</param>
        private void BeginWrapper(String title, String description, Int32 columnWidth)
        {
            if (!string.IsNullOrWhiteSpace(title))
            {
                _hasTitle = true;
                title = HttpUtility.HtmlDecode(title);
            }

            var html = new System.Text.StringBuilder();
            if (_hasTitle)
            {
                html.AppendFormat("<div class=\"wrapper wrapper-content animated fadeInRight\">").AppendLine();
                html.AppendFormat("<div class=\"row\">").AppendLine();
                html.AppendFormat("<div class=\"col-lg-{0}\">", columnWidth).AppendLine();
                html.AppendFormat("<div class=\"ibox float-e-margins\">").AppendLine();
                html.AppendFormat("<div class=\"ibox-title\"><h5>{0} <small>{1}</small></h5></div>", title, description)
                    .AppendLine();
                html.AppendFormat("<div class=\"ibox-content\">").AppendLine();
                this._textWriter.WriteLine(html.ToString());
            }
            else
            {
                html.AppendFormat("<div class=\"wrapper wrapper-content animated fadeInUp\">").AppendLine();
                html.AppendFormat("<div class=\"ibox\">").AppendLine();
                html.AppendFormat("<div class=\"ibox-content\">").AppendLine();
                this._textWriter.WriteLine(html.ToString());
            }
        }

        /// <summary>
        /// Outputs the closing HTML for the wrapper
        /// </summary>
        private void EndWrapper()
        {
            if (_hasTitle)
            {
                this._textWriter.WriteLine("</div></div></div></div></div>");
            }
            else
            {
                this._textWriter.WriteLine("</div></div></div>");
            }
        }

        #endregion

        #region IDisposable

        private Boolean _isDisposed;

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(Boolean disposing)
        {
            if (!this._isDisposed)
            {
                this._isDisposed = true;
                this.EndWrapper();
                this._textWriter.Flush();
            }
        }

        #endregion
    }
}
