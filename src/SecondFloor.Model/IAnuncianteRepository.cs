using System;
using SecondFloor.Infrastructure.Repository;

namespace SecondFloor.Model
{
    public interface IAnuncianteRepository : IRepository, IDisposable
    {
        Anunciante EncontrarAnunciantePorToken(string anuncianteToken);

        void InserirAnunciante(Anunciante anunciante);
    }
}