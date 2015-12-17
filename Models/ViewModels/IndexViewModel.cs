//-----------------------------------------------------------------------
// Модель представления. Служит контейнером для шаблона пагинации страниц,
// каталога книг, выбранного тега.
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookMarket.Models;

namespace BookMarket.Models.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<BookView> BookViews { get; set; }
        public PageInfo PageInfo {get; set;}
        public Int32 BookTagId { get; set; }

        public IndexViewModel()
        {
        }

        public IndexViewModel(
            PageInfo pageInfo, IEnumerable<BookView> bookViews, Int32 bookTagId)
        {
            this.PageInfo = pageInfo;
            this.BookViews = bookViews;
            this.BookTagId = bookTagId;
        }
    }
}