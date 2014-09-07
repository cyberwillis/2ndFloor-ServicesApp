using System;
using System.Collections.Generic;
using SecondFloor.Infrastructure.Repository;

namespace SecondFloor.Model
{
    public interface IAnuncioRepository : IRepository<Anuncio,Guid>, IDisposable
    {
        IList<Anuncio> EncontrarTodosAnuncios();
        Anuncio EncontrarAnuncioPor(Guid id);
        void InserirAnuncio(Anuncio anuncio);
        void AlterarAnuncio(Anuncio anuncio);
        void ExcluirAnuncio(Guid id);
    }
}