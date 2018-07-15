using Newtonsoft.Json;

namespace AnticaptchaNet.ApiRequestParams
{
    public class GetTaskResultParams : RequestParams
    {
        /// <summary>
        /// Numeric identificator for created captcha task. 
        /// </summary>
        [JsonProperty(PropertyName = "taskId")]
        public int TaskId { get; set; }
    }
}
