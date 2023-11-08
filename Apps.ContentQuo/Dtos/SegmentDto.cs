using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.ContentQuo.Dtos
{
    public class SegmentDto
    {
        [JsonProperty("context")]
        public bool Context { get; set; }

        [Display("Count type")]
        [JsonProperty("countType")]
        public string CountType { get; set; }

        [Display("Diff ID")]
        [JsonProperty("diffId")]
        public string DiffId { get; set; }

        [Display("File ID")]
        [JsonProperty("fileId")]
        public string FileId { get; set; }

        [JsonProperty("filename")]
        public string Filename { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("locked")]
        public bool Locked { get; set; }

        [JsonProperty("match")]
        public int Match { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [Display("Source count")]
        [JsonProperty("sourceCount")]
        public int SourceCount { get; set; }

        [JsonProperty("target")]
        public string Target { get; set; }

        [Display("Target count")]
        [JsonProperty("targetCount")]
        public int TargetCount { get; set; }

        [Display("Update time")]
        [JsonProperty("updateTime")]
        public string UpdateTime { get; set; }

        [Display("Update type")]
        [JsonProperty("updateType")]
        public string UpdateType { get; set; }

        [Display("Update user Id")]
        [JsonProperty("updateUserId")]
        public string UpdateUserId { get; set; }

        [Display("Update user name")]
        [JsonProperty("updateUserName")]
        public string UpdateUserName { get; set; }
    }

}
