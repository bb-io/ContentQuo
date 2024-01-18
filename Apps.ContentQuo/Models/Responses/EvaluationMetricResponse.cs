using Blackbird.Applications.Sdk.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.ContentQuo.Models.Responses
{
    public class EvaluationMetricResponse
    {
        [Display("Grade")]
        public string? Grade { get; set; }

        [Display("Name")]
        public string? Name { get; set; }

        [Display("Quality score")]
        public int QualityScore { get; set; }
    }
}
