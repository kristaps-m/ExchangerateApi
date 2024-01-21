using Exchangerate.Integration;
using Microsoft.AspNetCore.Mvc;

namespace ExchangerateApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeratesController : ControllerBase
    {
        private readonly IGetExchangerates _exchangerates;
        //private readonly IConfiguration _configuration;
        private readonly IApiKeyEnvirometSettings _apiKeyEnviromentSettings;

        public ExchangeratesController(IApiKeyEnvirometSettings apiKeyEnviromentSettings, IGetExchangerates exchangerates)
        {
            //_configuration = configuration;
            _exchangerates = exchangerates;
            _apiKeyEnviromentSettings = apiKeyEnviromentSettings;
        }

        [HttpGet]
        [Route("{currency}")]
        public async Task<IActionResult> GetExchangeratesByCurrency(string currency)
        {
            //var apiSettings = _configuration.GetSection("ApiSettings");
            //var apiKey = apiSettings.GetValue<string>("ExchangeRatesApiKey");
            var apiKey = _apiKeyEnviromentSettings.ApiKey;
            try
            {
                var result = await _exchangerates.GetExchangeratesByCurrency(apiKey, currency);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest($"There is no such currency '{currency.ToUpper()}' or make sure you spelled it correctly!"); ;
            }
        }

        [HttpGet]
        [Route("exchange")]
        public async Task<IActionResult> GetExchangeResultByCurrenciesAndAmount(string cFrom, string cTo, double amount)
        {
            //var apiSettings = _configuration.GetSection("ApiSettings");
            //var apiKey = apiSettings.GetValue<string>("ExchangeRatesApiKey");
            var apiKey = _apiKeyEnviromentSettings.ApiKey;
            try
            {
                var result = await _exchangerates.GetExchangeResultByCurrenciesAndAmount(apiKey, cFrom, cTo, amount);
                return Ok(result);

            }
            catch (Exception)
            {
                return BadRequest($"There is no such currency '{cFrom.ToUpper()}' OR '{cTo.ToUpper()}' or make sure you spelled it correctly!");
            }
        }
    }
}
