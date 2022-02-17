using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace TransferWiseClient
{
    public class ApiHttpClient
    {
        private HttpClient Client { get; }

        string baseUrl = "https://api.sandbox.transferwise.tech";
        string token = "add your api token here";

        public ApiHttpClient()
        {
            Client = new HttpClient { BaseAddress = new Uri(baseUrl) };
        }

        public async Task<HttpResponseMessage> SendAsync<T>(T request, string endpoint, HttpMethod method)
        {
            var httpRequest = ApiHttpRequestMessage.CreateHttpRequest(
                method,
                $"{baseUrl}/{endpoint}",
                token,
                request);

            var response = await Client.SendAsync(httpRequest);

            await TraceRequestWithBody(request, httpRequest, response);

            response.EnsureSuccessStatusCode();

            return response;
        }

        public async Task<HttpResponseMessage> SendAsync(string endpoint, HttpMethod method)
        {
            var httpRequest = ApiHttpRequestMessage.CreateHttpRequest(
                method,
                $"{baseUrl}/{endpoint}",
                token);

            var response = await Client.SendAsync(httpRequest);

            await TraceRequest(httpRequest, response);

            response.EnsureSuccessStatusCode();

            return response;
        }

        public static async Task<T> GetAsAsync<T>(HttpContent content)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var data = await content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<T>(data, options);
        }

        private async Task TraceRequestWithBody<T>(T request, HttpRequestMessage httpRequest, HttpResponseMessage response)
        {
            Console.WriteLine($"Request Body:\n\t{JsonConvert.SerializeObject(request)}\n");
            await TraceRequest(httpRequest, response);
        }

        private async Task TraceRequest(HttpRequestMessage httpRequest, HttpResponseMessage response)
        {
            Console.WriteLine($"Request:\n\t{JsonConvert.SerializeObject(httpRequest.RequestUri)}");
            Console.WriteLine($"Response:\n\t{response.StatusCode}");
            Console.WriteLine($"Response Body:\n\t{await response.Content.ReadAsStringAsync()}");
        }
    }
}