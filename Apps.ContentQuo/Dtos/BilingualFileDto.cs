using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.ContentQuo.Dtos
{
    public class BilingualFileDto
    {
        [JsonProperty("countSegments")]
        public int CountSegments { get; set; }

        [JsonProperty("countWords")]
        public int CountWords { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("fid")]
        public string Fid { get; set; }

        [JsonProperty("fileUri")]
        public string FileUri { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
