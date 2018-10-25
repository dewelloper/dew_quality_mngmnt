using System;

namespace EvaluationAssistt.Web.Pages
{
    public partial class XtraCallsOfAgents : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraCallsOfAgents()
        {
            InitializeComponent();
        }

        private void XtraReport1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            DataMember = "CallsOfAgentDto";

            xrlAgentName.DataBindings.Add("Text", null, "CallsOfAgentDto.AgentName");
            xrlCallId.DataBindings.Add("Text", null, "CallsOfAgentDto.CallId");
            xrlPhone.DataBindings.Add("Text", null, "CallsOfAgentDto.Phone");
            xrlDate.DataBindings.Add("Text", null, "CallsOfAgentDto.Date");

            xrlFormId.DataBindings.Add("Text", null, "CallsOfAgentDto.FormId");
            xrlId.DataBindings.Add("Text", null, "CallsOfAgentDto.Id");
            xrlQuestion.DataBindings.Add("Text", null, "CallsOfAgentDto.Question");
            xrlScore.DataBindings.Add("Text", null, "CallsOfAgentDto.Score");
            xrlNote.DataBindings.Add("Text", null, "CallsOfAgentDto.ResultNote");
        }
    }
}
