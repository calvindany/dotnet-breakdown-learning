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

    public class VaNumberObj
    {
        [JsonProperty("bank")]
        public string Bank { get; set; }

        [JsonProperty("va_number")]
        public string VANumber { get; set; }
    }

    public class MidtransTransactionStatusResponse
    {
        [JsonProperty("status_code")]
        public string StatusCode { get; set; }

        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }

        [JsonProperty("gross_amount")]
        public string GrossAmount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("order_id")]
        public string OrderId { get; set; }

        [JsonProperty("payment_type")]
        public string PaymentType { get; set; }

        [JsonProperty("signature_key")]
        public string SignatureKey { get; set; }

        [JsonProperty("transaction_status")]
        public string TransactionStatus { get; set; }

        [JsonProperty("fraud_status")]
        public string FraudStatus { get; set; }

        [JsonProperty("status_message")]
        public string StatusMessage { get; set; }

        [JsonProperty("merchant_id")]
        public string MerchantId { get; set; }

        [JsonProperty("va_numbers")]
        public List<VaNumberObj> VaNumbers { get; set; }

        [JsonProperty("payment_amounts")]
        public List<object> PaymentAmounts { get; set; }

        [JsonProperty("transaction_time")]
        public DateTime TransactionTime { get; set; }

        [JsonProperty("expiry_time")]
        public DateTime ExpiryTime { get; set; }
    }

}
