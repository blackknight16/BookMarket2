//-----------------------------------------------------------------------
// Репозиторий тега книги.
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
    public class BookTagRepository : BaseRepository, IDbModelRepository
    {
        private BookMarketDbContext db;
        private SqlConnection conn;

        public BookTagRepository() : base() {
            db = new BookMarketDbContext();
        }

        public ModelToModel GetAll()
        {
            ModelToModel mm;

            mm = new ModelToModel();
            mm.bookTags = new List<BookTag>();
            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
                foreach (var entry in db.GetAllBookTags())
                    mm.bookTags.Add(entry);
            //}
            return mm;
        }

        public object Add(object item)
        {
            BookTag bookTag = (BookTag)item;

            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
            return db.AddBookTag(bookTag.Name, bookTag.BookTypeId);
            //}

            //return GetAll().bookTags.Last();
        }

        public object FindById(Int32 id)
        {
            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
                var items = db.FindBookTagById(id);
                var item = items.FirstOrDefault();
                return item;
            //}
        }

        public IList<BookTag> FindBookTagsByBook(Int32 bookId)
        {
            List<BookTag> bookTags;

            bookTags = new List<BookTag>();
            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
                foreach (var entry in db.FindBookTagsByBook(bookId))
                    bookTags.Add(entry);
            //}
            return bookTags;
        }

        public IList<string> GetNames()
        {
            List<string> names;

            names = new List<string>();
            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
                foreach (var entry in db.GetBookTagNames())
                    names.Add(entry);
            //}

            return names;
        }

        public List<SelectListItem> GetSelectItemList(
            IList<BookTag> values
            )
        {
            Int32 i = 0;
            List<SelectListItem> items;
            IEnumerable<SelectListItem> selectList;

            items = new List<SelectListItem>();
            foreach (BookTag value in values)
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