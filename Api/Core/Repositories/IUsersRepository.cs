using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Repositories
{
    public interface IUsersRepository
    {
        Task<IEnumerable<UserEntity>> GetAllAsync();
        Task<UserEntity> GetByIdAsync(int id);
        Task<UserEntity> GetByLoginAsync(string login);
        Task<UserEntity> CreateAsync(UserEntity user);
        Task<UserEntity> UpdateAsync(UserEntity user);
        Task<UserEntity> DeleteAsync(int id);
    }
}
