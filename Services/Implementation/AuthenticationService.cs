using Microsoft.IdentityModel.Tokens;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace Services.Implementation
{
    public class AuthenticationService : IAuthentication
    {
        private readonly string _username = "admin";
        private readonly string _password = "123456";
        private readonly string _key;

        public AuthenticationService(string key)
        {
            _key = key;
        }

        public string Authentication(string username, string password)
        {
            if ((username != _username) || (password != _password))
            {
                return null;
            }

            //Create security token handler
            var tokenHandler = new JwtSecurityTokenHandler();

            //create private key to be encrypted
            var tokenKey = Encoding.ASCII.GetBytes(_key);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.Name, username)
                    }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                       new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };

            //create token
            var token = tokenHandler.CreateToken(tokenDescriptor);

            //
            return tokenHandler.WriteToken(token);
        }
    }
}
