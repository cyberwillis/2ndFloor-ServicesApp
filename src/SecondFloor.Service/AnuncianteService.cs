using System;
using Microsoft.Practices.ObjectBuilder2;
using SecondFloor.DataContracts.Messages.Anunciante;
using SecondFloor.I18n;
using SecondFloor.Model;
using SecondFloor.Model.Rules;
using SecondFloor.Service.ExtensionMethods;
using SecondFloor.ServiceContracts;

namespace SecondFloor.Service
{
    
    public class AnuncianteService : IAnuncianteService
    {
        private readonly IAnuncianteRepository _anuncianteRepository;

        public AnuncianteService( IAnuncianteRepository anuncianteRepository )
        {
            _anuncianteRepository = anuncianteRepository;
        }

        public CadastrarAnuncianteResponse CadastrarAnunciante(CadastrarAnuncianteRequest request)
        {
            var response = new CadastrarAnuncianteResponse();

            var anunciante = request.Anunciante.ConvertToAnunciante();
            if (!anunciante.IsValid())
            {
                anunciante.BrokenRules.ForEach(x => response.Rules.Add(x.Key,x.Value));

                response.Message = anunciante.GetErrorMessages().ToString();
                response.MessageType = "alert-warning";
                response.Success = false;
                return response;
            }

            try
            {
                var anuncianteEmail = _anuncianteRepository.EncontrarAnunciantesPorEmail(anunciante.Email);
                if (anuncianteEmail.Count > 0)
                {
                    response.Message = "E-mail indisponível para cadastro";
                    response.MessageType = "alert-warning";
                    response.Success = false;
                    return response;
                }

                var anuncianteCnpj = _anuncianteRepository.EncontrarAnunciantesPorCnpj(anunciante.Cnpj);
                if (anuncianteCnpj.Count > 0)
                {
                    response.Message = "Cnpj indisponível para cadastro";
                    response.MessageType = "alert-warning";
                    response.Success = false;
                    return response;
                }
                
                _anuncianteRepository.InserirAnunciante(anunciante);
                _anuncianteRepository.Persist();

                response.Message = Resources.AnuncianteServices_CadastrarAnunciante_Success;
                response.MessageType = "alert-info";
                response.Success = true;
                response.Id = anunciante.Id.ToString();
            }
            catch (Exception ex)
            {
                response.Message = Resources.AnuncianteServices_CadastrarAnunciante_Error + "\n" + ex.Message;
                response.MessageType = "alert-danger";
                response.Success = false;
            }

            return response;
        }

        public EncontrarTodosAnunciantesResponse EncontrarTodosAnunciantes()
        {
            var response = new EncontrarTodosAnunciantesResponse();

            try
            {
                var anunciantes = _anuncianteRepository.EncontrarTodosAnunciantes();
                if (anunciantes == null)
                {
                    response.Message = Resources.AnuncianteServices_EncontrarTodosAnunciantes_NotFound;
                    response.MessageType = "alert-warning";
                    response.Success = false;
                    return response;
                }

                response.Message = string.Format(Resources.AnuncianteServices_EncontrarTodosAnunciantes_Success, anunciantes.Count);
                response.MessageType = "alert-info";
                response.Success = true;
                response.Anunciantes = anunciantes.ConvertToListaAnunciantesDto();
            }
            catch (Exception ex)
            {
                response.Message = Resources.AnuncianteServices_EncontrarTodosAnunciantes_Error + "\n" + ex.Message;
                response.MessageType = "alert-danger";
                response.Success = false;
            }

            return response;
        }

        public EncontrarAnuncianteResponse EncontrarAnunciantePor(EncontrarAnuncianteRequest request)
        {
            var response = new EncontrarAnuncianteResponse();

            try
            {
                var id = Guid.Parse(request.Id);
                var anunciante = _anuncianteRepository.EncontrarAnunciantePor(id);
                if (anunciante == null)
                {
                    response.Message = Resources.AnuncianteServices_EncontrarAnunciantePor_NotFound;
                    response.MessageType = "alert-warning";
                    response.Success = false;
                    return response;
                }

                response.Message = Resources.AnuncianteServices_EncontrarAnunciantePor_Scuccess;
                response.MessageType = "alert-info";
                response.Success = true;
                response.Anunciante = anunciante.ConvertToAnuncianteDto();
            }
            catch (Exception ex)
            {
                response.Message = Resources.AnuncianteServices_EncontrarAnunciantePor_Error + "\n" + ex.Message;
                response.MessageType = "alert-danger";
                response.Success = false;
            }

            return response;
        }

        public AlterarAnuncianteResponse AlterarAnunciante(AlterarAnuncianteRequest request)
        {
            var response = new AlterarAnuncianteResponse();

            try
            {
                var id = Guid.Parse(request.Anunciante.Id);
                var anunciante = _anuncianteRepository.EncontrarAnunciantePor(id);
                if (anunciante == null)
                {
                    response.Message = Resources.AnuncianteServices_AlterarAnunciante_NotFound;
                    response.MessageType = "alert-warning";
                    response.Success = false;
                    return response;
                }

                var novoAnunciante = request.Anunciante.ConvertToAnunciante();
                anunciante.Responsavel = novoAnunciante.Responsavel;
                anunciante.RazaoSocial = novoAnunciante.RazaoSocial;
                anunciante.Email = novoAnunciante.Email;
                anunciante.Cnpj = novoAnunciante.Cnpj;
                if (!anunciante.IsValid())
                {
                    anunciante.BrokenRules.ForEach(x => response.Rules.Add(x.Key, x.Value));

                    response.Message = anunciante.GetErrorMessages().ToString();
                    response.MessageType = "alert-warning";
                    response.Success = false;
                    return response;
                }

                _anuncianteRepository.AtualizarAnunciante(anunciante);
                _anuncianteRepository.Persist();

                response.Message = Resources.AnuncianteServices_AlterarAnunciante_Success;
                response.MessageType = "alert-info";
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = Resources.AnuncianteServices_AlterarAnunciante_Error + "\n" + ex.Message;
                response.MessageType = "alert-danger";
                response.Success = false;
            }

            return response;
        }

        public ExcluirAnuncianteResponse ExcluirAnunciante(ExcluirAnuncianteRequest request)
        {
            var response = new ExcluirAnuncianteResponse();

            try
            {
                var id = Guid.Parse(request.Id);
                var anunciante = _anuncianteRepository.EncontrarAnunciantePor(id);
                if (anunciante == null)
                {
                    response.Message = "Anunciante não encontrado!";
                    response.MessageType = "alert-warning";
                    response.Success = false;
                    return response;
                }

                _anuncianteRepository.ExcluirAnunciante(anunciante);
                _anuncianteRepository.Persist();

                response.Message = "Anunciante excluido com sucesso!";
                response.MessageType = "alert-info";
                response.Success = true;

            }
            catch (Exception ex)
            {
                response.Message = "Ocorreu um erro\n" + ex.Message;
                response.MessageType = "alert-danger";
                response.Success = false;
            }

            return response;
        }
    }
}