using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Core.Options
{
    public class AuthOptions
    {
        public const string Issuer = "Hotel Booking Server";
        public const string Audience = "Hotel Booking Client";
        private const string Key = "fa42fajasUIlfl8";
        public const int LifeTime = 1;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
        }
    }
}
