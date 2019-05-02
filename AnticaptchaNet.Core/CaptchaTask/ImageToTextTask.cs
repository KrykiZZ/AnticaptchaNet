using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace AnticaptchaNet.CaptchaTask
{
    /// <summary>
    /// Usual image to text captcha task.
    /// </summary>
    public class ImageToTextTask : ICaptchaTask
    {
        /// <summary>
        /// Task type.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type => "ImageToTextTask";

        /// <summary>
        /// Image file base64 encoded.
        /// </summary>
        [JsonProperty(PropertyName = "body")]
        public string ImageBase64;

        /// <summary>
        /// Create task from image file path.
        /// </summary>
        /// <param name="filePath">Image file path.</param>
        public ImageToTextTask(string filePath)
        {
            this.ImageBase64 = Convert.ToBase64String(File.ReadAllBytes(filePath));
        }

        /// <summary>
        /// Create task from image URI.
        /// <para>Downloads the image (without saving) and encodes it.</para>
        /// </summary>
        /// <param name="imageUri">Image URI.</param>
        public ImageToTextTask(Uri imageUri)
        {
            using (var wc = new WebClient())
                this.ImageBase64 = Convert.ToBase64String(wc.DownloadData(imageUri));
        }

        #region Optional Fields

        /// <summary>
        /// Optional. Tells anticaptcha if current task contains spaces.
        /// </summary>
        [JsonProperty(PropertyName = "phrase")]
        public bool WillContainSpaces;

        /// <summary>
        /// Optional. 
        /// <para>Tells anticaptcha if current task contains math equation.</para>
        /// </summary>
        [JsonProperty(PropertyName = "math")]
        public bool WillContainMath;

        /// <summary>
        /// Optional. 
        /// <para>Use <code>enum SymbolicContent</code> to set this property.</para>
        /// </summary>
        [JsonProperty(PropertyName = "numeric")]
        public int Numeric;

        /// <summary>
        /// Optional.
        /// <para>Tells anticaptcha if current task is case sensitive.</para>
        /// </summary>
        [JsonProperty(PropertyName = "case")]
        public bool CaseSensitive;

        /// <summary>
        /// Optional.
        /// <para>Minimal response length.</para>
        /// </summary>
        [JsonProperty(PropertyName = "minLength")]
        public int MinResponseLength; // 0..20 min resp length

        /// <summary>
        /// Optional.
        /// <para>Maximum response length.</para>
        /// </summary>
        [JsonProperty(PropertyName = "maxLength")]
        public int MaxResponseLength; // 0..20 max resp length

        #endregion
        
    }

    /// <summary>
    /// Type of the content.
    /// </summary>
    enum SymbolicContent
    {
        All = 0,
        OnlyDigits = 1,
        OnlyChars = 2
    }
}
