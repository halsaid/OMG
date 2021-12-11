using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using OMG_Code_Challenge.Common.CustomException;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using static OMG_Code_Challenge.Common.Enums.EnumHelper;

namespace OMG_Code_Challenge.Common.CommonHelpers
{
    public class ReadErrorFromJson<T> where T : class
    {
        private static string _JsonFilePath;
        public static List<T> GetAllObjects()
        {
            
            _JsonFilePath = Path.GetFullPath("Errors.json");

            if (_JsonFilePath == null)
                throw new Exception("Can not find the error file path");

            using (StreamReader r = new StreamReader(_JsonFilePath))
            {
                string json = r.ReadToEnd();

                return JsonConvert.DeserializeObject<List<T>>(json);
            }
        }
    }
}
