using SecondFloor.DataContracts.Messages.Produto;

namespace SecondFloor.ServiceContracts
{
    public interface IProdutoService
    {
        EncontrarTodosProdutosResponse EncontrarTodosProdutos(EncontrarTodosProdutosRequest request);
        EncontrarProdutoResponse EncontrarProdutoPor(EncontrarProdutoRequest request);
        CadastrarProdutoResponse CadastrarProduto(CadastrarProdutoRequest request);
        AlterarProdutoResponse AlterarProduto(AlterarProdutoRequest request);
        ExcluirProdutoResponse ExcluirProduto(ExcluirProdutoRequest request);
    }
}