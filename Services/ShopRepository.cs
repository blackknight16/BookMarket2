//-----------------------------------------------------------------------
// Репозиторий магазина.
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
    public class ShopRepository : BaseRepository, IDbModelRepository
    {
        private BookMarketDbContext db;
        private SqlConnection conn;

        public ShopRepository() : base() {
            db = new BookMarketDbContext();
        }

        public ModelToModel GetAll()
        {
            ModelToModel mm;

            mm = new ModelToModel();
            mm.shops = new List<Shop>();
            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
                foreach (var entry in db.GetAllShops())
                    mm.shops.Add(entry);
            //}
            return mm;
        }

        //не использую, поэтому null
        public object Add(object item)
        {
            return null;
        }

        public object FindById(Int32 id)
        {
            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
                var items = db.FindShopById(id);
                var item = items.FirstOrDefault();
                return item;
            //}
        }

        //Так как связь City и Address 1:1, то ищем адрес по Id Shop
        public IList<Shop> FindAllByCity(Int32 cityId)
        {
            IList<Shop> items;

            items = new List<Shop>();
            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
                foreach (var entry in db.FindAllShopsByCity(cityId))
                    items.Add(entry);
            //}
            return items;
        }

        public IList<string> GetNames()
        {
            List<string> names;

            names = new List<string>();
            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
                foreach (var entry in db.GetShopNames())
                    names.Add(entry);
            //}
            return names;
        }

        public List<SelectListItem> GetSelectItemList(
            IList<Shop> values
            )
        {
            Int32 i = 0;
            List<SelectListItem> items;
            IEnumerable<SelectListItem> selectList;

            items = new List<SelectListItem>();
            foreach (Shop value in values)
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