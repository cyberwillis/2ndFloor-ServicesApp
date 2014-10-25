using System;
using Quartz;
using SecondFloor.Model;
using SecondFloor.RepositoryEF;
using SecondFloor.RepositoryEF.Repositories;
using SecondFloor.Service;
using SecondFloor.ServiceContracts;

namespace SecondFloor.Wcf.SelfHost.Jobs
{
    public class JobPublicacao : IJob
    {
        private IAnuncioService _anuncioService;
        

        public JobPublicacao() : this(new AnuncioService(new AnuncioRepository(new EFUnitOfWork<Anuncio>()),null,null))
        {

        }

        public JobPublicacao(IAnuncioService anuncioService)
        {
            _anuncioService = anuncioService;
        }

        

        public void Execute(IJobExecutionContext context)
        {
            Console.Write("{0} procurando anuncios... ", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));

            var response = _anuncioService.PublicarAnuncio(); //Publicacao
            
            Console.WriteLine(response.Message);
        }
    }
}