using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using WashingtonRedskins.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Newtonsoft.Json;
using System.Linq;

namespace WashingtonRedskins
{
    class AuthController
    {
        private static string plainTextSecurityKey = "HIlnb@pSyzwd7V&WHW*W1J#7bS1Raw%I488ldSzpiob2&79B3f&U@P3VwM04YbtLjToA%OjhEje";
        public static object Datetime { get; private set; }

        public static string hashPassword(string password)
        {
            //trying to hit .5 seconds - ish
            return BCrypt.Net.BCrypt.HashPassword(password, 10);
        }

        public static bool validatePassword(string email, string password)
        {
            Users usr;
            try
            {
                using (var dbContext = new WashingtonRedskinsContext())
                {
                    usr = dbContext.Users.Where(u => u.Email == email).First();
                }
                if (BCrypt.Net.BCrypt.Verify(password, usr.Password))
                {
                    return true;
                }

            }
            catch (Exception ex) { }
            return false;
        }

        public static string generateToken(Users info)
        {
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(plainTextSecurityKey));
            var signingCredentials = new SigningCredentials(signingKey,
                SecurityAlgorithms.HmacSha256);

            var claimsIdentity = new ClaimsIdentity(new List<Claim>()
            {
                new Claim(ClaimTypes.Sid, info.Id.ToString()),
                new Claim(ClaimTypes.NameIdentifier, info.Email),
                new Claim(ClaimTypes.GivenName, info.Firstname),
                new Claim(ClaimTypes.Role, info.UserGroupId.ToString()),
                new Claim("privileges", JsonConvert.SerializeObject(info.GetUserPrivileges())),
            }, "Custom");

            var securityTokenDescriptor = new SecurityTokenDescriptor()
            {
                Issuer = "washingtonredskins",
                Subject = claimsIdentity,
                SigningCredentials = signingCredentials,
                Expires = DateTime.Now.AddHours(2),
                IssuedAt = DateTime.Now.AddHours(1),
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var plainToken = tokenHandler.CreateToken(securityTokenDescriptor);
            var signedAndEncodedToken = tokenHandler.WriteToken(plainToken);

            return signedAndEncodedToken;
        }

        public static JwtSecurityToken refreshToken(JwtSecurityToken signedAndValidatedToken = null)
        {
            string name;
            string role;

            var jwt = (JwtSecurityToken)signedAndValidatedToken;
            name = jwt.Payload["nameid"].ToString();
            role = jwt.Payload["role"].ToString();

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(plainTextSecurityKey));
            var signingCredentials = new SigningCredentials(signingKey,
                SecurityAlgorithms.HmacSha256);

            var claimsIdentity = new ClaimsIdentity(new List<Claim>()
            {
                new Claim(ClaimTypes.Sid, jwt.Payload["sid"].ToString()),
                new Claim(ClaimTypes.NameIdentifier, jwt.Payload["nameid"].ToString()),
                new Claim(ClaimTypes.GivenName, jwt.Payload["givenname"].ToString()),
                new Claim(ClaimTypes.Role, jwt.Payload["role"].ToString()),
                new Claim("privileges", jwt.Payload["privileges"].ToString()),
            }, "Custom");

            var securityTokenDescriptor = new SecurityTokenDescriptor()
            {
                Issuer = "washingtonredskins",
                Subject = claimsIdentity,
                SigningCredentials = signingCredentials,
                Expires = DateTime.Now.AddHours(2),
                IssuedAt = DateTime.Now.AddHours(1),
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var plainToken = tokenHandler.CreateToken(securityTokenDescriptor);
            var signedAndEncodedToken = tokenHandler.WriteToken(plainToken);

            return tokenHandler.ReadJwtToken(signedAndEncodedToken);
        }

        public static JwtSecurityToken getValidatedToken(string signedAndEncodedToken)
        {
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(plainTextSecurityKey));
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenValidationParameters = new TokenValidationParameters()
            {
                ValidateAudience = false,
                ValidIssuers = new string[]
                           {
                    "washingtonredskins",
                           },
                IssuerSigningKey = signingKey
            };

            SecurityToken validatedToken;
            try
            {
                tokenHandler.ValidateToken(signedAndEncodedToken, tokenValidationParameters, out validatedToken);
                if (isTokenInGracePeriod(validatedToken))
                {
                    validatedToken = refreshToken(validatedToken as JwtSecurityToken);
                }
                return validatedToken as JwtSecurityToken;
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public static bool isTokenInGracePeriod(SecurityToken token)
        {
            if (token.ValidTo.AddMinutes(15) > DateTime.Now && token.ValidTo < DateTime.Now)
            {
                return true;
            }
            return false;
        }

        public static JwtSecurityToken isInGracePeriod(JwtSecurityToken token)
        {
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(plainTextSecurityKey));
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenValidationParameters = new TokenValidationParameters()
            {

                ValidIssuers = new string[]
                           {
                    "washingtonredskins",
                           },
                IssuerSigningKey = signingKey,
                ClockSkew = TimeSpan.FromMinutes(15)
            };
            SecurityToken validatedToken;
            try
            {
                tokenHandler.ValidateToken(token.RawCiphertext, tokenValidationParameters, out validatedToken);
                return validatedToken as JwtSecurityToken;
            }
            catch
            {

            }
            return null;
        }
    }
}
