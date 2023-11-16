﻿using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Apps.ContentQuo.Models.Requests
{
    public class CreateEvaluationRequest
    {
        [Display("Name")]
        [JsonProperty("name")]
        public string Name { get; set; }

        // https://apac1.contentquo.com/api/v1/docs#tag/users/operation/getusergroups when implemented
        [Display("Group")]
        [JsonProperty("groupID")]
        public string? GroupID { get; set; }

        [Display("Source locale")]
        [JsonProperty("srcLocale")]
        public string SrcLocale { get; set; }

        [Display("Target locale")]
        [JsonProperty("tgtLocale")]
        public string TgtLocale { get; set; }

        // Data source endpoint needed
        [Display("Project")]
        [JsonProperty("projectID")]
        public string? ProjectID { get; set; }

        // Data source endpoint needed
        [Display("Workflow")]
        [JsonProperty("workflowID")]
        public string? WorkflowID { get; set; }

        // https://apac1.contentquo.com/api/v1/docs#tag/quality_profiles/paths/~1qualityProfiles/get when implemented
        [Display("Profile")]
        [JsonProperty("profileID")]
        public string? ProfileID { get; set; }
    }
}
