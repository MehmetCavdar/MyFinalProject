using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {

        public Result(bool success, string message)
        {
            Message = message;  // set edilemez demistik get'ler constructor icinde set edilebilir
            //Success = success;  // buradan silebiliriz- cünkü assagida zaten calisiyor. gerek yok
        }


        public Result(bool success)  // burada mesaj yok
        {
            Success = success;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
