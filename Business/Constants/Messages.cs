using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi";   // degisken olmasina ragmen public oldugu icin büyük harfle basladik
        public static string ProductNameInvalid = "Ürün ismi gecersiz";
        public static string MaintenanceTime= "Sistem bakimda";
        public static string ProductsListed= "Ürünler listelendi"; 
        public static string ProductsDetailed = "Istenen Ürün detayi sergilendi";
        public static string ProductDeleted = "Ürün silindi";
        public static string ProductUpdated = "Ürün güncellendi";
        public static string ProductCountCategoryError = "bir ketoride en fazla 10 ürün olabilir";
        public static string ProductNameAlreadyExist = "Ayni isimle birden fazla ürün olamaz";

        public static string CategoryLimitExceeded = "kategor limiti asti";
    }
}
