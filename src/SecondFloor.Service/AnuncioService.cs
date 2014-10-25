using System;
using Microsoft.Practices.ObjectBuilder2;
using SecondFloor.DataContracts.Messages.Anunciante;
using SecondFloor.DataContracts.Messages.Anuncio;
using SecondFloor.I18n;
using SecondFloor.Model;
using SecondFloor.Model.Rules;
using SecondFloor.Service.ExtensionMethods;
using SecondFloor.ServiceContracts;

namespace SecondFloor.Service
{
    public class AnuncioService : IAnuncioService
    {
        private readonly IAnuncioRepository _anuncioRepository;
        private readonly IAnuncianteRepository _anuncianteRepository;
        private readonly IEnderecoRepository _enderecoRepository;

        public AnuncioService(IAnuncioRepository anuncioRepository, IAnuncianteRepository anuncianteRepository, IEnderecoRepository enderecoRepository)
        {
            _anuncioRepository = anuncioRepository;
            _anuncianteRepository = anuncianteRepository;
            _enderecoRepository = enderecoRepository;
        }

        public EncontrarTodosAnunciosResponse EncontrarTodosAnuncios(EncontrarTodosAnunciosRequest request)
        {
            var response = new EncontrarTodosAnunciosResponse();

            try
            {
                var id = Guid.Parse(request.AnuncianteId);
                var anunciante = _anuncianteRepository.EncontrarAnunciantePor(id);
                if (anunciante == null)
                {
                    response.Message = Resources.AnuncioService_EncontrarTodosAnuncios_NotFound;
                    response.MessageType = "alert-warning";
                    response.Success = false;
                    return response;
                }

                response.Message = string.Format(Resources.AnuncioService_EncontrarTodosAnuncios_Success, anunciante.Produtos);
                response.MessageType = "alert-info";
                response.Success = true;
                response.Anuncios = anunciante.Anuncios.ConvertToListaAnunciosDtos();
            }
            catch (Exception ex)
            {
                response.Message = Resources.AnuncioService_EncontrarTodosAnuncios_Error + "\n" + ex.Message;
                response.MessageType = "alert-danger";
                response.Success = false;
            }

            return response;
        }

        public EncontrarAnuncioResponse EncontrarAnuncioPor(EncontrarAnuncioRequest request)
        {
            var response = new EncontrarAnuncioResponse();

            try
            {
                var id = Guid.Parse(request.Id);
                var anuncio = _anuncioRepository.EncontrarAnuncioPor(id);
                if (anuncio == null)
                {
                    response.Message = Resources.AnuncioService_EncontrarAnuncioPor_NotFound;
                    response.MessageType = "alert-warning";
                    response.Success = false;
                    return response;
                }

                response.Message = Resources.AnuncioService_EncontrarAnuncioPor_Success;
                response.MessageType = "alert-info";
                response.Success = true;
                response.Anuncio = anuncio.ConvertToAnuncioDto();
            }
            catch (Exception ex)
            {
                response.Message = Resources.AnuncioService_EncontrarAnuncioPor_Error + "\n" + ex.Message;
                response.MessageType = "alert-danger";
                response.Success = false;
            }

            return response;
        }

        public CadastrarAnuncioResponse CadastrarAnuncio(CadastrarAnuncioRequest request)
        {
            var response = new CadastrarAnuncioResponse();

            var anuncio = request.Anuncio.ConvertToAnuncio();
            if (!anuncio.IsValid())
            {
                anuncio.BrokenRules.ForEach(x => response.Rules.Add(x.Key, x.Value));

                response.Message = anuncio.GetErrorMessages().ToString();
                response.MessageType = "alert-warning";
                response.Success = false;
                return response;
            }

            try
            {
                var anuncianteId = Guid.Parse(request.AnuncianteId);
                var anunciante = _anuncianteRepository.FindBy(anuncianteId);
                if (anunciante == null)
                {
                    response.Message = Resources.AnuncioService_CadastrarAnuncio_NotFound;
                    response.MessageType = "alert-warning";
                    response.Success = false;
                    return response;
                }

                /*var enderecoId = Guid.Parse(request.EnderecoId);
                var endereco = _enderecoRepository.FindBy(enderecoId);
                if (endereco == null)
                {
                    response.Message = "Endereco não encontrado para inclusão do novo Anuncio";
                    response.MessageType = "alert-warning";
                    response.Success = false;
                    return response;
                }*/
                
                anuncio.Status = AnuncioStatusEnum.Cadastrado;
                anunciante.Anuncios.Add(anuncio);
                
                //anuncio.Anunciante = anunciante;
                _anuncioRepository.InserirAnuncio(anuncio);
                _anuncioRepository.Persist();

                response.Message = Resources.AnuncioService_CadastrarAnuncio_Success;
                response.MessageType = "alert-info";
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = Resources.AnuncioService_CadastrarAnuncio_Error + "\n" + ex.Message;
                response.MessageType = "alert-danger";
                response.Success = false;
            }

            return response;
        }

