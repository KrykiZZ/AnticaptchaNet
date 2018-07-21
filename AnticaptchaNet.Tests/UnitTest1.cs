using AnticaptchaNet.ApiResponse;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Threading;

namespace AnticaptchaNet.Tests
{
    [TestClass]
    public class UnitTest1
    {
        Anticaptcha anticaptcha;

        public void Initialize()
        {
            anticaptcha = new Anticaptcha(File.ReadAllText("anticaptcha_key.txt"));
        }

        [TestMethod]
        public void ImageToTextTest()
        {
            Initialize();

            string actualCaptchaSolution = "sqc48";
            int taskId = anticaptcha.CreateTask($"captcha_{actualCaptchaSolution}.jpg");

            TaskResult taskResult = anticaptcha.GetTaskResult(taskId);

            while (!taskResult.IsDone)
            {
                Thread.Sleep(1000); // Wait for captcha solution.
                taskResult = anticaptcha.GetTaskResult(taskId);
            }

            string captchaSolution = ((Captcha.ImageToTextSolution)taskResult.Solution).Text;

            Assert.AreEqual(captchaSolution, actualCaptchaSolution);
        }
    }
}
