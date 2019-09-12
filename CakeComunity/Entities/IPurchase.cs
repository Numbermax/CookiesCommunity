using System;
using System.Collections.Generic;

namespace CakeComunity.Entities
{
    interface IPurchase
    {
        void Add(Purchase purchase);
        Purchase GetById(int id);
        ICollection<Purchase> GetByUserId(int userId);        

    }
}