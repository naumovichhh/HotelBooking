using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.DTO;

namespace Core.Services
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(UserDTO user);
        Task<UserTokenDTO> LoginAsync(LoginDTO creds);
        Task<UserTokenDTO> RefreshAsync(string refreshToken);
    }
}
