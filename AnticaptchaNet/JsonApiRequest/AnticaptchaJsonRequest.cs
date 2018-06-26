using Newtonsoft.Json;

namespace AnticaptchaNet.JsonApiRequest
{
    public abstract class AnticaptchaJsonRequest
    {
        /// <summary>
        /// Your anticaptcha client key.
        /// </summary>
        [JsonProperty(PropertyName = "clientKey")]
        public string ClientKey { get; set; }
    }
}
