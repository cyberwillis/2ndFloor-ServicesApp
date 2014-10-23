using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using SecondFloor.DataContracts.Messages.Consumidor;
using SecondFloor.DataContracts.Messages.ConsumidorOfertas;
using SecondFloor.I18n;
using SecondFloor.Model;
using SecondFloor.Model.Rules;
using SecondFloor.Service.ExtensionMethods;
using SecondFloor.ServiceContracts;

namespace SecondFloor.Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, Namespace = "services.secondfloor.com",Name = "ConsumidorServiceClient")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ConsumidorService : IConsumidorService
    {
        private readonly IOfertaRepository _ofertaRepository;
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IConsumidorRepository _consumidorRepository;

        public ConsumidorService( IOfertaRepository ofertaRepository, IFeedbackRepository feedbackRepository, IConsumidorRepository consumidorRepository )
        {
            _ofertaRepository = ofertaRepository;
            _feedbackRepository = feedbackRepository;
            _consumidorRepository = consumidorRepository;
        }

        public EncontrarOfertaResponse EncontrarOfertaPor(EncontrarOfertaRequest request)
        {
            var response = new EncontrarOfertaResponse();
            try
            {
                var ofertas = _ofertaRepository.EncontrarOfertasPorProduto(request.Produto);
                if (ofertas == null)
                {
                    response.Message = Resources.ConsumidorServices_EncontrarOfertaPor_NotFound;
                    response.MessageType = "alert-warning";
                    response.Success = false;
                    return response;
                }

                response.Message = string.Format(Resources.ConsumidorServices_EncontrarOfertaPor_Success, ofertas.Count);
                response.MessageType = "alert-info";
                response.Success = true;
                response.Ofertas = ofertas.ConvertToListaConsumidorOfertasDto();
            }
            catch (Exception ex)
            {
                response.Message = Resources.ConsumidorServices_EncontrarOfertaPor_Error + "\n" + ex.Message;
                response.MessageType = "alert-danger";
                response.Success = false;
            }
            return response;
        }

        public AtribuirRatingOfertaResponse AtribuirRatingPara(AtribuirRatingOfertaRequest request)
        {
            var response = new AtribuirRatingOfertaResponse();

            try
            {
                var ofertaId = new Guid(request.Produto);
                var oferta = _ofertaRepository.EncontrarOfertaPor(ofertaId);
                if (oferta == null)
                {
                    response.Message = Resources.ConsumidorServices_AtribuirRatingPara_NotFound;
                    response.MessageType = "alert-warning";
                    response.Success = true;
                }

                var feedback = new Feedback()
                {
                    Id = Guid.NewGuid(),
                    Nota = decimal.Parse(request.Rating),
                    Consumidor = request.Consumidor,
                    Produto = request.Produto,
                };

                _feedbackRepository.InserirFeedback(feedback);
                _feedbackRepository.Persist();

                response.Message = Resources.ConsumidorServices_AtribuirRatingPara_Success;
                response.MessageType = "alert-info";
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = Resources.ConsumidorServices_AtribuirRatingPara_Error + "\n" + ex.Message;
                response.MessageType = "alert-danger";
                response.Success = false;
            }

            return response;
        }

        public CadastrarConsumidorResponse CadastrarConsumidor(CadastrarConsumidorRequest request)
        {
            var response = new CadastrarConsumidorResponse(){Success = true, Message = "Cadastrado com sucesso", Token = new Guid().ToString()};

            var consumidor = new Consumidor() {Id = Guid.NewGuid(), Nome = request.Nome, Email = request.Email};
            if (!consumidor.IsValid())
            {
                response.Message = consumidor.GetErrorMessages().ToString();
                response.MessageType = "alert-warning";
                response.Success = false;
                return response;
            }

            try
            {
                _consumidorRepository.InserirConsumidor(consumidor);
                _consumidorRepository.Persist();

                response.Message = Resources.ConsumidorServices_CadastrarConsumidor_Success;
                response.MessageType = "alert-info";
                response.Success = true;
                response.Token = consumidor.Id.ToString();
            }
            catch (Exception ex)
            {
                response.Message = Resources.ConsumidorServices_CadastrarConsumidor_Error + "\n" + ex.Message;
                response.MessageType = "alert-danger";
                response.Success = false;
            }
            
            return response;
        }
    }
}