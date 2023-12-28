using Blackbird.Applications.Sdk.Common;

namespace Apps.ContentQuo.Models.Requests;

public class AssignWorkflowStepRequest
{
    [Display("Step ID")]
    public string StepId { get; set; }

    [Display("User ID")]
    public string UserId { get; set; }
}