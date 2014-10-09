using System;
using System.Collections.Generic;
using System.Linq;
using SecondFloor.Infrastructure.Repository;
using SecondFloor.Model;

namespace SecondFloor.RepositoryEF.Repositories
{
    public class EnderecoRepository : RepositoryBase<Endereco,Guid> , IEnderecoRepository
    {
        public EnderecoRepository(EFUnitOfWork<Endereco> unitOfWork) : base(unitOfWork)
        {
        }

        public Endereco EncontrarEnderecoPor(Guid id)
        {
            return this.FindBy(id);
        }

        public void InserirEndereco(Endereco endereco)
        {
            this.Insert(endereco);
        }

        public void AtualizarEndereco(Endereco endereco)
        {
            this.Update(endereco);
        }

        public void ExcluirEndereco(Endereco endereco)
        {
            //var endereco = EncontrarEnderecoPor(id);
            //if(endereco != null)
            this.Delete(endereco);
        }

        public IList<Endereco> EncontrarTodosEnderecosPorAnunciante(Guid id)
        {
            var endercos = from e in AnuncianteContextFactory.GetAnuncianteContext().Set<Endereco>()
                where e.Anunciante.Id == id
                select e;

            return endercos.ToList();
        }
    }
}