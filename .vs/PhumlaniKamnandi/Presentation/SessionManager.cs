using System;
using PhumlaniKamnandi.Business;

namespace PhumlaniKamnandi.Presentation.Infrastructure
{
    public static class SessionManager
    {
        public static Employee CurrentUser { get; set; }
        public static DateTime LoginTime { get; set; }
        public static bool IsLoggedIn => CurrentUser != null;

        public static void StartSession(Employee employee)
        {
            CurrentUser = employee;
            LoginTime = DateTime.Now;
        }

        public static void EndSession()
        {
            CurrentUser = null;
            LoginTime = default(DateTime);
        }

        public static bool HasRole(string role)
        {
            return IsLoggedIn && CurrentUser.Role.Equals(role, StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsSessionValid()
        {
            if (!IsLoggedIn) return false;
            
            // Session expires after 8 hours
            return DateTime.Now.Subtract(LoginTime).TotalHours < 8;
        }

        public static void ValidateSession()
        {
            if (!IsSessionValid())
            {
                EndSession();
                throw new UnauthorizedAccessException("Session has expired. Please log in again.");
            }
        }
    }
}