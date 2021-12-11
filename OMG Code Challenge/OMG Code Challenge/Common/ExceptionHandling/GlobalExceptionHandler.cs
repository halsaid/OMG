using Microsoft.AspNetCore.Mvc.Filters;
using OMG_Code_Challenge.Common.CustomeResponse;
using OMG_Code_Challenge.Common.CustomException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using static OMG_Code_Challenge.Common.Enums.EnumHelper;

namespace OMG_Code_Challenge.Common.ExceptionHandling
{
    public static class GlobalExceptionHandler
    {
        public static Response ExceptionHandle(Exception exception)
        {
            if (exception is BussinessException)
            {
                var message = ((BussinessException)exception).MessageId;
                var messageEnglish = ((BussinessException)exception).MessageEnglish;
                var messageArabic = ((BussinessException)exception).MessageArabic;
                return new Response() { StatusCode = ((BussinessException)exception).StatusCode, Errors = new List<string>() { messageEnglish, messageArabic } };
            }
            else
            {
                return new Response() { StatusCode = ResponseStatusCode.IINTERNAL_SERVER_ERROR, Errors = new List<string>() { "Unexpected Error!" } };
            }
        }
    }
}
