using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnticaptchaNet.Tests
{
    [TestClass]
    public class OtherApiMethods
    {
        private Anticaptcha Api { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            this.Api = new Anticaptcha(File.ReadAllText("anticaptcha_key.txt"));
        }

        [TestMethod]
        public void GetBalance()
        {
            float balance = this.Api.GetBalance();
        }
    }
}
