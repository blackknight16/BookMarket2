//-----------------------------------------------------------------------
// Репозиторий переменной информации книги.
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
    public class BookVariableInfoRepository : BaseRepository, IDbModelRepository
    {
        private BookMarketDbContext db;
        private SqlConnection conn;

        public BookVariableInfoRepository() {
            db = new BookMarketDbContext();
        }

        public ModelToModel GetAll()
        {
            ModelToModel mm;

            mm = new ModelToModel();
            mm.bookVariableInfoes = new List<BookVariableInfo>();
            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
                foreach (var entry in db.GetAllBookVariableInfoes())
                    mm.bookVariableInfoes.Add(entry);
            //}
            return mm;
        }

        public object Add(object item)
        {
            BookVariableInfo bookVariableInfo = (BookVariableInfo)item;

            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
            return db.AddBookVariableInfo(bookVariableInfo.Id,
                    bookVariableInfo.ProductCount, bookVariableInfo.Price).First<BookVariableInfo>();
            //}
            //return GetAll().bookVariableInfoes.Last();

        }

        public object FindById(Int32 id)
        {
            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
                var items = db.FindBookVariableInfoById(id);
                var item = items.FirstOrDefault();
                return item;
            //}
        }

        //Нк использую
        public IList<string> GetNames()
        {
            return null;
        }

        //BookVariableInfo и Book связь 1:1
        public BookVariableInfo FindByBookId(Int32 id)
        {
            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
                var items = db.FindBookVariableInfoByBookId(id);
                var item = items.FirstOrDefault<BookVariableInfo>();
                return item;
            //}
        }

        public void Edit(BookVariableInfo bookVariableInfo)
        {
            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
                db.EditBookVariableInfo(bookVariableInfo.Id,
                    bookVariableInfo.ProductCount, bookVariableInfo.Price);
            //}
        }

    }
}