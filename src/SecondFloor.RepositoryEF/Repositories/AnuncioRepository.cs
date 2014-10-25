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
        public AnuncioRepository(EFUnitOfWork<Anuncio> unitOfWork) 
            : base(unitOfWork)
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

        public void AtualizarAnuncio(Anuncio anuncio)
        {
            this.Update(anuncio);
        }

        public void ExcluirAnuncio(Anuncio anuncio)
        {
            //var anuncio = EncontrarAnuncioPor(id);
            //if(anuncio != null)
            this.Delete(anuncio);
        }

        public IList<Anuncio> EncontrarAnunciosPorStatus(AnuncioStatusEnum status)
        {
            var anuncio = from a in AnuncianteContextFactory.GetAnuncianteContext().Anuncios
                           where a.Status == AnuncioStatusEnum.Agendado
                           select a;

            return anuncio.ToList();
        }
    }
}