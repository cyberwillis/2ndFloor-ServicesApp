using System.Collections.Generic;
using System.Linq;
using SecondFloor.DataContracts.DTO;
using SecondFloor.Web.Mvc.Models;

namespace SecondFloor.Web.Mvc.Services
{
    public static class EnderecoViewModelExtensionMethods
    {
        public static EnderecoViewModels ConvertToEnderecoViewModel(this EnderecoDto enderecoDto)
        {
            var enderecoViewModel = new EnderecoViewModels();
            enderecoViewModel.Id = enderecoDto.Id;
            enderecoViewModel.Logradouro = enderecoDto.Logradouro;
            enderecoViewModel.Numero = int.Parse(enderecoDto.Numero);
            enderecoViewModel.Complemento = enderecoDto.Complemento;
            enderecoViewModel.Bairro = enderecoDto.Bairro;
            enderecoViewModel.Cidade = enderecoDto.Cidade;
            enderecoViewModel.Estado = enderecoDto.Estado;
            enderecoViewModel.Cep = enderecoDto.Cep;
            enderecoViewModel.AnuncianteId = enderecoDto.AnuncianteId; //facilitar a identificacao do Parent deste objeto

            return enderecoViewModel;
        }

        public static EnderecoDto ConvertToEnderecoDto(this EnderecoViewModels enderecoViewModel)
        {
            var enderecoDto = new EnderecoDto();
            enderecoDto.Id = enderecoViewModel.Id;
            enderecoDto.Logradouro = enderecoViewModel.Logradouro;
            enderecoDto.Numero = enderecoViewModel.Numero.ToString();
            enderecoDto.Complemento = enderecoViewModel.Complemento;
            enderecoDto.Bairro = enderecoViewModel.Bairro;
            enderecoDto.Cidade = enderecoViewModel.Cidade;
            enderecoDto.Estado = enderecoViewModel.Estado;
            enderecoDto.Cep = enderecoViewModel.Cep;

            return enderecoDto;
        }

        public static IList<EnderecoViewModels> ConvertToListaEnderecosViewModel(this IList<EnderecoDto> enderecosDto)
        {
            var enderecosViewModel = enderecosDto.Select(x => x.ConvertToEnderecoViewModel()).ToList();

            return enderecosViewModel;
        }
    }
}