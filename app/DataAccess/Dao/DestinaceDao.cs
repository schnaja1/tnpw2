using DataAccess.Model;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dao
{
    public class DestinaceDao : DaoBase<Destinace>
    {

        public IList<Destinace> GetDestinationByState(int id)
        {
            return session.CreateCriteria<Destinace>()
              
                .Add(Restrictions.Eq("stat.Id", id))
                .List<Destinace>();
        }

        public Destinace FindDestinace(string destinace)
        {
            return session.CreateCriteria<Destinace>()
                 .Add(Restrictions.Eq("nazev", destinace))
                 .UniqueResult<Destinace>();
        }




    }
}
