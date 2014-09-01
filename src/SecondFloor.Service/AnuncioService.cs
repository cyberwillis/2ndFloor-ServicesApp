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
            var response = new CadastrarAnuncioResponse();
            response.Success = false;
            response.Message = "";

            var anunciante = _anuncianteRepository.GetByToken(request.Anuncio.AnuncianteToken); //(Contexto Anunciante)
            if (anunciante != null)
            {
                var anuncio = request.Anuncio.ConvertToAnuncio();
                anuncio.Anunciante = anunciante; //(Contexto Anuncio) ,hidratacao por fora para que possamos passar para o contexto especifico, não há necessidade de cache

                if (anuncio.GetBrokenBusinessRules().Count == 0)
                {
                    _anuncioRepository.Insert(anuncio);

                    _anuncioRepository.Persist();

                    response.Message = "Anuncio cadastrado com sucesso";
                    response.Success = true;
                }
                else
                {
                    response.Message = anuncio.GetErrorMessages().ToString(); //escreve uma lista imensa de erros para o WebApp
                    response.Success = false;
                }
            }
            else
            {
                response.Message = "Anunciante não identificado";
                response.Success = false;
            }
            return response;
        }
    }
}