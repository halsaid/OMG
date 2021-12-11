using Newtonsoft.Json;
using OMG_Code_Challenge.Common.CustomException;
using OMG_Code_Challenge.Model.Data_Transfer_Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using static OMG_Code_Challenge.Common.Enums.EnumHelper;

namespace OMG_Code_Challenge.Common.CommonHelpers
{
    public  class OMGJsonConvert<T> where T : class
    {
        public static T DeserializeObject(dynamic convertedObject)
        {
            T requiredObject;
            try {
                requiredObject = JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(convertedObject));
            }
            catch(Exception e)
            {
                throw new BussinessException(ResponseStatusCode.INVALID_Model, "ERR_001");
            }

            var properties = requiredObject.GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance| BindingFlags.Static);

            if (properties.Length == 0)
            {
                throw new BussinessException(ResponseStatusCode.INVALID_Model, "ERR_001");
            }

            foreach (var property in properties)
            {
                if (property.GetValue(requiredObject, null) == null)
                    throw new BussinessException(ResponseStatusCode.INVALID_Model, "ERR_001");
            }

            return requiredObject;
        }
    }
}
