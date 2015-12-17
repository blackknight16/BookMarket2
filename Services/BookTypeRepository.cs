//-----------------------------------------------------------------------
// Репозиторий типа книги.
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookMarket.DbInfrastructure;
using BookMarket.Models;

namespace BookMarket.Services
{
    public class BookTypeRepository : BaseRepository, IDbModelRepository
    {
        private BookMarketDbContext db;
        private SqlConnection conn;

        public BookTypeRepository() : base() {
            db = new BookMarketDbContext();
        }

        public ModelToModel GetAll()
        {
            ModelToModel mm;

            mm = new ModelToModel();
            mm.bookTypes = new List<BookType>();
            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
                foreach (var entry in db.GetAllBookTypes())
                    mm.bookTypes.Add(entry);
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
                var items = db.FindBookTypeById(id);
                var item = items.FirstOrDefault();
                return item;
            //}
        }

        public IList<string> GetNames()
        {
            List<string> names;

            names = new List<string>();
            using (BookMarketDbContext db = new BookMarketDbContext())
            {
                foreach (var entry in db.GetBookTypeNames())
                    names.Add(entry);
            }

            return names;
        }

    }
}