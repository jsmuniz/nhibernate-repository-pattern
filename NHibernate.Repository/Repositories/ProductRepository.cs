using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Entity.Models;

namespace NHibernate.Repository.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ISession session) : base(session)
        {
        }
    }
}
