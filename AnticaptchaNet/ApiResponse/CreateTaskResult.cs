using Newtonsoft.Json;

namespace AnticaptchaNet.ApiResponse
{
    public class CreateTaskResult : AnticaptchaResponse
    {
        /// <summary>
        /// Id of the created task.
        /// </summary>
        [JsonProperty(PropertyName = "taskId")]
        public int TaskId;
    }
}
