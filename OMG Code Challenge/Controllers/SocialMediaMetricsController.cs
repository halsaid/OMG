using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OMG_Code_Challenge.AuthorizationHandler;
using OMG_Code_Challenge.Common.CustomeResponse;
using OMG_Code_Challenge.Common.CustomException;
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
    public class SocialMediaMetricsController : Controller
    {
        private readonly ISocialMediaMetricsService _socialMediaMetricsService;

        public SocialMediaMetricsController(ISocialMediaMetricsService socialMediaMetricsService)
        {
            this._socialMediaMetricsService = socialMediaMetricsService;
        }
        [Authorize]
        [HttpPost]
        [Route("[Action]")]
        public Response PullsMedia([FromBody]dynamic socialMediaDTO)
        {
            if (!ModelState.IsValid)
                throw new BussinessException(ResponseStatusCode.INVALID_Model, "ERR_001");

            return new Response() {StatusCode=ResponseStatusCode.OK,Data= _socialMediaMetricsService.PullsMedia(socialMediaDTO) };
        }
    }
}
