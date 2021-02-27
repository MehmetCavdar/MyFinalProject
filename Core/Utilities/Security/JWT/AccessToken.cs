using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public class AccessToken   // a´nlamsit gözüken anahtar degeri ve bitis süresi tanimlanir
    {
        public string Token { get; set; }

        public DateTime Expiration { get; set; }

    }
}
