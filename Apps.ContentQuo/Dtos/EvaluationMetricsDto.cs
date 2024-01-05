using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.ContentQuo.Dtos
{
    public class EvaluationMetricsDto
    {
        [JsonProperty("evaluationName")]
        public string EvaluationName { get; set; }

        [JsonProperty("overallComment")]
        public string OverallComment { get; set; }

        [JsonProperty("qualityProfile")]
        public string QualityProfile { get; set; }

        [JsonProperty("scope")]
        public MetricScope Scope { get; set; }

    }

    public class MetricScope
    {
        [JsonProperty("fileCount")]
        public int FileCount { get; set; }

        [JsonProperty("samplePercentage")]
        public int SamplePercentage { get; set; }

        [JsonProperty("segmentCount")]
        public int SegmentCount { get; set; }

        [JsonProperty("wordCount")]
        public int WordCount { get; set; }
    }
}
