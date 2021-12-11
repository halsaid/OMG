using OMG_Code_Challenge.Common.CommonHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static OMG_Code_Challenge.Common.Enums.EnumHelper;

namespace OMG_Code_Challenge.Common.CustomException
{
    public class BussinessException : Exception
    {
        public string MessageId { set; get; }
        public string MessageEnglish { set; get; }
        public string MessageArabic { set; get; }
        public ResponseStatusCode StatusCode { get; set; }
        public BussinessException(ResponseStatusCode StatusCode, string messageId)
        {
            this.StatusCode = StatusCode;
            MessageId = messageId;
            var errors = GetAllErrors.GetErrorDetailsByMessageId(messageId);
            MessageEnglish = errors[0];
            MessageArabic = errors[1];
        }
    }
}
