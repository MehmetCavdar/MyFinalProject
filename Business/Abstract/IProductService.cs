using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService // public yap
    {
        IDataResult<List<Product>> GetAll();                                   //10.02.2021 degistirdik
        IDataResult<List<Product>> GetAllByCategoryId(int Id);                  //ekledik 8.ders 03.02.2021
        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);  //ekledik 8.ders 03.02.2021
        IDataResult<List<ProductDetailDto>> GetProductDetails();                // 06.02.2021
        IDataResult<Product> GetById(int productId);                        // eklendi 10.02
        IResult Add(Product product);                                        // eklendi 10.02
        IResult Update(Product product);                                        // eklendi 10.02
    }
}
