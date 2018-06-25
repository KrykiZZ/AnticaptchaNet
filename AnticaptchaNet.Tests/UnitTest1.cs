using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnticaptchaNet.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateAndUpload()
        {
            Anticaptcha anticaptcha = new Anticaptcha("YOUR_ANTICAPTCHA_KEY");

            int taskId = anticaptcha.CreateTask("captcha_filepath.jpg");

            var taskResult = new JsonApiResponse.AnticaptchaTaskResult();
            while (!taskResult.IsDone)
                taskResult = anticaptcha.GetTaskResult(taskId);

            string captchaSolution = taskResult.Solution.Text;
        }
    }
}
