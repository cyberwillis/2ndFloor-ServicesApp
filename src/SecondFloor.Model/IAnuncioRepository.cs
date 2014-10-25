using System;
using System.Collections.Generic;
using SecondFloor.Infrastructure.Repository;

namespace SecondFloor.Model
{
    public interface IAnuncioRepository : IRepository<Anuncio,Guid>
    {
        IList<Anuncio> EncontrarTodosAnuncios();
        Anuncio EncontrarAnuncioPor(Guid id);
        void InserirAnuncio(Anuncio anuncio);
        void AtualizarAnuncio(Anuncio anuncio);
        void ExcluirAnuncio(Anuncio anuncio);
        IList<Anuncio> EncontrarAnunciosPorStatus(AnuncioStatusEnum status);
    }
}