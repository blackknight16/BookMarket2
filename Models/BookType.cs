//-----------------------------------------------------------------------
// Модель БД. Представляет информацию о типе книги, отображаемой в 
// каталоге магазина.
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookMarket.Models
{
    public class BookType
    {
        [Key]
        public Int32 Id { get; set; }
        public string Name { get; set; }

        public ICollection<BookTag> BookTags { get; set; } 
    }
}