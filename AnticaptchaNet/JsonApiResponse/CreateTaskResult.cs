using Newtonsoft.Json;

namespace AnticaptchaNet.JsonApiResponse
{
    public class CreateTaskResult : AnticaptchaJsonResponse
    {
        /// <summary>
        /// Id of the created task.
        /// </summary>
        [JsonProperty(PropertyName = "taskId")]
        public int TaskId;
    }
}
