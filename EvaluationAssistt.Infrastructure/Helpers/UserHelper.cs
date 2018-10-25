using EvaluationAssistt.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvaluationAssistt.Infrastructure.Helpers
{
    public class UserHelper
    {
        /// <summary>
        /// GET: Session'da yer alan AgentId deÄŸerini dÃ¶ndÃ¼rÃ¼r.
        /// SET: Session'da yer alan AgentId'ye deÄŸer atar.
        /// </summary>
        public static int UserId
        {
            get
            {
                return HttpContext.Current.Session["UserId"] != null
                    ? Convert.ToInt32(HttpContext.Current.Session["UserId"])
                    : 0;
            }
            set
            {
                HttpContext.Current.Session["UserId"] = value;
            }
        }

        public static string LoginId
        {
            get
            {
                return HttpContext.Current.Session["LoginId"] != null
                    ? HttpContext.Current.Session["LoginId"].ToString()
                    : null;
            }
            set
            {
                HttpContext.Current.Session["LoginId"] = value;
            }
        }

        public static string FullName
        {
            get
            {
                return HttpContext.Current.Session["FullName"] != null
                   ? HttpContext.Current.Session["FullName"].ToString()
                   : null;
            }
            set
            {
                HttpContext.Current.Session["FullName"] = value;
            }
        }

        public static string AccountName
        {
            get
            {
                return HttpContext.Current.Session["AccountName"] != null
                    ? HttpContext.Current.Session["AccountName"].ToString()
                    : null;
            }
            set
            {
                HttpContext.Current.Session["AccountName"] = value;
            }
        }

        public static UserType Type
        {
            get
            {
                return HttpContext.Current.Session["UserType"] != null
                    ? (UserType)HttpContext.Current.Session["UserType"]
                    : 0;
            }
            set
            {
                HttpContext.Current.Session["UserType"] = value;
            }
        }

        public static UserType GetUserType(int typeId)
        {
            switch (typeId)
            {
                case 1:
                    return UserType.Admin;

                case 2:
                    return UserType.QualityExpert;

                case 3:
                    return UserType.GroupLeader;

                case 4:
                    return UserType.TeamLeader;

                case 5:
                    return UserType.Agent;
                default:
                    return UserType.Agent;
            }
        }

        public static int? TeamId
        {
            get
            {
                return HttpContext.Current.Session["TeamId"] != null
                    ? Convert.ToInt32(HttpContext.Current.Session["TeamId"])
                    : (int?)null;
            }
            set
            {
                HttpContext.Current.Session["TeamId"] = value;
            }
        }

        public static string TeamName
        {
            get
            {
                return HttpContext.Current.Session["TeamName"] != null
                   ? HttpContext.Current.Session["TeamName"].ToString()
                   : null;
            }
            set
            {
                HttpContext.Current.Session["TeamName"] = value;
            }
        }

        public static int? GroupId
        {
            get
            {
                return HttpContext.Current.Session["GroupId"] != null
                    ? Convert.ToInt32(HttpContext.Current.Session["GroupId"])
                    : (int?)null;
            }
            set
            {
                HttpContext.Current.Session["GroupId"] = value;
            }
        }

        public static string GroupName
        {
            get
            {
                return HttpContext.Current.Session["GroupName"] != null
                   ? HttpContext.Current.Session["GroupName"].ToString()
                   : null;
            }
            set
            {
                HttpContext.Current.Session["GroupName"] = value;
            }
        }

        public static List<int> TeamIdsAssociated
        {
            get
            {
                return HttpContext.Current.Session["TeamIdsAssociated"] != null
                   ? HttpContext.Current.Session["TeamIdsAssociated"] as List<int>
                   : new List<int>();
            }
            set
            {
                HttpContext.Current.Session["TeamIdsAssociated"] = value;
            }
        }

        public static List<string> Pages
        {
            get
            {
                return HttpContext.Current.Session["Pages"] != null
                   ? HttpContext.Current.Session["Pages"] as List<string>
                   : new List<string>();
            }
            set
            {
                HttpContext.Current.Session["Pages"] = value;
            }
        }
    }
}
