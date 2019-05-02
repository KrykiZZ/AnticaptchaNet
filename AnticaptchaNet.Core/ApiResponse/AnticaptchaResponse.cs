using Newtonsoft.Json;

namespace AnticaptchaNet.ApiResponse
{
    public abstract class AnticaptchaResponse
    {
        /// <summary>
        /// <para>Error id.</para>
        /// <para>Error list: <see cref="https://anticaptcha.atlassian.net/wiki/spaces/API/pages/196679"/></para>
        /// </summary>
        [JsonProperty(PropertyName = "errorId")]
        public int ErrorId { get; protected set; }

        /// <summary>
        /// Error name.
        /// </summary>
        [JsonProperty(PropertyName = "errorCode")]
        public string ErrorCode { get; protected set; }

        /// <summary>
        /// Error description.
        /// </summary>
        [JsonProperty(PropertyName = "errorDescription")]
        public string ErrorDescription { get; protected set; }


        public void ThrowExceptionIfError()
        {
            if (this.ErrorId != 0)
                throw new AnticaptchaError(this.ErrorId, this.ErrorCode, this.ErrorDescription);
        }
    }
}
