using System;
using System.Collections.Generic;
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

        public IList<Oferta> EncontrarOdertasPorAnuncio(Guid id)
        {
            var ofertas = from o in AnuncianteContextFactory.GetAnuncianteContext().Ofertas
                where o.Anuncio.Id == id
                select o;

            return ofertas.ToList();
        }
    }
}