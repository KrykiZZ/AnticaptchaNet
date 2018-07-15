using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

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

            //var taskResult = new JsonApiResponse.TaskResult();
            //throw new NotImplementedException();

            var taskResult = anticaptcha.GetTaskResult(taskId);

            while (!taskResult.IsDone)
                taskResult = anticaptcha.GetTaskResult(taskId);

            string captchaSolution = ((Captcha.ImageToTextSolution)taskResult.Solution).Text;

            Assert.AreEqual(captchaSolution, actualCaptchaSolution);
        }
    }
}
