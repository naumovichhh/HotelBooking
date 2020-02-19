using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Repositories;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class RefreshTokensRepository : IRefreshTokensRepository
    {
        private DefaultContext _context;

        public RefreshTokensRepository(DefaultContext context)
        {
            _context = context;
        }

        public async Task<bool> InvalidateAsync(string key)
        {
            var found = await _context.RefreshTokens.FindAsync(key);
            if (found == null) return false;

            found.WasUsed = true;
            var entry = _context.RefreshTokens.Update(found);
            int count = await _context.SaveChangesAsync();
            if (count > 0) return true;
            else return false;
        }

        public async Task<bool> DisableSuccessorsAsync(string key)
        {
            var successors = new List<RefreshTokenEntity>();
            var tokens = _context.RefreshTokens.Include(t => t.SuccessorNavigation);
            var tokenEntity = await tokens.SingleOrDefaultAsync(t => t.Value == key);
            if (tokenEntity == null) return false;

            var current = tokenEntity.SuccessorNavigation;
            while (current != null)
            {
                successors.Add(current);
                current = current.SuccessorNavigation;
            }

            if (successors.Count > 0)
            {
                _context.RefreshTokens.RemoveRange(successors);
                tokenEntity.Successor = null;
                _context.RefreshTokens.Update(tokenEntity);
                int count = await _context.SaveChangesAsync();
                if (count > 0) return true;
                else return false;
            }

            return true;
        }

        public async Task<RefreshTokenEntity> GenerateTokenAsync(int userId, string precursorKey)
        {
            var created = new RefreshTokenEntity()
            {
                Value = Guid.NewGuid().ToString(),
                ExpiredTime = DateTime.Now + TimeSpan.FromDays(30),
                User = userId,
                WasUsed = false
            };

            var precursor = await _context.RefreshTokens.FindAsync(precursorKey);

            if (precursor != null)
            {
                precursor.Successor = created.Value;
                _context.RefreshTokens.Update(precursor);
            }

            var result = (await _context.RefreshTokens.AddAsync(created)).Entity;
            await _context.SaveChangesAsync();
            return result;
        }

        public async Task<RefreshTokenEntity> GetByIdAsync(string id)
        {
            return await _context.RefreshTokens.FindAsync(id);
        }
    }
}
