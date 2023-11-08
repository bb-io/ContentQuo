using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.ContentQuo.Dtos
{
    public class IssueDto
    {
        [JsonProperty("categories")]
        public List<Category> Categories { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("fileName")]
        public string FileName { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [Display("Segment ID")]
        [JsonProperty("segmentId")]
        public string SegmentId { get; set; }

        [JsonProperty("severity")]
        public string Severity { get; set; }

        [Display("Status name")]
        [JsonProperty("statusName")]
        public StatusName StatusName { get; set; }
    }

    public class Category
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class StatusName
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
