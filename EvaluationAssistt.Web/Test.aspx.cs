using System;
using System.Web.Services;

namespace EvaluationAssistt.Web
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        [WebMethod]
        public static string Deneme()
        {
            return "Naber lan?";
        }
    }
}
