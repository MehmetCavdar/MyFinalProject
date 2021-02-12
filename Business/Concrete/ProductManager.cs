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
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            //business codes
          
            if (product.ProductName.Length < 2)
            {
                //magic strings
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded); // step 49

           // return new Result(true,"ürün eklendi");  // step 47 de yaptik. iptal etttik
        }

        public IDataResult<List<Product>> GetAll()
        {
            // is kodlari

            if (DateTime.Now.Hour == 22)  // saat  22 ise hata döndür (denemek icin)
            {
                Console.WriteLine("bakim zamani döngüsü calisti");
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            // yetkisi var mi?
            // tüm ürüleri listeleyecek metot
         return new SuccessDataResult<List<Product>>( _productDal.GetAll(), Messages.ProductsListed); //10.02.2021 
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id) //dikkat 02.03.2021
        {
            // sadece secilen kategoride ürünler listelenecek
            return new SuccessDataResult<List<Product>> (_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<Product>GetById(int productId)  //  Tanimladik 10.02..2021
        {
            return new SuccessDataResult<Product> (_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max) 
        {
            // sadece secilen fiyat araligindaki ürünler listelenecek
            return new SuccessDataResult<List<Product>> (_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails(), Messages.ProductsDetailed);
        }
    }
}
