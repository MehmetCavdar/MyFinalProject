using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //newleme yapacagiz. Daha sonra gerek kalmayacak
            ProductManager productManager = new ProductManager(new InMemoryProductDal());  // sonra bu bilgileri basla yerden alabiliriz
            foreach (var product in productManager.GetAll())
            {
                Console.WriteLine(product.ProductName);
            }
        }
    } 
}
