using System;
using System.Collections.Generic;
using System.Text;

namespace VastCartyDBL.Models
{
    public class Users
    {
        public int Id{ get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? PasswordHash { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public DateTime UpdatedAtUtc { get; set; }
        public DateTime? LastLoginAtUtc { get; set; }
        public DateTime? LastPasswordChangeUtc { get; set; }
        public bool? IsLocked { get; set; }
        public bool? IsActive { get; set; }
        public string? Role { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public string? Gender { get; set; }
        public required string PasswordResetToken { get; set; }
        public DateTime? PasswordResetTokenExpiry { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public string? TwoFactorSecret { get; set; }
        public string? LastLoginIn { get; set; }
        public string? EmailVerificationToken { get; set; }
        public bool IsEmailVerified { get; set; }
        public int LoginAttempts { get; set; }
        public bool IsPhoneVerified { get; set; }
    }
}
