using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using VastCartyDBL.Model;

namespace VastCartyDBL.Services
{
    public class EmailServices : IEmailServices
    {
        private readonly EmailSettings _emailSettings;
        private readonly ILogger<EmailServices> _logger;
        private string _connectionString;

        public EmailServices(
            IOptions<EmailSettings> emailSettings,
            ILogger<EmailServices> logger)
        {
            _emailSettings = emailSettings.Value;
            _logger = logger;

        }

        public async Task SendEmailAsync(string to, string subject, string body, bool isHtml = true)
        {
            try
            {
                // Validate email settings
                if (string.IsNullOrEmpty(_emailSettings.SmtpServer))
                    throw new InvalidOperationException("SMTP server is not configured");

                if (string.IsNullOrEmpty(_emailSettings.SenderEmail))
                    throw new InvalidOperationException("Sender email is not configured");

                using var client = new SmtpClient(_emailSettings.SmtpServer, _emailSettings.SmtpPort)
                {
                    EnableSsl = _emailSettings.EnableSsl,
                    UseDefaultCredentials = _emailSettings.UseDefaultCredentials,
                    Credentials = string.IsNullOrEmpty(_emailSettings.Username)
                        ? null
                        : new NetworkCredential(_emailSettings.Username, _emailSettings.Password)
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_emailSettings.SenderEmail, _emailSettings.SenderName),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = isHtml
                };
                mailMessage.To.Add(to);

                await client.SendMailAsync(mailMessage);
                _logger.LogInformation("Email sent successfully to {Email}", to);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send email to {Email}", to);
                throw;
            }
        }

        public async Task SendVerificationEmailAsync(string to, string verificationLink, string userName)
        {
            var subject = "Verify Your Email Address - FitTrack";
            var body = GetVerificationEmailTemplate(userName, verificationLink);
            await SendEmailAsync(to, subject, body);
        }

        public async Task SendPasswordResetEmailAsync(string to, string resetLink, string userName)
        {
            var subject = "Reset Your Password - FitTrack";
            var body = GetPasswordResetEmailTemplate(userName, resetLink);
            await SendEmailAsync(to, subject, body);
        }
        public Task SendOTPEmailAsync(string to, string otp, string purpose)
        {
            var subject = $"Your {purpose} OTP - FitTrack";
            var body = $@"
            <!DOCTYPE html>
            <html>
            <head><meta charset='UTF-8'></head>
            <body style='font-family: Arial, sans-serif;'>
                <div style='max-width: 600px; margin: 0 auto; padding: 20px;'>
                    <h2 style='color: #4F46E5;'>Your OTP Code</h2>
                    <p>Your One-Time Password (OTP) for <strong>{purpose}</strong> is:</p>
                    <div style='text-align: center; margin: 30px 0;'>
                        <div style='font-size: 32px; font-weight: bold; letter-spacing: 5px; background: #F3F4F6; padding: 20px; border-radius: 10px;'>
                            {otp}
                        </div>
                    </div>
                    <p>This code is valid for <strong>10 minutes</strong>.</p>
                    <p style='color: #EF4444;'>⚠️ Never share this code with anyone, including FitTrack support.</p>
                </div>
            </body>
            </html>";
            return SendEmailAsync(to, subject, body);
        }
        public Task Send2FADisableEmailAsync(string to, string userName)
        {
            var subject = "Two-Factor Authentication Disabled - FitTrack";
            var body = $@"
            <!DOCTYPE html>
            <html>
            <head><meta charset='UTF-8'></head>
            <body style='font-family: Arial, sans-serif;'>
                <div style='max-width: 600px; margin: 0 auto; padding: 20px;'>
                    <h2 style='color: #4F46E5;'>2FA Disabled</h2>
                    <p>Hi <strong>{userName}</strong>,</p>
                    <p>Two-Factor Authentication has been disabled on your account.</p>
                    <p>If you didn't make this change, please contact support immediately.</p>
                </div>
            </body>
            </html>";
            return SendEmailAsync(to, subject, body);
        }

       

    }
}