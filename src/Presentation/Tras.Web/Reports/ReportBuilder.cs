using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tras.Web.Reports
{
    public class ReportBuilder
    {

        public Report GetReportObject(IEnumerable  reportData,string fileName, Report.ReportFormat formate = Report.ReportFormat.Pdf)
        {
            var report = new Report
            {
                Format = formate,
                FileName = fileName,
                ReportDataList = reportData
            };
            return report;
        }
    }
}