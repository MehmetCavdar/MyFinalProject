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
            ProductManager productManager = new ProductManager(new EfProductDal());
            //foreach (var product in productManager.GetAllByCategoryId(2))
            foreach (var product in productManager.GetByUnitPrice(40, 100))
            {
                Console.WriteLine(product.ProductName);
            }
        }
    } 
}
