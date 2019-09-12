using CakeComunity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CakeComunity.Entities
{
    class Transact
    {
        public virtual int Id { get; set; }
        public virtual DateTime CreateDate { get; set; }
        public virtual TypeEnum Type { get; set; }
        public virtual float Summ { get; set; }
        public virtual string Source { get; set; }
        public virtual string Target { get; set; }

    }
}
