using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using Microsoft.Practices.Unity;
using SecondFloor.Service;
using SecondFloor.Wcf.SelfHost.IoC;

namespace SecondFloor.Wcf.SelfHost
{
    class Program
    {
        static void Main(string[] args)
        {

            //IoC Unity inicialization
            //http://www.devtrends.co.uk/blog/introducing-unity.wcf-providing-easy-ioc-integration-for-your-wcf-services
            var container = new UnityContainer();
            var host = new UnityServiceHost(container,typeof(AnuncianteService));

            //var host = new ServiceHost(typeof(AnuncianteService)); //old
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
