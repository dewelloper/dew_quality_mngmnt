using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvaluationAssistt.Infrastructure.Helpers
{
    public class UnityHelper
    {
        public static IUnityContainer Container
        {
            get
            {
                return HttpContext.Current.Application["UnityContainer"] as IUnityContainer;
            }
            set
            {
                HttpContext.Current.Application["UnityContainer"] = value;
            }
        }
    }
}
