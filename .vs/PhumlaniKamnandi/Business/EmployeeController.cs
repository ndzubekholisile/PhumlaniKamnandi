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
            employees = hotelDB.AllEmployees;
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
            int index = 0;
            bool found = (employees[index].EmpID == ID);
            int count = AllEmployees.Count;

            while (!(found) && (index < employees.Count - 1))
            {
                index++;
                found = (employees[index].EmpID == ID);
            }


            return AllEmployees[index];
        }

        private int FindIndex(Employee aEmployee)
        {
            int counter = 0;
            bool found = false;
            found = (aEmployee.EmpID == employees[counter].EmpID);
            while (!found && counter <= employees.Count)
            {
                counter++;
                found = (aEmployee.EmpID == employees[counter].EmpID);
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
        public Employee AuthenticateUser(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return null;

            return employees.FirstOrDefault(e => 
                e != null &&
                !string.IsNullOrEmpty(e.Username) &&
                e.Username.Trim().Equals(username.Trim(), StringComparison.OrdinalIgnoreCase) && 
                !string.IsNullOrEmpty(e.Password) &&
                e.Password == password);
        }

        public Employee FindByUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return null;

            return employees.FirstOrDefault(e => 
                e != null &&
                !string.IsNullOrEmpty(e.Username) &&
                e.Username.Trim().Equals(username.Trim(), StringComparison.OrdinalIgnoreCase));
        }
        #endregion
    }
}