using System;
using SecondFloor.DataContracts.Messages;
using SecondFloor.Infrastructure.Repository;
using SecondFloor.Model;
using SecondFloor.Service.ExtensionMethods;

namespace SecondFloor.Service
{
    public class AnuncioService
    {
        private IAnuncioRepository<Anuncio, Guid> _anuncioRepository;
        private IAnuncianteRepository<Anunciante, Guid> _anuncianteRepository;

        public AnuncioService(IAnuncioRepository<Anuncio, Guid> anuncioRepository, IAnuncianteRepository<Anunciante, Guid> anuncianteRepository )
        {
            _anuncianteRepository = anuncianteRepository;
            _anuncioRepository = anuncioRepository;
        }

        public CadastrarAnuncioResponse CadastrarAnuncio(CadastrarAnuncioRequest request )
        {
            var anuncio = request.Anuncio.ConvertToAnuncio();
            
            var anunciante = _anuncianteRepository.GetByToken(request.Anuncio.AnuncianteToken); //(Contexto Anunciante)
            if (anunciante == null)
                return new CadastrarAnuncioResponse(){ Message = "Anunciante não identificado.", Success = false };

            anuncio.Anunciante = anunciante; //(Contexto Anuncio), hidratacao por fora para que possamos passar para o contexto especifico, não há necessidade de cache

            if (anuncio.GetBrokenBusinessRules().Count != 0)
                return new CadastrarAnuncioResponse() { Message = anuncio.GetErrorMessages().ToString(), Success = false };
                
            _anuncioRepository.Insert(anuncio);
            _anuncioRepository.Persist();

            return new CadastrarAnuncioResponse() { Message = "Anuncio cadastrado com sucesso.", Success = true };
        }
    }
}