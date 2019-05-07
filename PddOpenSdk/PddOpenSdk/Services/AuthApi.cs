using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PddOpenSdk.Models;

namespace PddOpenSdk.Services.PddApi
{
    public class AuthApi : PddCommonApi
    {
        /// <summary>
        /// access_token
        /// </summary>
        public static readonly string TokenUrl = "https://open-api.pinduoduo.com/oauth/token";
        /// <summary>
        /// 商家授权地址
        /// </summary>
        public static readonly string MmsURL = "https://mms.pinduoduo.com/open.html";
        /// <summary>
        /// 移动端授权地址
        /// </summary>
        public static readonly string MaiURL = "https://mai.pinduoduo.com/h5-login.html";
        /// <summary>
        /// 多多客授权地址
        /// </summary>
        public static readonly string DDKUrl = "https://jinbao.pinduoduo.com/open.html";


        public AuthApi() : base()
        {

        }

        public AuthApi(HttpClient httpClient) : base(httpClient)
        {
        }

        /// <summary>
        /// 获取Token请求
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        /// <param name="redirectUrl"></param>
        /// <param name="code"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public async Task<AccessTokenResponseModel> GetAccessTokenAsync(string appId, string appSecret, string redirectUrl, string code, string state = null)
        {
            if (string.IsNullOrEmpty(code))
            {
                throw new ArgumentNullException(nameof(code), "code is null");
            }
            var dic = new Dictionary<string, string>
            {
                { "client_id", appId },
                { "client_secret", appSecret },
                { "grant_type", "authorization_code" },
                { "code", code },
                { "redirect_uri", redirectUrl }
            };

            if (state != null)
            {
                dic.Add("state", state);
            }

            var data = new StringContent(JsonConvert.SerializeObject(dic), Encoding.UTF8, "application/json");
            var response = await ApiHttpClient.PostAsync(TokenUrl, data);
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<AccessTokenResponseModel>(jsonString);

            return result;
        }

        /// <summary>
        /// 获取网页授权地址
        /// </summary>
        /// <param name="callbackUrl"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public string GetWebOAuthUrl(string callbackUrl, string state = null)
        {
            string url = MmsURL + "?response_type=code&client_id=" + AppId + "&redirect_uri=" + callbackUrl;
            if (!string.IsNullOrEmpty(state))
            {
                url += "&state=" + state;
            }
            return url;
        }
        /// <summary>
        /// 获取移动网页授权地址
        /// </summary>
        /// <param name="callbackUrl"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public string GetH5OAuthUrl(string callbackUrl, string state = null)
        {
            string url = MaiURL + "?response_type=code&client_id=" + AppId + "&redirect_uri=" + callbackUrl + "&view=h5";
            if (!string.IsNullOrEmpty(state))
            {
                url += "&state=" + state;
            }
            return url;
        }

        /// <summary>
        /// 多多客授权
        /// </summary>
        /// <param name="redirectUrl"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public string GetDdkoAuthUrl(string redirectUrl, string state = null)
        {
            string url = DDKUrl + "?response_type=code&client_id=" + AppId + "&redirect_uri=" + redirectUrl;
            if (!string.IsNullOrEmpty(state))
            {
                url += "&state=" + state;
            }
            return url;
        }
    }
}
