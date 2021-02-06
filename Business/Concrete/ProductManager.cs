using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
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

        public List<Product> GetAll()
        {
            // is kodlari
            // yetkisi var mi?
            // tüm ürüleri listeleyecek metot
            return _productDal.GetAll();
        }

        public List<Product> GetAllByCategoryId(int id) //dikkat 02.03.2021
        {
            // sadece secilen kategoride ürünler listelenecek
            return _productDal.GetAll(p => p.CategoryID == id);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max) 
        {
            // sadece secilen fiyat araligindaki ürünler listelenecek
            return _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }
    }
}
