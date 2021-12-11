using Microsoft.AspNetCore.Mvc.Filters;
using OMG_Code_Challenge.Common.CustomException;
using OMG_Code_Challenge.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static OMG_Code_Challenge.Common.Enums.EnumHelper;

namespace OMG_Code_Challenge.AuthorizationHandler
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = (User)context.HttpContext.Items["User"];

            if (user == null)
                throw new BussinessException(ResponseStatusCode.INVALID_TOKEN, "ERR_003");
        }
    }
}
