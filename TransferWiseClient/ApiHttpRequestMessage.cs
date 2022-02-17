using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace TransferWiseClient
{
    public static class ApiHttpRequestMessage
    {
        private const string MediaTypeHeaderKey = "application/json";
        private const string AuthorizationHeaderKey = "Authorization";
       
        public static HttpRequestMessage CreateHttpRequest<T>(HttpMethod method, string url, string token, T value)
        {
            var content = new StringContent(JsonSerializer.Serialize(value), Encoding.UTF8, MediaTypeHeaderKey);
            
            var message = new HttpRequestMessage(method, url)
            {
                Content = content
            };

            message.AddHeaders(token);

            return message;
        }

        public static HttpRequestMessage CreateHttpRequest(HttpMethod method, string url, string token)
        {
            var message = new HttpRequestMessage(method, url);

            message.AddHeaders(token);

            return message;
        }

        public static HttpRequestMessage AddHeaders(this HttpRequestMessage request, string token)
        {
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaTypeHeaderKey));
            request.Headers.Add(AuthorizationHeaderKey, "Bearer " + token);
            return request;
        }
    }
}