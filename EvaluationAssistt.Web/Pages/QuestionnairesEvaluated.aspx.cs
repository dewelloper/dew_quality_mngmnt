using EvaluationAssistt.Domain.Dto;
using EvaluationAssistt.Infrastructure.Helpers;
using EvaluationAssistt.Presenter.Interfaces;
using EvaluationAssistt.Presenter.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace EvaluationAssistt.Web.Pages
{
    public partial class QuestionnairesEvaluated : EvaluationAssisttPage, IQuestionnairesEvaluatedView
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
                var call_id = Request.QueryString["FormId"];
                int callId;
                Int32.TryParse(call_id, out callId);
                return callId;
            }
        }

        public string FormName
        {
            set
            {
                lblFormName.InnerText = value;
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

        public string EvaluatorName
        {
            set
            {
                lblEvaluatorName.InnerText = value;
            }
        }

        public string EvaluationDate
        {
            set
            {
                lblEvaluationDate.InnerText = value;
            }
        }

        public string TotalScore
        {
            set
            {
                hiddenTotalScore.Value = value.ToString();
            }
        }

        public string CalculatedScore
        {
            set
            {
                lblTotalScore.InnerText = value;
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
            }
        }

        public QuestionnairesEvaluatedPresenter presenter;

        private static int _fceid = 0;
        public int Fceid
        {
            get
            {
                return _fceid;
            }
            set
            {
                _fceid = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (presenter == null)
            {
                presenter = new QuestionnairesEvaluatedPresenter(this);
            }
            if (Request.QueryString["Fceid"] != null)
            {
                Fceid = Convert.ToInt32(Request.QueryString["Fceid"]);
            }
            string agentCommant = "";
            if (CallId != 0)
            {
                presenter.GetCallDetails();
                presenter.GetEvaluationDetails();
                presenter.GetSectionsByFormId();
                presenter.GetFormNameById();
                agentCommant = presenter.GetFormNote();
            }

            if (!IsPostBack)
            {
                hiddenIsCalculated.Value = string.Empty;
            }
            hiddenFormId.Value = FormId.ToString();
            lblQualityExpertNote.Visible = false;
            btnSend.Visible = false;
            btnSave.Visible = false;
            txtEvaluationNote.Value = presenter.GetEvaluationNote();
            txtEvaluationNote.Disabled = true;
            //txtTlComment.Text = agentCommant;

            switch (UserHelper.Type)
            {
                case EvaluationAssistt.Infrastructure.Enums.UserType.Agent:
                    applyProcess.Visible = false;
                    btnSave.Visible = false;
                    btnSend.Visible = true;
                    btnCalculateScore.Visible = false;
                    btnDelete.Visible = false;
                    //txtTlComment.Visible = true;
                    txtISMNote.Visible = true;
                    txtISMNote.Enabled = false;
                    txtTLNote.Visible = true;
                    txtTLNote.Enabled = false;
                    txtTLNote.Text = presenter.GetFormTLNote();
                    //txtTlComment.Text = txtTLNote.Text;
                    //if (txtTlComment.Text != "")
                    //    Session["isExistAttention"] = true;
                    //txtISMNote.Text = presenter.GetFormISMNote();
                    txtEvaluationNote.Disabled = true;
                    rbListNoYes.Enabled = false;
                    btnUpdate.Disabled = true;
                    break;
                case EvaluationAssistt.Infrastructure.Enums.UserType.TeamLeader:
                    txtISMNote.Visible = true;
                    txtTLNote.Visible = true;
                    applyProcess.Visible = true;
                    txtTLNote.Text = presenter.GetFormTLNote();
                    txtISMNote.Text = presenter.GetFormISMNote();
                    txtISMNote.Enabled = false;
                    lblQualityExpertNote.Visible = true;
                    btnSave.Visible = true;
                    btnDelete.Visible = false;
                    break;
                case EvaluationAssistt.Infrastructure.Enums.UserType.GroupLeader:
                    txtISMNote.Visible = true;
                    txtTLNote.Visible = true;
                    applyProcess.Visible = true;
                    txtTLNote.Text = presenter.GetFormTLNote();
                    txtISMNote.Text = presenter.GetFormISMNote();
                    txtISMNote.Enabled = false;
                    lblQualityExpertNote.Visible = true;
                    btnSave.Visible = true;
                    btnDelete.Visible = false;
                    break;
                case EvaluationAssistt.Infrastructure.Enums.UserType.QualityExpert:
                    txtISMNote.Visible = true;
                    txtTLNote.Visible = true;
                    applyProcess.Visible = true;
                    txtTLNote.Text = presenter.GetFormTLNote();
                    txtTLNote.Enabled = false;
                    txtISMNote.Text = presenter.GetFormISMNote();
                    lblQualityExpertNote.Visible = true;
                    btnSave.Visible = true;
                    btnDelete.Visible = true;
                    break;
                case EvaluationAssistt.Infrastructure.Enums.UserType.Admin:
                    txtISMNote.Visible = true;
                    txtTLNote.Visible = true;
                    applyProcess.Visible = true;
                    txtTLNote.Text = presenter.GetFormTLNote();
                    txtTLNote.Enabled = false;
                    txtISMNote.Text = presenter.GetFormISMNote();
                    lblQualityExpertNote.Visible = true;
                    btnSave.Visible = true;
                    btnDelete.Visible = true;
                    break;
                default:
                    break;
            }

            txtEvaluationNote.Disabled = true;

            if (txtTLNote.Text != string.Empty)
            {
                txtTLNote.Enabled = false;
            }
            if (txtISMNote.Text != string.Empty)
            {
                txtISMNote.Enabled = false;
            }
            if (Request.QueryString["CallState"] != null && UserHelper.Type == Infrastructure.Enums.UserType.TeamLeader)
            {
                if (Request.QueryString["CallState"].ToString() == "31" || Request.QueryString["CallState"].ToString() == "32"
                    || Request.QueryString["CallState"].ToString() == "1" ||
                    Request.QueryString["CallState"].ToString() == "51" || Request.QueryString["CallState"].ToString() == "52")
                {
                    Session["CallState"] = false;
                    applyProcess.Visible = true;
                    if (Convert.ToInt32(Request.QueryString["CallState"]) != 1)
                    {
                        txtTLNote.Text = presenter.GetFormTLNote();
                        txtTLNote.Enabled = false;
                        btnSave.Visible = false;
                        btnUpdate.Disabled = true;
                        rbListNoYes.Enabled = false;
                    }
                }
                else
                {
                    Session["CallState"] = true;
                    applyProcess.Visible = true;
                    btnSave.Visible = true;
                    btnUpdate.Disabled = false;
                }
            }

            if (Request.QueryString["CallState"] != null && Request.QueryString["CallState"].ToString() == "1" && UserHelper.Type == Infrastructure.Enums.UserType.TeamLeader)
            {
                Session["CallState"] = true;
                applyProcess.Visible = true;
            }
        }

        [WebMethod]
        public static void SaveNote(int callId, int formId, string note)
        {
            var presenter = new QuestionnairesEvaluatedPresenter(HttpContext.Current.Handler as QuestionnairesEvaluated);

            presenter.SaveNote(callId, formId, note);
        }

        [WebMethod]
        public static void SaveInstantancy(int callId, int formId, string selection, string editedScore, string TLNote, string ISMNote, string ids)
        {
            var presenter = new QuestionnairesEvaluatedPresenter(HttpContext.Current.Handler as QuestionnairesEvaluated);
            var stateTotal = 10;
            switch (UserHelper.Type)
            {
                case EvaluationAssistt.Infrastructure.Enums.UserType.Agent:
                    stateTotal = 20;
                    break;
                case EvaluationAssistt.Infrastructure.Enums.UserType.TeamLeader:
                    stateTotal = 30;
                    break;
                case EvaluationAssistt.Infrastructure.Enums.UserType.GroupLeader:
                    stateTotal = 40;
                    break;
                case EvaluationAssistt.Infrastructure.Enums.UserType.QualityExpert:
                    stateTotal = 50;
                    break;
                case EvaluationAssistt.Infrastructure.Enums.UserType.Admin:
                    stateTotal = 60;
                    break;
                default:
                    break;
            }
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

            if (selection.ToString() == "on")
            {
                return;
            }

            stateTotal = stateTotal + Convert.ToInt32(selection);
            presenter.SaveInstantancy(callId, formId, stateTotal.ToString(), editedScore, ISMNote, TLNote, answers, _fceid);
        }

        [WebMethod]
        public static string CalculateScoreOnCs(string radioScores, string checkScores, string formId)
        {
            var presenter = new QuestionnairesEvaluatedPresenter(HttpContext.Current.Handler as QuestionnairesEvaluated);

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

        [WebMethod]
        public static void SubmitForm(string ids, int formId, string callId, string comments, int score)
        {
            var page = HttpContext.Current.Handler as QuestionnairesEvaluated;

            var presenter = new QuestionnairesEvaluatedPresenter(page);

            var answers = new Dictionary<int, int>();

            var id_list = ids.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in id_list)
            {
                var arr = item.Split('_');

                var questionId = int.Parse(arr[3]);
                var answerId = int.Parse(arr[4]);

                if (answers.ContainsKey(questionId))
                {
                    answers.Remove(questionId);
                }
                answers.Add(questionId, answerId);
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

            presenter.SubmitForm(answers, comment_dictionary, formId, callId, UserHelper.UserId, score, _fceid);
        }

        [WebMethod]
        public static bool DeleteEvaluationById(string callId)
        {
            var page = HttpContext.Current.Handler as QuestionnairesEvaluated;
            var presenter = new QuestionnairesEvaluatedPresenter(page);
            presenter.DeleteFormCallsById(Convert.ToInt32(callId));
            return true;
        }
    }
}
