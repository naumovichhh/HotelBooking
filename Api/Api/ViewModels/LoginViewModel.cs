using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.ViewModels
{
    public class LoginViewModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string RefreshToken { get; set; }
    }
}
