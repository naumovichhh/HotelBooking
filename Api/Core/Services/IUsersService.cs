using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.DTO;

namespace Core.Services
{
    public interface IUsersService
    {
        Task<IEnumerable<UserDTO>> GetAllAsync();
        Task<UserDTO> GetByNameAsync(string username);
        Task<UserDTO> CreateAsync(UserDTO user);
        Task<UserDTO> UpdateAsync(UserDTO user);
        Task<UserDTO> DeleteAsync(string username);
    }
}
