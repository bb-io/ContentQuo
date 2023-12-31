﻿using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.ContentQuo.Dtos;

public class CreatedEvaluationDto
{
    [Display("ID")]
    [JsonProperty("eid")]
    public string Id { get; set; }

    [Display("Group ID")]
    [JsonProperty("groupID")]
    public string GroupID { get; set; }

    [Display("Profile ID")]
    [JsonProperty("profileID")]
    public string ProfileID { get; set; }

    [Display("Workflow ID")]
    [JsonProperty("workflowID")]
    public string WorkflowID { get; set; }
}