using Blackbird.Applications.Sdk.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.ContentQuo.Models.Requests
{
    public class AssignWorkflowStepRequest
    {
        [Display("Step ID")]
        public string StepId { get; set; }

        [Display("User ID")]
        public string UserId { get; set; }
    }
}
