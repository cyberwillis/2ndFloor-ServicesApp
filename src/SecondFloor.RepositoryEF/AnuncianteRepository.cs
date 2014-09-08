using System;
using System.Collections.Generic;
using System.Linq;
using SecondFloor.Model;

namespace SecondFloor.RepositoryEF
{
    public class AnuncianteRepository : IAnuncianteRepository
    {
        private AnuncioContext _context;

        public AnuncianteRepository(AnuncioContext context)
        {
            _context = context;
        }

        public Anunciante EncontrarAnunciantePorToken(string anuncianteToken)
        {
            var queryAnunciante = from a in _context.Anunciantes.ToList()
                where a.Token == anuncianteToken
                select a;

            return queryAnunciante.SingleOrDefault();
        }

        public void InserirAnunciante(Anunciante anunciante)
        {
            _context.Anunciantes.Add(anunciante);
        }

        public void Persist()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}