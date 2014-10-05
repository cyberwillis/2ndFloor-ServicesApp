using System.Collections;
using System.Threading;

namespace SecondFloor.RepositoryEF.DataContextStorage
{
    public class ThreadDataContextStorageContainer : IDataContextStorageContainer
    {
        private static readonly Hashtable AnuncioDataContexts = new Hashtable();

        public AnuncianteContext GetDataContext()
        {
            AnuncianteContext anuncianteDataContext = null;

            var threadname = GetThreadName();

            if (AnuncioDataContexts.Contains(GetThreadName()))
                anuncianteDataContext = (AnuncianteContext)AnuncioDataContexts[threadname];

            return anuncianteDataContext;
        }

        public void Store(AnuncianteContext anuncianteDataContext)
        {
            var threadName = GetThreadName();

            if (AnuncioDataContexts.Contains(threadName))
                AnuncioDataContexts[threadName] = anuncianteDataContext;
            else
                AnuncioDataContexts.Add(threadName, anuncianteDataContext);
        }

        private static string GetThreadName()
        {
            if (Thread.CurrentThread.Name == null)
                Thread.CurrentThread.Name = "EFThread";

            return Thread.CurrentThread.Name;
        } 
    }
}