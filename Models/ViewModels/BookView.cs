//-----------------------------------------------------------------------
// Модель представления. Отображает данные о деталях книги.
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Web;
using BookMarket.Services;

namespace BookMarket.Models.ViewModels
{
    public class BookView
    {
        public Int32 Id { get; set; }
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Display(Name = "Год")]
        public Int32 Year { get; set; }
        [Display(Name = "Число страниц")]
        public Int32 PageCount { get; set; }
        [Display(Name = "Название изображения")]
        public string ImageName { get; set; }
        public string ShortDescription { get; set; }
        [Display(Name = "Полное описание")]
        public string FullDescription { get; set; }
        [Display(Name = "Авторы")]
        public string Authors { get; set; }
        [Display(Name = "Язык")]
        public Language Language { get; set; }
        [Display(Name = "Издатели")]
        public string Publishers { get; set; }
        public IList<BookTagView> BookTags { get; set; }

        public BookView()
        {
        }

        public BookView(Book book)
        {
            IList<Author> authors;
            IList<BookTag> bookTags;
            Language language;
            IList<Publisher> publishers;
            AuthorRepository authorRepository = new AuthorRepository();
            BookTagRepository bookTagRepository = new BookTagRepository();
            PublisherRepository publisherRepository = new PublisherRepository();
            LanguageRepository languageRepository = new LanguageRepository();

            authors = authorRepository.FindAllAuthorsByBook(book.Id);
            bookTags = bookTagRepository.FindBookTagsByBook(book.Id);
            publishers = publisherRepository.FindAllByBook(book.Id);
            language = (Language)languageRepository.FindById(book.LanguageId);
            
            this.Id = book.Id;
            this.Name = book.Name;
            this.Year = book.Year;
            this.PageCount = book.PageCount;
            this.ImageName = book.ImageName;
            this.FullDescription = MakeFullDescription(book.Description);
            this.ShortDescription = MakeShortDescription(book.Description);
            this.Authors = MakeAuthors(authors);
            this.Language = language;
            this.Publishers = MakePublishers(publishers);
            this.BookTags = MakeBookTagViews(bookTags);
        }

        //Возвращаем 1 абзац описания
        protected string MakeShortDescription(string fullDescription)
        {
            string shortDescription;
            string[] parts;

            parts = fullDescription.Split(
                new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            shortDescription = parts.Count() > 0 ? parts[0] : "";

            return shortDescription;
        }

        //1 выводимая строка в представление
        protected string MakeAuthors(ICollection<Author> authorList)
        {
            StringBuilder oneAuthorString;

            var combineAuthorList = (from a in authorList
                                     select a.LastName + " " + (a.FirstName != null ? a.FirstName : "")
                ).ToList<string>();

            oneAuthorString = new StringBuilder();
            oneAuthorString.Append(combineAuthorList[0]); // не менее 1 автора
            for (Int32 i = 1; i < combineAuthorList.Count; i++)
            {
                oneAuthorString.Append(", ");
                oneAuthorString.Append(combineAuthorList[i]);
            }

            return oneAuthorString.ToString();
        }

        protected string MakePublishers(ICollection<Publisher> publishers)
        {
            StringBuilder onePublisherString;

            onePublisherString = new StringBuilder();
            onePublisherString.Append(publishers.ElementAt(0).Name); // не менее 1 издателя
            for (Int32 i = 1; i < publishers.Count; i++)
            {
                onePublisherString.Append(", ");
                onePublisherString.Append(publishers.ElementAt(i).Name);
            }

            return onePublisherString.ToString();
        }

        protected IList<BookTagView> MakeBookTagViews(ICollection<BookTag> bookTags)
        {
            IList<BookTagView> bookTagViewList;

            bookTagViewList = (from tag in bookTags
                               select new BookTagView(tag)).ToList<BookTagView>();
            return bookTagViewList;
        }

        protected string MakeFullDescription(string originalDescription)
        {
            string formattedDescription;
            string[] strMas;

            formattedDescription =
                originalDescription.Replace("\r\n", "<br /><br />");
            return formattedDescription.ToString();
        }
    }
}