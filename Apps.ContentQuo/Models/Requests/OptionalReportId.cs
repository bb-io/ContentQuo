using Blackbird.Applications.Sdk.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.ContentQuo.Models.Requests
{
    public class OptionalReportId
    {
        [Display("Report ID", Description = "Use when your ContentQuo instance has customized generated reports. Default is 0")]
        public string? ReportId { get; set; }
    }
}
