using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Repositories
{
    public interface IRefreshTokensRepository
    {
        Task<RefreshTokenEntity> GetByIdAsync(string id);
        Task<bool> InvalidateAsync(string id);
        Task<bool> DisableSuccessorsAsync(string id);
        Task<RefreshTokenEntity> GenerateTokenAsync(int userId, string precursor = null);
    }
}
