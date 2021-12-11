using OMG_Code_Challenge.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMG_Code_Challenge.Model.Data_Transfer_Object
{
    public class AuthenticateResponseDTO
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public AuthenticateResponseDTO(User user , string token)
        {
            Id = user.Id;
            Token = token;
        }
    }
}
