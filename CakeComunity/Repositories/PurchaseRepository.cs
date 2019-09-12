using CakeComunity.Entities;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CakeComunity.Repositories
{
    class PurchaseRepository : IPurchase
    {
     

        public void Add(Purchase purchase)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(purchase);
                transaction.Commit();
            }
        }

        public Purchase GetById(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.Get<Purchase>(id);
            }
        }

        public ICollection<Purchase> GetByUserId(int userId)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var purchases = session
                      .CreateCriteria(typeof(Purchase))
                      .Add(Restrictions.Eq("UserId", userId))
                      .List<Purchase>();
                return purchases;
            }
        }
        public ICollection<Purchase> GetAll()
        {
            using(ISession session = NHibernateHelper.OpenSession())
            {
                return session.Query<Purchase>().ToList();
            }
        }
    }
}
