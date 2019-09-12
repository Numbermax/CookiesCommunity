using CakeComunity.Entities;
using CakeComunity.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeComunity.Logic
{
    public class Operations
    {
        public bool LogIn(string login, int password)
        {
            var employees = new EmployeeRepository();
            var autorisedUser = employees.ValidatePassword(login, password);
            if (autorisedUser != null)
            {
                Autorisation.LogIn(autorisedUser);
                return true;
            }
            return false;

        }

        public bool SigIn(string login, string fullName, int passHash)
        {
            EmployeeRepository user = new EmployeeRepository();

            user.Add(new Employee
            {
                Login = login,
                Password = passHash,
                FullName = fullName,
                CreateDate = DateTime.Now,
                IsAdmin = false,
                IsActive = true,
                WalletGuid = Guid.NewGuid().ToString()
            });
            return true;
        }
        public bool AddPayment(string payerGuid, string employeeGuid, float summ)
        {
            try
            {
                TransactRepository transacts = new TransactRepository();
                transacts.Add(new Transact
                {
                    CreateDate = DateTime.Now,
                    Type = Enums.TypeEnum.Pay,
                    Source = payerGuid,
                    Target = employeeGuid,
                    Summ = summ
                });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool AddPurchase(Employee employee, float summ, string purchase)
        {
            try
            {
                PurchaseRepository purchases = new PurchaseRepository();
                TransactRepository transacts = new TransactRepository();
                EmployeeRepository employees = new EmployeeRepository();

                var activeEmployees = employees.GetAllActive().Where(x=>x != employee);
                float shareSumm = summ / activeEmployees.Count();

                purchases.Add(new Purchase
                {
                    Comment = purchase,
                    Cost = summ,
                    CreateDate = DateTime.Now,
                    EmployeeId = employee.Id,
                    CountEmployees = activeEmployees.Count()
                });

                foreach (Employee item in activeEmployees)
                {
                    if (item.WalletGuid == employee.WalletGuid) continue;
                    transacts.Add(new Transact
                    {
                        CreateDate = DateTime.Now,
                        Type = Enums.TypeEnum.Debt,
                        Source = employee.WalletGuid,
                        Target = item.WalletGuid,
                        Summ = shareSumm
                    });
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
