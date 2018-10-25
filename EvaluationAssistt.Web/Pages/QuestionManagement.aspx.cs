using DevExpress.Web;
using EvaluationAssistt.Domain.Dto;
using EvaluationAssistt.Infrastructure.Enums;
using EvaluationAssistt.Infrastructure.Extensions;
using EvaluationAssistt.Infrastructure.Helpers;
using EvaluationAssistt.Presenter.Interfaces;
using EvaluationAssistt.Presenter.Presenters;
using EvaluationAssistt.Web.JsHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace EvaluationAssistt.Web.Pages
{
    public partial class QuestionManagement : EvaluationAssisttPage, IQuestionManagementView
    {
        public int Id
        {
            get
            {
                if (ViewState["Id"] == null)
                {
                    ViewState["Id"] = 0;
                }

                return Convert.ToInt32(ViewState["Id"]);
            }
            set
            {
                ViewState["Id"] = value;
            }
        }

        public string QuestionText
        {
            get
            {
                return txtQuestionText.Text;
            }
            set
            {
                txtQuestionText.Text = value;
            }
        }

        public bool HasComment
        {
            get
            {
                return cbHasComment.Checked;
            }
            set
            {
                cbHasComment.Checked = value;
            }
        }

        public bool RequiresComment
        {
            get
            {
                return cbRequiresComment.Checked;
            }
            set
            {
                cbRequiresComment.Checked = value;
            }
        }

        public bool HasVisibleScore
        {
            get
            {
                return cbHasVisibleScore.Checked;
            }
            set
            {
                cbHasVisibleScore.Checked = value;
            }
        }

        public bool HasMultipleAnswers
        {
            get
            {
                return cbHasMultipleAnswers.Checked;
            }
            set
            {
                cbHasMultipleAnswers.Checked = value;
            }
        }

        public IQueryable<QuestionsDto> Questions
        {
            set
            {
                gridviewQuestions.DataSource = value.ToList();
                gridviewQuestions.DataBind();
            }
        }

        public ICollection<AnswersDto> Answers
        {
            get
            {
                var answers = new List<AnswersDto>();

                foreach (ListEditItem item in lstboxAnswers.Items)
                {
                    answers.Add(new AnswersDto()
                    {
                        AnswerText = item.Text.Split('-')[0].Trim(),
                        Score = Convert.ToInt16(item.Value),
                        IsDefault = item.Text.EndsWith("(Varsayýlan)")
                    });
                }

                return answers;
            }
            set
            {
                lstboxAnswers.DataSource = value.ToList();
                lstboxAnswers.TextField = "AnswerFormat";
                lstboxAnswers.ValueField = "Score";
                lstboxAnswers.DataBind();
            }
        }

        public QuestionsDto Dto
        {
            get
            {
                var dto = new QuestionsDto()
                { Id = Id,
                    QuestionText = QuestionText,
                    HasComment = HasComment,
                    RequiresComment = RequiresComment,
                    HasVisibleScore = HasVisibleScore,
                    HasMultipleAnswers = HasMultipleAnswers,
                    Answers = Answers
                };

                return dto;
            }
        }

        private QuestionManagementPresenter presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (presenter == null)
            {
                presenter = new QuestionManagementPresenter(this);
            }
            presenter.GetQuestionsAll();

            if (EntitySelect)
            {
                presenter.GetQuestionById(EntityId);
                NewEntryUI();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Id == 0)
            {
                presenter.InsertQuestion();
                JsPopup.Popup(this, MessageType.Success, MessageHelper.CRUDMessage.SuccessInsert("Soru"));
            }
            else
            {
                try
                {
                    presenter.UpdateQuestion();
                    JsPopup.Popup(this, MessageType.Success, MessageHelper.CRUDMessage.SuccessUpdate("Soru"));
                }
                catch
                {
                    JsPopup.Popup(this, MessageType.Error, "İlgili soru daha önce bir ankette deðerlendirildiğinden dolayı cevapları düzenlenemez! Ancak soru sablonu güncellenmiştir");
                }
            }

            presenter.GetQuestionsAll();
            CancelEntryUI();
        }

        [WebMethod]
        public static void DeleteQuestion(int id)
        {
            var presenter =
                new QuestionManagementPresenter(HttpContext.Current.Handler as QuestionManagement);

            presenter.DeleteQuestion(id);
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            CancelEntryUI();
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            NewEntryUI();
        }

        private void NewEntryUI()
        {
            pnlRegister.Visible = true;
            btnNew.Visible = false;
        }

        private void CancelEntryUI()
        {
            pnlRegister.Clear();
            lstboxAnswers.Items.Clear();
            pnlRegister.Visible = false;
            btnNew.Visible = true;
            Id = 0;
        }
    }
}
