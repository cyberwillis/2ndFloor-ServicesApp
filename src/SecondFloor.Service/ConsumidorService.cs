using System.ServiceModel;
using System.ServiceModel.Activation;
using SecondFloor.DataContracts.Messages.ConsumidorOfertas;
using SecondFloor.ServiceContracts;

namespace SecondFloor.Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, Namespace = "services.am.fiap.com.br",Name = "ConsumidorServiceClient")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ConsumidorService : IConsumidorService
    {
        public EncontrarOfertaResponse EncontrarOfertaPor(EncontrarOfertaRequest request)
        {
            var response = new EncontrarOfertaResponse();

            //TODO: implementacao da busca

            return response;
        }

        public AtribuirRatingOfertaResponse AtribuirRatingFor(AtribuirRatingOfertaRequest request)
        {
            var response = new AtribuirRatingOfertaResponse();

            //TODO: implementacao da pontuacao

            return response;
        }
    }
}