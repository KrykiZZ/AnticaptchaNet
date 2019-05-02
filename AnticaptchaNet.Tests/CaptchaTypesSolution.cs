using AnticaptchaNet.ApiResponse;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Threading;

namespace AnticaptchaNet.Tests
{
    [TestClass]
    public class CaptchaTypesSolution
    {
        private Anticaptcha Api { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            this.Api = new Anticaptcha(File.ReadAllText("anticaptcha_key.txt"));
        }

        [TestMethod]
        public void ImageToTextTest()
        {
            string actualCaptchaSolution = "sqc48";
            int taskId = this.Api.CreateTask( new Uri("https://pp.userapi.com/c855136/v855136500/33437/82tgZE48vDE.jpg") );

            TaskResult taskResult = this.Api.GetTaskResult(taskId);

            while (!taskResult.IsDone)
            {
                Thread.Sleep(500); // Wait for captcha solution.
                taskResult = this.Api.GetTaskResult(taskId);
            }

            string captchaSolution = ((Captcha.ImageToTextSolution)taskResult.Solution).Text;

            Assert.AreEqual(captchaSolution, actualCaptchaSolution);
        }
    }
}
