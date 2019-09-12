using CakeComunity.Entities;
using CakeComunity.Enums;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CakeComunity.Repositories
{
    class TransactRepository : ITransact
    {
        public void Add(Transact transact)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(transact);
                transaction.Commit();
            }
        }

        public Transact GetById(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.Get<Transact>(id);
            }
        }

        public ICollection<Transact> GetBySource(Guid sourse)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var transacts = session
                      .CreateCriteria(typeof(Purchase))
                      .Add(Restrictions.Eq("Source", sourse))
                      .List<Transact>();
                return transacts;
            }
        }
        public ICollection<Transact> GetByTarget(Guid target)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var transacts = session
                      .CreateCriteria(typeof(Purchase))
                      .Add(Restrictions.Eq("Target", target))
                      .List<Transact>();
                return transacts;
            }
        }
        public ICollection<Balance> GetBalancesByGuid(string guid)
        {

            using (ISession session = NHibernateHelper.OpenSession())
            {
                var employees = session.Query<Employee>().ToList();
                var debts = session.Query<Transact>()
                    .Where(s => s.Type == TypeEnum.Debt && s.Target == guid)
                    .GroupBy(x => new { x.Target, x.Source })
                    .Select(l => new Balance
                    {
                        Debtor = l.First().Target,
                        Creditor = l.First().Source,
                        Amount = l.Sum(c => c.Summ),
                        FullNameDebtor = ""
                    }).ToList(); ;

                foreach (Balance item in debts)
                {
                    item.FullNameDebtor = employees.Where(x => x.WalletGuid == item.Debtor)
                        .Select(x => x.FullName)
                        .FirstOrDefault();
                    item.FullNameCreditor = employees.Where(x => x.WalletGuid == item.Creditor)
                        .Select(x => x.FullName)
                        .FirstOrDefault();
                }
                var pays = session.Query<Transact>()
                    .Where(s => s.Type == TypeEnum.Pay)
                    .GroupBy(x => new { x.Source, x.Target })
                    .Select(l => new Balance
                    {
                        Debtor = l.First().Source,
                        Creditor = l.First().Target,
                        Amount = l.Sum(c => c.Summ)
                    });

                if (pays.Count() > 0)
                {
                    var payEmplo = pays.ToArray();
                    foreach (Balance item in debts)
                    {

                        item.Amount -= payEmplo.Where(x => x.Creditor == item.Creditor && x.Debtor == item.Debtor)
                             .Select(x => x.Amount).FirstOrDefault();

                    }

                }
                return debts.ToList();


            }


        }
        public ICollection<Balance> GetBalancesAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var employees = session.Query<Employee>().ToList();
                var debts = session.Query<Transact>()
                    .Where(s => s.Type == TypeEnum.Debt)
                    .GroupBy(x => new { x.Target, x.Source })
                    .Select(l => new Balance
                    {
                        Debtor = l.First().Target,
                        Creditor = l.First().Source,
                        Amount = l.Sum(c => c.Summ),
                        FullNameDebtor = ""
                    }).ToList(); ;

                foreach (Balance item in debts)
                {
                    item.FullNameDebtor = employees.Where(x => x.WalletGuid == item.Debtor)
                        .Select(x => x.FullName)
                        .FirstOrDefault();
                    item.FullNameCreditor = employees.Where(x => x.WalletGuid == item.Creditor)
                        .Select(x => x.FullName)
                        .FirstOrDefault();
                }
                var pays = session.Query<Transact>()
                    .Where(s => s.Type == TypeEnum.Pay)
                    .GroupBy(x => new { x.Source, x.Target })
                    .Select(l => new Balance
                    {
                        Debtor = l.First().Source,
                        Creditor = l.First().Target,
                        Amount = l.Sum(c => c.Summ)
                    });

                if (pays.Count() > 0)
                {

                    var payEmplo = pays.ToArray();
                    foreach (Balance item in debts)
                    {
                        
                        item.Amount -= payEmplo.Where(x => x.Creditor == item.Creditor && x.Debtor == item.Debtor)
                             .Select(x => x.Amount).FirstOrDefault();

                    }

                }
                return debts.ToList();


            }
        }
    }
}
