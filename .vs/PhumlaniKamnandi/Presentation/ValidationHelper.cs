using System;
using System.Text.RegularExpressions;

namespace PhumlaniKamnandi.Presentation.Infrastructure
{
    public static class ValidationHelper
    {
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            
            try
            {
                var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
                return regex.IsMatch(email);
            }
            catch
            {
                return false;
            }
        }

        public static bool IsValidPhoneNumber(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone)) return false;
            
            // Remove all non-digit characters
            var digitsOnly = Regex.Replace(phone, @"[^\d]", "");
            
            // Check if it's between 10-15 digits
            return digitsOnly.Length >= 10 && digitsOnly.Length <= 15;
        }

        public static bool IsValidPostalCode(string postalCode)
        {
            if (string.IsNullOrWhiteSpace(postalCode)) return false;
            
            // Basic validation - adjust based on your country's postal code format
            return postalCode.Length >= 3 && postalCode.Length <= 10;
        }

        public static bool IsValidName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return false;
            
            // Name should contain only letters, spaces, hyphens, and apostrophes
            var regex = new Regex(@"^[a-zA-Z\s\-']+$");
            return regex.IsMatch(name) && name.Trim().Length >= 2;
        }

        public static bool IsValidDateRange(DateTime startDate, DateTime endDate)
        {
            return startDate < endDate && startDate >= DateTime.Today;
        }

        public static string SanitizeInput(string input)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;
            
            // Remove potentially dangerous characters
            return Regex.Replace(input.Trim(), @"[<>""'%;()&+]", "");
        }

        public static bool IsValidUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username)) return false;
            
            // Username: 3-50 characters, alphanumeric, dots, underscores
            var regex = new Regex(@"^[a-zA-Z0-9._]{3,50}$");
            return regex.IsMatch(username);
        }

        public static bool IsStrongPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password)) return false;
            
            // At least 8 characters, contains uppercase, lowercase, digit, and special character
            return password.Length >= 8 &&
                   Regex.IsMatch(password, @"[A-Z]") &&
                   Regex.IsMatch(password, @"[a-z]") &&
                   Regex.IsMatch(password, @"\d") &&
                   Regex.IsMatch(password, @"[!@#$%^&*(),.?""{}|<>]");
        }
    }
}