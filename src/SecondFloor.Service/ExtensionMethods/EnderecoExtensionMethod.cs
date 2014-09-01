using SecondFloor.DataContracts.DTO;
using SecondFloor.Model;

namespace SecondFloor.Service.ExtensionMethods
{
    public static class EnderecoExtensionMethod
    {
        public static Endereco ConvertToEndereco(this EnderecoDto enderecoDto)
        {
            var endereco = new Endereco();

            endereco.Logradouro = enderecoDto.Logradouro;
            endereco.Numero = enderecoDto.Numero;
            
            if(!string.IsNullOrEmpty(enderecoDto.Complemento))
                endereco.Complemento = enderecoDto.Complemento;

            endereco.Bairro = enderecoDto.Bairro;
            endereco.Cidade = enderecoDto.Cidade;
            endereco.Estado = enderecoDto.Estado;

            return endereco;
        }
    }
}