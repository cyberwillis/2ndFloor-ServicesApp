using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using Microsoft.Practices.Unity;
using SecondFloor.Model;
using SecondFloor.RepositoryEF;
using SecondFloor.Service;
using SecondFloor.ServiceContracts;

namespace SecondFloor.Wcf.SelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            //IoC Unity inicialization
            var container = new UnityContainer()
                .RegisterType<IAnuncioService, AnuncioService>()
                .RegisterType<IAnuncioRepository, AnuncioRepository>()
                .RegisterType<IAnuncianteRepository, AnuncianteRepository>()
                .RegisterType<AnuncioContext, AnuncioContext>(new HierarchicalLifetimeManager());
            
            //var host = new ServiceHost(typeof(AnuncioService));
            //IoC Container implementation: 
            //http://www.devtrends.co.uk/blog/introducing-unity.wcf-providing-easy-ioc-integration-for-your-wcf-services
            var host = new UnityServiceHost(container,typeof(AnuncioService)); 

            try
            {
                host.Open();

                Console.WriteLine("Service is up and running with these endpoints:");

                ServiceEndpointCollection endpoints = host.Description.Endpoints;

                foreach (ServiceEndpoint serviceEndpoint in endpoints)
                {
                    Console.WriteLine(serviceEndpoint.Address);
                }

                Console.WriteLine("Type <ENTER> to close");
                Console.ReadLine();

                host.Close();
            }
            catch (FaultException fe)
            {
                Console.WriteLine(fe.Reason);
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine(ce.Message);
            }
            catch (TimeoutException te)
            {
                Console.WriteLine(te.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                /*if (host.State == CommunicationState.Faulted)
                    host.Open();*/
            }
        }
    }
}
