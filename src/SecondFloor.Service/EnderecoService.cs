using System;
using System.Data.Entity.Validation;
using Microsoft.Practices.ObjectBuilder2;
using SecondFloor.DataContracts.Messages.Endereco;
using SecondFloor.Model;
using SecondFloor.Model.Rules;
using SecondFloor.Model.Rules.Specifications;
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
                    response.Message = "Os dados deste Anunciante não foram encontrados";
                    response.MessageType = "alert-warning";
                    response.Success = false;
                    return response;
                }

                response.Message = string.Format("Encontrado {0} anunciantes", anunciante.Enderecos.Count);
                response.MessageType = "alert-info";
                response.Success = true;
                response.Enderecos = anunciante.Enderecos.ConvertToListaEnderecosDto();
            }
            catch (Exception ex)
            {
                response.Message = "Ocorreu um erro\n" + ex.Message;
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
                    response.Message = "Endereço não encontrado!";
                    response.MessageType = "alert-warning";
                    response.Success = false;
                    return response;
                }

                response.Message = "Endereço encontrado!";
                response.MessageType = "alert-info";
                response.Success = true;
                response.Endereco = endereco.ConvertToEnderecoDto();
            }
            catch (Exception ex)
            {
                response.Message = "Ocorreu um erro\n" + ex.Message;
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
                    response.Message = "Estado não encontrado para inclusão do novo Endereço";
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
                    response.Message = "Anunciante não encontrado para inclusão do novo Endereço";
                    response.MessageType = "alert-warning";
                    response.Success = false;
                    return response;
                }
                
                anunciante.Enderecos.Add(endereco);
                //endereco.Anunciante = anunciante;

                _enderecoRepository.InserirEndereco(endereco);
                _enderecoRepository.Persist();

                response.Message = "Anuncio cadastrado com sucesso.";
                response.MessageType = "alert-info";
                response.Success = true;
            }
            catch (DbEntityValidationException ex)
            {
                response.Message = "Ocorreu um erro:\n" + ex.Message;
                
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
                response.Message = "Ocorreu um erro:\n" + ex.Message;
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
                    response.Message = "Estado não encontrado para inclusão do novo Endereço";
                    response.MessageType = "alert-warning";
                    response.Success = false;
                    return response;
                }

                var id = Guid.Parse(request.Endereco.Id);
                var endereco = _enderecoRepository.EncontrarEnderecoPor(id);
                if (endereco == null)
                {
                    response.Message = "Endereço não encontrado!";
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

                response.Message = "Endereço atualizado com sucesso!";
                response.MessageType = "alert-info";
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = "Ocorreu um erro\r" + ex.Message;
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
                    response.Message = "Endereço não encontrado!";
                    response.MessageType = "alert-warning";
                    response.Success = false;
                    return response;
                }

                _enderecoRepository.ExcluirEndereco(endereco);
                _enderecoRepository.Persist();

                response.Message = "Endereço excluido com sucesso!";
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