using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Infrastructure.Helpers
{
    public class HtmlHelper
    {
        public static string TrueFalseIcon(bool isTrue)
        {
            var element = String.Format("<center><img src=\"/Contents/Images/Icons/16/{0}.png\"/></center>", isTrue ? "i_16_checked" : "i_16_close");

            return element;
        }

        public static string TruncateString(object data)
        {
            if (data == null)
            {
                return String.Empty;
            }
            var value = data.ToString();

            if (value.Length > 40)
            {
                value = String.Format("{0} ...", value.Substring(0, 40));
            }
            return value;
        }

        public static void SelectMenu(System.Web.UI.Page page, string liName)
        {
            var menu = page.Master.FindControl("ulMenu") as System.Web.UI.HtmlControls.HtmlGenericControl;

            foreach (System.Web.UI.Control item in menu.Controls)
            {
                if (item != null && item.ID != null && item.ID.StartsWith("li"))
                {
                    var menuItem = item as System.Web.UI.HtmlControls.HtmlGenericControl;
                    if (menuItem.Attributes["class"].Contains("active_tab"))
                    {
                        var cssClassUpdated = menuItem.Attributes["class"].Replace("active_tab ", string.Empty);
                        menuItem.Attributes.Remove("class");
                        menuItem.Attributes.Add("class", cssClassUpdated);
                    }
                }
            }

            if (liName.Length < 1)
            {
                return;
            }
            var liMenu = page.Master.FindControl(liName) as System.Web.UI.HtmlControls.HtmlGenericControl;

            if (liMenu == null)
            {
                return;
            }
            var cssClass = liMenu.Attributes["class"];
            liMenu.Attributes.Remove("class");
            liMenu.Attributes.Add("class", "active_tab " + cssClass);

            switch (liName)
            {
                case "liHome":
                    liMenu.Style.Add("background", "url(\"/Contents/Images/Icons/32/i_32_home_hover.png\") no-repeat scroll transparent;");
                    break;
                case "liCall":
                    liMenu.Style.Add("background", "url(\"/Contents/Images/Icons/32/i_32_call_hover.png\") no-repeat scroll transparent;");
                    break;
                case "liForm":
                    liMenu.Style.Add("background", "url(\"/Contents/Images/Icons/32/i_32_form_hover.png\") no-repeat scroll transparent;");
                    break;
                case "liSettings":
                    liMenu.Style.Add("background", "url(\"/Contents/Images/Icons/32/i_32_settings_hover.png\") no-repeat scroll transparent;");
                    break;
                case "liUser":
                    liMenu.Style.Add("background", "url(\"/Contents/Images/Icons/32/i_32_user_hover.png\") no-repeat scroll transparent;");
                    break;
            }

            liMenu.Style.Add("background-position", "10px 29px");
            liMenu.Style.Add("background-color", "#F9F9F9");
        }
    }
}
