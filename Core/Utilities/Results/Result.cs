using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {

        public Result(bool success, string message):this(success)  // bu this olmadigi icin 2 saata ugrastim
        {
            Message = message;  // set edilemez demistik get'ler constructor icinde set edilebilir
                                    //Success = success;  // buradan silebiliriz- cünkü asagida zaten calisiyor. gerek yok
        }


        public Result(bool success)  // burada mesaj yok
        {
            Success = success;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
