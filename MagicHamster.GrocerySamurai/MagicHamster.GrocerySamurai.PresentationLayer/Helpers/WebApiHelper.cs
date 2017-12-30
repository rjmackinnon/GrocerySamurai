using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MagicHamster.GrocerySamurai.PresentationLayer.Helpers
{
    public static class WebApiHelper
    {
        private static HttpClient _client;

        private static HttpClient client
        {
            get
            {
                if (_client == null)
                {
                    Init(null);
                }
                return _client;
            }

            set
            {
                _client = value;
            }
        }

        public static string WebApiBaseUrl { get; set; }
        private static string getAbsoluteWebApiUrl(string actionPath) =>
            WebApiBaseUrl == null ? $"http://localhost/{actionPath}" :
                String.Concat(WebApiBaseUrl.EndsWith(@"/") ?
                     WebApiBaseUrl : String.Concat(WebApiBaseUrl, @"/"), actionPath.TrimStart('/'));

        public static void Init(HttpMessageHandler handler)
        {
            client = handler == null ? new HttpClient() : new HttpClient(handler);
            client.BaseAddress = new Uri(getAbsoluteWebApiUrl(""));
            client.Timeout = TimeSpan.FromMinutes(1);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Connection", "close"); 
        }

        public static async Task<HttpResponseMessage> GetWebApiResponseAsHttpResponseMessage(string actionUrl)
        {
            return await client.GetAsync(getAbsoluteWebApiUrl(actionUrl));
        }

        public static async Task<HttpResponseMessage> PostWebApiResponseAsHttpResponseMessage(string actionUrl, object rawContent)
        {
            var content = new StringContent(JsonConvert.SerializeObject(rawContent), Encoding.UTF8, "application/json");

            return await client.PostAsync(getAbsoluteWebApiUrl(actionUrl), content);
        }

        public static async Task<HttpResponseMessage> PutWebApiResponseAsHttpResponseMessage(string actionUrl, object rawContent)
        {
            var content = new StringContent(JsonConvert.SerializeObject(rawContent), Encoding.UTF8, "application/json");

            return await client.PutAsync(getAbsoluteWebApiUrl(actionUrl), content);
        }

        public static async Task<HttpResponseMessage> DeleteWebApiResponseAsHttpResponseMessage(string actionUrl)
        {
            return await client.DeleteAsync(getAbsoluteWebApiUrl(actionUrl));
        }
    }
}