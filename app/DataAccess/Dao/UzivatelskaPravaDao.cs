using DataAccess.Model;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dao
{
    public class UzivatelskaPravaDao : DaoBase<UzivatelskaPrava>
    {
        public UzivatelskaPravaDao() : base()
        { }

        public UzivatelskaPrava FindPrava(int id)
        {
            return session.CreateCriteria<UzivatelskaPrava>()
                 .Add(Restrictions.Eq("Id", id))
                 .UniqueResult<UzivatelskaPrava>();
        }
    }
    
}
