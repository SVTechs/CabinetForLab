using System;
using System.Collections.Generic;
using System.Linq;
using Utilities.Json;

namespace Utilities.Net
{
    public class ResponseParser
    {
        public static List<string> ParseResponse(string []response, out ServiceException exception)
        {
            if (response == null || response.Length == 0)
            {
                exception = new ServiceException(0, "No Data");
                return null;
            }
            ResponseMaker rm = ConvertJson.JsonToObject<ResponseMaker>(response[0]);
            if (rm.ResultCode != 1)
            {
                exception = new ServiceException(rm.ResultCode, rm.Description);
                return null;
            }
            exception = null;
            return response.Skip(1).Take(response.Length - 1).ToList();
        }

        public class ServiceException : Exception
        {
            public int ResponseCode;

            public ServiceException(int responseCode, string message) : base(message)
            {
                ResponseCode = responseCode;
            }
        }
    }
}
