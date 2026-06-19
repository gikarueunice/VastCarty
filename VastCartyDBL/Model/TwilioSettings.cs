using System;

namespace VastCartyDBL.Model
{
    public class TwilioSettings
    {
        public string AccountSid { get; set; } = string.Empty;
        public string AuthToken { get; set; } = string.Empty;
        public string FromPhoneNumber { get; set; } = string.Empty;
        public string MessagingServiceSid { get; set; } = string.Empty;
    }
}
