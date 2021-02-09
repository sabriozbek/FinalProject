using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _IPrdouctDal;

        public ProductManager(IProductDal ıPrdouctDal)
        {
            _IPrdouctDal = ıPrdouctDal;
        }

        public List<Product> getAll()
        {
            return _IPrdouctDal.getAll();
        }

        public List<Product> getAllByCategoryId(int id)
        {
            return _IPrdouctDal.getAll(p => p.CategoryId == id);
        }

        public List<Product> getAllByUnitPrice(decimal min, decimal max)
        {
            return _IPrdouctDal.getAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }
    }
}
