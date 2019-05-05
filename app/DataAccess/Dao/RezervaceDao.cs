using DataAccess.Model;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dao
{
    public class RezervaceDao : DaoBase<Rezervace>
    {
       

        public IList<Rezervace> GetByUser(int id)
        {
                return session.CreateCriteria<Rezervace>()
                   .Add(Restrictions.Eq("uzivatel.Id", id))
                   .List<Rezervace>();         
        }

        public IList<Rezervace> GetByZajezd(int id)
        {
            return session.CreateCriteria<Rezervace>()
               .Add(Restrictions.Eq("zajezd.Id", id))
               .List<Rezervace>();
        }


    }
}
