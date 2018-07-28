using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class JwtTokenHelper
    {
        private static string Secret = Config.SystemSecrect;
        private static int ExpireMinutes = int.Parse(Config.TokenExpireMinutes);
        private const string Issuer = "雾月哥";
        private const string ValidateFrom = "ValidateFrom";
        private const string ValidateTo = "ValidateTo";

        /// <summary>
        /// 生成Token
        /// </summary>
        public static string Generate(Dictionary<string, dynamic> payload)
        {
            IdentityModelEventSource.ShowPII = true;
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secret));
            var now = DateTime.UtcNow;
            var expiresTime = DateTime.UtcNow.AddMinutes(ExpireMinutes);
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var header = new JwtHeader(signingCredentials);
            var jwtPayload = new JwtPayload(Issuer, "", null, now, expiresTime);
            foreach (var item in payload)
                jwtPayload.Add(item.Key, item.Value);

            var jwtToken = new JwtSecurityToken(header, jwtPayload);
            var handler = new JwtSecurityTokenHandler();
            handler.TokenLifetimeInMinutes = ExpireMinutes;

            var jwt = handler.WriteToken(jwtToken);
            return jwt;
        }
        
        /// <summary>
        /// 解码Token 并返回过期时间
        /// </summary>
        public static IDictionary<string, dynamic> Decode(string token)
        {
            try
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secret));

                var validateParam = new TokenValidationParameters()
                {
                    //验证Secret
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = securityKey,

                    //验证发行者
                    ValidateIssuer = true,
                    ValidIssuer = Issuer,

                    //验证请求者
                    ValidateAudience = false,

                    //不验证超时时间
                    ValidateLifetime = false,
                    RequireExpirationTime = true,

                };
                SecurityToken validToken = null;
                var handler = new JwtSecurityTokenHandler();
                var principle = handler.ValidateToken(token, validateParam, out validToken);
                var result = (validToken as JwtSecurityToken).Payload;
                result.Add(ValidateFrom, result.ValidFrom);
                result.Add(ValidateTo, result.ValidTo);
                return result;
            }
            catch
            {
                return null;
            }
        }
    }
}
