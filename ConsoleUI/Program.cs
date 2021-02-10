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
            ProductTest();
            // CategoryTest();
        }

        private static void CategoryTest()
        {
            //newleme yapacagiz. Daha sonra gerek kalmayacak
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        { 
         
            ProductManager productManager = new ProductManager(new EfProductDal());
            var result = productManager.GetProductDetails();

            if (result.Success == true)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.ProductName + "/" + product.CategoryName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    } 
}
