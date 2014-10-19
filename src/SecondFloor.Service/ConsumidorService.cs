using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using SecondFloor.DataContracts.Messages.Consumidor;
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
            var response = new AtribuirRatingOfertaResponse() {Success = true, Message = "Rating enviado com sucesso"};

            //TODO: registrar no banco

            return response;
        }

        public CadastrarConsumidorResponse CadastrarConsumidor(CadastrarConsumidorRequest request)
        {
            var response = new CadastrarConsumidorResponse(){Success = true, Message = "Cadastrado com sucesso", Token = new Guid().ToString()};

            //TODO: registrar no banco

            return response;
        }

        public LogonConsumidorResponse LogonConsumidor(LogonConsumidorRequest request)
        {
            var response = new LogonConsumidorResponse(){Success = true, Message = "Logado com sucesso", Token = new Guid().ToString()};

            //TODO: buscar no banco

            return response;
        }
    }
}