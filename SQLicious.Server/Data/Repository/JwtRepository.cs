﻿using Microsoft.IdentityModel.Tokens;
using SQLicious.Server.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SQLicious.Server.Data.Repository
{
    public class JwtRepository
    {
        public string GenerateJwt(Admin admin)
        {
            try
            {
                //Create Claims
                List<Claim> claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, admin.Id),
                new Claim(JwtRegisteredClaimNames.Email, admin.Email),
            };


                //Configuration of Token settings
                SymmetricSecurityKey secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_SECRET")));
                SigningCredentials credentials = new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);

                // Create JWT
                JwtSecurityToken jwt = new JwtSecurityToken(
                    issuer: Environment.GetEnvironmentVariable("JWT_ISSUER"),
                    audience: Environment.GetEnvironmentVariable("JWT_AUDIENCE"),
                    claims: claims,
                    expires: DateTime.Now.AddHours(3),
                    signingCredentials: credentials
                    );

                // Serialize token
                var tokenHandler = new JwtSecurityTokenHandler();
                return tokenHandler.WriteToken(jwt);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error generating JWT token", ex);
            }
        }
    }
}