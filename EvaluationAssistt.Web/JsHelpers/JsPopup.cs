using EvaluationAssistt.Infrastructure.Enums;
using EvaluationAssistt.Infrastructure.Helpers;
using System;
using System.Web.UI;

namespace EvaluationAssistt.Web.JsHelpers
{
    public class JsPopup
    {
        public static void Popup(Page page, MessageType type, string message, bool closeAfter = false)
        {
            if (page == null)
            {
                return;
            }
            var _title = String.Empty;
            var _type = String.Empty;
            var _message = message.Replace("\n", "<br />");

            switch (type)
            {
                case MessageType.Success:
                    _title = MessageHelper.MessageType.Information;
                    _type = "info";
                    break;
                case MessageType.Warning:
                    _title = MessageHelper.MessageType.Warning;
                    _type = "alert";
                    break;
                case MessageType.Error:
                    _title = MessageHelper.MessageType.Error;
                    _type = "error";
                    break;
            }

            string script;

            if (!closeAfter)
            {
                script = String.Format("$(document).ready(function(){{$.msgbox(\"<b>{0}</b><br /><br />{1}\",{{ type: \"{2}\",buttons:[{{ type: \"submit\", value: \"Tamam\" }}]}})}});", _title, _message, _type);
            }
            else
            {
                script = String.Format("$(document).ready(function(){{$.msgbox(\"<b>{0}</b><br /><br />{1}\",{{ type: \"{2}\",buttons:[{{ type: \"submit\", value: \"Tamam\" }}]}}, function() {{window.close(); }}  )}});", _title, _message, _type);
            }

            page.ClientScript.RegisterClientScriptBlock(typeof(string), Guid.NewGuid().ToString(), script, true);
        }

        public static void Popup(Page page, MessageType type, string message, string redirectTo)
        {
            if (page == null)
            {
                return;
            }
            var _title = String.Empty;
            var _type = String.Empty;
            var _message = message.Replace("\n", "<br />");

            switch (type)
            {
                case MessageType.Success:
                    _title = MessageHelper.MessageType.Information;
                    _type = "info";
                    break;
                case MessageType.Warning:
                    _title = MessageHelper.MessageType.Warning;
                    _type = "alert";
                    break;
                case MessageType.Error:
                    _title = MessageHelper.MessageType.Error;
                    _type = "error";
                    break;
            }

            var script = String.Format("$(document).ready(function(){{$.msgbox(\"<b>{0}</b><br /><br />{1}\",{{ type: \"{2}\",buttons:[{{ type: \"submit\", value: \"Tamam\" }}]}}, function() {{window.location.href = '{3}'; }}  )}});", _title, _message, _type, redirectTo);

            page.ClientScript.RegisterClientScriptBlock(typeof(string), Guid.NewGuid().ToString(), script, true);
        }

        public static void ForeignKeyError(Page page)
        {
            if (page == null)
            {
                return;
            }
            var script = String.Format("$(document).ready(function(){{$.msgbox(\"<b>{0}</b><br /><br />{1}\",{{ type: \"error\",buttons:[{{ type: \"submit\", value: \"Tamam\" }}]}})}});", "Ä°ÅŸlem BaÅŸarÄ±sÄ±z!", "Ä°lgili kayÄ±t, baÅŸka bir tabloda kullanÄ±ldÄ±ÄŸÄ±ndan dolayÄ± silinemez!");

            page.ClientScript.RegisterClientScriptBlock(typeof(string), "FK", script, true);
        }

        public static void PrimaryKeyError(Page page)
        {
            if (page == null)
            {
                return;
            }
            var script = String.Format("$(document).ready(function(){{$.msgbox(\"<b>{0}</b><br /><br />{1}\",{{ type: \"error\",buttons:[{{ type: \"submit\", value: \"Tamam\" }}]}})}});", "Ä°ÅŸlem BaÅŸarÄ±sÄ±z!", "Ä°lgili kayÄ±t, zaten tabloda bulunduÄŸundan dolayÄ± eklenemez!");

            page.ClientScript.RegisterClientScriptBlock(typeof(string), "PK", script, true);
        }
    }
}
