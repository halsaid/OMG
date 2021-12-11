using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OMG_Code_Challenge.Common.CommonHelpers;
using OMG_Code_Challenge.Common.CustomException;
using OMG_Code_Challenge.IService;
using OMG_Code_Challenge.Model.Data_Transfer_Object;
using OMG_Code_Challenge.Model.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static OMG_Code_Challenge.Common.Enums.EnumHelper;

namespace OMG_Code_Challenge.Service
{
    public class UserService: IUserService
    {
        // users hardcoded for simplicity
        private List<User> _users = new List<User>
        {
            new User { Id = 1, FirstName = "Hussien", LastName = "Elsayed", Username = "admin", Password = "123" }
        };

        private readonly AppSettings _appSettings;
        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public AuthenticateResponseDTO Authenticate(AuthenticateRequestDTO authenticateRequestDTO)
        {
            var user = _users.SingleOrDefault(x => x.Username == authenticateRequestDTO.Username && x.Password == authenticateRequestDTO.Password);

            // return null if user not found
            if (user == null)
                throw new BussinessException(ResponseStatusCode.UNAUTHENTICATED, "ERR_004");

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return new AuthenticateResponseDTO(user, token);
        }
        public User GetById(int id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }
        private string generateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var audience = _appSettings.Audience;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                Audience= audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
