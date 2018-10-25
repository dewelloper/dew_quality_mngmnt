namespace EvaluationAssistt.Domain.Entity
{
    using System;

    public partial class ufnFormSettings_Result
    {
        public string QuestionText { get; set; }
        public string AnswerText { get; set; }
        public string Target { get; set; }
        public string TargetName { get; set; }
        public bool DoesZeroize { get; set; }
        public bool DoesDisable { get; set; }
    }
}
