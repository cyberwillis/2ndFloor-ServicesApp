using SecondFloor.DataContracts.Messages.Endereco;

namespace SecondFloor.ServiceContracts
{
    public interface IEnderecoService
    {
        EncontrarTodosEnderecosResponse EncontrarTodosEnderecos(EncontrarTodosEnderecosRequest request);
        EncontrarEnderecoResponse EncontrarEndereco(EncontrarEnderecoRequest request);
        CadastroEnderecoResponse CadastroEndereco(CadastroEnderecoRequest request);
        AlterarEnderecoResponse AlterarEndereco(AlterarEnderecoRequest request);
        ExcluirEnderecoResponse ExcluirEndereco(ExcluirEnderecoRequest request);

    }
}