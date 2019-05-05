using DataAccess.Model;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dao
{
    public class HotelDao : DaoBase<Hotel>
    {
        public int GetCountOfAllHotels()
        {
           return session.CreateCriteria<Hotel>()
               .SetProjection(Projections.RowCount())
               .UniqueResult<int>();
        }
        public IList<Hotel> GetHotelsPaged(int count, int page)
        {
              return session.CreateCriteria<Hotel>()
                          .AddOrder(Order.Asc("nazev"))
                          .SetFirstResult((page - 1) * count)
                          .SetMaxResults(count)
                          .List<Hotel>();
        }

        public IList<Hotel> searchHotel(string phrase)
        {
            return session.CreateCriteria<Hotel>()
                .Add(Restrictions.Like("nazev", string.Format("%{0}%", phrase)))                
                .List<Hotel>();
        }

        public IList<Hotel> GetHotelsInDestination(int id)
        {
            return session.CreateCriteria<Hotel>()
                .CreateAlias("destinace", "d")
                .Add(Restrictions.Eq("d.Id", id))
                .List<Hotel>();
        }

        public IList<Hotel> GetHotelsInState(int id)
        {
            return session.CreateCriteria<Hotel>()
                .CreateAlias("destinace", "d")
                .Add(Restrictions.Eq("d.stat.Id", id))
                .List<Hotel>();
        }

        public int GetCountWithDateFrom(DateTime datumOd)
        {
            return session.CreateCriteria<Zajezd>()
                      .SetProjection(Projections.CountDistinct("hotel"))
                      .Add(Restrictions.Ge("od", datumOd))
                      .UniqueResult<int>();
        }
        public IList<Hotel> GetZajezdyWithDateFrom(int count, int page, DateTime datumOd)
        {
            IList<Hotel> hotels = session.CreateCriteria<Zajezd>()
                      .Add(Restrictions.Ge("od", datumOd))
                      .SetProjection(Projections.GroupProperty("hotel"))
                      .List<Hotel>();

            hotels = hotels.OrderBy(h => h.nazev).ToList();

            List<Hotel> pagedHotels = new List<Hotel>();
            for (int i = (page - 1) * count; i < page * count; i++)
                pagedHotels.Add(hotels[i]);

            return pagedHotels;
        }

        public int GetCountWithDateTo(DateTime datumDo)
        {
            return session.CreateCriteria<Zajezd>()
                    .SetProjection(Projections.CountDistinct("hotel"))
                    .Add(Restrictions.Ge("doo", datumDo))
                    .UniqueResult<int>();
        }

        public IList<Hotel> GetZajezdyWithDateTo(int count, int page, DateTime datumDo)
        { 
            IList<Hotel> hotels = session.CreateCriteria<Zajezd>()
                      .Add(Restrictions.Ge("doo", datumDo))
                      .SetProjection(Projections.GroupProperty("hotel"))
                      .List<Hotel>();

            hotels = hotels.OrderBy(h => h.nazev).ToList();

            List<Hotel> pagedHotels = new List<Hotel>();
            for (int i = (page - 1) * count; i < page * count; i++)
                pagedHotels.Add(hotels[i]);

            return pagedHotels;
        }

        public object searchHotelByNazev(string nazev)
        {
            throw new NotImplementedException();
        }

        public int GetCountWithDateFromAndTo(DateTime datumOd, DateTime datumDo)
        {
            return session.CreateCriteria<Zajezd>()
                .SetProjection(Projections.CountDistinct("hotel"))
                .Add(Restrictions.Ge("od", datumOd))
                .Add(Restrictions.Le("doo", datumDo))
                .UniqueResult<int>();
        }

        public IList<Hotel> GetZajezdyWithDateFromAndTo(int count, int page, DateTime datumOd, DateTime datumDo)
        {
           IList<Hotel> hotels = session.CreateCriteria<Zajezd>()
                     .Add(Restrictions.Ge("od", datumOd))
                     .Add(Restrictions.Le("doo", datumDo))
                     .SetProjection(Projections.GroupProperty("hotel"))
                     .List<Hotel>();

            hotels = hotels.OrderBy(h => h.nazev).ToList();

            List<Hotel> pagedHotels = new List<Hotel>();
            for (int i = (page - 1) * count; i < page * count; i++)
                pagedHotels.Add(hotels[i]);

            return pagedHotels;
        }

    }
}
