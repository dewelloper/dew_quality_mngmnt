
using EvaluationAssistt.Domain.Dto;
using EvaluationAssistt.Infrastructure.Helpers;
using EvaluationAssistt.Presenter.Interfaces;
using EvaluationAssistt.Presenter.Presenters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EvaluationAssistt.Web.Pages
{
    public partial class AgentCallByDates : EvaluationAssisttPage, IReportingView
    {
        private static EvaluationReportingPresenter _reportingPresenter = null;
        private XtraCallsOfAgents _xrep = new XtraCallsOfAgents();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserHelper.Type == Infrastructure.Enums.UserType.Agent)
            {
                Response.Redirect("~/Redirections/Error403.Aspx");
            }
            if (UserHelper.Type == Infrastructure.Enums.UserType.TeamLeader)
            {
                chkQualityAdminAgent.Visible = false;
            }
            if (!IsPostBack)
            {
                ASPxGridView1.SettingsPager.PageSize = 20;
                _reportingPresenter = new EvaluationReportingPresenter(this);
            }

            var splitedValue = HiddenField1.Value.Split(',');
            if (splitedValue.Length > 1 && splitedValue[0] != null && splitedValue[0].ToString().Trim() != string.Empty)
            {
                btnRetriveDetailSource_Click(null, null);
            }
            ASPxGridView1.Columns["Note"].Visible = false;
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
                ASPxGridView1.DataSource = value.ToList();
                ASPxGridView1.DataBind();
            }
            get
            {
                return ASPxGridView1.DataSource as IQueryable<FormsCallsDto>;
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
                return _xrep.DataSource as IQueryable<CallsOfAgentDto>;
            }
        }

        public static DataSet ToDataSet<T>(IList<T> list)
        {
            var elementType = typeof(T);
            var ds = new DataSet();
            var t = new DataTable("CallsOfAgentDto");
            ds.Tables.Add(t);

            foreach (var propInfo in elementType.GetProperties())
            {
                var ColType = Nullable.GetUnderlyingType(propInfo.PropertyType) ?? propInfo.PropertyType;

                t.Columns.Add(propInfo.Name, ColType);
            }

            foreach (T item in list)
            {
                var row = t.NewRow();

                foreach (var propInfo in elementType.GetProperties())
                {
                    row[propInfo.Name] = propInfo.GetValue(item, null) ?? DBNull.Value;
                }

                t.Rows.Add(row);
            }

            return ds;
        }

        protected void ReportViewer1_Unload(object sender, EventArgs e)
        {
            ReportViewer1.Report = null;
        }

        [WebMethod]
        public static string ShowReport(int formId)
        {
            _reportingPresenter.GetSpecifiedCall(formId);
            return "yes";
        }

        protected void btnRetriveDetailSource_Click(object sender, EventArgs e)
        {
            var report = new XtraCallsOfAgents();

            var splitedValue = HiddenField1.Value.Split(',');
            var res = _reportingPresenter.GetSpecifiedCall(Convert.ToInt32(splitedValue[0]));

            var ds = ToDataSet<CallsOfAgentDto>(res.ToList());
            report.DataSource = ds;
            report.CreateDocument();
            ReportViewer1.Report = report;
            //ScriptManager.RegisterStartupScript(this, GetType(), "Sipariş Özel Notu", "reportViewer.Refresh(); ASPxPopupControl1.Show();", true);
        }

        protected void btnRetriveCalls_Click(object sender, EventArgs e)
        {
            var startDate = Convert.ToDateTime(aspxDateStart.Value);
            var endDate = Convert.ToDateTime(aspxDateEnd.Value);

            var reporterId = "0";
            if (UserHelper.Type == Infrastructure.Enums.UserType.Admin || UserHelper.Type == Infrastructure.Enums.UserType.QualityExpert)
            {
                reporterId = "9999999";
            }
            else
            {
                if (UserHelper.Type == Infrastructure.Enums.UserType.TeamLeader)
                {
                    reporterId = UserHelper.UserId.ToString();
                }
            }
            ods.SelectParameters.Clear();
            ods.SelectParameters.Add(new Parameter() { DbType = DbType.DateTime, DefaultValue = startDate.ToString(), Name = "startDate" });
            ods.SelectParameters.Add(new Parameter() { DbType = DbType.DateTime, DefaultValue = endDate.ToString(), Name = "endDate" });
            ods.SelectParameters.Add(new Parameter() { DbType = DbType.String, DefaultValue = reporterId, Name = "reporterId" });
            ods.SelectParameters.Add(new Parameter() { DbType = DbType.Boolean, DefaultValue = chkQualityAdminAgent.Checked.ToString(), Name = "isAdmQ" });
            ods.Update();
            ASPxGridView1.Columns["Note"].Visible = false;
        }

        protected void ASPxGridView1_PageIndexChanged(object sender, EventArgs e)
        {
        }

        protected void btnExport1_Click(object sender, EventArgs e)
        {
            ASPxGridView1.Columns["Note"].Visible = true;
            ASPxGridViewExporter2.ExportedRowType = DevExpress.Web.GridViewExportedRowType.All;
            ASPxGridViewExporter2.WriteXlsToResponse();
            ASPxGridView1.Columns["Note"].Visible = false;
        }

        protected void btnExportPdf1_Click(object sender, EventArgs e)
        {
            ASPxGridView1.Columns["Note"].Visible = true;
            ASPxGridViewExporter2.ExportedRowType = DevExpress.Web.GridViewExportedRowType.All;
            ASPxGridViewExporter2.WritePdfToResponse();
            ASPxGridView1.Columns["Note"].Visible = false;
        }

        protected void btnExportRtf1_Click(object sender, EventArgs e)
        {
            ASPxGridView1.Columns["Note"].Visible = true;
            ASPxGridViewExporter2.ExportedRowType = DevExpress.Web.GridViewExportedRowType.All;
            ASPxGridViewExporter2.WriteRtfToResponse();
            ASPxGridView1.Columns["Note"].Visible = false;
        }

        protected void btnExportCsv1_Click(object sender, EventArgs e)
        {
            ASPxGridView1.Columns["Note"].Visible = true;
            ASPxGridViewExporter2.ExportedRowType = DevExpress.Web.GridViewExportedRowType.All;
            ASPxGridViewExporter2.WriteCsvToResponse();
            ASPxGridView1.Columns["Note"].Visible = false;
        }
    }
}
