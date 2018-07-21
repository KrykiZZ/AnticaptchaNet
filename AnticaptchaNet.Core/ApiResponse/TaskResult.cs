using AnticaptchaNet.Captcha;
using Newtonsoft.Json.Linq;
using System;


namespace AnticaptchaNet.ApiResponse
{
    public class TaskResult : AnticaptchaResponse
    {
        public bool IsDone => (Status == "ready");

        /// <summary>
        /// Use IsDone property to check whether your task has solution.
        /// </summary>
        public string Status { get; protected set; }
        
        public CaptchaSolution Solution { get; protected set; }
        
        public double Cost { get; protected set; }
        
        public string TaskCreatorIp { get; protected set; }
        
        public int CreateTime { get; protected set; }
        
        public int EndTime { get; protected set; }
        
        public int SolveCount { get; protected set; }

        protected TaskResult()
        {

        }

        public static TaskResult FromJson(string json)
        {
            var jt = JToken.Parse(json);

            var taskResult = new TaskResult
            {
                Status =  (string) jt["status"],
                ErrorId = (int)    jt["errorId"]
            };

            if (taskResult.ErrorId != 0)
            {
                taskResult.ErrorCode = (string)jt["errorCode"];
                taskResult.ErrorDescription = (string)jt["errorDescription"];
                return taskResult;
            }

            if (taskResult.Status == "processing")
                return taskResult;

            taskResult.Cost          = (double) jt["cost"];
            taskResult.TaskCreatorIp = (string) jt["ip"];
            taskResult.CreateTime    = (int)    jt["createTime"];
            taskResult.EndTime       = (int)    jt["endTime"];
            taskResult.SolveCount    = (int)    jt["solveCount"];

            var solution = jt["solution"];
            if (solution == null) return taskResult;

            string solutionType = "None";

            if (solution["text"] != null)                    solutionType = nameof(ImageToTextSolution);
            else if (solution["gRecaptchaResponse"] != null) solutionType = "NoCaptchaSolution";
            else if (solution["token"] != null)              solutionType = "FunCaptchaSolution";
            else if (solution["cellNumbers"] != null)        solutionType = "SquareNetTextSolution";
            else if (solution["challenge"] != null)          solutionType = "GeeTaskSolution";

            switch (solutionType)
            {
                case nameof(ImageToTextSolution):
                    taskResult.Solution = new ImageToTextSolution
                    (
                        Text: (string)solution["text"],
                        Url: (string)solution["url"]
                    );

                    break;

                // case...
                // ...

                default:
                    throw new NotImplementedException($"Type {solutionType} is not implemented yet.");
            }

            return taskResult;
        }
    }
}
