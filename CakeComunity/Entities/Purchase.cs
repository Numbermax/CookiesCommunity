using System;
using System.Collections.Generic;
using System.Text;

namespace CakeComunity.Entities
{
    class Purchase 
    {
        public virtual int Id { get; set; }
        public virtual float Cost { get; set; }
        public virtual string Comment { get; set; }
        public virtual int CountEmployees { get; set; }
        public virtual DateTime CreateDate { get; set; }
        public virtual int EmployeeId { get; set; }
    }
}
