using System;
using System.Collections.Generic;

namespace SecondFloor.Model
{
    public interface IOfertaRepository
    {
        Oferta EncontrarOfertaPor(Guid id);
        IList<Oferta> EncontrarOfertasPorProduto(string nomeProduto);
        IList<Oferta> EncontrarOdertasPorAnuncio(Guid id);
    }
}