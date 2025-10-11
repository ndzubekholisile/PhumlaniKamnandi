
// ========== Employee ==========
using System;

namespace PhumlaniKamnandi.Business
{
    public class Employee
{
    public int EmpID { get; set; }
    public string Name { get; set; }
    public string Role { get; set; }       // generic role text
    public string Username { get; set; }
    public string Password { get; set; }

    public Employee() { }

    public Employee(string name, string role, string username, string password)
    {
        Name = name;
        Role = role;
        Username = username;
        Password = password;
    }

    #region Authentication Helper Methods
    
    /// <summary>
    /// Validates if the provided password matches this employee's password
    /// </summary>
    public bool ValidatePassword(string password)
    {
        if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(this.Password))
            return false;
            
        // Case-sensitive password comparison
        return this.Password == password;
    }

    /// <summary>
    /// Checks if the username matches (case-insensitive)
    /// </summary>
    public bool MatchesUsername(string username)
    {
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(this.Username))
            return false;
            
        return this.Username.Trim().Equals(username.Trim(), StringComparison.OrdinalIgnoreCase);
    }

    /// <summary>
    /// Checks if employee has a specific role
    /// </summary>
    public bool HasRole(string role)
    {
        if (string.IsNullOrWhiteSpace(role) || string.IsNullOrWhiteSpace(this.Role))
            return false;
            
        return this.Role.Trim().Equals(role.Trim(), StringComparison.OrdinalIgnoreCase);
    }

    /// <summary>
    /// Returns a safe display name (without sensitive information)
    /// </summary>
    public string GetDisplayName()
    {
        return string.IsNullOrWhiteSpace(Name) ? Username : Name;
    }

    #endregion
}

    }
