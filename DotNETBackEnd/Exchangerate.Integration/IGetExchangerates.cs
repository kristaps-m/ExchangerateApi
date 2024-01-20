using Exchangerate.Classes.Models;
using Refit;

namespace Exchangerate.Integration
{
    public interface IGetExchangerates
    {
        // End point to get direct result from 2 currencies and amount!
        [Get("/v6/{apiKey}/pair/{cFrom}/{cTo}/{amount}")]
        Task<ExchangeResultFromCurrenciesAndAmount> GetExchangeResultByCurrenciesAndAmount(string apiKey, string cFrom, string cTo, double amount);

        // End point to search all currencies by currency!
        [Get("/v6/{apiKey}/latest/{currency}")]
        Task<ExchangerateResult> GetExchangeratesByCurrency(string apiKey, string currency);
    }
}
