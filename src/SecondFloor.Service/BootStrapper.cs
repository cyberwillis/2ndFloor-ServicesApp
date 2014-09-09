using SecondFloor.Model;
using SecondFloor.RepositoryEF;
using SecondFloor.ServiceContracts;
using StructureMap;

namespace SecondFloor.Service
{
    public static class BootStrapper
    {
        public static void RegisterClasses()
        {
            ObjectFactory.Configure(x => 
            {
                x.For<IAnuncioRepository>().Use<AnuncioRepository>();
                x.For<IAnuncianteRepository>().Use<AnuncianteRepository>();
                x.For<IAnuncioService>().Use<AnuncioService>();
            });
        }
    }
}