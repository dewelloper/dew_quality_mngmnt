using EvaluationAssistt.Data.Interface;
using EvaluationAssistt.Data.Repository.EFRepository;
using EvaluationAssistt.Domain.Entity;
using EvaluationAssistt.Infrastructure.Helpers;
using Microsoft.Practices.Unity;
using System;
using System.Web;

namespace EvaluationAssistt.Web
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            BuildUpContainer();
        }

        protected void Session_Start(object sender, EventArgs e)
        {
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
        }

        protected void Application_Error(object sender, EventArgs e)
        {
        }

        protected void Session_End(object sender, EventArgs e)
        {
        }

        protected void Application_End(object sender, EventArgs e)
        {
            DisposeContainer();
        }

        private void BuildUpContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<EvaluationAssisttEntities>(new InjectionConstructor());
            container.RegisterType<IUnitOfWork, EFUnitOfWork>();
            container.RegisterType(typeof(IRepository<>), typeof(EFRepository<>));


            HttpContext.Current.Application["UnityContainer"] = container;

        }

        private void DisposeContainer()
        {
            UnityHelper.Container.Dispose();

            if (HttpContext.Current.Session != null)
            {
                HttpContext.Current.Session.Remove("UnityContainer");
            }
        }
    }
}
