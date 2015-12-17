//-----------------------------------------------------------------------
// Контроллер предназначенный для администрирования интернет-магазина.
// Пока, здесь можно только просматривать и добавлять товары.
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookMarket.Models;
using BookMarket.Models.ViewModels;
using BookMarket.Services;

namespace BookMarket.Controllers
{
    public class AdminController : Controller
    {
        private IDbModelRepository _bookRepository = new BookRepository();
        private IDbModelRepository _bookVariableInfoRepository =
            new BookVariableInfoRepository();
        private IDbModelRepository _bookTagRepository = new BookTagRepository();
        private IDbModelRepository _languageRepository =
            new LanguageRepository();

        public ActionResult Index()
        {
            IList<Book> books;
            IList<BookSummary> bookSummaries;
            BookVariableInfo bookVariableInfo;

            books = this._bookRepository.GetAll().books;
            bookSummaries = new List<BookSummary>();
            foreach (var b in books)
            {
                bookVariableInfo = (BookVariableInfo)
                    this._bookVariableInfoRepository.FindById(b.Id);
                bookSummaries.Add(new BookSummary(b, bookVariableInfo));
            }

            return View(bookSummaries);
        }

        public ActionResult AddBook()
        {
            BookTagRepository bookTagRepository;
            LanguageRepository languageRepository;

            bookTagRepository = (BookTagRepository)this._bookTagRepository;
            languageRepository = (LanguageRepository) this._languageRepository;

            ViewData["bookTagNames"] = bookTagRepository.GetSelectItemList(
                this._bookTagRepository.GetAll().bookTags);
            ViewData["languageNames"] = languageRepository.GetSelectItemList(
                this._languageRepository.GetAll().languages);

            return View(new BookSummary());
        }

        [HttpPost]
        public ActionResult AddBook(BookSummary bookSummary)
        {
            Book book;
            BookService bookService;
            BookTagRepository bookTagRepository;
            LanguageRepository languageRepository;

            bookService = new BookService();
            if (ModelState.IsValid)
            {
                book = bookService.MakeBook(bookSummary);
                bookService.MakeBookVariableInfo(bookSummary, book);

                return RedirectToAction("Index");
            }

            //Отображаем языки и теги для select элементов
            bookTagRepository = (BookTagRepository)this._bookTagRepository;
            languageRepository = (LanguageRepository)this._languageRepository;

            ViewData["bookTagNames"] = bookTagRepository.GetSelectItemList(
                this._bookTagRepository.GetAll().bookTags);
            ViewData["languageNames"] = languageRepository.GetSelectItemList(
                this._languageRepository.GetAll().languages);

            return View(bookSummary);
        }
    }
}
