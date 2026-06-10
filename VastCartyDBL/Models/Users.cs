using System;
using System.Collections.Generic;
using System.Text;

namespace VastCartyDBL.Models
{
    public class Users
    {
        public int{ get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime CreatedAt { get; set; }
        public string IsLocked { get; set; }
        public string IsActive { get; set; }
        public string Role { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string Gender { get; set; }
        public required string PasswordResetToken { get; set; }
        public DateTime? PasswordResetTokenExpiry { get; set; }
        public string TwoFactorEnabled { get; set; }
        public string TwoFactorSecret { get; set; }
        public string LastLoginIn { get; set; }
        public string EmailVerificationToken { get; set; }
    }
}
