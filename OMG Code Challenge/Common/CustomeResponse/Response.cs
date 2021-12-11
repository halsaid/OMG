using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static OMG_Code_Challenge.Common.Enums.EnumHelper;

namespace OMG_Code_Challenge.Common.CustomeResponse
{
    public class Response
    {
        public Response()
        {
            StatusCode = ResponseStatusCode.IINTERNAL_SERVER_ERROR;
            Errors = new List<string>();
        }

        public List<string> Errors { get; set; }
        public ResponseStatusCode StatusCode { get; set; }
        public dynamic Data { get; set; }
    }
}
