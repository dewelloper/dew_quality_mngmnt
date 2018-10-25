using DevExpress.XtraReports.UI;
namespace EvaluationAssistt.Web.Pages
{
    partial class XtraCallsOfAgents
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrlQuestion = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlId = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlScore = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlFormId = new DevExpress.XtraReports.UI.XRLabel();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrlNo = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlSorular = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlPuan = new DevExpress.XtraReports.UI.XRLabel();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrlNote = new DevExpress.XtraReports.UI.XRLabel();
            this.DetailReport = new DevExpress.XtraReports.UI.DetailReportBand();
            this.Detail1 = new DevExpress.XtraReports.UI.DetailBand();
            this.topMarginBand1 = new DevExpress.XtraReports.UI.TopMarginBand();
            this.bottomMarginBand1 = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrlAgentName = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlCallId = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlDate = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlPhone = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlAgentNameLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlCallIdLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlDateLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlPhoneLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlFormLabel = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrlQuestion,
            this.xrlId,
            this.xrlScore});
            this.Detail.HeightF = 34.83334F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrlQuestion
            // 
            this.xrlQuestion.LocationFloat = new DevExpress.Utils.PointFloat(67.41669F, 4.999987F);
            this.xrlQuestion.Name = "xrlQuestion";
            this.xrlQuestion.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlQuestion.SizeF = new System.Drawing.SizeF(564.5833F, 25F);
            // 
            // xrlId
            // 
            this.xrlId.LocationFloat = new DevExpress.Utils.PointFloat(5.250009F, 4.999987F);
            this.xrlId.Name = "xrlId";
            this.xrlId.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlId.SizeF = new System.Drawing.SizeF(62.16667F, 25F);
            // 
            // xrlScore
            // 
            this.xrlScore.LocationFloat = new DevExpress.Utils.PointFloat(632F, 5.000019F);
            this.xrlScore.Name = "xrlScore";
            this.xrlScore.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlScore.SizeF = new System.Drawing.SizeF(108F, 25F);
            this.xrlScore.StylePriority.UseTextAlignment = false;
            this.xrlScore.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrlFormId
            // 
            this.xrlFormId.LocationFloat = new DevExpress.Utils.PointFloat(110F, 86.79167F);
            this.xrlFormId.Name = "xrlFormId";
            this.xrlFormId.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlFormId.SizeF = new System.Drawing.SizeF(100F, 25F);
            this.xrlFormId.Text = "xrlFormId";
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrlFormLabel,
            this.xrlDateLabel,
            this.xrlPhoneLabel,
            this.xrlAgentNameLabel,
            this.xrlCallIdLabel,
            this.xrlPhone,
            this.xrlDate,
            this.xrlCallId,
            this.xrlAgentName,
            this.xrlNo,
            this.xrlSorular,
            this.xrLabel1,
            this.xrlFormId,
            this.xrlPuan});
            this.PageHeader.HeightF = 149.125F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.PageHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrlNo
            // 
            this.xrlNo.LocationFloat = new DevExpress.Utils.PointFloat(5.250009F, 125.0834F);
            this.xrlNo.Name = "xrlNo";
            this.xrlNo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlNo.SizeF = new System.Drawing.SizeF(62.16668F, 23F);
            this.xrlNo.Text = "No";
            // 
            // xrlSorular
            // 
            this.xrlSorular.LocationFloat = new DevExpress.Utils.PointFloat(67.4167F, 125.0834F);
            this.xrlSorular.Name = "xrlSorular";
            this.xrlSorular.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlSorular.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrlSorular.Text = "Sorular";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(740F, 28.45833F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "Çağrı Değerlendirme Sonucu";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrlPuan
            // 
            this.xrlPuan.LocationFloat = new DevExpress.Utils.PointFloat(632F, 125.0834F);
            this.xrlPuan.Name = "xrlPuan";
            this.xrlPuan.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlPuan.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrlPuan.StylePriority.UseTextAlignment = false;
            this.xrlPuan.Text = "Puan";
            this.xrlPuan.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrlNote});
            this.PageFooter.HeightF = 137.9167F;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.PageFooter.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrlNote
            // 
            this.xrlNote.AutoWidth = true;
            this.xrlNote.LocationFloat = new DevExpress.Utils.PointFloat(5.249897F, 10.00001F);
            this.xrlNote.Multiline = true;
            this.xrlNote.Name = "xrlNote";
            this.xrlNote.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlNote.SizeF = new System.Drawing.SizeF(726.7501F, 127.9166F);
            // 
            // DetailReport
            // 
            this.DetailReport.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail1});
            this.DetailReport.Level = 0;
            this.DetailReport.Name = "DetailReport";
            // 
            // Detail1
            // 
            this.Detail1.HeightF = 60.41667F;
            this.Detail1.Name = "Detail1";
            // 
            // topMarginBand1
            // 
            this.topMarginBand1.HeightF = 8.333333F;
            this.topMarginBand1.Name = "topMarginBand1";
            // 
            // bottomMarginBand1
            // 
            this.bottomMarginBand1.Name = "bottomMarginBand1";
            // 
            // xrlAgentName
            // 
            this.xrlAgentName.LocationFloat = new DevExpress.Utils.PointFloat(110F, 36.79168F);
            this.xrlAgentName.Name = "xrlAgentName";
            this.xrlAgentName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlAgentName.SizeF = new System.Drawing.SizeF(244.7917F, 25F);
            this.xrlAgentName.Text = "xrlAgentName";
            // 
            // xrlCallId
            // 
            this.xrlCallId.LocationFloat = new DevExpress.Utils.PointFloat(110F, 61.79168F);
            this.xrlCallId.Name = "xrlCallId";
            this.xrlCallId.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlCallId.SizeF = new System.Drawing.SizeF(244.7917F, 25F);
            this.xrlCallId.Text = "xrlCallId";
            // 
            // xrlDate
            // 
            this.xrlDate.LocationFloat = new DevExpress.Utils.PointFloat(500F, 61.79168F);
            this.xrlDate.Name = "xrlDate";
            this.xrlDate.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlDate.SizeF = new System.Drawing.SizeF(201.0417F, 25F);
            this.xrlDate.Text = "xrlDate";
            // 
            // xrlPhone
            // 
            this.xrlPhone.LocationFloat = new DevExpress.Utils.PointFloat(500F, 36.79168F);
            this.xrlPhone.Name = "xrlPhone";
            this.xrlPhone.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlPhone.SizeF = new System.Drawing.SizeF(201.0417F, 25F);
            this.xrlPhone.Text = "xrlPhone";
            // 
            // xrlAgentNameLabel
            // 
            this.xrlAgentNameLabel.LocationFloat = new DevExpress.Utils.PointFloat(5.250009F, 36.79168F);
            this.xrlAgentNameLabel.Name = "xrlAgentNameLabel";
            this.xrlAgentNameLabel.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlAgentNameLabel.SizeF = new System.Drawing.SizeF(100F, 25F);
            this.xrlAgentNameLabel.Text = "Agent :";
            // 
            // xrlCallIdLabel
            // 
            this.xrlCallIdLabel.LocationFloat = new DevExpress.Utils.PointFloat(5.250009F, 61.79168F);
            this.xrlCallIdLabel.Name = "xrlCallIdLabel";
            this.xrlCallIdLabel.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlCallIdLabel.SizeF = new System.Drawing.SizeF(100F, 25F);
            this.xrlCallIdLabel.Text = "Çağrı No :";
            // 
            // xrlDateLabel
            // 
            this.xrlDateLabel.LocationFloat = new DevExpress.Utils.PointFloat(400F, 61.79168F);
            this.xrlDateLabel.Name = "xrlDateLabel";
            this.xrlDateLabel.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlDateLabel.SizeF = new System.Drawing.SizeF(100F, 25F);
            this.xrlDateLabel.Text = "Tarih :";
            // 
            // xrlPhoneLabel
            // 
            this.xrlPhoneLabel.LocationFloat = new DevExpress.Utils.PointFloat(400F, 36.79168F);
            this.xrlPhoneLabel.Name = "xrlPhoneLabel";
            this.xrlPhoneLabel.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlPhoneLabel.SizeF = new System.Drawing.SizeF(100F, 25F);
            this.xrlPhoneLabel.Text = "Telefon No :";
            // 
            // xrlFormLabel
            // 
            this.xrlFormLabel.LocationFloat = new DevExpress.Utils.PointFloat(5.249914F, 86.79167F);
            this.xrlFormLabel.Name = "xrlFormLabel";
            this.xrlFormLabel.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlFormLabel.SizeF = new System.Drawing.SizeF(100F, 25F);
            this.xrlFormLabel.Text = "Form No :";
            // 
            // XtraCallsOfAgents
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.PageHeader,
            this.PageFooter,
            this.DetailReport,
            this.topMarginBand1,
            this.bottomMarginBand1});
            this.Margins = new System.Drawing.Printing.Margins(57, 53, 8, 100);
            this.Version = "12.2";
            this.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.XtraReport1_BeforePrint);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private XRLabel xrLabel1;
        private XRLabel xrlFormId;
        private DetailReportBand DetailReport;
        private DetailBand Detail1;
        private XRLabel xrlQuestion;
        private XRLabel xrlScore;
        private TopMarginBand topMarginBand1;
        private BottomMarginBand bottomMarginBand1;
        private XRLabel xrlId;
        private XRLabel xrlNo;
        private XRLabel xrlSorular;
        private XRLabel xrlPuan;
        public XRLabel xrlNote;
        private XRLabel xrlDateLabel;
        private XRLabel xrlPhoneLabel;
        private XRLabel xrlAgentNameLabel;
        private XRLabel xrlCallIdLabel;
        private XRLabel xrlPhone;
        private XRLabel xrlDate;
        private XRLabel xrlCallId;
        private XRLabel xrlAgentName;
        private XRLabel xrlFormLabel;
    }
}
