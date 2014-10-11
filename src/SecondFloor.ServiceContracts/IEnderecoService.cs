using SecondFloor.DataContracts.Messages.Endereco;

namespace SecondFloor.ServiceContracts
{
    public interface IEnderecoService
    {
        EncontrarTodosEnderecosResponse EncontrarTodosEnderecos(EncontrarTodosEnderecosRequest request);
        EncontrarEnderecoResponse EncontrarEnderecoPor(EncontrarEnderecoRequest request);
        CadastrarEnderecoResponse CadastrarEndereco(CadastrarEnderecoRequest request);
        AlterarEnderecoResponse AlterarEndereco(AlterarEnderecoRequest request);
        ExcluirEnderecoResponse ExcluirEndereco(ExcluirEnderecoRequest request);
    }
}