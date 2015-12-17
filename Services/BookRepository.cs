//-----------------------------------------------------------------------
// Репозиторий  книги.
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Core.Objects;
using BookMarket.DbInfrastructure;
using BookMarket.Models;

namespace BookMarket.Services
{
    public class BookRepository : BaseRepository, IDbModelRepository
    {
        private BookMarketDbContext db;
        private SqlConnection conn;

        //Словарь содержит число книг по каждому тегу
        public Dictionary<Int32, Int32> BOOK_TAG_BOOK_LIST
        {
            get
            {
                if (this.bookTagBookList == null)
                    this.bookTagBookList = BookTagBookListFill();
                return this.bookTagBookList;
            }
        }

        private Dictionary<Int32, Int32> bookTagBookList;

        public BookRepository() : base() {
            db = new BookMarketDbContext();
        }

        //Заполнение BOOK_TAG_BOOK_LIST
        private Dictionary<Int32, Int32> BookTagBookListFill()
        {
            Dictionary<Int32, Int32> booksByTagsDic;
            List<BookTag> bookTags;
            Int32 bookCount;
            System.Data.Entity.Core.Objects.ObjectParameter outputParameter;
            //Int32 outputParameter = 0;

            booksByTagsDic = new Dictionary<Int32, Int32>();
            bookTags = db.GetAllBookTags().ToList<BookTag>();

            foreach (BookTag bookTag in bookTags)
            {
                outputParameter = new System.Data.Entity.Core.Objects.ObjectParameter("Count", typeof(Int32));
                bookCount = db.GetAllBooksCountByTagId(bookTag.Id)//, out outputParameter)//, out garbage)
                    .First<Int32>();
                booksByTagsDic.Add(bookTag.Id, bookCount);

            }

            return booksByTagsDic;
        }

        public ModelToModel GetAll()
        {
            ModelToModel mm;

            mm = new ModelToModel();
            mm.books = new List<Book>();
            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
            var cc = db.GetAllBooks().ToList<Book>();
            //var cc = db.GetAllBooks();
            foreach (Book entry in db.GetAllBooks())
                {
                    mm.books.Add(entry);
                }
            //}
            //test 1query -> Rowset
            //var query = db.Database.SqlQuery<Book>("GetAllBooks").ToList<Book>();
            //

            return mm;
        }

        public object Add(object item)
        {
            Book book = (Book)item;

            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
            return db.AddBook(book.Name, book.Year, book.PageCount, book.ImageName,
                    book.Description, book.LanguageId).First<Book>();
            //}
            //return GetAll().books.Last();
        }

        public object FindById(Int32 id)
        {
            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
                var items = db.FindBookById(id);
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
                foreach (var entry in db.GetBookNames())
                    names.Add(entry);
            //}
            return names;
        }

        public List<SelectListItem> GetSelectItemList(
            List<Book> values
            )
        {
            Int32 i = 0;
            List<SelectListItem> items;
            IEnumerable<SelectListItem> selectList;

            items = new List<SelectListItem>();
            foreach (Book value in values)
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

        public IList<Book> GetAllBooksByTagId(Int32 tagId, Int32 fromVal, 
            Int32 increment)
        {
            List<Book> books;
            BookTag tag;
            Book book;
            BookService bookService;

            bookService = new BookService();
            books = new List<Book>();
            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
            foreach (Book entry in db.GetAllBooksByTagId(
                tagId, fromVal, increment))
            {
                //перевод T1 -> Book
                //book = bookService.ConvertT1ToBook(entry);
                books.Add(entry);
            }
            //}

            //test 
            SqlConnection sqlConnection1 = new SqlConnection(
                SpecialConstants.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[Books]");
            SqlDataReader reader;

            cmd.CommandText = "GetAllBooksByTagId";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = sqlConnection1;
            cmd.Parameters.Add("@TagId", SqlDbType.Int);
            cmd.Parameters["@TagId"].Value = tagId;
            cmd.Parameters.Add("@FromVal", SqlDbType.Int);
            cmd.Parameters["@FromVal"].Value = fromVal;
            cmd.Parameters.Add("@Increment", SqlDbType.Int);
            cmd.Parameters["@Increment"].Value = increment;

            sqlConnection1.Open();

            reader = cmd.ExecuteReader();
            List<Book> books2 = new List<Book>();
            if(reader.HasRows)
                while (reader.Read())
                {
                    book = new Book()
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Year = reader.GetInt32(2),
                        PageCount = reader.GetInt32(3),
                        ImageName = reader.GetString(4),
                        Description = reader.GetString(5),
                        LanguageId = reader.GetInt32(6)
                    };
                    books2.Add(book);
                }

            sqlConnection1.Close();
            // </test> <test2>
            List<Book> books3 = new List<Book>();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            //cmd.Connection = sqlConnection1;
            sqlConnection1.Open();
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            sqlConnection1.Close();

            for(Int32 i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                book = new Book()
                {
                    Id = (Int32)ds.Tables[0].Rows[i].ItemArray[0],
                    Name = Convert.ToString(ds.Tables[0].Rows[i].ItemArray[1]),
                    Year = (Int32)ds.Tables[0].Rows[i].ItemArray[2],
                    PageCount = (Int32)ds.Tables[0].Rows[i].ItemArray[3],
                    ImageName = Convert.ToString(ds.Tables[0].Rows[i].ItemArray[4]),
                    Description = Convert.ToString(ds.Tables[0].Rows[i].ItemArray[5]),
                    LanguageId = (Int32)ds.Tables[0].Rows[i].ItemArray[6]
                };
                books3.Add(book);   
            }


            return books;
        } 

        public IList<Book> GetAllBooksByTagName(string tagName)
        {
            List<Book> books;
            BookTag tag;

            books = new List<Book>();
            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
                foreach (Book entry in db.GetAllBooksByTagName(tagName))
                    books.Add(entry);
            //}

            return books;
        } 

    }
}