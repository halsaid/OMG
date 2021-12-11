using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using OMG_Code_Challenge.Common.CommonHelpers;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMG_Code_Challenge.Common.CustomException;
using static OMG_Code_Challenge.Common.Enums.EnumHelper;
using OMG_Code_Challenge.IService;

namespace OMG_Code_Challenge.JWTMiddlewares
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly AppSettings _appSettings;

        public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
        {
            _next = next;
            _appSettings = appSettings.Value;
        }
        public async Task Invoke(HttpContext context, IUserService userService)
        {
            var authorizationHeader = context.Request.Headers["Authorization"];

            if (!string.IsNullOrEmpty(authorizationHeader))
            {
                var token = authorizationHeader.FirstOrDefault()?.Split(" ").Last();

                if (token != null)
                    attachUserToContext(context, userService, token);
            }
            

            await _next(context);
        }
        private void attachUserToContext(HttpContext context, IUserService userService, string token)
        {
            try
            {
                var audience = _appSettings.Audience;
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = true,
                    ValidAudience = audience,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;

                var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

                // attach user to context on successful jwt validation
                context.Items["User"] = userService.GetById(userId);
            }
            catch
            {
                throw new BussinessException(ResponseStatusCode.UNAUTHORIZED, "ERR_003");
            }
        }
    }

}

