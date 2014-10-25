using System;
using System.Collections.Generic;
using SecondFloor.Infrastructure.Repository;

namespace SecondFloor.Model
{
    public interface IAnuncianteRepository : IRepository<Anunciante,Guid>
    {
        //Anunciante EncontrarAnunciantePorToken(string anuncianteToken);
        Anunciante EncontrarAnunciantePor(Guid id);
        void InserirAnunciante(Anunciante anunciante);
        void AtualizarAnunciante(Anunciante anunciante);
        void ExcluirAnunciante(Anunciante anunciante);
        IList<Anunciante> EncontrarTodosAnunciantes();
        IList<Anunciante> EncontrarAnunciantesPorEmail(string email);
        IList<Anunciante> EncontrarAnunciantesPorCnpj(string cnpj);
    }
}