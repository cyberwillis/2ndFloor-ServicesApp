using System;
using System.Collections.Generic;
using System.Linq;
using SecondFloor.Infrastructure.Repository;
using SecondFloor.Model;

namespace SecondFloor.RepositoryEF.Repositories
{
    public class ProdutoRepository : RepositoryBase<Produto,Guid> , IProdutoRepository
    {
        public ProdutoRepository(EFUnitOfWork<Produto> unitOfWork) : base(unitOfWork)
        {
        }

        public Produto EncontrarProdutoPor(Guid id)
        {
            return this.FindBy(id);
        }

        public void InserirProduto(Produto produto)
        {
            this.Insert(produto);
        }

        public void AtualizarProduto(Produto produto)
        {
            this.Update(produto);
        }

        public void ExcluirProduto(Produto produto)
        {
            //var produto = EncontrarProdutoPor(id);
            //if(produto != null)
            this.Delete(produto);
        }

        public IList<Produto> EncontrarProdutosPorAnunciante(Guid id)
        {
            var produtos = from p in AnuncianteContextFactory.GetAnuncianteContext().Set<Produto>()
                where p.Anunciante.Id == id
                select p;

            return produtos.ToList();
        }
    }
}