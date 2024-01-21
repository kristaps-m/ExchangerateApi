
using Microsoft.Extensions.Configuration;

namespace ExchangerateApi.Classes
{
    public class EnvirometSettings : IApiKeyEnvirometSettings
    {
        public string ApiKey { get; }

        public EnvirometSettings(IConfiguration configuration)
        {
            ApiKey = configuration.GetSection("ApiSettings").GetValue<string>("ExchangeRatesApiKey");
        }
    }
}
