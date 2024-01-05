using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.ContentQuo.Dtos
{
    public class ListIssuesDto
    {
        [JsonProperty("issues")]
        public List<IssueDto> Issues { get; set; }
    }
}
