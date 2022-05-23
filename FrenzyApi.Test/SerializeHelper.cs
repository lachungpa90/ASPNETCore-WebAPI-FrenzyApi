using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrenzyApi.Test
{
    public static class SerializeHelper
    {
        public static T GetObject<T>(string _fileName, Type type_)
        {
            var data = System.IO.File.ReadAllText(_fileName);
            var result= JsonConvert.DeserializeObject<T>(data);
            return result;
        }

    }
}
