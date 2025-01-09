using Newtonsoft.Json;

namespace midtrans_integration.DTOs
{
    public class MidtransDto
    {
        public class MidtransSnapToken
        {
            [JsonProperty("token")]
            public String token { get; set; }

            [JsonProperty("redirect_url")]
            public String redirect_url { get; set; }
        }
    }
}
