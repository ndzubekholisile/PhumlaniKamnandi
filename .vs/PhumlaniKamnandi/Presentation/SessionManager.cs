using System;
using PhumlaniKamnandi.Business;

namespace PhumlaniKamnandi.Presentation.Infrastructure
{
    /// <summary>
    /// Manages user session state across the application
    /// </summary>
    public static class SessionManager
    {
        private const int SESSION_TIMEOUT_HOURS = 8;
        
        public static Employee CurrentUser { get; private set; }
        public static DateTime LoginTime { get; private set; }
        public static bool IsLoggedIn => CurrentUser != null;

        /// <summary>
        /// Starts a new session for the authenticated employee
        /// </summary>
        public static void StartSession(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee), "Cannot start session with null employee.");

            CurrentUser = employee;
            LoginTime = DateTime.Now;
        }

        /// <summary>
        /// Ends the current session and clears user data
        /// </summary>
        public static void EndSession()
        {
            CurrentUser = null;
            LoginTime = default(DateTime);
        }

        /// <summary>
        /// Checks if the current user has a specific role
        /// </summary>
        public static bool HasRole(string role)
        {
            return IsLoggedIn && CurrentUser.HasRole(role);
        }

        /// <summary>
        /// Checks if the current session is still valid (not expired)
        /// </summary>
        public static bool IsSessionValid()
        {
            if (!IsLoggedIn) return false;
            
            // Session expires after configured hours
            return DateTime.Now.Subtract(LoginTime).TotalHours < SESSION_TIMEOUT_HOURS;
        }

        /// <summary>
        /// Validates the current session and throws exception if invalid
        /// </summary>
        public static void ValidateSession()
        {
            if (!IsSessionValid())
            {
                EndSession();
                throw new UnauthorizedAccessException("Session has expired. Please log in again.");
            }
        }

        /// <summary>
        /// Gets the display name of the current user
        /// </summary>
        public static string GetCurrentUserDisplayName()
        {
            return IsLoggedIn ? CurrentUser.GetDisplayName() : "Guest";
        }

        /// <summary>
        /// Gets the remaining session time in minutes
        /// </summary>
        public static double GetRemainingSessionMinutes()
        {
            if (!IsLoggedIn) return 0;
            
            var elapsed = DateTime.Now.Subtract(LoginTime).TotalHours;
            var remaining = SESSION_TIMEOUT_HOURS - elapsed;
            return remaining > 0 ? remaining * 60 : 0;
        }

        /// <summary>
        /// Extends the current session (resets the login time)
        /// </summary>
        public static void ExtendSession()
        {
            if (IsLoggedIn)
            {
                LoginTime = DateTime.Now;
            }
        }
    }
}