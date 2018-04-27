using DemoLinkedin.Common;
using DemoLinkedin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace DemoLinkedin.Helper
{
    public class ClientHelper
    {

        public static AuthCode GetAccessToken(string code)
        {
            var authCode = new AuthCode();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Consts.HOST_BASE_URL);
                client.DefaultRequestHeaders
                      .Accept
                      .Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header

                var request = new HttpRequestMessage(HttpMethod.Post, "oauth/v2/accessToken");
                var values = new Dictionary<string, string>
                {
                    { "code", code },
                    { "grant_type", "authorization_code" },
                    { "redirect_uri", Consts.REDIRECT_URI },
                    { "client_id", "77e8mfrek1rocm" },
                    { "client_secret", "gLGupqxdEDpOOIPT" },
                };
                request.Content = new FormUrlEncodedContent(values);

                string responseString = string.Empty;
                try
                {
                    var response = client.SendAsync(request).Result;

                    responseString = response.Content.ReadAsStringAsync().Result;

                    authCode = new JavaScriptSerializer().Deserialize<AuthCode>(responseString);

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception: {0}", ex);
                }

                return authCode;
            }
        }

        public static Profile GetLinkedinUserInfo(string accessToken)
        {
            Profile profile = new Profile();

            var requestUrl = "https://api.linkedin.com/v1/people/~?format=json";
            var url = "https://api.linkedin.com/";

            var client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders
                  .Accept
                  .Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header

            //client.DefaultRequestHeaders.Add("Content-Type", "application/json");
            client.DefaultRequestHeaders.Add("x-li-format", "json");
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");

            var request = new HttpRequestMessage(HttpMethod.Get, "v1/people/~?format=json");

            var values = new Dictionary<string, string>
            {
                {"Content-Type", "application/json" },
                {"x-li-format", "json" },
                {"Authorization", $"Bearer {accessToken}" },
            };

            //request.Content = new FormUrlEncodedContent(values);
            string responseString = string.Empty;
            try
            {
                var response = client.SendAsync(request).Result;

                responseString = response.Content.ReadAsStringAsync().Result;

                profile = new JavaScriptSerializer().Deserialize<Profile>(responseString);
            }
            catch (Exception ex)
            {
            }

            return profile;
        }

        public static T SendRequest<T>(ClientData clientData)
        {
            T result = default(T);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Consts.HOST_BASE_URL);
                client.DefaultRequestHeaders
                      .Accept
                      .Add(new MediaTypeWithQualityHeaderValue(clientData.Accept));//ACCEPT header
                client.DefaultRequestHeaders.Add("x-li-format", "json");
                if(!string.IsNullOrEmpty(clientData.AccessToken))
                {
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {clientData.AccessToken}");
                }

                var request = new HttpRequestMessage(clientData.Method, clientData.RelativeURL);
                if(clientData.PostData != null && clientData.PostData.Keys.Count > 0)
                {
                    request.Content = new FormUrlEncodedContent(clientData.PostData);
                }

                if(!string.IsNullOrEmpty(clientData.JsonPostData))
                {
                    request.Content = new StringContent(clientData.JsonPostData);
                }

                string responseString = string.Empty;
                try
                {
                    var response = client.SendAsync(request).Result;
                    responseString = response.Content.ReadAsStringAsync().Result;
                    result = new JavaScriptSerializer().Deserialize<T>(responseString);
                }
                catch (Exception ex)
                {
                    throw new Exception($"{responseString}{Environment.NewLine}{ex.ToString()}");
                }

                return result;
            }
        }
    }
}