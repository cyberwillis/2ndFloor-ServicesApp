using System.Collections;
using System.Threading;

namespace SecondFloor.RepositoryEF.DataContextStorage
{
    public class ThreadDataContextStorageContainer : IDataContextStorageContainer
    {
        private static readonly Hashtable AnuncioDataContexts = new Hashtable();

        public AnuncioContext GetDataContext()
        {
            AnuncioContext anuncioDataContext = null;

            var threadname = GetThreadName();

            if (AnuncioDataContexts.Contains(GetThreadName()))
                anuncioDataContext = (AnuncioContext)AnuncioDataContexts[threadname];

            return anuncioDataContext;
        }

        public void Store(AnuncioContext anuncioDataContext)
        {
            var threadName = GetThreadName();

            if (AnuncioDataContexts.Contains(threadName))
                AnuncioDataContexts[threadName] = anuncioDataContext;
            else
                AnuncioDataContexts.Add(threadName, anuncioDataContext);
        }

        private static string GetThreadName()
        {
            if (Thread.CurrentThread.Name == null)
                Thread.CurrentThread.Name = "EFThread";

            return Thread.CurrentThread.Name;
        } 
    }
}