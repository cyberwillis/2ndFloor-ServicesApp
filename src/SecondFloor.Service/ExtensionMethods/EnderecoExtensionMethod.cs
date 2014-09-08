using System;
using SecondFloor.DataContracts.DTO;
using SecondFloor.Model;

namespace SecondFloor.Service.ExtensionMethods
{
    public static class EnderecoExtensionMethod
    {
        public static Endereco ConvertToEndereco(this EnderecoDto enderecoDto)
        {
            var endereco = new Endereco();

            if (string.IsNullOrEmpty(enderecoDto.Id) || enderecoDto.Id == "00000000-0000-0000-0000-000000000000")
            {
                endereco.Id = Guid.NewGuid();
            }
            else
            {
                endereco.Id = new Guid(enderecoDto.Id);
            }

            endereco.Logradouro = enderecoDto.Logradouro;
            endereco.Numero = enderecoDto.Numero;
            
            //if(!string.IsNullOrEmpty(enderecoDto.Complemento)) //ja é empty
            endereco.Complemento = enderecoDto.Complemento;

            endereco.Bairro = enderecoDto.Bairro;
            endereco.Cidade = enderecoDto.Cidade;
            endereco.Estado = enderecoDto.Estado;

            return endereco;
        }

        public static EnderecoDto ConvertToEnderecoDto(this Endereco endereco)
        {
            var enderecoDto = new EnderecoDto();

            enderecoDto.Id = endereco.Id.ToString();
            enderecoDto.Logradouro = endereco.Logradouro;
            enderecoDto.Numero = endereco.Numero;
            enderecoDto.Complemento = endereco.Complemento;
            enderecoDto.Bairro = endereco.Bairro;
            enderecoDto.Cidade = endereco.Cidade;
            enderecoDto.Estado = endereco.Estado;

            return enderecoDto;
        }
    }
}