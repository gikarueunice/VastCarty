namespace VastCarty.Controllers
{
    [Serializable]
    internal class UserLockedException : Exception
    {
        public UserLockedException()
        {
        }

        public UserLockedException(string? message) : base(message)
        {
        }

        public UserLockedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}