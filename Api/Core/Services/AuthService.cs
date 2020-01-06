using Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BCrypt.Net;
using Core.Entities;
using Core.Options;
using Core.Repositories;
using Microsoft.IdentityModel.Tokens;

namespace Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly string constSalt = "25z2oKjK433ooJ";
        private IMapper _mapper;
        private IUsersRepository _repository;

        public AuthService(IMapper mapper, IUsersRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<string> RegisterAsync(UserDTO user)
        {
            var existing = await _repository.GetByNameOrEmailAsync(user.Name);
            if (existing != null)
                return null;

            existing = await _repository.GetByNameOrEmailAsync(user.Email);
            if (existing != null)
                return null;

            DateTime dt = DateTime.Now;
            var entity = _mapper.Map<UserEntity>(user);
            entity.RegistrationTime = dt;
            var cryptedPassword = BCrypt.Net.BCrypt.HashPassword(entity.Password+constSalt, dt.Ticks.ToString());
            entity.Password = cryptedPassword;
            var result = _mapper.Map<UserDTO>(await _repository.CreateAsync(entity));
            if (result == null) return null;
            else return result.Name;
        }

        public async Task<UserTokenDTO> LoginAsync(string id, string password)
        {
            var identity = await GetIdentityAsync(id, password);
            if (identity == null)
                return null;

            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                AuthOptions.Issuer,
                AuthOptions.Audience,
                identity.Claims,
                now,
                now.Add(TimeSpan.FromDays(AuthOptions.LifeTime)),
                new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new UserTokenDTO()
            {
                Name = identity.Name,
                Role = identity.Claims.Where(e => e.Type == ClaimTypes.Role).First().Value,
                Token = encodedJwt
            };
        }

        private async Task<ClaimsIdentity> GetIdentityAsync(string id, string password)
        {
            var entity = await _repository.GetByNameOrEmailAsync(id);
            if (entity == null)
                return null;

            var cryptedPassword = BCrypt.Net.BCrypt.HashPassword(password+constSalt, entity.RegistrationTime.Ticks.ToString());
            if (cryptedPassword != entity.Password)
                return null;

            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, entity.Name),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, entity.Role)
            };
            var claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
        }
    }
}
