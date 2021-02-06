using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    //SOLID kodlama prensibinin bas harfleri burada O harfini yaptik: Open CLosed Principle
    class Program
    {
        static void Main(string[] args)
        {
            //newleme yapacagiz. Daha sonra gerek kalmayacak
            //8.derste 7.dersten farkli olarak newledigimiz kismi degisirdik new EfProductDal() yaptik


            ProductTest();
            // CategoryTest();
        }




        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            //foreach (var product in productManager.GetAllByCategoryId(2))
           // foreach (var product in productManager.GetByUnitPrice(40, 100))
                foreach (var product in productManager.GetProductDetails())
                {
                Console.WriteLine(product.ProductName + "/" + product.CategoryName);
            }
        }
    } 
}
