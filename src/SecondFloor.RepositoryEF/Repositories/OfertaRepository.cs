using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using SecondFloor.Infrastructure.Repository;
using SecondFloor.Model;

namespace SecondFloor.RepositoryEF.Repositories
{
    public class OfertaRepository : RepositoryBase<Oferta, Guid>, IOfertaRepository
    {
        public OfertaRepository(EFUnitOfWork<Oferta> unitOfWork) : base(unitOfWork)
        {
        }

        public Oferta EncontrarOfertaPor(Guid id)
        {
            return this.FindBy(id);
        }

        public IList<Oferta> EncontrarOfertasPorProduto(string nomeProduto)
        {
            var ofertas = AnuncianteContextFactory.GetAnuncianteContext().Ofertas.Where(o => o.NomeProduto.Contains(nomeProduto));

            /*var ofertas = from o in AnuncianteContextFactory.GetAnuncianteContext().Ofertas
                          where SqlMethods.Like(o.NomeProduto, nomeProduto)
                          select o;*/

            return ofertas.ToList();
        }

        public IList<Oferta> EncontrarOfertasPorAnuncio(Guid id)
        {
            var anuncio = (from a in AnuncianteContextFactory.GetAnuncianteContext().Anuncios
                where a.Id == id
                select a).First();
            
            return anuncio.Ofertas;
        }
    }
}