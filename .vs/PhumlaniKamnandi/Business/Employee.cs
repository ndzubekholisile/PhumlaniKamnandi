
// ========== Employee ==========

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
}

    }
