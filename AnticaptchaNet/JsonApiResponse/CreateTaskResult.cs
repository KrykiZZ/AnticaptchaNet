using Newtonsoft.Json;

namespace AnticaptchaNet.JsonApiResponse
{
    public class CreateTaskResult : AnticaptchaJsonResponse
    {
        [JsonProperty(PropertyName = "taskId")]
        public int TaskId;
    }
}
