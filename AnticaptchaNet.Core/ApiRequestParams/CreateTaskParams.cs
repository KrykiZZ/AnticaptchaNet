using AnticaptchaNet.CaptchaTask;
using Newtonsoft.Json;

namespace AnticaptchaNet.ApiRequestParams
{
    public class CreateTaskParams : RequestParams
    {
        [JsonProperty(PropertyName = "task")]
        public ICaptchaTask CaptchaTask;
        
        [JsonProperty(PropertyName = "softId")]
        public int SoftId { get; set; }          // appcenter id

        /// <summary>
        /// Workers pool language.
        /// "ru" / "en"
        /// </summary>
        [JsonProperty(PropertyName = "languagePool")]
        public string LanguagePool { get; set; }

        [JsonProperty(PropertyName = "callbackUrl")]
        public string CallbackUrl { get; set; }
    }
}
