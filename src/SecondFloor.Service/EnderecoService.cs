using System;
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
        private IEnderecoRepository _enderecoRepository;
        private readonly IAnuncianteRepository _anuncianteRepository;

        public EnderecoService(IEnderecoRepository enderecoRepository, IAnuncianteRepository anuncianteRepository)
        {
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

        public CadastrarEnderecoResponse CadastroEndereco(CadastrarEnderecoRequest request)
        {
            var response = new CadastrarEnderecoResponse();

            var endereco = request.Endereco.ConvertToEndereco();
            if (!endereco.IsValid())
            {
                endereco.BrokenRules.ForEach(x => response.Rules.Add(x.Key,x.Value));

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

            try
            {
                
                anunciante.Enderecos.Add(endereco);
                endereco.Anunciante = anunciante;
                _enderecoRepository.InserirEndereco(endereco);
                _enderecoRepository.Persist();

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
        }

        public AlterarEnderecoResponse AlterarEndereco(AlterarEnderecoRequest request)
        {
            var response = new AlterarEnderecoResponse();

            try
            {
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
                endereco.CEP = novoEndereco.CEP;
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