
using EvaluationAssistt.Infrastructure.Enums;
using EvaluationAssistt.Infrastructure.Helpers;
using EvaluationAssistt.Presenter.Interfaces;
using EvaluationAssistt.Presenter.Presenters;
using EvaluationAssistt.Web.JsHelpers;
using System;
using System.Linq;
using System.Collections.Generic;

namespace EvaluationAssistt.Web.Pages
{
    public partial class Login : EvaluationAssisttPage, ILoginView
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

        public string Username
        {
            get
            {
                return Session["Username"].ToString();
            }
            set
            {
                Session["Username"] = value;
            }
        }

        public string Password
        {
            get
            {
                return Session["Password"].ToString();
            }
            set
            {
                Session["Password"] = value;
            }
        }

        private LoginPresenter presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (presenter == null)
            {
                presenter = new LoginPresenter(this);
            }
            if (UserHelper.UserId != 0)
            {
                Response.Redirect("~/Pages/Home.aspx");
            }

            var loginId = System.Environment.UserName;

            var signedOut = Request.QueryString["SignedOut"] != null && Request.QueryString["SignedOut"] == "1";

            if (signedOut)
            {
                return;
            }
            if (Request.QueryString["ForcedUsername"] != null)
            {
                loginId = Request.QueryString["ForcedUsername"];
            }

            bool valid;

            var agent = presenter.ValidateUser(loginId, out valid);

            if (!valid)
            {
                JsPopup.Popup(this, MessageType.Error, MessageHelper.LoginMessage.InvalidUsernamePassword);
                return;
            }

            UserHelper.UserId = agent.Id;
            UserHelper.AccountName = agent.Username;
            UserHelper.FullName = agent.FullName;
            UserHelper.LoginId = agent.LoginId;
            UserHelper.Type = UserHelper.GetUserType(agent.AgentTypeId);
            UserHelper.Pages = presenter.GetPagesByAgentId(UserHelper.UserId);

            if (UserHelper.Type == UserType.TeamLeader)
            {
                UserHelper.TeamId = agent.TeamId;
                UserHelper.TeamName = agent.TeamName;
            }
            else
            {
                if (UserHelper.Type == UserType.GroupLeader)
                {
                    UserHelper.GroupId = agent.GroupId;
                    UserHelper.GroupName = agent.GroupName;
                }
            }
            if (UserHelper.Type != UserType.Agent)
            {
                UserHelper.TeamIdsAssociated = agent.TeamIdsAssociated;
            }

            var returnUrl = Request.QueryString["ReturnUrl"];
            var redirect = String.IsNullOrEmpty(returnUrl) ? "~/Pages/Home.aspx" : returnUrl;

            Response.Redirect(redirect);
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Login.aspx");
        }
    }
}
