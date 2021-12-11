using OMG_Code_Challenge.Common.CutomeError;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMG_Code_Challenge.Common.CommonHelpers
{
    public class GetAllErrors
    {
        public static List<string> GetErrorDetailsByMessageId(string messageId)
        {
            var _CurrentError = ReadErrorFromJson<Errors>.GetAllObjects().Where(m => m.Message_ID == messageId).FirstOrDefault();
            if (_CurrentError != null)
                return new List<string>() { _CurrentError.Message_Description_EN, _CurrentError.Message_Description_AR };
            return new List<string>();
        }
    }
}
