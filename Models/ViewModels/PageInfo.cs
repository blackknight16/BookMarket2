//-----------------------------------------------------------------------
// Модель представления. Служит шаблоном данных для пагинации страниц
// в каталоге книг.
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookMarket.Models.ViewModels
{
    public class PageInfo
    {
        public const Int32 PAGE_SIZE = 5;
        public Int32 PageNumber { get; set; } // номер текущей страницы
        public Int32 PageSize { get; set; } // кол-во объектов на странице
        public Int32 TotalItems { get; set; } // всего объектов
        public Int32 TotalPages  // всего страниц
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / PageSize); }
        }

        public PageInfo()
        {
        }

        public PageInfo(Int32 pageNumber, Int32 totalItems, 
            Int32 pageSize = PAGE_SIZE)
        {
            this.PageNumber = pageNumber;
            this.TotalItems = totalItems;
            this.PageSize = pageSize;
        }
    }
}