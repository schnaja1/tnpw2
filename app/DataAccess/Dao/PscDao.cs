using DataAccess.Model;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dao
{
    public class PscDao : DaoBase<PSC>
    {
        public PscDao() : base()
        {
        }

        public PSC FindPsc(int psc)
        {
            return session.CreateCriteria<PSC>()
                 .Add(Restrictions.Eq("psc", psc))
                 .UniqueResult<PSC>();
        }

    
}
}