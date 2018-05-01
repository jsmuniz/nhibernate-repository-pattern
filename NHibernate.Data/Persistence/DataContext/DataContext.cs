using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;

namespace NHibernate.Data.Persistence.DataContext
{
    public class DataContext
    {
        public ISessionFactory SessionFactory { get; }

        public DataContext()
        {
            SessionFactory = Fluently
                .Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(@"Server=localhost\SQLEXPRESS;Database=Store;Trusted_Connection=True;"))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<DataContext>())
                .BuildSessionFactory();
        }

        public ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
