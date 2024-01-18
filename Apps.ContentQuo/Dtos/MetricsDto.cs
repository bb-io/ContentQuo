using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.ContentQuo.Dtos
{
    public class MetricsDto
    {
        [JsonProperty("evaluationId")]
        public int EvaluationId { get; set; }

        [JsonProperty("evaluationName")]
        public string EvaluationName { get; set; }

        [JsonProperty("metrics")]
        public List<Metric> Metrics { get; set; }

        [JsonProperty("overallComment")]
        public string OverallComment { get; set; }

        [JsonProperty("qualityProfile")]
        public string QualityProfile { get; set; }

        //[JsonProperty("scope")]
        //public Scope Scope { get; set; }
    }

    public class Metric
    {
        [JsonProperty("grade")]
        public string Grade { get; set; }

        //[JsonProperty("issueCounts")]
        //public List<IssueCount> IssueCounts { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("qualityScore")]
        public double QualityScore { get; set; }

        //[JsonProperty("subGrades")]
        //public object SubGrades { get; set; }
    }
}
