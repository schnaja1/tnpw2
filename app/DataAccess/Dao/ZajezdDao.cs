using DataAccess.Model;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dao
{
    public class ZajezdDao : DaoBase<Zajezd>
    {
        public void Insert(double cena, DateTime od, DateTime doo, int kapacita, int hotelID, string typ, string dopravce)
        {
            session.CreateSQLQuery("EXEC ZajezdVloz @cena='" + cena + "',  @od='" + od + "', @do='" + doo + "', @kapacita='" + kapacita + "', @hotelID='" + hotelID + "', @typ='" + typ + "', @dopravce='" + dopravce + "'");
        }


        public IList<Zajezd> GetByHotel(int id)
        {
            return session.CreateCriteria<Zajezd>()
               .Add(Restrictions.Eq("hotel.Id", id))
               .List<Zajezd>();
        }
    
        public int GetCountOfAllHotels()
        {
            return session.CreateCriteria<Zajezd>()
            .SetProjection(Projections.CountDistinct("hotel"))
               .UniqueResult<int>(); 
        }
  

        public IList<Hotel> GetHotelsIdPaged(int count, int page)
        {
            return session.CreateCriteria<Zajezd>() 
                              .SetProjection(Projections.GroupProperty("hotel"))
                              .AddOrder(Order.Asc(Projections.Min("cena")))
                              .SetFirstResult((page - 1) * count)
                              .SetMaxResults(count)
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
            return session.CreateCriteria<Zajezd>()
                      .Add(Restrictions.Ge("od", datumOd))
                           .SetProjection(Projections.GroupProperty("hotel"))
                              .AddOrder(Order.Asc(Projections.Min("cena")))
                              .SetFirstResult((page - 1) * count)
                              .SetMaxResults(count)
                              .List<Hotel>();
        }

        public int GetCountWithDateTo(DateTime datumDo)
        {
            return session.CreateCriteria<Zajezd>()
                   .SetProjection(Projections.CountDistinct("hotel"))
                   .Add(Restrictions.Le("doo", datumDo))
                   .UniqueResult<int>();
        }
        
        public IList<Hotel> GetZajezdyWithDateTo(int count, int page, DateTime datumDo)
        {
            return session.CreateCriteria<Zajezd>()
                    .Add(Restrictions.Le("doo", datumDo))
                     .SetProjection(Projections.GroupProperty("hotel"))
                              .AddOrder(Order.Asc(Projections.Min("cena")))
                              .SetFirstResult((page - 1) * count)
                              .SetMaxResults(count)
                              .List<Hotel>();
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
            return session.CreateCriteria<Zajezd>()
                       .Add(Restrictions.Ge("od", datumOd))                       
                       .Add(Restrictions.Le("doo", datumDo))
                       .SetProjection(Projections.GroupProperty("hotel"))                             
                       .AddOrder(Order.Asc(Projections.Min("cena")))                              
                       .SetFirstResult((page - 1) * count)                            
                       .SetMaxResults(count)                             
                       .List<Hotel>();
        }

        public Zajezd GetNejlevnejsiZajezd(int id)
        {
            return session.CreateCriteria<Zajezd>()
                .AddOrder(Order.Asc("cena"))
                .Add(Restrictions.Eq("hotel.Id", id))
                .List<Zajezd>().FirstOrDefault<Zajezd>();
        }

    }
}