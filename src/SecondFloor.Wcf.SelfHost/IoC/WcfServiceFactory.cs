using Microsoft.Practices.Unity;
using SecondFloor.Model;
using SecondFloor.RepositoryEF;
using SecondFloor.Service;
using SecondFloor.ServiceContracts;

namespace SecondFloor.Wcf.SelfHost.IoC
{
	public class WcfServiceFactory : UnityServiceHostFactory
    {
        protected override void ConfigureContainer(IUnityContainer container)
        {
			// register all your components with the container here
            // container
            //    .RegisterType<IService1, Service1>()
            //    .RegisterType<DataContext>(new HierarchicalLifetimeManager());

            container
                .RegisterType<IAnuncioService, AnuncioService>()
                .RegisterType<IAnuncioRepository, AnuncioRepository>()
                .RegisterType<IAnuncianteRepository, AnuncianteRepository>()
                .RegisterType<AnuncioContext, AnuncioContext>(new HierarchicalLifetimeManager());
            
        }
    }    
}