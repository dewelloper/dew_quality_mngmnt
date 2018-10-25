using System;
using System.Text;

namespace EvaluationAssistt.Web.Redirections
{
    public partial class Error500 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var ex = Server.GetLastError();

            if (ex == null)
            {
                return;
            }
            var error = new StringBuilder();

            if (ex.Message != null)
            {
                error.AppendLine("<b>Message:</b>");
                error.AppendLine(ex.Message);
                error.AppendLine();
            }

            if (ex.InnerException != null)
            {
                error.AppendLine("<b>InnerException:</b>");
                error.AppendLine(ex.InnerException.ToString());
                error.AppendLine();
            }

            if (ex.Source != null)
            {
                error.AppendLine("<b>Source:</b>");
                error.AppendLine(ex.Source);
                error.AppendLine();
            }

            if (ex.StackTrace != null)
            {
                error.AppendLine("<b>StackTrace:</b>");
                error.AppendLine(ex.StackTrace);
                error.AppendLine();
            }

            lblErrorDetail.InnerHtml = error.Replace("\r\n", "<br />").ToString();
        }
    }
}
