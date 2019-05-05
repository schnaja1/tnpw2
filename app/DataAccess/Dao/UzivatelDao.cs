using DataAccess.Model;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;


namespace DataAccess.Dao
{
    public class UzivatelDao : DaoBase<Uzivatel>
    {
  

        public Uzivatel GetByLoginAndPassword(string login, string password)
        {
          Uzivatel u = session.CreateCriteria<Uzivatel>()
                 .Add(Restrictions.Eq("login", login))
                 .Add(Restrictions.Eq("heslo", password))
                 .UniqueResult<Uzivatel>();
            return u;
        }

        public Uzivatel GetByLogin(string login)
        {
            return session.CreateCriteria<Uzivatel>()
                 .Add(Restrictions.Eq("login", login))
                 .UniqueResult<Uzivatel>();
        }

        public void Insert(string heslo, string jmeno, string prijmeni, string login, int prava, bool novinka, string telefon, int psc, int cp, string mesto, string ulice) {
           session.CreateSQLQuery("EXEC UzivatelVloz @heslo='" + heslo + "', @jmeno='" + jmeno + "', @prijmeni='" + prijmeni + "', @login='" + login + "', @prava='" + prava + "', @novinka='" + novinka + "', @telefon='" + telefon + "', @psc='" + psc + "', @cp='" + cp + "', @mesto='" + mesto + "', @ulice='" + ulice + "';").ExecuteUpdate();
        }

        public IList<Uzivatel> GetUsersPaged(int count, int page, out int totalUsers)
        {
            totalUsers = session.CreateCriteria<Uzivatel>()
                .SetProjection(Projections.RowCount())
                .UniqueResult<int>();

            return session.CreateCriteria<Uzivatel>()
                .AddOrder(Order.Asc("login"))
                .SetFirstResult((page - 1) * count)
                .SetMaxResults(count)
                .List<Uzivatel>();

        }

        public IList<Uzivatel> SearchByLogin(string login)
        {
            return session.CreateCriteria<Uzivatel>()
                .Add(Restrictions.Like("login", string.Format("%{0}%", login))).List<Uzivatel>();
        }

        public IList<Uzivatel> GetUsersWithNews()
        {
            return session.CreateCriteria<Uzivatel>()
                .Add(Restrictions.Like("novinky", true)).List<Uzivatel>();
        }

        public IList<Uzivatel> GetUsersNotInRole(UzivatelskaPrava pravo)
        {
            return session.CreateCriteria<Uzivatel>()
                .Add(Restrictions.Not(Restrictions.Like("prava", pravo))).List<Uzivatel>();
        }

    }
}