using DataAccess.Abstract;
using System.Linq;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal // public yapalim. IProductDal Interface ile iliskilendirelim
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            // Veri tabanindan geldigini varsayalim. olmasi gereken
            _products = new List<Product> {
             new Product {ProductId =1, CategoryID =1, ProductName = "Bardak", UnitPrice =15, UnitsInStock=15},
             new Product {ProductId =2, CategoryID =1, ProductName = "Kamera", UnitPrice =500, UnitsInStock=3},
             new Product {ProductId =3, CategoryID =2, ProductName = "Telefon", UnitPrice =1500, UnitsInStock=2},
             new Product {ProductId =4, CategoryID =2, ProductName = "Klavye", UnitPrice =150, UnitsInStock=65},
             new Product {ProductId =5, CategoryID =2, ProductName = "Fare", UnitPrice =85, UnitsInStock=1}
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product) // Referans tip silinmesi icin referansa ulasmaliyiz. 
                                            //Dongüyle dolasabiliriz ya da LINQ yapisi kullaniriz
        {        
            Product productToDelete = _products.SingleOrDefault(p=>p.ProductId == product.ProductId); //=> Lambda adi verilir 
            
            _products.Remove(productToDelete);
        }

        public Product GET(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryID == categoryId).ToList(); //kritere uyanlarin hepsini yeni bir liste halinde döndürür
        }

        public void Update(Product product)
        {
            //Gönderdigim ürün Id'sine sahip olan listedeki Ürünü bul demektir
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId); //=> Lambda adi verilir 
            
            //Güncelleme yap
            productToUpdate.ProductName =product.ProductName;
            productToUpdate.CategoryID= product.CategoryID;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}
