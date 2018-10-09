using Newtonsoft.Json;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using WashingtonRedskins.Models;

namespace WashingtonRedskins.Extensions
{
    static class JWTokenExtensionscs
    {
        public static bool hasPermission(this JwtSecurityToken jwt, string permissionName)
        {
            if (jwt != null)
            {
                var privileges = JsonConvert.DeserializeObject<List<string>>(jwt.Payload["privileges"].ToString());

                foreach (string p in privileges)
                {
                    if (p == permissionName)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static string[] getPermissions(this JwtSecurityToken jwt)
        {
            string[] priv = null;

            var privileges = JsonConvert.DeserializeObject<List<Privileges>>(jwt.Payload["privileges"].ToString());
            foreach (Privileges p in privileges)
            {
                priv[priv.Length] = p.Name;
            }
            return priv;
        }

        public static uint SID(this JwtSecurityToken jwt)
        {
            return uint.Parse(jwt.Payload["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid"].ToString());
        }
    }
}
