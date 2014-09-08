using System;
using SecondFloor.DataContracts.Messages;
using SecondFloor.Model;
using SecondFloor.Service.ExtensionMethods;

namespace SecondFloor.Service
{
    public class AnuncianteService
    {
        private IAnuncianteRepository _anuncianteRepository;

        public AnuncianteService(IAnuncianteRepository anuncianteRepository)
        {
            _anuncianteRepository = anuncianteRepository;
        }

        public CadastroAnuncianteResponse CadastrarAnunciante(CadastroAnuncianteRequest request)
        {
            var anunciante = request.Anunciante.ConvertToAnunciante();
            if (anunciante.GetBrokenBusinessRules().Count > 0)
            {
                return new CadastroAnuncianteResponse() { Message = anunciante.GetErrorMessages().ToString(), Success = false};
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

            return new CadastroAnuncianteResponse(){ Message = "Anuncio cadastrado com sucesso.", Success = true };
        }
    }
}