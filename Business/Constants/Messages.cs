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
        public static string ProductsListed= "Ürünler listelendi"; 
        public static string ProductsDetailed = "Istenen Ürün detayi sergilendi";
        public static string ProductDeleted = "Ürün silindi";
        public static string ProductUpdated = "Ürün güncellendi";
        public static string ProductCountCategoryError = "bir ketoride en fazla 10 ürün olabilir";
        public static string ProductNameAlreadyExist = "Ayni isimle birden fazla ürün olamaz";
        public static string MaintenanceTime = "Sistem bakimda";


        public static string CategoryAdded = "Kategori eklendi";   // Burali Frontend zamaninda ekledik
        public static string CategoryNameInvalid = "Kategori ismi gecersiz";
        public static string CategoriesListed = "Kategoriler listelendi";
        public static string CategoriesDetailed = "Istenen Kategori detayi sergilendi";
        public static string CategoryDeleted = "Kategori silindi";
        public static string CategoryUpdated = "Kategori güncellendi";

        public static string CategoryLimitExceeded = "Kategori limiti asti";


        public static string AuthorizationDenied = "Yetkiniz Yok";

        public static string UserRegistered = "Kayit Gerceklesti";

        public static string UserNotFound = "Kullanici Bulunamadi";

        public static string PasswordError = "Parola Hatali";

        public static string SuccessfulLogin = "Basarili Giris";

        public static string UserAlreadyExists = "Böyle bir hesap zaten mevcut";

        public static string AccessTokenCreated = "Access Token olusturuldu";
    }
}
