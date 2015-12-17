//-----------------------------------------------------------------------
// Репозиторий издателя.
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
    public class PublisherRepository : BaseRepository, IDbModelRepository
    {
        private BookMarketDbContext db;
        private SqlConnection conn;

        public PublisherRepository() : base() {
            db = new BookMarketDbContext();
        }

        public ModelToModel GetAll()
        {
            ModelToModel mm;

            mm = new ModelToModel();
            mm.publishers = new List<Publisher>();
            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
                foreach (var entry in db.GetAllPublishers())
                    mm.publishers.Add(entry);
            //}
            return mm;
        }

        public object Add(object item)
        {
            Publisher publisher = (Publisher)item;

            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
            return db.AddPublisher(publisher.Name).First<Publisher>();
            //}
            //return GetAll().publishers.Last();
        }

        public object FindById(Int32 id)
        {
            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
                var items = db.FindPublisherById(id);
                var item = items.FirstOrDefault();
                return item;
            //}
        }

        public Publisher FindByName(string name)
        {
            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
                var items = db.FindPublisherByName(name);
                var item = items.FirstOrDefault<Publisher>();
                return item;
            //}
        }

        public IList<Publisher> FindAllByBook(Int32 bookId)
        {
            IList<Publisher> items;

            items = new List<Publisher>();
            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
                foreach (var entry in db.FindPublishersByBook(bookId))
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
                foreach (var entry in db.GetPublisherNames())
                    names.Add(entry);
            //}
            return names;
        }

    }
}