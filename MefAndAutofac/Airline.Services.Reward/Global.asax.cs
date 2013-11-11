using System;
using Autofac;
using Autofac.Integration.Wcf;

namespace Airline.Services.Reward
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Airline.Services.Reward.RewardService>();
            var container = builder.Build();
            AutofacHostFactory.Container = container;
        }

        
    }
}