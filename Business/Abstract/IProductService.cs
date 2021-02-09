using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IProductService
    {
        List<Product> getAll();
        List<Product> getAllByCategoryId(int id);
        List<Product> getAllByUnitPrice(decimal min,decimal max);


    }
}
