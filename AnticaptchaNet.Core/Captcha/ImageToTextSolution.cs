namespace AnticaptchaNet.Captcha
{
    public class ImageToTextSolution : CaptchaSolution
    {
        /// <summary>
        /// Image captcha solution.
        /// </summary>
        public string Text { get; protected set; }
        
        public string Url { get; protected set; }

        public ImageToTextSolution(string text, string url)
        {
            this.Text = text;
            this.Url = url;
        }
    }
}
