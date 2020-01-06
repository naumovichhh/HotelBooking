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
    public class UsersRepository : IUsersRepository
    {
        DefaultContext _context;

        public UsersRepository(DefaultContext context)
        {
            _context = context;
        }

        public async Task<UserEntity> CreateAsync(UserEntity user)
        {
            var result = (await _context.Users.AddAsync(user)).Entity;
            await _context.SaveChangesAsync();
            return result;
        }

        public async Task<UserEntity> DeleteAsync(string key)
        {
            var entity = await _context.Users.FindAsync(key);
            if (entity == null)
            {
                entity = await _context.Users.SingleOrDefaultAsync(u => u.Email == key);
            }

            if (entity == null)
                return null;
            var result = _context.Users.Remove(entity).Entity;
            await _context.SaveChangesAsync();
            return result;
        }

        public async Task<IEnumerable<UserEntity>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<UserEntity> GetByNameOrEmailAsync(string key)
        {
            var entity =  await _context.Users.FindAsync(key);
            if (entity == null)
            {
                return await _context.Users.SingleOrDefaultAsync(u => u.Email == key);
            }
            else return entity;
        }

        public async Task<UserEntity> UpdateAsync(UserEntity user)
        {
            var existing = await _context.Users.FindAsync(user.Name);
            if (existing != null)
            {
                var result = _context.Users.Update(user).Entity;
                await _context.SaveChangesAsync();
                return result;
            }
            else
                return null;
        }
    }
}
