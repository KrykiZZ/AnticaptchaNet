using Newtonsoft.Json;

namespace AnticaptchaNet.JsonApiResponse
{
    public class BalanceResult : AnticaptchaJsonResponse
    {
        [JsonProperty(PropertyName = "balance")]
        public float Balance;
    }
}
