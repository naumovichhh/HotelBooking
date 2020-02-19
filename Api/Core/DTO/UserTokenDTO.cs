using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTO
{
    public class UserTokenDTO
    {
        public string Name { get; set; }

        public string Role { get; set; }

        public string AccessToken { get; set; }

        public DateTime AccessTokenExpired { get; set; }

        public string RefreshToken { get; set; }
    }
}
