//-----------------------------------------------------------------------
// Модель представления. Отображает данные о теге книги.
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookMarket.Models;
using BookMarket.Services;

namespace BookMarket.Models.ViewModels
{

    public class BookTagView
    {
        public Int32 Id { get; set; }
        public string HumanName { get; set; }
        public string MashineName { get; set; }
        public string BookType { get; set; }

        public BookTagView(BookTag bookTag)
        {
            SimpleValue simpleValue;
            BookTypeRepository bookTypeRepository;
            BookType bookType;

            bookTypeRepository = new BookTypeRepository();
            this.Id = bookTag.Id;
            this.HumanName = bookTag.Name;
            bookType = (BookType)bookTypeRepository.FindById(bookTag.BookTypeId);
            this.BookType = bookType.Name;

            simpleValue = BookTagService.FindById(this.Id);
            this.MashineName = simpleValue.MachineName;
        }
    }
}