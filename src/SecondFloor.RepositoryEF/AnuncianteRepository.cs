using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
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

        public Anunciante EncontrarAnunciantePor(Guid id)
        {
            return _context.Anunciantes.Find(id);
        }

        public void AtualizarAnunciante(Anunciante anunciante)
        {
            var oldAnunciante = _context.Anunciantes.Find(anunciante.Id);
            
            _context.Entry(anunciante).State = EntityState.Modified;
        }

        public void InserirAnunciante(Anunciante anunciante)
        {
            _context.Anunciantes.Add(anunciante);
        }

        public void ExcluirAnunciante(Guid id)
        {
            var anunciante = EncontrarAnunciantePor(id);
            if (anunciante != null)
                _context.Anunciantes.Remove(anunciante);
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