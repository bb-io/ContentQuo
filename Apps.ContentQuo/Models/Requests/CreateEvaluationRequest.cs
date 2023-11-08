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
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("groupID")]
        public string? GroupID { get; set; }

        [JsonProperty("srcLocale")]
        public string SrcLocale { get; set; }

        [JsonProperty("tgtLocale")]
        public string TgtLocale { get; set; }

        [JsonProperty("projectID")]
        public string? ProjectID { get; set; }

        [JsonProperty("workflowID")]
        public string? WorkflowID { get; set; }

        [JsonProperty("profileID")]
        public string? ProfileID { get; set; }
    }
}
