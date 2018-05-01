using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Repository.Repositories;

namespace NHibernate.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        void SaveChanges();
        void BeginTransaction();
        void CommitTransaction();
        void RollBackTransaction();
    }
}
