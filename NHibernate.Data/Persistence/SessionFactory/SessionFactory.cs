using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;

namespace NHibernate.Data.Persistence.SessionFactory
{
    public class SessionFactory
    {
        public ISessionFactory Session { get; }

        public SessionFactory()
        {
            Session = Fluently
                .Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(@"Server=localhost\SQLEXPRESS;Database=Store;Trusted_Connection=True;"))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<SessionFactory>())
                .BuildSessionFactory();
        }

        public ISession OpenSession()
        {
            return Session.OpenSession();
        }
    }
}
