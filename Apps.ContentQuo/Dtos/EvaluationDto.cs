using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.ContentQuo.Dtos
{
    public class EvaluationDto
    {
        [JsonProperty("analyticalIssueCount")]
        public int AnalyticalIssueCount { get; set; }

        [JsonProperty("assignees")]
        public List<Assignee> Assignees { get; set; }

        [JsonProperty("comments")]
        public List<Comment> Comments { get; set; }

        [JsonProperty("created")]
        public string Created { get; set; }

        [JsonProperty("editCount")]
        public int EditCount { get; set; }

        [JsonProperty("eid")]
        public int Eid { get; set; }

        [JsonProperty("finished")]
        public string Finished { get; set; }

        [JsonProperty("groupID")]
        public int GroupID { get; set; }

        [JsonProperty("groupName")]
        public string GroupName { get; set; }

        [JsonProperty("holisticRatingCount")]
        public int HolisticRatingCount { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("profileID")]
        public string ProfileID { get; set; }

        [JsonProperty("projectID")]
        public int ProjectID { get; set; }

        [JsonProperty("qualityResult")]
        public QualityResult QualityResult { get; set; }

        [JsonProperty("scope")]
        public Scope Scope { get; set; }

        [JsonProperty("scoredAnalyticalIssueCount")]
        public int ScoredAnalyticalIssueCount { get; set; }

        [JsonProperty("srcLocale")]
        public string SrcLocale { get; set; }

        [JsonProperty("started")]
        public string Started { get; set; }

        [JsonProperty("tgtLocale")]
        public string TgtLocale { get; set; }

        [JsonProperty("translatorID")]
        public int TranslatorID { get; set; }

        [JsonProperty("workflowID")]
        public int WorkflowID { get; set; }

        [JsonProperty("workflowName")]
        public string WorkflowName { get; set; }
    }

    public class Accuracy
    {
        [JsonProperty("gradeIndex")]
        public int GradeIndex { get; set; }

        [JsonProperty("gradeName")]
        public string GradeName { get; set; }

        [JsonProperty("score")]
        public double Score { get; set; }
    }

    public class Analytical
    {
        [JsonProperty("gradeIndex")]
        public int GradeIndex { get; set; }

        [JsonProperty("gradeName")]
        public string GradeName { get; set; }

        [JsonProperty("score")]
        public double Score { get; set; }
    }

    public class Assignee
    {
        [JsonProperty("assignments")]
        public List<Assignment> Assignments { get; set; }

        [JsonProperty("fullname")]
        public string Fullname { get; set; }

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
        public double CharacTer { get; set; }

        [JsonProperty("tausEditDensity")]
        public int TausEditDensity { get; set; }
    }

    public class Comment
    {
        [JsonProperty("comments")]
        public List<Comment> Comments { get; set; }

        [JsonProperty("stepId")]
        public string StepId { get; set; }

        [JsonProperty("assignmentIndex")]
        public int AssignmentIndex { get; set; }

        [JsonProperty("assignmentRole")]
        public string AssignmentRole { get; set; }

        [JsonProperty("authorId")]
        public int AuthorId { get; set; }

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
        [JsonProperty("analytical")]
        public Analytical Analytical { get; set; }

        [JsonProperty("auto")]
        public Auto Auto { get; set; }

        [JsonProperty("holistic")]
        public List<Holistic> Holistic { get; set; }
    }

    public class Scope
    {
        [JsonProperty("fileCount")]
        public int FileCount { get; set; }

        [JsonProperty("volume")]
        public int Volume { get; set; }
    }
}
