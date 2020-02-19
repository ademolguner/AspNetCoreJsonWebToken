﻿using System;

namespace TokenProject.Core.Utilities.Security.Jwt
{
    public class AccessToken
    {
        public string Token { get; set; }  // Token Değeri
        public DateTime Expiration { get; set; } // Token geçerlilik süresi

        // Refresh Token
    }
}