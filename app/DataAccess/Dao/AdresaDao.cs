using DataAccess.Model;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dao
{
    public class AdresaDao : DaoBase<Adresa>
    {
        public AdresaDao() : base()
        {

        }
        public Adresa FindAdresa(string mesto, string ulice, int cp, PSC psc)
        {
            return session.CreateCriteria<Adresa>()
                 .Add(Restrictions.Eq("psc", psc))
                 .Add(Restrictions.Eq("mesto", mesto))
                 .Add(Restrictions.Eq("ulice", ulice))
                 .Add(Restrictions.Eq("cp", cp))
                 .UniqueResult<Adresa>();
        }


    }
}