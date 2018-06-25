using Newtonsoft.Json;

namespace AnticaptchaNet.JsonApiRequest
{
    public class GetTaskResultRequest : AnticaptchaJsonRequest
    {
        [JsonProperty(PropertyName = "taskId")]
        public int TaskId { get; set; }
    }
}
