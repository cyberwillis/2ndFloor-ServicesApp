using System;
using SecondFloor.DataContracts.Messages;
using SecondFloor.Infrastructure.Repository;
using SecondFloor.Model;
using SecondFloor.Service.ExtensionMethods;
using SecondFloor.ServiceContracts;

namespace SecondFloor.Service
{
    public class AnuncioService : IAnuncioService
    {
        private IAnuncioRepository _anuncioRepository;
        private IAnuncianteRepository _anuncianteRepository;

        public AnuncioService(IAnuncioRepository anuncioRepository, IAnuncianteRepository anuncianteRepository )
        {
            _anuncianteRepository = anuncianteRepository;
            _anuncioRepository = anuncioRepository;
        }

        public CadastrarAnuncioResponse CadastrarAnuncio(CadastrarAnuncioRequest request )
        {
            var anuncio = request.Anuncio.ConvertToAnuncio();
            
            var anunciante = _anuncianteRepository.EncontrarAnunciantePorToken(request.AnuncianteToken); //(Contexto Anunciante)
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
    }
}