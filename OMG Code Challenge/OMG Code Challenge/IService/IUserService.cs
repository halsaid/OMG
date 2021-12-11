using OMG_Code_Challenge.Model.Data_Transfer_Object;
using OMG_Code_Challenge.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMG_Code_Challenge.IService
{
    public interface IUserService
    {
        AuthenticateResponseDTO Authenticate(AuthenticateRequestDTO authenticateRequestDTO);
        User GetById(int id);
    }
}
