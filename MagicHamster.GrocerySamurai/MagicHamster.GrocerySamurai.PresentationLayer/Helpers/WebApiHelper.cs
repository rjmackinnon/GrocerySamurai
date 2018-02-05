namespace MagicHamster.GrocerySamurai.PresentationLayer.Helpers
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    public static class WebApiHelper
    {
        private static HttpClient _client;

        public static string WebApiBaseUrl { get; set; }

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

            set => _client = value;
        }

        public static void Init(HttpMessageHandler handler)
        {
            client = handler == null ? new HttpClient() : new HttpClient(handler);
            client.BaseAddress = new Uri(getAbsoluteWebApiUrl(string.Empty));
            client.Timeout = TimeSpan.FromMinutes(1);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Connection", "close");
        }

        public static Task<HttpResponseMessage> GetWebApiResponseAsHttpResponseMessage(string actionUrl)
        {
            return client.GetAsync(getAbsoluteWebApiUrl(actionUrl));
        }

        public static Task<HttpResponseMessage> PostWebApiResponseAsHttpResponseMessage(string actionUrl, object rawContent)
        {
            var content = new StringContent(JsonConvert.SerializeObject(rawContent), Encoding.UTF8, "application/json");

            return client.PostAsync(getAbsoluteWebApiUrl(actionUrl), content);
        }

        public static Task<HttpResponseMessage> PutWebApiResponseAsHttpResponseMessage(string actionUrl, object rawContent)
        {
            var content = new StringContent(JsonConvert.SerializeObject(rawContent), Encoding.UTF8, "application/json");

            return client.PutAsync(getAbsoluteWebApiUrl(actionUrl), content);
        }

        public static Task<HttpResponseMessage> DeleteWebApiResponseAsHttpResponseMessage(string actionUrl)
        {
            return client.DeleteAsync(getAbsoluteWebApiUrl(actionUrl));
        }

        private static string getAbsoluteWebApiUrl(string actionPath) =>
            WebApiBaseUrl == null ? $"http://localhost/{actionPath}" :
                String.Concat(
                    WebApiBaseUrl.EndsWith(@"/", StringComparison.CurrentCulture) ?
                    WebApiBaseUrl : String.Concat(WebApiBaseUrl, @"/"), actionPath.TrimStart('/'));
    }
}