        public AlterarAnuncioResponse AlterarAnuncio(AlterarAnuncioRequest request)
        {
            var response = new AlterarAnuncioResponse();

            try
            {
                var id = Guid.Parse(request.Anuncio.Id);
                var anuncio = _anuncioRepository.EncontrarAnuncioPor(id);
                if (anuncio == null)
                {
                    response.Message = "Anuncio não encontrado!";
                    response.MessageType = "alert-warning";
                    response.Success = false;
                    return response;
                }

                var novoAnuncio = request.Anuncio.ConvertToAnuncio();
                anuncio.Titulo = novoAnuncio.Titulo;
                anuncio.DataInicio = novoAnuncio.DataInicio;
                anuncio.DataFim = novoAnuncio.DataFim;
                anuncio.Logradouro = novoAnuncio.Logradouro;
                anuncio.Numero = novoAnuncio.Numero;
                anuncio.Complemento = novoAnuncio.Complemento;
                anuncio.Bairro = novoAnuncio.Bairro;
                anuncio.Cidade = novoAnuncio.Cidade;
                anuncio.Estado = novoAnuncio.Estado;
                anuncio.Cep = novoAnuncio.Cep;

                if(anuncio.Status == AnuncioStatusEnum.Cadastrado)
                    anuncio.Status = AnuncioStatusEnum.Cadastrado;
                else if (anuncio.Status == AnuncioStatusEnum.Agendado)
                    anuncio.Status = AnuncioStatusEnum.Agendado;
                else if (anuncio.Status == AnuncioStatusEnum.Publicado)
                    anuncio.Status = AnuncioStatusEnum.PublicadoAlterado;

                if (!anuncio.IsValid())
                {
                    anuncio.BrokenRules.ForEach(x => response.Rules.Add(x.Key, x.Value));

                    response.Message = anuncio.GetErrorMessages().ToString();
                    response.MessageType = "alert-warning";
                    response.Success = false;
                    return response;
                }

                _anuncioRepository.AtualizarAnuncio(anuncio);
                _anuncioRepository.Persist();

                response.Message = "Anuncio atualizado com sucesso!";
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

        public ExcluirAnuncioResponse ExcluirAnuncio(ExcluirAnuncioRequest request)
        {
            //throw new NotImplementedException("Anuncio não pode ser exclido");
            var response = new ExcluirAnuncioResponse();

            try
            {
                var id = Guid.Parse(request.Id);
                var anuncio = _anuncioRepository.EncontrarAnuncioPor(id);
                if (anuncio == null)
                {
                    response.Message = "Anuncio não encontrado!";
                    response.MessageType = "alert-warning";
                    response.Success = false;
                    return response;
                }

                _anuncioRepository.ExcluirAnuncio(anuncio);
                _anuncioRepository.Persist();

                response.Message = "Anuncio excluido com sucesso!";
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

        public PublicarAnuncioResponse EnviarAnuncioParaPublicacao(PublicarAnuncioRequest request)
        {
            var response = new PublicarAnuncioResponse();

            try
            {
                var id = Guid.Parse(request.Id);
                var anuncio = _anuncioRepository.EncontrarAnuncioPor(id);
                if (anuncio == null)
                {
                    response.Message = Resources.AnuncioService_EnviarAnuncioParaPublicacao_NotFound;
                    response.MessageType = "alert-warning";
                    response.Success = false;
                    return response;
                }

                if (anuncio.Status == AnuncioStatusEnum.Cadastrado)
                    anuncio.Status = AnuncioStatusEnum.Agendado;

                _anuncioRepository.AtualizarAnuncio(anuncio);
                _anuncioRepository.Persist();

                response.Message = Resources.AnuncioService_EnviarAnuncioParaPublicacao_Success;
                response.MessageType = "alert-info";
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = Resources.AnuncioService_EnviarAnuncioParaPublicacao_Error + "\n" + ex.Message;
                response.MessageType = "alert-danger";
                response.Success = false;
            }

            return response;
        }

        public EfetuarPublicacaoResponse PublicarAnuncio()
        {
            var response = new EfetuarPublicacaoResponse();

            const AnuncioStatusEnum status = AnuncioStatusEnum.Agendado;
            var anuncios = _anuncioRepository.EncontrarAnunciosPorStatus(status);
            if (anuncios.Count == 0)
            {
                response.Message = Resources.AnuncioService_PublicarAnuncio_NotFound;
                response.MessageType = "alert-warning";
                response.Success = false;
                return response;
            }

            try
            {
                anuncios.ForEach(anuncio => anuncio.Status = AnuncioStatusEnum.Publicado);
                anuncios.ForEach(anuncio => _anuncioRepository.AtualizarAnuncio(anuncio));
                _anuncioRepository.Persist();

                response.Message = Resources.AnuncioService_PublicarAnuncio_Success;
                response.MessageType = "alert-info";
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = Resources.AnuncioService_PublicarAnuncio_Error + "\n" + ex.Message;
                response.MessageType = "alert-danger";
                response.Success = false;
            }

            return response;
        }
    }
}