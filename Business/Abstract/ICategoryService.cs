﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;  // IDataResult icin ekledim

namespace Business.Abstract
{
    public interface ICategoryService
    {

        IDataResult<List<Category>> GetAll();
        IDataResult<Category> GetById(int categoryId);

        ////IResult Add(Product product);
       
        //////IResult Update(Product product);                                        

    }
}
