﻿using System;
using System.Collections.Generic;

namespace EvaluationAssistt.Infrastructure.Helpers
{
    public class ControlHelper
    {
        public static void ClearControls(System.Web.UI.WebControls.Panel pnl)
        {
            var prop_list = new Dictionary<string, object>() { { "Text", null }, { "SelectedItem", null }, { "Value", null }, { "Checked", false } };

            var type_list = new List<Type>() { typeof(System.Web.UI.WebControls.TextBox),
            typeof(DevExpress.Web.ASPxComboBox),
            typeof(DevExpress.Web.ASPxSpinEdit),
            typeof(System.Web.UI.HtmlControls.HtmlInputCheckBox) };

            foreach (var item in pnl.Controls)
            {
                var t = item.GetType();

                if (!type_list.Contains(t))
                {
                    continue;
                }
                var properties = t.GetProperties();

                foreach (var prop in properties)
                {
                    if (prop_list.ContainsKey(prop.Name))
                    {
                        prop.SetValue(item, prop_list[prop.Name]);
                        continue;
                    }
                }
            }
        }
    }
}
