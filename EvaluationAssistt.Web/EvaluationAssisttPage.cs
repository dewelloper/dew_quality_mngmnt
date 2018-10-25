using EvaluationAssistt.Domain.Dto;
using EvaluationAssistt.Infrastructure.Extensions;
using EvaluationAssistt.Infrastructure.Helpers;
using EvaluationAssistt.Presenter.Interfaces;
using EvaluationAssistt.Presenter.Presenters;
using System;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;

namespace EvaluationAssistt.Web
{
    public class EvaluationAssisttPage : Page, IEvaluationAssisttPage, IReportingView
    {
        public EvaluationAssisttPage()
        {
        }

        public bool EntitySelect
        {
            get
            {
                return Request.QueryString["Id"] != null;
            }
        }

        public int EntityId
        {
            get
            {
                var _id = Request.QueryString["Id"];
                int id;
                Int32.TryParse(_id, out id);
                return id;
            }
        }

        public bool EntityUpdate
        {
            get
            {
                return this.GetPostBackControlId() == "btnSave";
            }
        }

        [WebMethod]
        public static string UncheckedAgents()
        {
            var presenter = new EvaluationAssisttPagePresenter(HttpContext.Current.Handler as EvaluationAssisttPage);

            var agents = presenter.GetUncheckedAgentsNames(UserHelper.TeamIdsAssociated).ToList().OrderBy(x => x.FullName);

            var sb = new StringBuilder("<b>Bu ay içerisinde değerlendirilmemiş asistanlar :</b><ul>");

            foreach (var item in agents)
            {
                sb.Append(String.Format("<li><a style=\"color:black;\" onmouseover=\"this.style.textDecoration='underline'; this.style.color='#F18103'\" onmouseout=\"this.style.textDecoration='none'; this.style.color='black'\" href=\"/Pages/CallManagement.aspx?AgentId={1}\">{0}</li>", item.FullName, item.Id));
            }

            return sb.ToString();
        }

        [WebMethod]
        public static void BookmarkPage()
        {
            var context = HttpContext.Current;

            context.Session.Remove("ulBookmarkedPages");

            var pageName = context.Request.UrlReferrer.Segments[2];

            var presenter = new EvaluationAssisttPagePresenter(HttpContext.Current.Handler as EvaluationAssisttPage);

            presenter.BookmarkPage(UserHelper.UserId, pageName);
        }

        public int Id { get; set; }
        public string LoginId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RegisterNumber { get; set; }
        public int? TeamId { get; set; }
        public int AgentTypeId { get; set; }

        public IQueryable<FormsCallsDto> FormsCalls
        {
            set
            {
            }
            get
            {
                return null;
            }
        }

        public IQueryable<TeamCallsDto> TeamCalls
        {
            set
            {
            }
            get
            {
                return null;
            }
        }

        public IQueryable<CallsOfAgentDto> CallsOfAgents
        {
            set
            {
            }
            get
            {
                return null;
            }
        }

        public IQueryable<AgentsDto> Agents { get; set; }
        public IQueryable<FormsDto> Forms { get; set; }
    }
}
