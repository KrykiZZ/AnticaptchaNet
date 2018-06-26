using Newtonsoft.Json;

namespace AnticaptchaNet.JsonApiResponse
{
    public abstract class AnticaptchaJsonResponse
    {
        /// <summary>
        /// <para>Error id.</para>
        /// <para>Error list: <see cref="https://anticaptcha.atlassian.net/wiki/spaces/API/pages/196679"/></para>
        /// </summary>
        [JsonProperty(PropertyName = "errorId")]
        public int ErrorId;

        /// <summary>
        /// Error name.
        /// </summary>
        [JsonProperty(PropertyName = "errorCode")]
        public string ErrorCode;

        /// <summary>
        /// Error description.
        /// </summary>
        [JsonProperty(PropertyName = "errorDescription")]
        public string ErrorDescription;
    }
}
