using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService // public yap
    {
        List<Product> GetAll();
        List<Product> GetAllByCategoryId(int Id); //ekledik 8.ders 03.02.2021
        List<Product> GetByUnitPrice(decimal min, decimal max);  //ekledik 8.ders 03.02.2021
        List<ProductDetailDto> GetProductDetails(); // 06.02.2021
    }
}
