using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Builder;

namespace Core.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)   // extend edilmis StartUp'ta kullanilan bir yasam döngüsü
        {
            app.UseMiddleware<ExceptionMiddleware>();  // satartup'ta olan yasam döngüsüne hata olup olmadigini gözeten ekleme yapiyoruz
        }
    }
}