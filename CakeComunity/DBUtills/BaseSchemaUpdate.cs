using CakeComunity.Entities;
using CakeComunity.Repositories;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbWorks
{
    class BaseSchemaUpdate
    {
        //private ISessionFactory _sessionFactory;
        private Configuration _configuration;

        public void TextFixtureSetUp()
        {
            _configuration = new Configuration().Configure("hibernate.cfg.xml");
            _configuration.AddAssembly(typeof(Employee).Assembly);            
            //_sessionFactory = _configuration.BuildSessionFactory();

            new SchemaExport(_configuration).Execute(false, true, false);
            EmployeeRepository users = new EmployeeRepository();
            users.Add(new Employee
            {
                Login = "admin",
                Password = "admin".GetHashCode(),
                FullName = "Mr. Main Admin",
                CreateDate = DateTime.Now,
                IsAdmin = true,
                IsActive = true,
                WalletGuid = Guid.NewGuid().ToString()

            }); ;
            users.Add(new Employee
            {
                Login = "Ivan",
                Password = "Ivan".GetHashCode(),
                FullName = "Ivan Petrovich Plushkin",
                CreateDate = DateTime.Now,
                IsAdmin = false,
                IsActive = true,
                WalletGuid = Guid.NewGuid().ToString()

            });
            
        }
       
        public void SetupContext()
        {
            new SchemaExport(_configuration).Execute(false, true, false);


        }

    }
}
