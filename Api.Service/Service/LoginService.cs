using System;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.User;
using Domain.Repository;

namespace Api.Service.Service
{
    public class LoginService : ILoginService
    {
        private IUserRepository _repository;

        public LoginService(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<object> FindByLogin(UserEntity user)
        {
            var baseUser = new UserEntity();
            if (user != null && !String.IsNullOrWhiteSpace(user.Email))
            {
               return  await _repository.FindByLogin(user.Email);
               
            }
            else
            {
                return null;
            }
            
            
        }
    }
}
