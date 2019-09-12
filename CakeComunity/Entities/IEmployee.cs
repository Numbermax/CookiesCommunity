using System;
using System.Collections.Generic;

namespace CakeComunity.Entities
{
    public interface IEmployee
    {
        void Add(Employee employee);
        void Edit(Employee employee);
        Employee GetById(int id);
        IEnumerable<Employee> GetAllActive();
        IEnumerable<Employee> GetAll();

    }
}