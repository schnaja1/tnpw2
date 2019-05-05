using DataAccess.Model;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dao
{
    public class StatDao : DaoBase<Stat>
    {
        public StatDao() : base()
        {

        }
        public Stat FindStat(string stat)
        {
            return session.CreateCriteria<Stat>()
                 .Add(Restrictions.Eq("jmeno", stat))
                 .UniqueResult<Stat>();
        }
    }
}
