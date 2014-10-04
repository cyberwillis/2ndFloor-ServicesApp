using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SecondFloor.Infrastructure.Repository;
using SecondFloor.Model;

namespace SecondFloor.RepositoryEF.Repositories
{
    public class AnuncioRepository : RepositoryBase<Anuncio,Guid>, IAnuncioRepository
    {
        public AnuncioRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }


        public IList<Anuncio> EncontrarTodosAnuncios()
        {
            return this.FindAll();
        }

        public Anuncio EncontrarAnuncioPor(Guid id)
        {
            return this.FindBy(id);
        }

        public void InserirAnuncio(Anuncio anuncio)
        {
            this.Insert(anuncio);
        }

        public void AlterarAnuncio(Anuncio anuncio)
        {
            this.Update(anuncio);
        }

        public void ExcluirAnuncio(Guid id)
        {
            var anuncio = EncontrarAnuncioPor(id);
            if(anuncio != null)
                this.Delete(anuncio);
        }
    }
}