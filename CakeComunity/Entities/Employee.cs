using System;
using System.Collections.Generic;
using System.Text;

namespace CakeComunity.Entities
{
    public class Employee
    {
        public virtual int Id { get; set; }
        public virtual string Login { get; set; }
        public virtual int Password { get; set; }
        public virtual string FullName { get; set; }
        public virtual DateTime CreateDate { get; set; }
        public virtual string WalletGuid { get; set; }
        public virtual bool IsAdmin { get; set; }
        public virtual bool IsActive { get; set; }
        public override string ToString()
        {
            return FullName;

        }
    }
}
