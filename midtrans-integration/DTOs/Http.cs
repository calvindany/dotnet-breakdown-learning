using Newtonsoft.Json;

namespace midtrans_integration.DTOs
{
    public class HttpRequestHeader
    {
        public required String BaseUrl {  get; set; }
        public required String Route { get; set; }
        public String? BearerToken { get; set; }
        public String ServerKey { get; set; }
        public String MimeType { get; set; }
    }
    public class MidtransRequestBody
    {
        [JsonProperty("transaction_details")]
        public TransactionDetailsObj TransactionDetails { get; set; }

        [JsonProperty("customer_details")]
        public  CustomerDetailsObj CustomerDetails { get; set; }

    }

    public class TransactionDetailsObj
    {
        [JsonProperty("order_id")]
        public required String OrderId { get; set; }

        [JsonProperty("gross_amount")]
        public required Int128 GrossAmmount { get; set; }
    }

    public class CustomerDetailsObj
    {
        [JsonProperty("first_name")]
        public required String FirstName { get; set; }
        [JsonProperty("last_name")]
        public required String LastName { get; set; }
        [JsonProperty("email")]
        public required String Email { get; set; }
        [JsonProperty("phone")]
        public required String Phone { get; set; }
    }

    public class MidtransResponse
    {
        [JsonProperty("token")]
        public String token { get; set; }

        [JsonProperty("redirect_url")]
        public String redirect_url { get; set;}
    }

}
