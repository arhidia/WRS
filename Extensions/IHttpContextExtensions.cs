using Grapevine.Interfaces.Server;
using System.Collections.Specialized;
using System.IdentityModel.Tokens.Jwt;

namespace WashingtonRedskins.Extensions
{
    static class IHttpContextExtensions
    {
        public static JwtSecurityToken token(this IHttpContext context)
        {
            NameValueCollection data;

            if (context.Request.HttpMethod == Grapevine.Shared.HttpMethod.GET)
            {
                data = context.Request.QueryString;
            }
            else
            {
                data = Parsers.parseURLEncoded(context.Request.Payload);
            }

            var jwt = AuthController.getValidatedToken(data["token"]);

            return jwt;
        }
    }
}
