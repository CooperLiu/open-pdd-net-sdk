using Newtonsoft.Json;

namespace PddOpenSdk.Models.Response
{
    /// <summary>
    /// 拼多多请求模型
    /// </summary>
    public partial class PddResponseModel
    {
        [JsonProperty("error_response")]
        public ErrorResponseModel ErrorResponse { get; set; }
        public partial class ErrorResponseModel
        {
            [JsonProperty("sub_msg")]
            public string SubMsg { get; set; }

            [JsonProperty("sub_code")]
            public string SubCode { get; set; }
            /// <summary>
            /// 错误代码
            /// </summary>
            [JsonProperty("error_code")]
            public long? ErrorCode { get; set; }
            /// <summary>
            /// 错误参数
            /// </summary>
            [JsonProperty("error_msg")]
            public string ErrorMsg { get; set; }

            [JsonProperty("request_id")]
            public string RequestId { get; set; }
        }
    }
}
