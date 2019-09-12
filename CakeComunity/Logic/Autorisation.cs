using CakeComunity.Entities;
using CakeComunity.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeComunity.Logic
{
    public static class Autorisation
    {
        static Employee _employee = new Employee();
        public static void LogIn(Employee user)
        {
            _employee = user;
        }
        public static Employee GetAutorisedUser()
        {
            return _employee;
        }
        public static string GetName()
        {
            return _employee.FullName;
        }
        public static bool IsAdmin()
        {
            return _employee.IsAdmin;
        }
        public static int GetUserId()
        {
            return _employee.Id;
        }
        public static string GetUserWalletGuid()
        {
            return _employee.WalletGuid;
        }
        public static void SetActive(bool isActive)
        {
            _employee.IsActive = isActive;
           new EmployeeRepository().Edit(_employee);
        }
        public static string GetAutirisationDate()
        {
            return _employee.CreateDate.ToString("dd.MM.yyyy");
        }
        public static bool IsActive()
        {
            return _employee.IsActive;
        }
    }
}
