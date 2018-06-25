using Newtonsoft.Json;

namespace AnticaptchaNet.JsonCaptchaSolution
{
    public class ImageToTextSolution : CaptchaSolution
    {
        [JsonProperty(PropertyName = "text")]
        public string Text;

        [JsonProperty(PropertyName = "url")]
        public string Url;
    }
}
