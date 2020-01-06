/*using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Repositories;
using Core.Entities;

namespace Core.Services
{
    public class UsersService : IUsersService
    {
        private readonly string constSalt = "25z2";
        private IMapper _mapper;
        private IUsersRepository _repository;

        public UsersService(IMapper mapper, IUsersRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<UserDTO> CreateAsync(UserDTO user)
        {
            if (_repository.GetByNameAsync(user.Name) != null)
                return null;

            DateTime dt = DateTime.Now;
            var entity = _mapper.Map<UserEntity>(user);
            entity.RegistrationTime = dt;
            var cryptedPassword = Crypter.Blowfish.Crypt(user.Password+dt.ToString()+constSalt);
            entity.Password = cryptedPassword;
            return _mapper.Map<UserDTO>(await _repository.CreateAsync(entity));
        }

        public async Task<bool> CheckCredentialsAsync(UserDTO user)
        {
            var entity = await _repository.GetByNameAsync(user.Name);
            if (entity == null)
                return false;

            var cryptedPassword = Crypter.Blowfish.Crypt(user.Password+entity.RegistrationTime.ToString()+constSalt);
            if (cryptedPassword == entity.Password)
                return true;
            else
                return false;
        }

        public async Task<UserDTO> DeleteAsync(string name)
        {
            return _mapper.Map<UserDTO>(await _repository.DeleteAsync(name));
        }

        public async Task<IEnumerable<UserDTO>> GetAllAsync()
        {
            return _mapper.Map<List<UserDTO>>(await _repository.GetAllAsync());
        }

        public async Task<UserDTO> GetByNameAsync(string name)
        {
            return _mapper.Map<UserDTO>(await _repository.GetByNameAsync(name));
        }

        public async Task<UserDTO> UpdateAsync(UserDTO user)
        {
            if (_repository.GetByNameAsync(user.Name) == null)
                return null;

            var prevEntity = await _repository.GetByNameAsync(user.Name);
            var cryptedPassword = Crypter.Blowfish.Crypt(user.Password+prevEntity.RegistrationTime.ToString()+constSalt);
            var entity = _mapper.Map<UserEntity>(user);
            entity.Password = cryptedPassword;
            return _mapper.Map<UserDTO>(await _repository.UpdateAsync(entity));
        }
    }
}
*/