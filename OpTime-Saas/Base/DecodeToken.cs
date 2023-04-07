using Newtonsoft.Json.Linq;
using OpTime_Saas.Messages.DTOs;
using System.IdentityModel.Tokens.Jwt;

namespace OpTime_Saas.Base
{
    public static class Token
    {
        public static TokenClaims DeCode(string jwtToken)
        {
            var response = new TokenClaims();
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtTokenObject = tokenHandler.ReadJwtToken(jwtToken);

            // read the claims
            var claims = jwtTokenObject.Claims;

            foreach (var claim in claims)
            {
                switch (claim.Type)
                {
                    case "username":
                        response.userName = claim.Value;
                        break;
                    case "userid":
                        response.userId = claim.Value;
                        break;

                    default:
                        break;
                }
            }
            return response;
        }

        public static  string GetToken(HttpRequest request)
        {
            var token = request.Headers.ContainsKey("Authorization")
                                                                        ? request.Headers["Authorization"].ToString().Split(" ")[1]
                                                                        : string.Empty;
            return token;
        }
    }
}
