using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;

namespace Radma.Framework.Testing
{
    public static class HttpClientHelpers
    {
        public static async Task<HttpResponseMessage> CallGetAsync(TestServer webApp, string uri)
        {
            var client = webApp.CreateClient();
            var result = await client.GetAsync(uri);
            return result;
        }

        public static async Task<HttpResponseMessage> CallGetAsync(TestServer webApp, string token, string uri)
        {
            var client = CreateSecureClient(webApp, token);
            return await client.GetAsync(uri);
        }

        public static async Task<HttpResponseMessage> CallPostAsync(TestServer webApp, string uri, ByteArrayContent payload)
        {
            var client = webApp.CreateClient();
            return await client.PostAsync(uri, payload);
        }

        public static async Task<HttpResponseMessage> CallPostAsync(TestServer webApp, string token, string uri, ByteArrayContent payload)
        {
            var client = CreateSecureClient(webApp, token);
            return await client.PostAsync(uri, payload);
        }

        public static async Task<HttpResponseMessage> CallPutAsync(TestServer webApp, string token, string uri, ByteArrayContent payload)
        {
            var client = CreateSecureClient(webApp, token);
            return await client.PutAsync(uri, payload);
        }

        public static async Task<HttpResponseMessage> CallDeleteAsync(TestServer webApp, string token, string uri)
        {
            var client = CreateSecureClient(webApp, token);
            return await client.DeleteAsync(uri);
        }

        public static async Task<HttpResponseMessage> CallPatchAsync(TestServer webApp, string token, string uri)
        {
            var request = new HttpRequestMessage(new HttpMethod("PATCH"), uri);
            request.Headers.Add("Authorization", "Bearer " + token);
            var client = CreateSecureClient(webApp, token);
            return await client.SendAsync(request);
        }

        public static ByteArrayContent GeneratePayload(object data)
        {
            var jsonPayload = JsonConvert.SerializeObject(data);
            var buffer = Encoding.UTF8.GetBytes(jsonPayload);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return byteContent;
        }

        private static HttpClient CreateSecureClient(TestServer webApp, string token)
        {
            var client = webApp.CreateClient();
            var authorizationValue = new AuthenticationHeaderValue("Bearer", token);
            client.DefaultRequestHeaders.Authorization = authorizationValue;
            return client;
        }
    }
}