using System;
using System.Collections.Generic;
using Utilities.Json;

namespace Utilities.Net
{
    public class ResponseMaker
    {
        public int ResultCode;
        public string Description;

        public ResponseMaker(int resultCode, string description)
        {
            ResultCode = resultCode;
            Description = description;
        }

        public ResponseMaker()
        {
            ResultCode = 1;
            Description = "Success";
        }

        public override string ToString()
        {
            return ConvertJson.ObjectToJson(this);
        }

        public static List<string> GenerateResponseHeader()
        {
            List<string> resultList = new List<string>
            {
                new ResponseMaker().ToString()
            };
            return resultList;
        }

        public static List<string> GenerateSimpleResponse(ResponseMaker responseType, string data)
        {
            List<string> resultList = new List<string>
            {
                responseType.ToString(),
                data
            };
            return resultList;
        }

        public static List<string> GenerateSimpleResponse<T>(T data)
        {
            List<string> resultList = new List<string>
            {
                new ResponseMaker().ToString(),
                data.ToString()
            };
            return resultList;
        }

        public static List<string> GenerateObjectResponse(object data, bool trimResult = false)
        {
            string infoJson = trimResult ? ConvertJson.ObjectToJsonTrimmed(data) : ConvertJson.ObjectToJson(data);
            List<string> resultList = new List<string>
            {
                new ResponseMaker().ToString(),
                infoJson
            };
            return resultList;
        }

        public static List<string> GenerateStringListResponse(List<string> data)
        {
            List<string> resultList = new List<string>
            {
                new ResponseMaker().ToString()
            };
            resultList.AddRange(data);
            return resultList;
        }

        public static List<string> GenerateObjectListResponse<T>(IList<T> data, bool stripHeader = false)
        {
            List<string> resultList = new List<string>(); 
            if (!stripHeader)
            {
                resultList.Add(new ResponseMaker().ToString());
            }
            for (int i = 0; i < data.Count; i++)
            {
                string objJson = ConvertJson.ObjectToJson(data[i]);
                resultList.Add(objJson);
            }
            return resultList;
        }

        public static List<string> GenerateEncryptedObjectListResponse<T>(IList<T> data)
        {
            List<string> resultList = new List<string>
            {
                new ResponseMaker().ToString()
            };
            for (int i = 0; i < data.Count; i++)
            {
                string objJson = ConvertJson.ObjectToJson(data[i]);
                resultList.Add(objJson);
            }
            return resultList;
        }

        public static List<string> GenerateEmptyResponse()
        {
            List<string> resultList = new List<string>
            {
                new ResponseMaker(0, "No Data").ToString()
            };
            return resultList;
        }

        /*
        public static List<string> GenerateErrorResponse(string description)
        {
            List<string> resultList = new List<string>
            {
                new ResponseType(-600, description).ToString()
            };
            return resultList;
        }*/

        public static List<string> GenerateErrorResponse(Exception exception)
        {
            string description = exception.Message ?? "";
            if (exception.InnerException != null) description += " InnerException:" + exception.InnerException?.Message;
            List<string> resultList = new List<string>
            {
                new ResponseMaker(-600, description).ToString()
            };
            return resultList;
        }

        public static List<string> GenerateCustomErrorResponse(int resultCode, string description)
        {
            List<string> resultList = new List<string>
            {
                new ResponseMaker(resultCode, description).ToString()
            };
            return resultList;
        }

        public static List<string> GenerateNotLoginResponse()
        {
            List<string> resultList = new List<string>
            {
                new ResponseMaker(-500, "Not logged in").ToString()
            };
            return resultList;
        }

        public static List<string> GeneratePermissionDeniedResponse()
        {
            List<string> resultList = new List<string>
            {
                new ResponseMaker(-510, "Permission Denied").ToString()
            };
            return resultList;
        }
    }
}
