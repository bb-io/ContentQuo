using Apps.ContentQuo.DataSourceHandler;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.ContentQuo.Models.Requests
{
    public class GetEvaluationRequest
    {
        [Display("Evaluation")]
        [DataSource(typeof(EvaluationDataHandler))]
        public string Id { get; set; }
    }
}
