using System.Text.Json.Serialization;

namespace Exchangerate.Classes.Models
{
    public class ExchangeResultFromCurrenciesAndAmount
    {
        public string Result { get; set; } = String.Empty;
        public string Documentation { get; set; } = String.Empty;
        [JsonPropertyName("terms_of_use")]
        public string TermsOfUse { get; set; } = String.Empty;
        [JsonPropertyName("time_last_update_unix")]
        public int TimeLastUpdateUnix { get; set; }
        [JsonPropertyName("time_last_update_utc")]
        public string TimeLastUpdateUtc { get; set; } = String.Empty;
        [JsonPropertyName("time_next_update_unix")]
        public int TimeNextUpdateUnix { get; set; }
        [JsonPropertyName("time_next_update_utc")]
        public string TimeNextUpdateUtc { get; set; } = String.Empty;
        [JsonPropertyName("base_code")]
        public string BaseCode { get; set; } = String.Empty;
        [JsonPropertyName("target_code")]
        public string TargetCode { get; set; } = String.Empty;
        [JsonPropertyName("conversion_rate")]
        public double ConversionRate { get; set; }
        [JsonPropertyName("conversion_result")]
        public double ConversionResult { get; set; }
    }
}
