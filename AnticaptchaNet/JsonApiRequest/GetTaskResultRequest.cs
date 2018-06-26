using Newtonsoft.Json;

namespace AnticaptchaNet.JsonApiRequest
{
    public class GetTaskResultRequest : AnticaptchaJsonRequest
    {
        /// <summary>
        /// Numeric identificator for created captcha task. 
        /// </summary>
        [JsonProperty(PropertyName = "taskId")]
        public int TaskId { get; set; }
    }
}
