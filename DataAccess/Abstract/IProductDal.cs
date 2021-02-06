using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IProductDal: IEntityRepository<Product>  // public yapalim. Default internaldir. Interface'in operasyonlari deault publictir
    {
        List<ProductDetailDto> GetProductDetails();
    }
}
