using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using NHibernate.Data.Persistence.SessionFactory;
using NHibernate.Entity.Models;
using NHibernate.Repository;

namespace NHibernate.Service.Services
{
    public class ProductService : IService<Product>
    {
        private readonly UnitOfWork _unitOfWork;

        public ProductService(SessionFactory session)
        {
            _unitOfWork = new UnitOfWork(session);
        }
        public Product Get(int id)
        {
            return _unitOfWork.Products.Get(id);
        }

        public IQueryable<Product> GetAll()
        {
            return _unitOfWork.Products.GetAll().AsQueryable();
        }

        public IQueryable<Product> Find(Expression<Func<Product, bool>> predicate)
        {
            return _unitOfWork.Products.Find(predicate).AsQueryable();
        }

        public void Add(Product category)
        {
            _unitOfWork.Products.Add(category);
            _unitOfWork.SaveChanges();
        }

        public void AddRange(IEnumerable<Product> products)
        {
            _unitOfWork.Products.AddRange(products);
            _unitOfWork.SaveChanges();
        }

        public void Update(Product product)
        {
            _unitOfWork.Products.Update(product);
            _unitOfWork.SaveChanges();
        }

        public void Remove(Product product)
        {
            _unitOfWork.Products.Remove(product);
            _unitOfWork.SaveChanges();

        }

        public void RemoveRange(IEnumerable<Product> products)
        {
            _unitOfWork.Products.RemoveRange(products);
            _unitOfWork.SaveChanges();
        }
    }
}
