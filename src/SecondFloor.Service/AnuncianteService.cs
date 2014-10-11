using System;
using Microsoft.Practices.ObjectBuilder2;
using SecondFloor.DataContracts.Messages.Anunciante;
using SecondFloor.Model;
using SecondFloor.Model.Rules;
using SecondFloor.Model.Rules.Specifications;
using SecondFloor.Service.ExtensionMethods;
using SecondFloor.ServiceContracts;

namespace SecondFloor.Service
{
    
    public class AnuncianteService : IAnuncianteService
    {
        private IAnuncioRepository _anuncioRepository;
        private IAnuncianteRepository _anuncianteRepository;

        public AnuncianteService(IAnuncioRepository anuncioRepository, IAnuncianteRepository anuncianteRepository )
        {
            _anuncianteRepository = anuncianteRepository;
            _anuncioRepository = anuncioRepository;
        }

        /*public CadastrarAnuncioResponse CadastrarAnuncio(CadastrarAnuncioRequest request )
        {
            var response = new CadastrarAnuncioResponse();

            var anunciante = _anuncianteRepository.EncontrarAnunciantePor(Guid.Parse(request.AnuncianteId)); //(Contexto Anunciante)
            //var anunciante = _anuncianteRepository.EncontrarAnunciantePorToken(request.AnuncianteToken); //(Contexto Anunciante)
            if (anunciante == null)
            {
                response.Message = "Anunciante não identificado.";
                response.MessageType = "alert-warning";
                response.Success = false;
                return response;
            }
            
            var anuncio = request.Anuncio.ConvertToAnuncio();
            anuncio.Anunciante = anunciante; //(Contexto Anuncio), hidratacao por fora para que possamos passar para o contexto especifico, não há necessidade de cache
            if (anuncio.GetBrokenBusinessRules().Count != 0)
            {
                response.Message = anuncio.GetErrorMessages().ToString();
                response.MessageType = "alert-warning";
                response.Success = false;
                return response;
            }

            try
            {
                _anuncioRepository.InserirAnuncio(anuncio);
                _anuncioRepository.Persist();

                response.Message = "Anuncio cadastrado com sucesso.";
                response.MessageType = "alert-info";
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = "Ocorreu um erro:\n" + ex.Message;
                response.MessageType = "alert-danger";
                response.Success = false;
            }

            return response;
        }*/

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
                _anuncianteRepository.InserirAnunciante(anunciante);
                _anuncianteRepository.Persist();

                response.Message = "Anuncio cadastrado com sucesso.";
                response.MessageType = "alert-info";
                response.Success = true;
                response.Id = anunciante.Id.ToString();
            }
            catch (Exception ex)
            {
                response.Message = "Ocorreu um erro:\n" + ex.Message;
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
                    response.Message = "Nenhum anunciante encontrado!";
                    response.MessageType = "alert-warning";
                    response.Success = false;
                    return response;
                }

                response.Message = string.Format("Encontrado {0} anunciantes", anunciantes.Count);
                response.MessageType = "alert-info";
                response.Success = true;
                response.Anunciantes = anunciantes.ConvertToListaAnunciantesDto();
            }
            catch (Exception ex)
            {
                response.Message = "Ocorreu um erro\n" + ex.Message;
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
                    response.Message = "Anunciante não encontrado!";
                    response.MessageType = "alert-warning";
                    response.Success = false;
                    return response;
                }

                response.Message = "Anunciante encontrado!";
                response.MessageType = "alert-info";
                response.Success = true;
                response.Anunciante = anunciante.ConvertToAnuncianteDto();
            }
            catch (Exception ex)
            {
                response.Message = "Ocorreu um erro\n" + ex.Message;
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
                    response.Message = "Anunciante não encontrado!";
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

                response.Message = "Anunciante atualizado com sucesso!";
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