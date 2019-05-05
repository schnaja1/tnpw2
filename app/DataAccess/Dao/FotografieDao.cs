using DataAccess.Model;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dao
{
    public class FotografieDao : DaoBase<Fotografie>
    {
        public FotografieDao() : base()
        {

        }
        public IList<Fotografie> GetPhotosByHotelId(int id)
        {
            return session.CreateCriteria<Fotografie>()
                .CreateAlias("hotel", "h")
                .Add(Restrictions.Eq("h.Id", id))
                .List<Fotografie>();
        }
    }
}
