using System;
using System.Collections.Generic;
using SecondFloor.Infrastructure.Repository;

namespace SecondFloor.Model
{
    public interface IProdutoRepository : IRepository<Produto, Guid>
    {
        Produto EncontrarProdutoPor(Guid id);
        void InserirProduto(Produto produto);
        void AtualizarProduto(Produto produto);
        void ExcluirProduto(Produto produto);
        IList<Produto> EncontrarProdutosPorAnunciante(Guid id);
    }
}