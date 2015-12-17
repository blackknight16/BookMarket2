using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookMarket.DbInfrastructure;
using BookMarket.Models;

namespace BookMarket.Services
{
    public class WebmoneyRepository : IDbModelRepository
    {
        //private BookMarketDbContext _db = BookMarketDbContext._db;

        public ModelToModel GetAll()
        {
            ModelToModel mm;

            mm = new ModelToModel();
            /*var query = (from item in this._db.WebMoneys
                         orderby item.Id ascending 
                         select item);
            mm.webmoneys = query != null ? query.ToList<WebMoney>() : null;*/
            mm.webmoneys = new List<WebMoney>();
            using (BookMarketDbContext db = new BookMarketDbContext())
            {
                foreach (var entry in db.GetAllWebmoneys())
                    mm.webmoneys.Add(entry);
            }
            return mm;
        }

        public object Add(object item)
        {
            WebMoney webmoney = (WebMoney)item;

            /*this._db.WebMoneys.Add(webmoney);
            this._db.SaveChanges();*/
            using (BookMarketDbContext db = new BookMarketDbContext())
            {
                db.AddWebMoney(webmoney.WMR, webmoney.IndividualId);
            }
            return GetAll().webmoneys.Last();
        }

        public object FindById(Int32 id)
        {
            //var item = this._db.WebMoneys.Find(id);
            using (BookMarketDbContext db = new BookMarketDbContext())
            {
                var items = db.FindWebmoneyById(id);
                var item = items.FirstOrDefault();
                return item;
            }
        }

        public IList<string> GetNames()
        {
            return null;
        }


    }
}