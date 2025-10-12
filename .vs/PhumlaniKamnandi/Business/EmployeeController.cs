// ========== Employee Controller ==========
using System;
using PhumlaniKamnandi.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using PhumlaniKamnandi.Business;
using System.Linq;

namespace PhumlaniKamnandi.Business
{
    public class EmployeeController
    {
        #region Constructor
        public EmployeeController()
        {
            hotelDB = new HotelDB();
            employees = hotelDB.AllEmployees ?? new Collection<Employee>();
            
            // Debug: Show employee count
            System.Windows.Forms.MessageBox.Show($"Loaded {employees.Count} employees from database.", "Debug Info");
            
            // Debug: Show employee details if any exist
            if (employees.Count > 0)
            {
                var emp = employees[0];
                System.Windows.Forms.MessageBox.Show($"First employee: ID={emp.EmpID}, Name={emp.Name}, Username={emp.Username}, Role={emp.Role}", "Debug Info");
            }
        }
        #endregion

        #region Data Members
        HotelDB hotelDB;
        Collection<Employee> employees;
        #endregion

        #region Properties
        public Collection<Employee> AllEmployees
        {
            get
            {
                return employees;
            }
        }
        #endregion

        #region Database Communication
        public void DataMaintenance(Employee aEmployee, DB.DBOperation operation)
        {
            int index = 0;
            hotelDB.DataSetChange(new HotelDB.HotelObject(aEmployee), operation);

            switch (operation)
            {
                case DB.DBOperation.Add:
                    employees.Add(aEmployee);
                    break;
                case DB.DBOperation.Edit:
                    index = FindIndex(aEmployee);
                    employees[index] = aEmployee;
                    break;
                case DB.DBOperation.Delete:
                    index = FindIndex(aEmployee);
                    employees.RemoveAt(index);
                    break;
            }

        }

        public bool FinalizeChanges(Employee employee)
        {
            return hotelDB.UpdateDataSource(new HotelDB.HotelObject(employee));
        }
        #endregion

        #region Find Methods

        public Employee Find(int ID)
        {
            if (employees == null || employees.Count == 0)
                return null;

            int index = 0;
            bool found = (employees[index] != null && employees[index].EmpID == ID);
            int count = AllEmployees.Count;

            while (!(found) && (index < employees.Count - 1))
            {
                index++;
                found = (employees[index] != null && employees[index].EmpID == ID);
            }

            return found ? AllEmployees[index] : null;
        }

        private int FindIndex(Employee aEmployee)
        {
            if (employees == null || employees.Count == 0 || aEmployee == null)
                return -1;

            int counter = 0;
            bool found = false;
            found = (employees[counter] != null && aEmployee.EmpID == employees[counter].EmpID);
            while (!found && counter < employees.Count - 1)
            {
                counter++;
                found = (employees[counter] != null && aEmployee.EmpID == employees[counter].EmpID);
            }
            if (found)
            {
                return counter;
            }
            else
            {
                return -1;
            }
        }
        #endregion

        #region Authentication Methods
        
        /// <summary>
        /// Authenticates a user with username and password
        /// Returns the authenticated Employee object or null if authentication fails
        /// </summary>
        public Employee AuthenticateUser(string username, string password)
        {
            // Debug: Show authentication attempt
            System.Windows.Forms.MessageBox.Show($"Authentication attempt: Username='{username}', Password='{password}'", "Debug Info");
            
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                System.Windows.Forms.MessageBox.Show("Username or password is empty", "Debug Info");
                return null;
            }

            if (employees == null || employees.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show("No employees loaded from database", "Debug Info");
                return null;
            }

            // Find employee by username and validate password
            var employee = employees.FirstOrDefault(e => 
                e != null && e.MatchesUsername(username));

            if (employee == null)
            {
                System.Windows.Forms.MessageBox.Show($"No employee found with username '{username}'", "Debug Info");
                return null;
            }

            System.Windows.Forms.MessageBox.Show($"Found employee: Username='{employee.Username}', Password='{employee.Password}'", "Debug Info");

            if (employee.ValidatePassword(password))
            {
                System.Windows.Forms.MessageBox.Show("Password validation successful", "Debug Info");
                return employee;
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Password validation failed", "Debug Info");
                return null;
            }
        }

        /// <summary>
        /// Finds an employee by username (case-insensitive)
        /// </summary>
        public Employee FindByUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return null;

            if (employees == null || employees.Count == 0)
                return null;

            return employees.FirstOrDefault(e => 
                e != null && e.MatchesUsername(username));
        }

        /// <summary>
        /// Validates if a username exists in the system
        /// </summary>
        public bool UsernameExists(string username)
        {
            return FindByUsername(username) != null;
        }

        /// <summary>
        /// Gets all employees with a specific role
        /// </summary>
        public List<Employee> GetEmployeesByRole(string role)
        {
            if (employees == null || string.IsNullOrWhiteSpace(role))
                return new List<Employee>();

            return employees.Where(e => e != null && e.HasRole(role)).ToList();
        }

        /// <summary>
        /// Validates password strength (for future password change functionality)
        /// </summary>
        public bool ValidatePasswordStrength(string password, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(password))
            {
                errorMessage = "Password cannot be empty.";
                return false;
            }

            if (password.Length < 4)
            {
                errorMessage = "Password must be at least 4 characters long.";
                return false;
            }

            if (password.Length > 100)
            {
                errorMessage = "Password cannot exceed 100 characters.";
                return false;
            }

            return true;
        }

        /// <summary>
        /// Changes an employee's password (for future functionality)
        /// </summary>
        public bool ChangePassword(int empId, string oldPassword, string newPassword, out string errorMessage)
        {
            errorMessage = string.Empty;

            var employee = Find(empId);
            if (employee == null)
            {
                errorMessage = "Employee not found.";
                return false;
            }

            if (!employee.ValidatePassword(oldPassword))
            {
                errorMessage = "Current password is incorrect.";
                return false;
            }

            if (!ValidatePasswordStrength(newPassword, out errorMessage))
            {
                return false;
            }

            employee.Password = newPassword;
            DataMaintenance(employee, DB.DBOperation.Edit);
            return FinalizeChanges(employee);
        }

        #endregion
    }
}