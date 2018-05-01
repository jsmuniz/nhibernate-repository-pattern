using FluentNHibernate.Mapping;
using NHibernate.Entity.Models;

namespace NHibernate.Data.Persistence.Mappings
{
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Description);
        }
        
    }
}
