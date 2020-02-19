using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<UserEntity> DeleteAsync(int id)
        {
            var entity = await _context.Users.FindAsync(id);

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

        public async Task<UserEntity> GetByIdAsync(int id)
        {
            var entity =  await _context.Users.FindAsync(id);
            return entity;
        }

        public async Task<UserEntity> GetByLoginAsync(string login)
        {
            var entity = await Task.Run(() => _context.Users.FirstOrDefault(u => u.Name == login));
            if (entity == null)
            {
                entity = await Task.Run(() => _context.Users.FirstOrDefault(u => u.Email == login));
            }

            return entity;
        }

        public async Task<UserEntity> UpdateAsync(UserEntity user)
        {
            var existing = await _context.Users.FindAsync(user.Id);
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
