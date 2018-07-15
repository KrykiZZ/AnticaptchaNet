using Newtonsoft.Json;

namespace AnticaptchaNet.ApiResponse
{
    public class BalanceResult : AnticaptchaResponse
    {
        /// <summary>
        /// User's current balance.
        /// </summary>
        [JsonProperty(PropertyName = "balance")]
        public float Balance;
    }
}
