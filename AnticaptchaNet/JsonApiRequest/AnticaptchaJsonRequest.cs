using Newtonsoft.Json;

namespace AnticaptchaNet.JsonApiRequest
{
    public abstract class AnticaptchaJsonRequest
    {
        [JsonProperty(PropertyName = "clientKey")]
        public string ClientKey { get; set; }
    }
}
