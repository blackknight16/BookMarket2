//-----------------------------------------------------------------------
// Сервис книги.
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookMarket.Models;
using BookMarket.Models.ViewModels;

namespace BookMarket.Services
{
    public class BookService : BaseService
    {
        private const string blankImageName = "blank.jpg";

        //Извлечение и создание книги по BookSummary
        public Book MakeBook(BookSummary bookSummary)
        {
            Author author, newAuthor;
            Publisher publisher, newPublisher;
            BookTag bookTag;
            Book book, dbBook;
            string[] strings1, strings2;
            AuthorRepository authorRepository;
            PublisherRepository publisherRepository;

            book = new Book();
            //Остальные поля
            book.LanguageId = bookSummary.Language.Id;
            book.ImageName = blankImageName; //пока бланк
            book.Name = bookSummary.Name;
            book.PageCount = bookSummary.PageCount;
            book.Year = bookSummary.Year;
            book.Description = bookSummary.FullDescription;

            this._bookRepository.Add(book);
            dbBook = (Book)this._bookRepository.GetAll().books.Last();
            book.Id = dbBook.Id;
            //Создание авторов
            strings1 = bookSummary.Authors.Split(new char[] { ',' },
                StringSplitOptions.RemoveEmptyEntries);
            book.Authors = new List<Author>();
            authorRepository = (AuthorRepository)this._authorRepository;
            publisherRepository = (PublisherRepository)this._publisherRepository;
            foreach (string authorStrings in strings1)
            {
                strings2 = authorStrings.Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);
                if (strings2.Length == 2)
                    newAuthor = new Author()
                    {
                        LastName = strings2[0],
                        FirstName = strings2[1]
                    };
                else newAuthor = new Author() { LastName = strings2[0] };

                author = authorRepository.FindByName(
                    newAuthor.LastName, newAuthor.FirstName);
                if (author != null)
                {
                    this._commonRepository.AddBookAuthor(book.Id, author.Id);
                    book.Authors.Add(author);
                }
                else
                {
                    var dbNewAuthor = (Author)this._authorRepository.Add(newAuthor);
                    newAuthor.Id = dbNewAuthor.Id;
                    this._commonRepository.AddBookAuthor(book.Id, newAuthor.Id);
                    book.Authors.Add(newAuthor);
                }
            }

            //Создание издетелей
            strings1 = bookSummary.Publishers.Split(new char[] { ',' },
                StringSplitOptions.RemoveEmptyEntries);
            book.Publishers = new List<Publisher>();
            foreach (string publisherName in strings1)
            {
                newPublisher = new Publisher() { Name = publisherName };
                publisher = publisherRepository.FindByName(publisherName);

                if (publisher != null)
                {
                    this._commonRepository.AddPublisherBook(
                        publisher.Id, book.Id);
                    book.Publishers.Add(publisher);
                }
                else
                {
                    var dbNewPublisher = (Publisher)this._publisherRepository.Add(newPublisher);
                    newPublisher.Id = dbNewPublisher.Id;
                    this._commonRepository.AddPublisherBook(newPublisher.Id, book.Id);
                    book.Publishers.Add(newPublisher);
                }
            }

            //Ассоциация с тегами
            book.BookTags = new List<BookTag>();
            foreach (string bookTagSLI in bookSummary.BookTagSelectListItems)
            {
                //поиск выбранного тега по ег Id и вставка в таблицу ассоциацию
                bookTag = (BookTag)this._bookTagRepository.FindById(
                    Convert.ToInt32(bookTagSLI));
                this._commonRepository.AddBookTagBook(bookTag.Id, book.Id);
                book.BookTags.Add(bookTag);
            }

            return book;
        }

        //Извлечение и создание информации о книге по BookSummary
        public BookVariableInfo MakeBookVariableInfo(
            BookSummary bookSummary, Book book)
        {
            BookVariableInfo bookVariableInfo;

            bookVariableInfo = new BookVariableInfo(){
                Id = book.Id,
                Price = bookSummary.Price,
                ProductCount = bookSummary.ProductCount,
                Book = book
            };
            this._bookVariableInfoRepository.Add(bookVariableInfo);

            return bookVariableInfo;
        }

        /*public Book ConvertT1ToBook(T1 data)
        {
            Book book = new Book()
            {
                Id = data.Id1,
                Name = data.Name,
                Year = data.Year,
                PageCount = data.PageCount,
                ImageName = data.ImageName,
                Description = data.Description,
                LanguageId = data.LanguageId
            };
            return book;
        }*/

    }
}