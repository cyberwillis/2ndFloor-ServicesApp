using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Activation;
using SecondFloor.DataContracts.Messages;
using SecondFloor.Model;
using SecondFloor.Model.Specifications;
using SecondFloor.Service.ExtensionMethods;
using SecondFloor.ServiceContracts;

namespace SecondFloor.Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, Namespace = "services.am.fiap.com.br",Name = "AnuncianteServiceClient")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class AnuncianteService : IAnuncianteService
    {
        private IAnuncioRepository _anuncioRepository;
        private IAnuncianteRepository _anuncianteRepository;

        public AnuncianteService(IAnuncioRepository anuncioRepository, IAnuncianteRepository anuncianteRepository )
        {
            _anuncianteRepository = anuncianteRepository;
            _anuncioRepository = anuncioRepository;
        }

        public CadastrarAnuncioResponse CadastrarAnuncio(CadastrarAnuncioRequest request )
        {
            var anuncio = request.Anuncio.ConvertToAnuncio();
            
            //var anunciante = _anuncianteRepository.EncontrarAnunciantePorToken(request.AnuncianteToken); //(Contexto Anunciante)
            var anunciante = _anuncianteRepository.EncontrarAnunciantePor(Guid.Parse(request.AnuncianteId)); //(Contexto Anunciante)
            if (anunciante == null)
                return new CadastrarAnuncioResponse(){ Message = "Anunciante não identificado.", Success = false };

            anuncio.Anunciante = anunciante; //(Contexto Anuncio), hidratacao por fora para que possamos passar para o contexto especifico, não há necessidade de cache

            if (anuncio.GetBrokenBusinessRules().Count != 0)
                return new CadastrarAnuncioResponse() { Message = anuncio.GetErrorMessages().ToString(), Success = false };

            try
            {
                _anuncioRepository.InserirAnuncio(anuncio);
                _anuncioRepository.Persist();
            }
            catch (Exception ex)
            {
                return new CadastrarAnuncioResponse() { Message = "Ocorreu um erro:\n" + ex.Message, Success = false };
            }
            
            return new CadastrarAnuncioResponse() { Message = "Anuncio cadastrado com sucesso.", Success = true };
        }

        public CadastroAnuncianteResponse CadastrarAnunciante(CadastroAnuncianteRequest request)
        {
            var anunciante = request.Anunciante.ConvertToAnunciante();
            if (anunciante.GetBrokenBusinessRules().Count > 0)
            {
                return new CadastroAnuncianteResponse() { Message = anunciante.GetErrorMessages().ToString(), Success = false };
            }

            try
            {
                _anuncianteRepository.InserirAnunciante(anunciante);
                _anuncianteRepository.Persist();
            }
            catch (Exception ex)
            {
                return new CadastroAnuncianteResponse() { Message = "Ocorreu um erro:\n" + ex.Message, Success = false };
            }

            return new CadastroAnuncianteResponse() { Message = "Anuncio cadastrado com sucesso.", Success = true };
        }

        public EncontrarTodosAnunciantesResponse EncontrarTodosAnunciantes()
        {
            IList<Anunciante> anunciantes = null;

            try
            {
                anunciantes = _anuncianteRepository.EncontrarTodosAnunciantes();
            }
            catch (Exception ex)
            {
                return new EncontrarTodosAnunciantesResponse() { Message = "Ocorreu um erro\n" + ex.Message, Success = false };
            }

            return new EncontrarTodosAnunciantesResponse()
            {
                Message = string.Format("Encontrado {0} anunciantes",anunciantes.Count), 
                Success = true,
                Anunciantes = anunciantes.ConvertToListaAnunciantesDto()
            };
        }
        
    }
}