using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Utilities.Encryption;
using Utilities.Json;

namespace Utilities.Net
{
    public class ApiResponse
    {
        public bool Status;
        public int StatusCode;
        public string Message;
        public int DataCount;
        public string Data;

        public ApiResponse(bool status, string data, int statusCode = 1, string message = null)
        {
            Status = status;
            StatusCode = statusCode;
            Data = data;
            DataCount = 0;
            if (statusCode > 0 && !string.IsNullOrEmpty(data)) DataCount = 1;
            if (message != null)
            {
                Message = message;
            }
            else
            {
                if (status) Message = "操作成功";
                else Message = "操作失败";
            }
        }

        public ApiResponse(bool status, int dataCount, string data, int statusCode = 1, string message = null)
        {
            Status = status;
            StatusCode = statusCode;
            Data = data;
            DataCount = dataCount;
            if (message != null)
            {
                Message = message;
            }
            else
            {
                if (status) Message = "操作成功";
                else Message = "操作失败";
            }
        }

        public ApiResponse()
        {
        }

        public override string ToString()
        {
            return ConvertJson.ObjectToJson(this);
        }

        public HttpResponseMessage ToResponseMessage()
        {
            return new HttpResponseMessage { Content = new StringContent(this.ToString(), Encoding.GetEncoding("UTF-8"), "application/json") };
        }

        public static HttpResponseMessage GenerateSimpleResponse(string content)
        {
            ApiResponse info = new ApiResponse(true, content);
            return info.ToResponseMessage();
        }

        public static HttpResponseMessage GenerateSimpleResponse<T>(T data)
        {
            ApiResponse info = new ApiResponse(true, data.ToString());
            return info.ToResponseMessage();
        }

        public static HttpResponseMessage GenerateObjectResponse(object data)
        {
            ApiResponse info = new ApiResponse(true, ConvertJson.ObjectToJson(data));
            return info.ToResponseMessage();
        }

        public static HttpResponseMessage GenerateObjectListResponse<T>(IList<T> data, int fullCount)
        {
            ApiResponse info = new ApiResponse(true, data.Count, ConvertJson.ListToJsonWithKey(data), fullCount);
            return info.ToResponseMessage();
        }

        public static HttpResponseMessage GenerateEncryptedObjectResponse<T>(T data, string key)
        {
            string dataJson = ConvertJson.ObjectToJson(data);
            string encJson = JRsaHelper.EncryptString(dataJson, key);
            ApiResponse info = new ApiResponse(true, encJson);
            return info.ToResponseMessage();
        }

        public static HttpResponseMessage GenerateEmptyResponse()
        {
            ApiResponse info = new ApiResponse(true, null, 0);
            return info.ToResponseMessage();
        }

        public static HttpResponseMessage GenerateErrorResponse(Exception exception)
        {
            string description = exception.Message ?? "";
            if (exception.InnerException != null) description += " InnerException:" + exception.InnerException?.Message;
            ApiResponse info = new ApiResponse(false, null, -500, description);
            return info.ToResponseMessage();
        }

        public static HttpResponseMessage GenerateCustomErrorResponse(int resultCode, string description)
        {
            ApiResponse info = new ApiResponse(false, null, resultCode, description);
            return info.ToResponseMessage();
        }

        public static HttpResponseMessage GenerateNotLoginResponse()
        {
            ApiResponse info = new ApiResponse(false, null, -401, "未登录");
            return info.ToResponseMessage();
        }

        public static HttpResponseMessage GenerateTokenExpireResponse()
        {
            ApiResponse info = new ApiResponse(false, null, -402, "Token已过期");
            return info.ToResponseMessage();
        }

        public static HttpResponseMessage GenerateWrongSignatureResponse()
        {
            ApiResponse info = new ApiResponse(false, null, -405, "Signature验证失败");
            return info.ToResponseMessage();
        }

        public static HttpResponseMessage GeneratePermissionDeniedResponse()
        {
            ApiResponse info = new ApiResponse(false, null, -410, "拒绝访问，权限不足");
            return info.ToResponseMessage();
        }

        public static HttpResponseMessage GenerateInvalidRequestResponse()
        {
            ApiResponse info = new ApiResponse(false, null, -440, "请求类型无效，只支持Post/Get方式");
            return info.ToResponseMessage();
        }
    }
}
