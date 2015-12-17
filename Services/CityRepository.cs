//-----------------------------------------------------------------------
// Репозиторий города.
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
    public class CityRepository : BaseRepository, IDbModelRepository
    {
        private BookMarketDbContext db;
        private SqlConnection conn;

        public CityRepository() : base() {
            db = new BookMarketDbContext();
        }

        public ModelToModel GetAll()
        {
            ModelToModel mm;

            mm = new ModelToModel();
            mm.cities = new List<City>();
            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
                foreach (var entry in db.GetAllCities())
                    mm.cities.Add(entry);
            //}
            return mm;
        }

        public object Add(object item)
        {
            City city = (City)item;

            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
            return db.AddCity(city.Name);
            //}

            //return GetAll().cities.Last();
        }

        public object FindById(Int32 id)
        {
            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
                var items = db.FindCityById(id);
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
                foreach (var entry in db.GetCityNames())
                    names.Add(entry);
            //}
            return names;
        }

        public List<SelectListItem> GetSelectItemList(
            IList<City> values
            )
        {
            Int32 i = 0;
            List<SelectListItem> items;
            IEnumerable<SelectListItem> selectList;

            items = new List<SelectListItem>();
            foreach (City value in values)
            {
                items.Add(new SelectListItem
                {
                    Value = Convert.ToString(value.Id),
                    Text = value.Name
                });
                i++;
            }
            return items;
        }

    }
}