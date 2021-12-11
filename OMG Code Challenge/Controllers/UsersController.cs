using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using OMG_Code_Challenge.Common.CustomeResponse;
using OMG_Code_Challenge.IService;
using OMG_Code_Challenge.Model.Data_Transfer_Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static OMG_Code_Challenge.Common.Enums.EnumHelper;

namespace OMG_Code_Challenge.Controllers
{
    [Route("api/[controller]/")]
    public class UsersController : Controller
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [EnableCors("OMGPolicy")]
        [HttpPost]
        [Route("[Action]")]
        public Response Authenticate([FromBody]AuthenticateRequestDTO authenticateRequestDTO)
        {
            return new Response() { StatusCode = ResponseStatusCode.OK , Data= _userService.Authenticate(authenticateRequestDTO) };
        }
    }
}
