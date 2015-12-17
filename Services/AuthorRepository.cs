//-----------------------------------------------------------------------
// Репозиторий авторов.
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
    public class AuthorRepository : BaseRepository, IDbModelRepository
    {
        private BookMarketDbContext db;
        private SqlConnection conn;

        public AuthorRepository() : base()
        {
            db = new BookMarketDbContext();
        }

        public ModelToModel GetAll()
        {
            ModelToModel mm;

            mm = new ModelToModel();
            mm.authors = new List<Author>();
            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
                foreach (var entry in db.GetAllAuthors())
                    mm.authors.Add(entry);
            //}
            return mm;
        }

        public object Add(object item)
        {
            Author author = (Author)item;

            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
                return db.AddAuthor(author.LastName, author.FirstName).First<Author>();
            //}
            //return GetAll().authors.Last();
        }

        public object FindById(Int32 id)
        {
            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
                var items = db.FindAuthorById(id);
                var item = items.FirstOrDefault();
                return item;
            //}
        }

        public Author FindByName(string lastName, string firstName)
        {
            Author item;

            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
                if (firstName != null)
                {
                    var items = db.FindAuthorByFullName(lastName, firstName);
                    item = items.FirstOrDefault<Author>();
                }
                else
                {
                    var items = db.FindAuthorByLastName(lastName);
                    item = items.FirstOrDefault<Author>();
                }
            //}
            return item;
        }

        public IList<Author> FindAllAuthorsByBook(Int32 bookId)
        {
            IList<Author> books;

            books = new List<Author>();
            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
                foreach (var entry in db.FindAllAuthorsByBook(bookId))
                    books.Add(entry);
            //}
            return books;
        }

        public IList<string> GetNames()
        {
            return null;
        }

    }
}