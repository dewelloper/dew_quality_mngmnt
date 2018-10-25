using EvaluationAssistt.Domain.Dto;
using EvaluationAssistt.Infrastructure.Helpers;
using EvaluationAssistt.Presenter.Interfaces;
using EvaluationAssistt.Presenter.Presenters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace EvaluationAssistt.Web
{
    public partial class Main : System.Web.UI.MasterPage, IMainView
    {
        public int UncheckedAgentsCount
        {
            get
            {
                if (Session["lblUncheckedAgentsCount"] == null)
                {
                    return -1;
                }
                else
                {
                    return Convert.ToInt32(Session["lblUncheckedAgentsCount"]);
                }
            }
            set
            {
                Session["lblUncheckedAgentsCount"] = value.ToString();
            }
        }

        public int UnreadMessagesCount
        {
            get
            {
                if (Session["lblUnreadMessagesCount"] == null)
                {
                    return -1;
                }
                else
                {
                    return Convert.ToInt32(Session["lblUnreadMessagesCount"]);
                }
            }
            set
            {
                Session["lblUnreadMessagesCount"] = value.ToString();
                lblMessageCount.InnerText = value.ToString();
                lblMessageCountNested.InnerText = value.ToString();
            }
        }

        public List<PagesAgentsDto> BookmarkedPages
        {
            get
            {
                if (Session["ulBookmarkedPages"] == null)
                {
                    return null;
                }
                else
                {
                    return Session["ulBookmarkedPages"] as List<PagesAgentsDto>;
                }
            }
            set
            {
                Session["ulBookmarkedPages"] = value;

                var sb = new StringBuilder();

                foreach (var item in value)
                {
                    sb.Append(String.Format("<li><a class=\"i_16_pages\" href=\"/Pages/{0}.aspx\"><span class=\"label\">{1}</span></a></li>", item.PageName, item.PageDescription));
                }

                ulBookmarkedPages.InnerHtml = sb.ToString();
            }
        }

        private MainPresenter presenter;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (UserHelper.UserId == 0)
            {
                Server.Transfer("~/Pages/Login.aspx?ReturnUrl=" + Request.Url.PathAndQuery);
                return;
            }

            if (HttpContext.Current.Request.Url == null || HttpContext.Current.Request.Url.Segments.Length < 3)
            {
                return;
            }
            HttpContext.Current.Request.Url.Segments[2].Replace(".aspx", String.Empty);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["isExistAttention"] != null)
            {
                isExistAttention.Visible = true;
            }
            else
            {
                isExistAttention.Visible = false;
            }
            if (presenter == null)
            {
                presenter = new MainPresenter(this);
            }
            presenter.GetUncheckedAgentsCount(UserHelper.TeamIdsAssociated);
            presenter.GetUnreadMailsCount(UserHelper.UserId);
            presenter.GetBookmarkedPages(UserHelper.UserId);

            lblLoginName.InnerText = String.Format("{0} - {1}", UserHelper.FullName, UserHelper.LoginId);
        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.Abandon();
            HttpContext.Current.User = null;
            System.Web.Security.FormsAuthentication.SignOut();
            Response.Redirect("~/Pages/Login.aspx?SignedOut=1");
        }
    }
}
