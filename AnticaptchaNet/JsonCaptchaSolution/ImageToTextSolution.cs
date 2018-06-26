using Newtonsoft.Json;

namespace AnticaptchaNet.JsonCaptchaSolution
{
    public class ImageToTextSolution : CaptchaSolution
    {
        /// <summary>
        /// Image captcha solution.
        /// </summary>
        [JsonProperty(PropertyName = "text")]
        public string Text;

        [JsonProperty(PropertyName = "url")]
        public string Url;
    }
}
