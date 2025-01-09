using Newtonsoft.Json;
using midtrans_integration.DTOs;

namespace midtrans_integration.Helper
{
    public class HttpHelper
    {
        public static async Task<T?> PostRequest<T>(HttpRequestHeader header, object body)
        {
            var client = new HttpClient();

            var requestBody = JsonConvert.SerializeObject(body);

            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(header.MimeType));
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("basic", header.BearerToken);

            var content = new StringContent(requestBody, System.Text.Encoding.UTF8, "application/json");
            
            var response = await client.PostAsync(header.BaseUrl + header.Route, content);

            if(!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed Post To Midtrans");
            }

            String responseBody = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(responseBody);
        }
    }
}
