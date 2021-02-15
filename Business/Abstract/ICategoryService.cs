using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public  interface ICategoryService
    {
        List<Category> getAll();

        Category getById(int categoryId);

    }
}
