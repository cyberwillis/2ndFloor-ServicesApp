using System;
using System.ServiceModel;
using Microsoft.Practices.Unity;
using SecondFloor.Infrastructure.Repository;
using SecondFloor.Model;
using SecondFloor.RepositoryEF;
using SecondFloor.RepositoryEF.Repositories;
using SecondFloor.Service;
using SecondFloor.ServiceContracts;
using SecondFloor.Wcf.SelfHost.IoC;

namespace SecondFloor.Wcf.SelfHost
{
	public class WcfServiceFactory : UnityServiceHostFactory
    {
        public ServiceHost GetInstance(Type serviceType, params Uri[] baseAddresses)
	    {
            return base.CreateServiceHost(serviceType, baseAddresses);
	    }

	    protected override void ConfigureContainer(IUnityContainer container)
        {
			// register all your components with the container here
            // container
            //    .RegisterType<IService1, Service1>()
            //    .RegisterType<DataContext>(new HierarchicalLifetimeManager());

            container
                .RegisterType<IAnuncianteService, AnuncianteService>()
                .RegisterType<IAnuncioRepository, AnuncioRepository>()
                .RegisterType<IAnuncianteRepository, AnuncianteRepository>()
                .RegisterType<AnuncianteContext>( new HierarchicalLifetimeManager() );
                //.RegisterInstance<IAnuncioContext>(new AnuncianteContext());

            /*container.RegisterInstance<TimerViewModel>(new TimerViewModel());
            container.RegisterType<IPieceImageManager, PieceImageManager>();
            container.RegisterType<IImageFileManager, ImageFileManager>(new InjectionConstructor("/images"));
            container.RegisterType<IImageManager, ImageManager>();*/
        }


    }    
}