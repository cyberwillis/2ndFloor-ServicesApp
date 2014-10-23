using System;
using System.Data.Entity.Validation;
using Microsoft.Practices.ObjectBuilder2;
using SecondFloor.DataContracts.Messages.Endereco;
using SecondFloor.I18n;
using SecondFloor.Model;
using SecondFloor.Model.Rules;
using SecondFloor.Service.ExtensionMethods;
using SecondFloor.ServiceContracts;

namespace SecondFloor.Service
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEstadoRepository _estadoRepository;
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IAnuncianteRepository _anuncianteRepository;

        public EnderecoService(IEstadoRepository estadoRepository, IEnderecoRepository enderecoRepository, IAnuncianteRepository anuncianteRepository)
        {
            _estadoRepository = estadoRepository;
            _enderecoRepository = enderecoRepository;
            _anuncianteRepository = anuncianteRepository;
        }

        public EncontrarTodosEnderecosResponse EncontrarTodosEnderecos(EncontrarTodosEnderecosRequest request)
        {
            var response = new EncontrarTodosEnderecosResponse();

            try
            {
                var id = Guid.Parse(request.AnuncianteId);
                var anunciante = _anuncianteRepository.EncontrarAnunciantePor(id);
                if (anunciante == null)
                {
                    response.Message = Resources.EnderecoServices_EncontratTodosEnderecos_NotFound;
                    response.MessageType = "alert-warning";
                    response.Success = false;
                    return response;
                }

                response.Message = string.Format(Resources.EnderecoServices_EncontratTodosEnderecos_Success, anunciante.Enderecos.Count);
                response.MessageType = "alert-info";
                response.Success = true;
                response.Enderecos = anunciante.Enderecos.ConvertToListaEnderecosDto();
            }
            catch (Exception ex)
            {
                response.Message = Resources.EnderecoServices_EncontratTodosEnderecos_Error  + "\n" + ex.Message;
                response.MessageType = "alert-danger";
                response.Success = false;
            }

            return response;
        }

        public EncontrarEnderecoResponse EncontrarEnderecoPor(EncontrarEnderecoRequest request)
        {
            var response = new EncontrarEnderecoResponse();

            try
            {
                var id = Guid.Parse(request.Id);
                var endereco = _enderecoRepository.EncontrarEnderecoPor(id);
                if (endereco == null)
                {
                    response.Message = Resources.EnderecoServices_EncontrarEnderecoPor_NotFound;
                    response.MessageType = "alert-warning";
                    response.Success = false;
                    return response;
                }

                response.Message = Resources.EnderecoServices_EncontrarEnderecoPor_Success;
                response.MessageType = "alert-info";
                response.Success = true;
                response.Endereco = endereco.ConvertToEnderecoDto();
            }
            catch (Exception ex)
            {
                response.Message = Resources.EnderecoServices_EncontrarEnderecoPor_Error + "\n" + ex.Message;
                response.MessageType = "alert-danger";
                response.Success = false;
            }

            return response;
        }

        public CadastrarEnderecoResponse CadastrarEndereco(CadastrarEnderecoRequest request)
        {
            var response = new CadastrarEnderecoResponse();

            try
            {
                var estado = _estadoRepository.EncontrarEstadoPorSigla(request.EstadoSigla);
                if (estado == null)
                {
                    response.Message = Resources.EnderecoServices_CadastrarEndereco_EstadoNotFound;
                    response.MessageType = "alert-warning";
                    response.Success = false;
                    return response;
                }

                var endereco = request.Endereco.ConvertToEndereco();
                //endereco.Estado = estado; //inclusao de estado que veio como sigla
                //estado.Endereco = endereco;
                if (!endereco.IsValid())
                {
                    endereco.BrokenRules.ForEach(x => response.Rules.Add(x.Key, x.Value));

                    response.Message = endereco.GetErrorMessages().ToString();
                    response.MessageType = "alert-warning";
                    response.Success = false;
                    return response;
                }

                var anuncianteId = Guid.Parse(request.AnuncianteId);
                var anunciante = _anuncianteRepository.FindBy(anuncianteId);
                if (anunciante == null)
                {
                    response.Message = "";
                    response.MessageType = "alert-warning";
                    response.Success = false;
                    return response;
                }
                
                anunciante.Enderecos.Add(endereco);
                //endereco.Anunciante = anunciante;

                _enderecoRepository.InserirEndereco(endereco);
                _enderecoRepository.Persist();

                response.Message = Resources.EnderecoServices_CadastrarEndereco_Success;
                response.MessageType = "alert-info";
                response.Success = true;
            }
            catch (DbEntityValidationException ex)
            {
                response.Message = Resources.EnderecoServices_CadastrarEndereco_Error + "\n" + ex.Message;
                
                foreach (var eve in ex.EntityValidationErrors)
                {
                    response.Message += string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        response.Message += string.Format("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                            ve.PropertyName,
                            eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                            ve.ErrorMessage);
                    }
                }
                response.MessageType = "alert-danger";
                response.Success = false;
            }
            catch (Exception ex)
            {
                response.Message = Resources.EnderecoServices_CadastrarEndereco_Error + "\n" + ex.Message;
                response.MessageType = "alert-danger";
                response.Success = false;
            }
            

            return response;
        }

        public AlterarEnderecoResponse AlterarEndereco(AlterarEnderecoRequest request)
        {
            var response = new AlterarEnderecoResponse();

            try
            {
                var estado = _estadoRepository.EncontrarEstadoPorSigla(request.EstadoSigla);
                if (estado == null)
                {
                    response.Message = Resources.EnderecoServices_CadastrarEndereco_EstadoNotFound;
                    response.MessageType = "alert-warning";
                    response.Success = false;
                    return response;
                }

                var id = Guid.Parse(request.Endereco.Id);
                var endereco = _enderecoRepository.EncontrarEnderecoPor(id);
                if (endereco == null)
                {
                    response.Message = Resources.EnderecoServices_AlterarEndereco_NotFound;
                    response.MessageType = "alert-warning";
                    response.Success = false;
                    return response;
                }

                var novoEndereco = request.Endereco.ConvertToEndereco();
                endereco.Logradouro = novoEndereco.Logradouro;
                endereco.Numero = novoEndereco.Numero;
                endereco.Complemento = novoEndereco.Complemento;
                endereco.Bairro = novoEndereco.Bairro;
                endereco.Cidade = novoEndereco.Cidade;
                endereco.Estado = novoEndereco.Estado;
                //estado.Endereco = endereco;
                endereco.Cep = novoEndereco.Cep;
                if (!endereco.IsValid())
                {
                    endereco.BrokenRules.ForEach(x => response.Rules.Add(x.Key,x.Value));

                    response.Message = endereco.GetErrorMessages().ToString();
                    response.MessageType = "alert-warning";
                    response.Success = false;
                    return response;
                }

                _enderecoRepository.AtualizarEndereco(endereco);
                _enderecoRepository.Persist();

                response.Message = Resources.EnderecoServices_AlterarEndereco_Success;
                response.MessageType = "alert-info";
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = Resources.EnderecoServices_AlterarEndereco_Error + "\r" + ex.Message;
                response.MessageType = "alert-danger";
                response.Success = false;
            }

            return response;
        }

        public ExcluirEnderecoResponse ExcluirEndereco(ExcluirEnderecoRequest request)
        {
            var response = new ExcluirEnderecoResponse();

            try
            {
                var id = Guid.Parse(request.Id);
                var endereco = _enderecoRepository.EncontrarEnderecoPor(id);
                if (endereco == null)
                {
                    response.Message = Resources.EnderecoServices_ExcluirEndereco_NotFound;
                    response.MessageType = "alert-warning";
                    response.Success = false;
                    return response;
                }

                _enderecoRepository.ExcluirEndereco(endereco);
                _enderecoRepository.Persist();

                response.Message = Resources.EnderecoServices_ExcluirEndereco_Success;
                response.MessageType = "alert-info";
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = Resources.EnderecoServices_ExcluirEndereco_Error + "\n" + ex.Message;
                response.MessageType = "alert-danger";
                response.Success = false;
            }

            return response;
        }
    }
}