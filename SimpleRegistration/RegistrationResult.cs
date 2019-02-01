using System.Collections.Generic;

namespace SimpleRegistration
{
    public class RegistrationResult
    {
        public RegistrationResult()
        {
            Success = true;
            Errors = new List<string>();
        }
        public bool Success { get; internal set; }
        public List<string> Errors { get; internal set; }
    }
}