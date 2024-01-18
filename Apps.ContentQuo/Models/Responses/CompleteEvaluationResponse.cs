using Apps.ContentQuo.Dtos;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.ContentQuo.Models.Responses
{
    public class CompleteEvaluationResponse
    {
        [Display("ID")]
        public string Id { get; set; }

        [Display("Name")]
        public string Name { get; set; }

        [Display("Group ID")]
        public string GroupId { get; set; }

        [Display("Group name")]
        public string GroupName { get; set; }

        [Display("Workflow ID")]
        public string WorkflowId { get; set; }

        [Display("Workflow name")]
        public string WorkflowName { get; set; }

        [Display("Profile ID")]
        public string ProfileId { get; set; }

        [Display("Project ID")]
        public string ProjectId { get; set; }

        [Display("Source locale")]
        public string SourceLocale { get; set; }

        [Display("Target locale")]
        public string TargetLocale { get; set; }

        [Display("Assignees")]
        public IEnumerable<Assignee>? Assignees { get; set; }

        [Display("Issues")]
        public IEnumerable<IssueDto>? Issues { get; set; }

        [Display("Metrics")]
        public EvaluationMetricResponse Metrics { get; set; }

        [Display("Files")]
        public IEnumerable<BilingualFileDto>? BilingualFiles { get; set; }
    }
}
