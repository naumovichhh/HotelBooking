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
        private readonly string ConstSalt = "25z2oKjK433ooJ";
        private IMapper _mapper;
        private IUsersRepository _usersRepository;
        private IRefreshTokensRepository _refreshTokensRepository;

        public AuthService(IMapper mapper, IUsersRepository usersRepository, IRefreshTokensRepository refreshTokensRepository)
        {
            _mapper = mapper;
            _usersRepository = usersRepository;
            _refreshTokensRepository = refreshTokensRepository;
        }

        public async Task<string> RegisterAsync(UserDTO user)
        {
            var existing = await _usersRepository.GetByLoginAsync(user.Name);
            if (existing != null)
                return null;

            existing = await _usersRepository.GetByLoginAsync(user.Email);
            if (existing != null)
                return null;

            DateTime dt = DateTime.Now;
            var ticks = dt.Ticks.ToString();
            var entity = _mapper.Map<UserEntity>(user);
            entity.RegistrationTime = dt;
            entity.Salt = BCrypt.Net.BCrypt.GenerateSalt();
            var cryptedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password+ConstSalt, entity.Salt);
            entity.Password = cryptedPassword;
            var result = _mapper.Map<UserDTO>(await _usersRepository.CreateAsync(entity));
            if (result == null) return null;
            else return result.Name;
        }

        public async Task<UserTokenDTO> LoginAsync(LoginDTO creds)
        {
            string login = creds.Login, password = creds.Password, oldRefreshToken = creds.RefreshToken;
            var identity = await GetIdentityAsync(login, password);
            if (identity == null) return null;

            if (oldRefreshToken != null)
            {
                await _refreshTokensRepository.DisableSuccessorsAsync(oldRefreshToken);
            }

            var (encodedJwt, expired) = GetJwt(identity);

            var user = await _usersRepository.GetByLoginAsync(login);
            var refreshToken = await _refreshTokensRepository.GenerateTokenAsync(user.Id, oldRefreshToken);
            if (refreshToken == null) return null;
            var refreshTokenValue = refreshToken.Value;

            return new UserTokenDTO()
            {
                Name = identity.Name,
                Role = identity.Claims.Where(e => e.Type == ClaimTypes.Role).First().Value,
                AccessToken = encodedJwt,
                AccessTokenExpired = expired,
                RefreshToken = refreshTokenValue
            };
        }

        public async Task<UserTokenDTO> RefreshAsync(string refreshTokenValue)
        {
            var refreshToken = await _refreshTokensRepository.GetByIdAsync(refreshTokenValue);
            if (refreshToken == null) return null;

            if (DateTime.Now > refreshToken.ExpiredTime || refreshToken.WasUsed)
            {
                return null;
            }

            var identity = await GetIdentityAsync(refreshToken.User);
            if (identity == null) return null;

            var isInvalidated = await _refreshTokensRepository.InvalidateAsync(refreshTokenValue);
            if (!isInvalidated) return null;

            var (encodedJwt, expired) = GetJwt(identity);

            var newRefreshToken = await _refreshTokensRepository.GenerateTokenAsync(refreshToken.User, refreshTokenValue);
            if (newRefreshToken == null) return null;
            var newRefreshTokenValue = newRefreshToken.Value;

            return new UserTokenDTO()
            {
                Name = identity.Name,
                Role = identity.Claims.Where(e => e.Type == ClaimTypes.Role).First().Value,
                AccessToken = encodedJwt,
                AccessTokenExpired = expired,
                RefreshToken = newRefreshTokenValue
            };
        }

        private (string, DateTime) GetJwt(ClaimsIdentity identity)
        {
            var now = DateTime.UtcNow;
            var expired = now.Add(AuthOptions.LifeTime);
            var jwt = new JwtSecurityToken(
                AuthOptions.Issuer,
                AuthOptions.Audience,
                identity.Claims,
                now,
                expired,
                new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return (encodedJwt, expired);
        }

        private async Task<ClaimsIdentity> GetIdentityAsync(int id)
        {
            var entity = await _usersRepository.GetByIdAsync(id);
            if (entity == null)
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
        private async Task<ClaimsIdentity> GetIdentityAsync(string login, string password)
        {
            var entity = await _usersRepository.GetByLoginAsync(login);
            if (entity == null)
                return null;

            if (!BCrypt.Net.BCrypt.Verify(password + ConstSalt, entity.Password))
            {
                return null;
            }

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
