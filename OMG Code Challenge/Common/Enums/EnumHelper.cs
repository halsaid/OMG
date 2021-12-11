using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMG_Code_Challenge.Common.Enums
{
    public class EnumHelper
    {
        public enum ResponseStatusCode
        {
            OK = 2001,
            IINTERNAL_SERVER_ERROR=500,
            INVALID_Model=1,
            UNAUTHORIZED=2,
            INVALID_TOKEN=3,
            UNAUTHENTICATED=4,
        }
    }
}
