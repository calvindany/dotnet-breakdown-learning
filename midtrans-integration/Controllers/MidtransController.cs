using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using midtrans_integration.DTOs;
using midtrans_integration.Helper;

namespace midtrans_integration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MidtransController : ControllerBase
    {

        /**
         * POST
         * Create Transaction
         * Return Snap Token
         * 
         */
        [HttpPost]
        public async Task<IActionResult> CreateTransaction()
        {
            String path = "/snap/v1/transactions";
            String targetUrl = DotNetEnv.Env.GetString("MIDTRANS_URL");

            HttpRequestHeader requestHeader = new HttpRequestHeader()
            {
                BaseUrl = targetUrl,
                Route = path,
                BearerToken = DotNetEnv.Env.GetString("MIDTRANS_AUTH_KEY"),
                ServerKey = DotNetEnv.Env.GetString("MIDTRANS_SERVER_KEY"),
                MimeType = "application/json"
            };

            MidtransRequestBody requestBody = new MidtransRequestBody()
            {
                CustomerDetails = new CustomerDetailsObj()
                {
                    Email = "calvin@mail.com",
                    FirstName = "calvin",
                    LastName = "danyalson",
                    Phone = "0819182777"
                },
                TransactionDetails = new TransactionDetailsObj()
                {
                    GrossAmmount = 20000,
                    OrderId = Guid.NewGuid().ToString(),
                }
            };

            MidtransResponse? result = await HttpHelper.PostRequest<MidtransResponse>(requestHeader, requestBody);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetTransactionStatus(String OrderID)
        {
            String path = $"/v2/{OrderID}/status";
            String baseUrl = DotNetEnv.Env.GetString("MIDTRANS_URL");

            HttpRequestHeader requestHeader = new HttpRequestHeader()
            {
                BaseUrl = baseUrl,
                Route = path,
                BearerToken = DotNetEnv.Env.GetString("MIDTRANS_AUTH_KEY"),
                ServerKey = DotNetEnv.Env.GetString("MIDTRANS_SERVER_KEY"),
                MimeType = "application/json"
            };

            MidtransTransactionStatusResponse result = await HttpHelper.GetRequest< MidtransTransactionStatusResponse>(requestHeader);

            return Ok(result);
        }
    }
}
