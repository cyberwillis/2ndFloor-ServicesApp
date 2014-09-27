using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SecondFloor.Model;

namespace SecondFloor.RepositoryEF
{
    public class AnuncioRepository : IAnuncioRepository
    {
        private AnuncioContext _context;

        public AnuncioRepository(AnuncioContext context)
        {
            _context = context;
        }

        public IList<Anuncio> EncontrarTodosAnuncios()
        {
            return _context.Anuncios.ToList();
        }

        public Anuncio EncontrarAnuncioPor(Guid id)
        {
            return _context.Anuncios.Find(id);
        }

        public void InserirAnuncio(Anuncio anuncio)
        {
            _context.Anuncios.Add(anuncio);
        }

        public void AlterarAnuncio(Anuncio anuncio)
        {
            var anucioOld = EncontrarAnuncioPor(anuncio.Id); //somente para capturar o item em memoria
            _context.Entry(anuncio).State = EntityState.Modified; //altera entidade anuncio e foçar estado de alteracao
        }

        public void ExcluirAnuncio(Guid id)
        {
            var anuncio = EncontrarAnuncioPor(id);
            if (anuncio != null)
                _context.Anuncios.Remove(anuncio);
        }

        public void Persist()
        {
            _context.SaveChanges();
            _context.Configuration.ValidateOnSaveEnabled = true;
            /*using (var transaction =  Connection.BeginTransaction())
            {
                try
                {
                    _context.SaveChanges();
                    transaction.Commit();
                }
                catch (OptimisticConcurrencyException)
                {
                    if (ObjectStateManager.GetObjectStateEntry(entity).State == EntityState.Deleted || ObjectStateManager.GetObjectStateEntry(entity).State == EntityState.Modified)
                        this.Refresh(RefreshMode.StoreWins, entity);
                    else if (ObjectStateManager.GetObjectStateEntry(entity).State == EntityState.Added)
                        Detach(entity);
                    AcceptAllChanges();
                    transaction.Commit();
                }
            }*/
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}