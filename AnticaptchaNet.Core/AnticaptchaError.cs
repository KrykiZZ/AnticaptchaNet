using System;

namespace AnticaptchaNet
{
    [Serializable]
    public class AnticaptchaError : Exception
    {
        public int Id { get; private set; }
        public string Code { get; private set; }
        public string Description { get; private set; }

        public AnticaptchaError(int errorId, string errorCode, string errorDescription)
        {
            Id = errorId;
            Code = errorCode;
            Description = errorDescription;
        }
    }
}
