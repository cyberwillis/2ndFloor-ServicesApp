using System.Reflection;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Connection;
using NHibernate.Dialect;
using NHibernate.Driver;
using SecondFloor.RepositoryNH.SessionStorage;

namespace SecondFloor.RepositoryNH
{
    public class SessionFactory
    {
        private static ISessionFactory _sessionFactory;

        private static void Init()
        {
            Configuration config = new Configuration();
            config.DataBaseIntegration(x =>
            {
                x.LogFormattedSql = true;
                x.LogSqlInConsole = true;
                x.ConnectionProvider<DriverConnectionProvider>();
                x.ConnectionString = "Data Source=192.168.1.65;Initial Catalog=Generic.NH;UID=generic;PWD=generic";
                x.Driver<SqlClientDriver>();
                x.Dialect<MsSql2012Dialect>();
            });
            //config.AddAssembly("Framework.RepositoryNH");
            config.AddAssembly(Assembly.GetExecutingAssembly());
            //config.Configure(); //configura de acordo com App.config ou Web.config

            _sessionFactory = config.BuildSessionFactory();
        }

        private static ISession GetNewSession()
        {
            return GetSessionFactory().OpenSession();
        }

        private static ISessionFactory GetSessionFactory()
        {
            if (_sessionFactory == null)
                Init();

            return _sessionFactory;
        }

        public static ISession GetCurrentSession()
        {
            ISessionStorageContainer sessionStorageContainer = SessionStorageFactory.GetStorageContainer();

            ISession currentSession = sessionStorageContainer.GetCurrentSession();

            if (currentSession == null)
            {
                currentSession = GetNewSession();
                sessionStorageContainer.Store(currentSession);
            }

            return currentSession;
        }
    }
}