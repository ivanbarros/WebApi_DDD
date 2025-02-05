using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Api.Domain.DTOs;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.User;
using Api.Domain.Security;
using Domain.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Api.Service.Service
{
    public class LoginService : ILoginService
    {
        private IUserRepository _repository;
        private SigningConfigurations _signingConfig;
        private TokenConfigurations _tokenConfig;                                                                                                                                   
        private IConfiguration _configuration {get;}
        
        public LoginService(IUserRepository repository, SigningConfigurations signingConfigurations, TokenConfigurations tokenConfigurations, IConfiguration configuration)
        {
            _repository = repository;
            _signingConfig = signingConfigurations;
            _tokenConfig = tokenConfigurations;
            _configuration = configuration;
        }
        public async Task<object> FindByLogin(LoginDTO user)
        {
            var baseUser = new UserEntity();

            if (user != null && !String.IsNullOrWhiteSpace(user.Email))
            {
               baseUser =   await _repository.FindByLogin(user.Email);

               if (baseUser == null)
               {
                   return new {
                       authenticated = false,
                        message = "Falha ao autenticar"
                        };
                }
                else
                {
                    var identity =  new ClaimsIdentity(new GenericIdentity(baseUser.Email),
                    new []
                    {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), //jti é o id do token
                        new Claim(JwtRegisteredClaimNames.UniqueName, user.Email),
                    });
                    DateTime createDate = DateTime.Now;
                    DateTime expirationDate = createDate  + TimeSpan.FromSeconds(_tokenConfig.Seconds);

                    var handler = new JwtSecurityTokenHandler();

                    string token = CreateToken(identity, createDate,expirationDate, handler);
                    return SuccessObject(createDate, expirationDate, token, user);
                }
             }
               
            
    
            else
            {
                return new
                {
                authenticated = false,
                        message = "Falha ao autenticar"
                };
            }
        
            
        }
        private string CreateToken (ClaimsIdentity identity, DateTime createDate, DateTime expirationDate, JwtSecurityTokenHandler handler)
        {
            var securityToken =  handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer =  _tokenConfig.Issuer,
                Audience = _tokenConfig.Audience,
                SigningCredentials = _signingConfig.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expirationDate,
            });
            var token = handler.WriteToken(securityToken);
            return token;
        }

                //Caso queira o nome do usuario, basta trocar o LoginDTO para UserEntity e trocar no FindByLogin
                //trocar o return user para baseuser
        private object SuccessObject(DateTime createDate, DateTime expirationDate, string token, LoginDTO user)
        {
            return new 
            {
                authenticated = true, 
                created = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                accessToken = token,
                userName = user.Email,
                message = "Usuario Logado com sucesso" 

            };
        }
    }

    
}
