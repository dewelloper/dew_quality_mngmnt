namespace EvaluationAssistt.Domain.Entity
{
    using System;
    using System.Collections.Generic;

    public partial class DetailFormView : IEntity
    {
        public int Id { get; set; }
        public int SCId { get; set; }
        public int SCSectionId { get; set; }
        public int SCCategoryId { get; set; }
        public bool SCIsDeleted { get; set; }
        public int CAId { get; set; }
        public string CAName { get; set; }
        public bool CAIsDisabled { get; set; }
        public short CAMaxScore { get; set; }
        public short CAMinScore { get; set; }
        public int CAScoreTypeId { get; set; }
        public bool CAIsDeleted { get; set; }
        public int FOId { get; set; }
        public string FOName { get; set; }
        public bool FORequiresComment { get; set; }
        public short FOMinScore { get; set; }
        public short FOMaxScore { get; set; }
        public Nullable<bool> FOCategorieBasedScore { get; set; }
        public bool FOIsDeleted { get; set; }
        public Nullable<bool> FOIsDisabled { get; set; }
        public int FSId { get; set; }
        public int FSFormId { get; set; }
        public int FSSectionId { get; set; }
        public bool FSIsDeleted { get; set; }
        public Nullable<bool> FSIsDisabled { get; set; }
        public int SEId { get; set; }
        public string SEName { get; set; }
        public bool SEIsDisabled { get; set; }
        public short SEMaxScore { get; set; }
        public short SEMinScore { get; set; }
        public int SEScoreTypeId { get; set; }
        public bool SEIsDeleted { get; set; }
        public int CQId { get; set; }
        public int CQCategoryId { get; set; }
        public int CQQuestionId { get; set; }
        public bool CQIsDeleted { get; set; }
        public int QUId { get; set; }
        public string QUQuestionText { get; set; }
        public bool QUHasComment { get; set; }
        public bool QURequiresComment { get; set; }
        public bool QUHasVisibleScore { get; set; }
        public bool QUHasMultipleAnswers { get; set; }
        public bool QUIsDeleted { get; set; }
        public int ANAnswerId { get; set; }
        public string ANAnswerText { get; set; }
        public int ANQuestionId { get; set; }
        public short ANScore { get; set; }
        public bool ANIsDefault { get; set; }
        public bool IsDeleted { get; set; }
    }
}
