using System.ComponentModel.Composition.Hosting;
using System.ServiceModel;
using System.Windows;
using Airline.Services.Reward.Contracts;
using Autofac;
using Autofac.Integration.Wcf;
using MefContrib.Containers;
using MefContrib.Integration.Autofac;
using Thinktecture.IdentityServer.Repositories;

namespace Airline.IdentityServer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Container.Current = new CompositionContainer(new RepositoryExportProvider(), SetUpExportProviderForAutofac());
        }

        private ContainerExportProvider SetUpExportProviderForAutofac()
        {
            // Autofac container builder
            var builder = new ContainerBuilder();

            // Register reward service
            builder.Register(c => new ChannelFactory<IRewardServiceClient>(
                new BasicHttpBinding(),
                new EndpointAddress("http://localhost:60112/RewardService.svc")))
              .SingleInstance();

            builder.Register(c => c.Resolve<ChannelFactory<IRewardServiceClient>>().CreateChannel()).UseWcfSafeRelease();

            var container = builder.Build();

            // Adapt and export to MEF
            var adapter = new AutofacContainerAdapter(container);
            return new ContainerExportProvider(adapter);
        }

    }
}
