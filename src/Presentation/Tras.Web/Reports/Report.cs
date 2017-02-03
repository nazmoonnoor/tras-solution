using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace Tras.Web.Reports
{
    public class Report
    {
        public enum ReportFormat
        {
            Pdf = 1,
            Word = 2,
            Excel = 3
        }
        public ReportFormat Format { get; set; }
        public string ContentType
        {
            get
            {
                switch (this.Format)
                {
                    case ReportFormat.Word:
                        return "application/doc";
                    case ReportFormat.Excel:
                        return "application/vnd.ms-excel";
                    default:
                        return "application/pdf";
                }
            }
        }
        //CrystalDecisions.Shared.ExportFormatType.WordForWindows
        public ExportFormatType ReportFormatType
        {
            get
            {
                switch (this.Format)
                {
                    case ReportFormat.Word:
                        return ExportFormatType.WordForWindows;
                    case ReportFormat.Excel:
                        return ExportFormatType.Excel;
                    default:
                        return ExportFormatType.PortableDocFormat;
                }
            }
        }
        public DataSet ReportDataSet { get; set; }
        public DataSet ReportDataTable { get; set; }
        public IEnumerable ReportDataList { get; set; }
        public string FileName { get; set; }
        public Stream RenderReport()
        {
            ReportClass rptH = new ReportClass { FileName = System.Web.HttpContext.Current.Server.MapPath(FileName) };
            rptH.Load();
            rptH.SetDataSource(ReportDataList);
            // Parameter Section 
            var stream = rptH.ExportToStream(this.ReportFormatType);
            //
            //stream.Position = 0;
           

            return stream;
        }
    }
}