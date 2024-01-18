using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.ContentQuo.Dtos;

public class EvaluationDto
{
    [Display("Analytical issue count")]
    [JsonProperty("analyticalIssueCount")]
    public int AnalyticalIssueCount { get; set; }

    [JsonProperty("assignees")]
    public List<Assignee>? Assignees { get; set; }

    [JsonProperty("comments")]
    public List<Comment>? Comments { get; set; }

    [JsonProperty("created")]
    public string Created { get; set; }

    //[Display("Edit count")]
    //[JsonProperty("editCount")]
    //public int EditCount { get; set; }

    [Display("ID")]
    [JsonProperty("eid")]
    public string Id { get; set; }

    //[JsonProperty("finished")]
    //public string Finished { get; set; }

    [Display("Group ID")]
    [JsonProperty("groupID")]
    public string GroupID { get; set; }

    [Display("Group name")]
    [JsonProperty("groupName")]
    public string GroupName { get; set; }

    //[Display("Holistic rating count")]
    //[JsonProperty("holisticRatingCount")]
    //public int HolisticRatingCount { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [Display("Profile ID")]
    [JsonProperty("profileID")]
    public string ProfileID { get; set; }

    [Display("Project ID")]
    [JsonProperty("projectID")]
    public string ProjectID { get; set; }

    //[Display("Quality result")]
    //[JsonProperty("qualityResult")]
    //public QualityResult QualityResult { get; set; }

    //[JsonProperty("scope")]
    //public Scope Scope { get; set; }

    //[Display("Scored analytical issue count")]
    //[JsonProperty("scoredAnalyticalIssueCount")]
    //public int ScoredAnalyticalIssueCount { get; set; }

    [Display("Source locale")]
    [JsonProperty("srcLocale")]
    public string SrcLocale { get; set; }

    //[JsonProperty("started")]
    //public string Started { get; set; }

    [Display("Target locale")]
    [JsonProperty("tgtLocale")]
    public string TgtLocale { get; set; }

    //[Display("Translator ID")]
    //[JsonProperty("translatorID")]
    //public string TranslatorID { get; set; }

    [Display("Workflow ID")]
    [JsonProperty("workflowID")]
    public string WorkflowID { get; set; }

    [Display("Workflow name")]
    [JsonProperty("workflowName")]
    public string WorkflowName { get; set; }
}

public class Accuracy
{
    [Display("Grade index")]
    [JsonProperty("gradeIndex")]
    public int GradeIndex { get; set; }

    [Display("Grade name")]
    [JsonProperty("gradeName")]
    public string GradeName { get; set; }

    [JsonProperty("score")]
    public double Score { get; set; }
}

public class Analytical
{
    [Display("Grade index")]
    [JsonProperty("gradeIndex")]
    public int GradeIndex { get; set; }

    [Display("Grade name")]
    [JsonProperty("gradeName")]
    public string GradeName { get; set; }

    [JsonProperty("score")]
    public double Score { get; set; }
}

public class Assignee
{
    //[JsonProperty("assignments")]
    //public List<Assignment> Assignments { get; set; }

    [Display("Name")]
    [JsonProperty("fullname")]
    public string Fullname { get; set; }

    [Display("User ID")]
    [JsonProperty("userId")]
    public int UserId { get; set; }
    }

public class Assignment
{
    [JsonProperty("role")]
    public string Role { get; set; }
}

public class Auto
{
    [JsonProperty("characTer")]
    public double? CharacTer { get; set; }

    [Display("Taus edit density")]
    [JsonProperty("tausEditDensity")]
    public int? TausEditDensity { get; set; }
}

public class Comment
{
    //[JsonProperty("comments")]
    //public List<Comment> Comments { get; set; }

    [Display("Step ID")]
    [JsonProperty("stepId")]
    public string StepId { get; set; }

    [Display("Assignment index")]
    [JsonProperty("assignmentIndex")]
    public int AssignmentIndex { get; set; }

    [Display("Assignment role")]
    [JsonProperty("assignmentRole")]
    public string AssignmentRole { get; set; }

    [Display("Author ID")]
    [JsonProperty("authorId")]
    public string AuthorId { get; set; }

    [JsonProperty("text")]
    public string Text { get; set; }
}

public class Holistic
{
    [JsonProperty("accuracy")]
    public Accuracy Accuracy { get; set; }
}

    public class QualityResult
    {
    //[JsonProperty("analytical")]
    //public Analytical Analytical { get; set; }

    [JsonProperty("auto")]
    public Auto Auto { get; set; }

    [JsonProperty("holistic")]
    public List<Holistic>? Holistic { get; set; }
}

public class Scope
{
    [Display("File count")]
    [JsonProperty("fileCount")]
    public int FileCount { get; set; }

    [JsonProperty("volume")]
    public int Volume { get; set; }
}