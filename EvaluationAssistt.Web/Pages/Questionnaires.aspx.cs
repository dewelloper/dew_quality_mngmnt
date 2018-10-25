using EvaluationAssistt.Domain.Dto;
using EvaluationAssistt.Infrastructure.Helpers;
using EvaluationAssistt.Presenter.Interfaces;
using EvaluationAssistt.Presenter.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Services;
using System.Web.UI.WebControls;

namespace EvaluationAssistt.Web.Pages
{
    public partial class Questionnaires : EvaluationAssisttPage, IQuestionnairesView
    {
        public int CallId
        {
            get
            {
                var call_id = Request.QueryString["CallId"];
                int callId;
                Int32.TryParse(call_id, out callId);
                return callId;
            }
        }

        public int FormId
        {
            get
            {
                return Convert.ToInt32(cmbForms.Value);
            }
            set
            {
                cmbForms.SelectedItem = cmbForms.Items.FindByValue(value);
            }
        }

        public string AgentName
        {
            set
            {
                lblAgentName.Text = value;
            }
        }

        public string DateStarted
        {
            set
            {
                lblDateStarted.Text = value;
            }
        }

        public string FileName
        {
            set
            {
                litPlayer.Text = FileHelper.GetSoundPlayer(FileHelper.GetFilePath(value));
            }
        }

        public string CallPhone
        {
            set
            {
                lblPhone.Text = value;
            }
        }

        public int Score
        {
            set
            {
                if (FormSelected.CategoriesBasedScore == true)
                {
                    var score = !String.IsNullOrEmpty(hiddenTotalScore.Value) ? int.Parse(hiddenTotalScore.Value) : 0;

                    score += value;

                    hiddenTotalScore.Value = score.ToString();
                }
                else
                {
                    hiddenTotalScore.Value = FormSelected.MaximumScore.ToString();
                }

                hiddenTotalScore.Value = value.ToString();
            }
        }

        public bool? Marked
        {
            get
            {
                return Convert.ToBoolean(hiddenMarked.Value);
            }
            set
            {
                hiddenMarked.Value = value.ToString();
            }
        }

        public FormsDto FormSelected
        {
            get
            {
                if (ViewState["FormSelected"] == null)
                {
                    return null;
                }
                else
                {
                    return ViewState["FormSelected"] as FormsDto;
                }
            }
            set
            {
                ViewState["FormSelected"] = value;
                Score = value.MaximumScore;
            }
        }

        public IQueryable<FormsDto> Forms
        {
            set
            {
                cmbForms.DataSource = value.OrderBy(k => k.Id).ToList();
                cmbForms.TextField = "Name";
                cmbForms.ValueField = "Id";
                cmbForms.DataBind();
            }
        }

        public IQueryable<SectionsDto> Sections
        {
            get
            {
                if (ViewState["Sections"] == null)
                {
                    ViewState["Sections"] = new List<SectionsDto>();
                }

                return (ViewState["Sections"] as List<SectionsDto>).AsQueryable();
            }
            set
            {
                ViewState["Sections"] = value.ToList();
                hiddenTotalScore.Value = value.Where(k => k.IsDisabled == false).Sum(x => x.MaximumScore).ToString();
                Session["SectionsForValidation"] = value.ToList();
            }
        }

        private IQueryable<FlagsDto> _flags;
        public IQueryable<FlagsDto> Flags
        {
            set
            {
                _flags = value;
                foreach (FlagsDto fd in _flags)
                {
                    chklstStates.Items.Add(new ListItem() { Text = fd.FlagName, Value = fd.Id.ToString() });
                }
            }
        }

        private int _insertedId = 0;
        public int InsertedId
        {
            get
            {
                if (Session["InsertedId"] != null)
                {
                    return Convert.ToInt32(Session["InsertedId"]);
                }
                return _insertedId;
            }
            set
            {
                _insertedId = value;
                Session["InsertedId"] = value;
                if (Convert.ToInt32(value) > 0)
                {
                    Info = _insertedId.ToString() + " nolu Değerlendirme kaydedilmiştir...";
                }
            }
        }

        private string _info = string.Empty;
        public string Info
        {
            get
            {
                return _info;
            }
            set
            {
                _info = value;
            }
        }


        public QuestionnairesPresenter presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (presenter == null)
            {
                presenter = new QuestionnairesPresenter(this);
            }
            if (Request.QueryString["CallId"] != null)
            {
                var callId = Request.QueryString["CallId"];
                if (presenter.ISUsedCallId(Convert.ToInt32(callId)))
                {
                    Response.Redirect("Home.Aspx");
                }
            }

