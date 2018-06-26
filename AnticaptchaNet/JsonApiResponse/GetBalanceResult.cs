using Newtonsoft.Json;

namespace AnticaptchaNet.JsonApiResponse
{
    public class BalanceResult : AnticaptchaJsonResponse
    {
        /// <summary>
        /// User's current balance.
        /// </summary>
        [JsonProperty(PropertyName = "balance")]
        public float Balance;
    }
}
