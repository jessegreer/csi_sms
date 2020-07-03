using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace CSIdb
{
    public static class SessionVars
    {
        public static HttpSessionState Session
        {
            get
            {
                //if (HttpContext.Current == null)
                //    throw new ApplicationException("No Http Context, No Session to Get!");

                return HttpContext.Current.Session;
            }
        }

        public static T Get<T>(string key)
        {
            if (Session[key] == null)
                return default(T);
            else
                return (T)Session[key];
        }

        public static void Set<T>(string key, T value)
        {
            Session[key] = value;
        }

        public static string GetString(string key)
        {
            string s = Get<string>(key);
            return s == null ? string.Empty : s;
        }

        public static void SetString(string key, string value)
        {
            Set<string>(key, value);
        }


        public static Dictionary<string, ProductionJobInfo> ProductionInfoDict
        {
            get
            {
                return (Dictionary<string, ProductionJobInfo>)HttpContext.Current.Session["ProductionInfoDict"];
            }

            set
            {
                HttpContext.Current.Session["ProductionInfoDict"] = value;
            }
        }

        public static List<ProductionJobInfo> ProductionJobInfoList
        {
            get
            {
                return (List<ProductionJobInfo>)HttpContext.Current.Session["ProductionJobInfoList"];
            }

            set
            {
                HttpContext.Current.Session["ProductionJobInfoList"] = value;
            }
        }

        public static Dictionary<string, List<string>> SummaryControlsAndTags
        {
            get
            {
                return (Dictionary<string, List<string>>)HttpContext.Current.Session["SummaryControlsAndTags"];
            }

            set
            {
                HttpContext.Current.Session["SummaryControlsAndTags"] = value;
            }
        }

        public static Dictionary<string, List<string>> SummaryControlIDToTags
        {
            get
            {
                return (Dictionary<string, List<string>>)HttpContext.Current.Session["SummaryControlIDToTags"];
            }

            set
            {
                HttpContext.Current.Session["SummaryControlIDToTags"] = value;
            }
        }


        public static Dictionary<string, List<string>> SummaryControlNameToTags
        {
            get
            {
                return (Dictionary<string, List<string>>)HttpContext.Current.Session["SummaryControlNameToTags"];
            }
            set
            {
                HttpContext.Current.Session["SummaryControlNameToTags"] = value;
            }
        }
    }
}