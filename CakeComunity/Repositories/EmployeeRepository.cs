using CakeComunity.Entities;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CakeComunity.Repositories
{
    class EmployeeRepository : IEmployee
    {
        public void Add(Employee employee)
        {
           using(ISession session = NHibernateHelper.OpenSession())
                using(ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(employee);
                    transaction.Commit();
                }
        }

        public void Edit(Employee employee)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Update(employee);
                transaction.Commit();
            }
        }

        public Employee GetById(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.Get<Employee>(id);
            }
        }
        public Employee ValidatePassword(string login, int pass)
        {
            var employee = GetByLogin(login);
            if (employee == null) return null;
            if (employee.Password == pass)
            {
                return employee;
            }
            return null;
        }
        public Employee GetByLogin(string login)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var employee = session
                      .CreateCriteria(typeof(Employee))
                      .Add(Restrictions.Eq("Login", login))
                      .UniqueResult<Employee>();
                return employee;
            }
        }
        public IEnumerable<Employee> GetAllActive()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var employees = session.Query<Employee>().Where(x => x.IsActive).ToList();
                      
                return employees;
            }
        }
        public IEnumerable<Employee> GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var employees = session.Query<Employee>().ToList();

                return employees;
            }
        }

    }
}
