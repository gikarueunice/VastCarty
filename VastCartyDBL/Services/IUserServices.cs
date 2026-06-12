using System;
using System.Collections.Generic;
using System.Text;
using VastCartyDBL.Models;

namespace VastCartyDBL.Services
{
    public interface IUserServices
    {
        Task<Users?> GetUserByEmailAsync(string email);
        Task<Users?> GetUserByPhoneNumberAsync(string phoneNumber);
        Task<Users?> GetUserByVerificationTokenAsync(string token);
        Task<Users?> CreateUsersAsync(Users user);
        Task<Users?> UpdateUserAsync(Users user);
        Task<Users> DeleteUserAsync(int id);
        Task <Users> GetUsersByIdAsync(int id);
        Task<Users> GetUserByPhoneOTPAsync(string phoneNumber);
        Task<bool> HasExceededLoginAttemptsAsync(object id);
        Task<bool> IncrementLoginAttemptsAsync(object id);
        Task <bool> ResetLoginAttemptsAsync(object id);

    }
}
