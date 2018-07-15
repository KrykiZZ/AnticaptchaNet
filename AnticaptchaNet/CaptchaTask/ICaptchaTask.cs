using Newtonsoft.Json;

namespace AnticaptchaNet.CaptchaTask
{
    public interface ICaptchaTask
    {
        [JsonProperty(PropertyName = "type")]
        string Type { get; }
    }
}
