﻿using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IProductService
    {
        IDataResult<List<Product>> getAll();
       IDataResult<List<Product>>  getAllByCategoryId(int id);
        IDataResult<List<Product>> getAllByUnitPrice(decimal min,decimal max);
        IDataResult<List<ProductDetailDTO>>  GetProductDetails();

        IDataResult<Product> GetById(int productId);
        IResult Add(Product product);



    }
}
