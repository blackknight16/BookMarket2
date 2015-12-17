//-----------------------------------------------------------------------
// Модель представления. Отображает данные о книге + ее переменную 
// информацию.
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using BookMarket.Models;
using BookMarket.Services;

namespace BookMarket.Models.ViewModels
{
    public class BookSummary : BookView
    {
        [Required(ErrorMessage = "Укажите число страниц")]
        [Display(Name = "Число страниц")]
        public Int32 ProductCount { get; set; }
        [Required(ErrorMessage = "Укажите цену")]
        [Display(Name = "Цена")]
        public Decimal Price { get; set; }
        [Required(ErrorMessage = "Укажите не менее 1 тега")]
        [Display(Name = "Теги")]
        public List<string> 
            BookTagSelectListItems { get; set; }

        public string BookTagOne
        {
            get
            {
                StringBuilder bookTagsOne;

                bookTagsOne = new StringBuilder(
                    this.BookTags.ElementAt(0).HumanName);
                for (Int32 i = 1; i < this.BookTags.Count; i++)
                {
                    bookTagsOne.Append(", ");
                    bookTagsOne.Append(this.BookTags.ElementAt(i).HumanName);
                }
                return bookTagsOne.ToString();
            }
        }

        public BookSummary()
            :base()
        {
        }

        public BookSummary(Book book)
            : base(book)
        {
        }

        public BookSummary(Book book, BookVariableInfo bookVariableInfo)
            : this(book)
        {
            this.ProductCount = bookVariableInfo.ProductCount;
            this.Price = bookVariableInfo.Price;
        }
    }
}