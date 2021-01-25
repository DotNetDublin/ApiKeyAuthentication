using System;

namespace ApiKeyAuthentication.Shared
{
    public class UserActivity
    {
        public int Id { get; }
        public string EmailAddress { get; }
        public string Activity { get; }
        public string IpAddress { get; }
        public DateTime Date { get; }
    }
}
