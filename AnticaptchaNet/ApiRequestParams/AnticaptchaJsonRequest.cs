using Newtonsoft.Json;

namespace AnticaptchaNet.ApiRequestParams
{
    public abstract class RequestParams
    {
        /// <summary>
        /// Your anticaptcha client key.
        /// </summary>
        [JsonProperty(PropertyName = "clientKey")]
        public string ClientKey { get; set; }
    }
}