            if (!IsPostBack)
            {
                hdnIsSaved.Value = string.Empty;
                presenter.GetFlags();
            }

            presenter.GetForms();

            if (CallId != 0)
            {
                presenter.GetCallDetails();
            }
        }

        protected void cmbForms_SelectedIndexChanged(object sender, EventArgs e)
        {
            var evaluated = presenter.GetIfFormIsEvaluated();

            if (evaluated)
            {
                hpDetails.Visible = true;
                hpDetails.Text = "Daha önceki değerlendirme Formu";
                hpDetails.NavigateUrl = String.Format("~/Pages/QuestionnairesEvaluated.aspx?CallId={0}&FormId={1}", CallId, FormId);
            }
            else
            {
                hpDetails.Visible = false;
            }
            presenter.GetFormById(FormId);
            presenter.GetSectionsByFormId();
            hiddenFormId.Value = FormId.ToString();
        }

        [WebMethod]
        public static string IsAllReplied(string radioScores, object cancelledParts)
        {
            var presenter = new QuestionnairesPresenter(HttpContext.Current.Handler as Questionnaires);

            var radios = radioScores.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);

            var radio_scores = new List<int>();

            foreach (var item in radios)
            {
                var arr = item.Split('_');
                var answerId = int.Parse(arr[4]);

                radio_scores.Add(answerId);
            }

            return presenter.IsAllReplied(radio_scores, cancelledParts.ToString());
        }

        [WebMethod]
        public static string CalculateScoreOnCs(string radioScores, string checkScores, string formId)
        {
            if (EvaluationAssistt.Infrastructure.Helpers.UserHelper.Type.ToString() == "Asistan")
            {
                return string.Empty;
            }
            var presenter = new QuestionnairesPresenter(HttpContext.Current.Handler as Questionnaires);

            var radios = radioScores.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
            var checkes = checkScores.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);

            var radio_scores = new List<int>();
            var check_scores = new List<int>();

            foreach (var item in radios)
            {
                var arr = item.Split('_');
                var answerId = int.Parse(arr[4]);

                radio_scores.Add(answerId);
            }

            foreach (var item in checkes)
            {
                var arr = item.Split('_');
                var answerId = int.Parse(arr[4]);

                check_scores.Add(answerId);
            }

            return presenter.CalculateScore(radio_scores, check_scores, formId);
        }

        public static bool IsInsertOrUpdateMode
        {
            get
            {
                var settings = WebConfigurationManager.AppSettings;
                var isInsertOrUpdateMode = Convert.ToBoolean(settings["IsInsertOrUpdateMode"].ToString().Trim() == "1");
                return isInsertOrUpdateMode;
            }
        }

        [WebMethod]
        public static void SubmitForm(string ids, int formId, string callId, string comments, int score, string evalutaionNote)
        {
            var page = HttpContext.Current.Handler as Questionnaires;

            var presenter = new QuestionnairesPresenter(page);

            var answers = new Dictionary<int, int>();

            var id_list = ids.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in id_list)
            {
                var arr = item.Split('_');

                var questionId = int.Parse(arr[3]);
                var answerId = int.Parse(arr[4]);

                if (!answers.ContainsKey(questionId))
                {
                    answers.Add(questionId, answerId);
                }
            }

            var comment_list = comments.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);

            var comment_dictionary = new Dictionary<int, string>();

            foreach (var item in comment_list)
            {
                var arr = item.Split('_');
                var questionId = int.Parse(arr[0]);
                var comment = arr[1];

                if (String.IsNullOrEmpty(comment))
                {
                    continue;
                }
                comment_dictionary.Add(questionId, comment);
            }

            presenter.SubmitForm(answers, comment_dictionary, formId, callId, UserHelper.UserId, score, IsInsertOrUpdateMode, evalutaionNote);
        }

        protected void btnSaveFlags_Click(object sender, EventArgs e)
        {
            var page = HttpContext.Current.Handler as Questionnaires;
            var presenter = new QuestionnairesPresenter(page);

            var flagIds = new List<int>();
            foreach (ListItem item in chklstStates.Items)
            {
                if (item.Selected)
                {
                    flagIds.Add(Convert.ToInt32(item.Value));
                }
            }

            if (InsertedId > 0)
            {
                presenter.SaveFlags(InsertedId, flagIds);
            }
        }
    }
}
