using Newtonsoft.Json;

namespace AnticaptchaNet.JsonApiResponse
{
    public abstract class AnticaptchaJsonResponse
    {
        [JsonProperty(PropertyName = "errorId")]
        public int ErrorId;

        [JsonProperty(PropertyName = "errorCode")]
        public string ErrorCode;

        [JsonProperty(PropertyName = "errorDescription")]
        public string ErrorDescription;
    }
}
