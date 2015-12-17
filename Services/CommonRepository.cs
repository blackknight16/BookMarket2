//-----------------------------------------------------------------------
// Репозиторий общего назначения.
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
    public class CommonRepository : BaseRepository
    {
        private BookMarketDbContext db;
        private SqlConnection conn;

        public CommonRepository() : base() {
            db = new BookMarketDbContext();
        }

        public void AddBookTagBook(Int32 bookTag_Id, Int32 book_Id)
        {
            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
                db.AddBookTagBook(bookTag_Id, book_Id);
            //}
        }

        public void AddBookAuthor(Int32 book_Id, Int32 author_Id)
        {
            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
                db.AddBookAuthor(book_Id, author_Id);
            //}
        }

        public void AddPublisherBook(Int32 publisher_Id, Int32 book_Id)
        {
            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
                db.AddPublisherBook(publisher_Id, book_Id);
            //}
        }

    }
}