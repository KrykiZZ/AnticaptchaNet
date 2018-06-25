using Newtonsoft.Json;

namespace AnticaptchaNet.JsonCaptchaTask
{
    public interface ICaptchaTask
    {
        [JsonProperty(PropertyName = "type")]
        string Type { get; }
    }
}
