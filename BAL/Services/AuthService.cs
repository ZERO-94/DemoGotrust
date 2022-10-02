using BAL.DTOs;
using DAL.Models;
using DAL.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAccountUserRepository _accountUserRepository;
        public IConfiguration _configuration;

        public AuthService(IAccountUserRepository accountUserRepository, IConfiguration config)
        {
            _accountUserRepository = accountUserRepository;
            _configuration = config;
        }


        public JwtDto login(string username, string password)
        {
            try
            {
                AccountUser user = _accountUserRepository.GetByUserIdAndPassword(username, password);

                if (user == null) return null;

                //create token
                JwtDto jwt = CreateToken(user);

                return jwt;

            } catch (Exception ex)
            {
                throw;
            }
        }

        private JwtDto CreateToken(AccountUser user)
        {
            var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", user.UserId.ToString()),
                        new Claim("UserFullName", user.UserFullName),
                        new Claim("UserRole", user.UserRole.ToString())
                    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: signIn);

            return new JwtDto
            {
                accessToken = new JwtSecurityTokenHandler().WriteToken(token),
                expire = token.ValidTo.ToUniversalTime().ToLongTimeString()
            };
        }
    }
}
