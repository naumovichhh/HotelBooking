using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTO
{
    public class LoginDTO
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string RefreshToken { get; set; }
    }
}
