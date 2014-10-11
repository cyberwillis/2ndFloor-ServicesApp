using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.ObjectBuilder2;
using SecondFloor.DataContracts.DTO;
using SecondFloor.Model;

namespace SecondFloor.Service.ExtensionMethods
{
    public static class EnderecoExtensionMethod
    {
        public static Endereco ConvertToEndereco(this EnderecoDto enderecoDto)
        {
            var endereco = new Endereco();

            if (string.IsNullOrEmpty(enderecoDto.Id) || enderecoDto.Id == default(Guid).ToString())
            {
                endereco.Id = Guid.NewGuid();
            }
            else
            {
                endereco.Id = new Guid(enderecoDto.Id);
            }

            endereco.Logradouro = enderecoDto.Logradouro;
            endereco.Numero = enderecoDto.Numero;
            endereco.Complemento = enderecoDto.Complemento;
            endereco.Bairro = enderecoDto.Bairro;
            endereco.Cidade = enderecoDto.Cidade;
            endereco.Estado = enderecoDto.Estado;
            endereco.Cep = enderecoDto.Cep;

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
            enderecoDto.Cep = endereco.Cep;
            enderecoDto.AnuncianteId = endereco.Anunciante.Id.ToString(); //facilitar a identificacao do Parent deste objeto

            return enderecoDto;
        }

        public static IList<EnderecoDto> ConvertToListaEnderecosDto(this IList<Endereco> enderecos)
        {
            var enderecosDto = enderecos.Select( x => x.ConvertToEnderecoDto() ).ToList();

            return enderecosDto;
        }
    }
}