//-----------------------------------------------------------------------
// Репозиторий улицы.
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using BookMarket.DbInfrastructure;
using BookMarket.Models;

namespace BookMarket.Services
{
    public class StreetRepository : BaseRepository, IDbModelRepository
    {
        private BookMarketDbContext db;
        private SqlConnection conn;

        public StreetRepository()
            : base(){
            db = new BookMarketDbContext();
        }

        public ModelToModel GetAll()
        {
            ModelToModel mm;

            mm = new ModelToModel();

            mm.streets = new List<Street>();
            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
                foreach (Street entry in db.GetAllStreets())
                {
                    mm.streets.Add(entry);
                }
            //}
            return mm;
        }

        public object Add(object item)
        {
            return null;
        }

        public object FindById(Int32 id)
        {
            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
                var items = db.FindStreetById(id);
                var item = items.FirstOrDefault();
                return item;
            //}
        }

        public IList<string> GetNames()
        {
            List<string> names;

            names = new List<string>();
            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
                foreach (var entry in db.GetStreetNames())
                    names.Add(entry);
            //}
            return names;
        }

    }
}