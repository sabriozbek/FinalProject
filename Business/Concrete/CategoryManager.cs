﻿using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public List<Category> getAll()
        {
            return _categoryDal.getAll();
           

        }

        public Category getById(int categoryId)
        {
            return _categoryDal.get(c=>c.CategoryId == categoryId);
            
        }
    }
}
