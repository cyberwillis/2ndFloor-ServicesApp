using System;
using System.Collections.Generic;
using SecondFloor.Infrastructure.Repository;

namespace SecondFloor.Model
{
    public interface IAnuncianteRepository : IRepository, IDisposable
    {
        Anunciante EncontrarAnunciantePorToken(string anuncianteToken);
        Anunciante EncontrarAnunciantePor(Guid id);
        void InserirAnunciante(Anunciante anunciante);
        void AtualizarAnunciante(Anunciante anunciante);
        void ExcluirAnunciante(Guid id);
        IList<Anunciante> EncontrarTodosAnunciantes();
    }
}