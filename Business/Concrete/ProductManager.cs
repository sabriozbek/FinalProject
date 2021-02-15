using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
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

        public IResult Add(Product product)
        {
            if (product.ProductName.Length<2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _IPrdouctDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Product>> getAll()
        {
            if (DateTime.Now.Hour==18)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(_IPrdouctDal.getAll(),Messages.ProductsListed);
        }

        public IDataResult<List<Product>>  getAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>> ( _IPrdouctDal.getAll(p => p.CategoryId == id));
        }

        public IDataResult<List<Product>> getAllByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_IPrdouctDal.getAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public  IDataResult<Product>  GetById(int productId)
        {
            return  new SuccessDataResult<Product>( _IPrdouctDal.get(p => p.ProductId == productId));
        }

        public IDataResult< List<ProductDetailDTO>> GetProductDetails()
        {
            return  new SuccessDataResult<List<ProductDetailDTO>>( _IPrdouctDal.GetProductDetails());
                }
    }
}
