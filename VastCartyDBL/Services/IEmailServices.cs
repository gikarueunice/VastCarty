using System;
using System.Collections.Generic;
using System.Text;

namespace VastCartyDBL.Services
{
    public interface IEmailServices
    {
        Task SendEmailAsync(string to, string subject, string body, bool isHtml = true);
        Task SendVerificationEmailAsync(string to, string verificationLink, string userName);
        Task SendPasswordResetEmailAsync(string to, string resetLink, string userName);
        Task SendEmailAsync(string to, string subject, string body);
        Task SendOTPEmailAsync(string to, string otp, string purpose);
        Task Send2FADisableEmailAsync(string to, string userName);
        Task SendRegistrationOTPAsync(string to, string otp, string userName);
        Task Send2FAEnableEmailAsync(string to, string userName, string backupCodes);
    }
}
