using System;
using System.Collections.Generic;
using System.Linq;
using SecondFloor.Infrastructure.Repository;
using SecondFloor.Model;

namespace SecondFloor.RepositoryEF.Repositories
{
    public class AnuncianteRepository : RepositoryBase<Anunciante,Guid>,IAnuncianteRepository
    {
        public AnuncianteRepository(EFUnitOfWork<Anunciante> unitOfWork)
            : base(unitOfWork)
        {
        }

        public IList<Anunciante> EncontrarTodosAnunciantes()
        {
            return this.FindAll();
        }

        public IList<Anunciante> EncontrarAnunciantesPorEmail(string email)
        {
            var query = from a in AnuncianteContextFactory.GetAnuncianteContext().Anunciantes
                where a.Email == email
                select a;

            return query.ToList();
        }

        public IList<Anunciante> EncontrarAnunciantesPorCnpj(string cnpj)
        {
            var query = from a in AnuncianteContextFactory.GetAnuncianteContext().Anunciantes
                        where a.Cnpj == cnpj
                        select a;

            return query.ToList();
        }

        /*public Anunciante EncontrarAnunciantePorToken(string anuncianteToken)
        {
            var queryAnunciante = from a in AnuncianteContextFactory.GetAnuncianteContext().Anunciantes
                where a.Token == anuncianteToken
                select a;

            return queryAnunciante.SingleOrDefault();
        }*/

        public Anunciante EncontrarAnunciantePor(Guid id)
        {
            return this.FindBy(id);
        }

        public void AtualizarAnunciante(Anunciante anunciante)
        {
            this.Update(anunciante);
        }

        public void InserirAnunciante(Anunciante anunciante)
        {
            this.Insert(anunciante);
        }

        public void ExcluirAnunciante(Anunciante anunciante)
        {
            //var anunciante = EncontrarAnunciantePor(id);
            //if (anunciante != null)
            this.Delete(anunciante);
        }
    }
}