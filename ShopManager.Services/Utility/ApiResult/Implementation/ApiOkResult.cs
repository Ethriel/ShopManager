﻿namespace ShopManager.Services.Utility.ApiResult
{
    public class ApiOkResult : ApiResult, IApiOkResult
    {
        public object Data { get; set; }

        public ApiOkResult() { }

        public ApiOkResult(ApiResultStatus apiResultStatus = ApiResultStatus.Ok, string message = "Success", object data = null)
        {
            SetOkResult(apiResultStatus, message, data);
        }

        public void SetOkResult(ApiResultStatus apiResultStatus = ApiResultStatus.Ok, string message = "Success", object data = null)
        {
            ApiResultStatus = apiResultStatus;
            Data = data;
            Message = message;
        }
    }
}
