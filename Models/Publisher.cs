//-----------------------------------------------------------------------
// Модель БД. Представляющий информацию об издателе.
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookMarket.Models
{
    public class Publisher
    {
        [Key]
        public Int32 Id { get; set; }
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; } 
    }
}