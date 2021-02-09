using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product> {
            new Product{ProductId=1,CategoryId=1,ProductName="Bardak",UnitPrice=12,UnitsInStock=100},
            new Product{ProductId=2,CategoryId=2,ProductName="Klavye",UnitPrice=23,UnitsInStock=233},
            new Product{ProductId=3,CategoryId=3,ProductName="Matara",UnitPrice=44,UnitsInStock=345},
            new Product{ProductId=4,CategoryId=4,ProductName="Şarj Kablosu",UnitPrice=23,UnitsInStock=231},
            new Product{ProductId=5,CategoryId=5,ProductName="Kulaklık",UnitPrice=11,UnitsInStock=32},





            };
        }
        public void Add(Product product)
        {
            _products.Add(product);        
        }

        public void Delete(Product product)
        {
            Product productToDelete=_products.SingleOrDefault(p=>p.ProductId==product.ProductId);
            _products.Remove(productToDelete);

        }

        public Product get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> getAll()
        {
            return _products;
        }

        public List<Product> getAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> getAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();

        }

        public void Update(Product product)
        {   //LİNQ Language
            Product productToupdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToupdate.ProductName = product.ProductName;
            productToupdate.CategoryId = product.CategoryId;
            productToupdate.UnitPrice = product.UnitPrice;
            productToupdate.UnitsInStock = product.UnitsInStock;


        }
    }
}
