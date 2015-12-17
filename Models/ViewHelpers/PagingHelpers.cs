//-----------------------------------------------------------------------
// Представляет помощник представления в пагинации страниц. Пагинация
// реализуется ручным способом.
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using BookMarket.Models.ViewModels;

namespace BookMarket.Models.ViewHelpers
{
    public static class PagingHelpers
    {
        //создание <a href="pageUrl(i)" 
        //              style="selected btn-primary btn btn-default"> i 
        //         </a>
        //Используются стандартные классы Bootstrap
        public static MvcHtmlString PageLinks(this HtmlHelper html,
            PageInfo pageInfo, Func<Int32, string> pageUrl)
        {
            StringBuilder result;
            TagBuilder tag;

            result = new StringBuilder();
            for (Int32 i = 1; i <= pageInfo.TotalPages; i++)
            {
                tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                //если текущая страница, то выделяем ее,
                //например, добавляя класс
                if (i == pageInfo.PageNumber)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default");
                result.Append(tag.ToString());
            }
            return MvcHtmlString.Create(result.ToString());
        }

    }
}