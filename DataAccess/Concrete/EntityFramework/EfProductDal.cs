using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Added;
                context.SaveChanges();

            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var deleteEntity = context.Entry(entity);
                deleteEntity.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                context.SaveChanges();

            }
        }

        public Product get(Expression<Func<Product, bool>> filter)
        {
            using(NorthwindContext context=new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> getAll(Expression<Func<Product, bool>> filter = null)
        {
            using(NorthwindContext context=new NorthwindContext())
            {
                return filter == null ? context.Set<Product>().ToList(): context.Set<Product>().Where(filter).ToList();
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updateEntity = context.Entry(entity);
                updateEntity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();

            }
        }
    }
}
