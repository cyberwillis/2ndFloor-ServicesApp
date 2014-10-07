using System;
using System.Collections.Generic;

namespace SecondFloor.Model
{
    public interface IProdutoRepository
    {
        Produto EncontrarProdutoPor(Guid id);
        void InserirProduto(Produto produto);
        void AtualizarProduto(Produto produto);
        void ExcluirProduto(Produto produto);
        IList<Produto> EncontrarProdutosPorAnunciante(Guid id);
    }
}