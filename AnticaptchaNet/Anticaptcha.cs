using System;
using JsonRequest;
using Newtonsoft.Json;
using AnticaptchaNet.JsonApiRequest;
using AnticaptchaNet.JsonApiResponse;

namespace AnticaptchaNet
{
    /// <summary>
    /// An instance of Anticaptcha API wrapper.
    /// </summary>
    public class Anticaptcha
    {
        /// <summary>
        /// Handles JSON POST requests.
        /// </summary>
        protected Request RequestWorker = new Request();

        /// <summary>
        /// User's Anticaptcha API key from settings.
        /// </summary>
        protected string AnticaptchaKey { get; private set; }

        /// <summary>
        /// Get user's current balance.
        /// </summary>
        public float Balance { get => GetBalance(); }

        /// <summary>
        /// Create an instance of Anticaptcha API wrapper.
        /// </summary>
        /// <param name="anticaptchaKey">User's anticaptcha API key from settings.</param>
        public Anticaptcha(string anticaptchaKey)
        {
            AnticaptchaKey = anticaptchaKey;
        }

        /// <summary>
        /// Get anticaptcha balance.
        /// </summary>
        /// <returns>Returns anticaptcha balance.</returns>
        protected float GetBalance()
        {
            var req = new GetBalance { ClientKey = AnticaptchaKey };

            var reqJson = JsonConvert.SerializeObject(req);
            var response = (BalanceResult) RequestWorker.Execute<BalanceResult>(ApiMethodUrl.GetBalance, reqJson, "POST");

            if (response.ErrorId != 0)
                throw new AnticaptchaError(response.ErrorId, response.ErrorCode, response.ErrorDescription);
            
            return response.Balance;
        }

        /// <summary>
        /// Submit new task.
        /// </summary>
        /// <param name="captchaTask">Captcha task of any type.</param>
        /// <returns>Id of the created task.</returns>
        public int CreateTask(JsonCaptchaTask.ICaptchaTask captchaTask)
        {
            var req = new CreateTaskRequest
            {
                ClientKey = AnticaptchaKey,
                CaptchaTask = captchaTask
            };

            var reqJson = JsonConvert.SerializeObject(req);
            var response = (CreateTaskResult)RequestWorker.Execute<CreateTaskResult>(ApiMethodUrl.CreateTask, reqJson, "POST");

            if (response.ErrorId != 0)
                throw new AnticaptchaError(response.ErrorId, response.ErrorCode, response.ErrorDescription);

            return response.TaskId;
        }

        /// <summary>
        /// Submit task by image file path from your computer.
        /// </summary>
        /// <param name="filePath">Image file path.</param>
        /// <returns>Id of the created task.</returns>
        public int CreateTask(string filePath) => CreateTask(new JsonCaptchaTask.ImageToTextTask(filePath));

        /// <summary>
        /// Submit task by URI of the captcha image.
        /// </summary>
        /// <param name="uri">URI of the captcha image.</param>
        /// <returns>Id of the created task.</returns>
        public int CreateTask(Uri uri) => CreateTask(new JsonCaptchaTask.ImageToTextTask(uri));

        /// <summary>
        /// Get task result by its id.
        /// </summary>
        /// <param name="taskId">Id of the task.</param>
        /// <returns>AnticaptchaTaskResult object.</returns>
        public AnticaptchaTaskResult GetTaskResult(int taskId)
        {
            var req = new GetTaskResultRequest
            {
                ClientKey = AnticaptchaKey,
                TaskId = taskId
            };

            var reqJson = JsonConvert.SerializeObject(req);
            var taskResult = (AnticaptchaTaskResult)RequestWorker.Execute<AnticaptchaTaskResult>(ApiMethodUrl.GetTaskResult, reqJson, "POST");

            if (taskResult.ErrorId != 0)
                throw new AnticaptchaError(taskResult.ErrorId, taskResult.ErrorCode, taskResult.ErrorDescription);

            return taskResult;
        }
    }
}
