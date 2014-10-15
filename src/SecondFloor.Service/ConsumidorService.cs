using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using SecondFloor.DataContracts.Messages.ConsumidorOfertas;
using SecondFloor.Model;
using SecondFloor.Service.ExtensionMethods;
using SecondFloor.ServiceContracts;

namespace SecondFloor.Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, Namespace = "services.secondfloor.com",Name = "ConsumidorServiceClient")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ConsumidorService : IConsumidorService
    {
        private readonly IOfertaRepository _ofertaRepository;

        public ConsumidorService( IOfertaRepository ofertaRepository )
        {
            _ofertaRepository = ofertaRepository;
        }

        public EncontrarOfertaResponse EncontrarOfertaPor(EncontrarOfertaRequest request)
        {
            var response = new EncontrarOfertaResponse();
            try
            {
                var ofertas = _ofertaRepository.EncontrarOfertasPorProduto(request.Produto);
                if (ofertas == null)
                {
                    response.Message = "Nenhuma oferta encontrada";
                    response.MessageType = "alert-warning";
                    response.Success = false;
                    return response;
                }

                response.Message = string.Format("Encontrado {0} ofertas", ofertas.Count);
                response.MessageType = "alert-info";
                response.Success = true;
                response.Ofertas = ofertas.ConvertToListaConsumidorOfertasDto();
            }
            catch (Exception ex)
            {
                response.Message = "Ocorreu um erro\n" + ex.Message;
                response.MessageType = "alert-danger";
                response.Success = false;
            }

            return response;
        }

        public AtribuirRatingOfertaResponse AtribuirRatingPara(AtribuirRatingOfertaRequest request)
        {
            var response = new AtribuirRatingOfertaResponse();

            //TODO: implementacao da pontuacao
            //TODO: pensar com calma
            response.Message = string.Format("FAKE: Rating Enviado com sucesso!");
            response.MessageType = "alert-info";
            response.Success = true;

            return response;
        }
    }
}