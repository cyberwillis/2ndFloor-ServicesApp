using System;
using Quartz;

namespace SecondFloor.Wcf.SelfHost.Jobs
{
    public class JobPublicacao : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            Console.WriteLine("{0} procurando anuncios para publicação... ", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));

            //TODO: chamar servico de publicacao
        }
    }
}