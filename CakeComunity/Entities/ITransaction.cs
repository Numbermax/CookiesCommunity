using System;
using System.Collections.Generic;

namespace CakeComunity.Entities
{
    interface ITransact
    {
        void Add(Transact transaction);
        Transact GetById(int id);
        ICollection<Transact> GetBySource(Guid source);
        ICollection<Transact> GetByTarget(Guid target);
    }
}