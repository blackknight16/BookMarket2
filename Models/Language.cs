//-----------------------------------------------------------------------
// Модель БД. Представляет информацию о языке.
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookMarket.Models
{
    public class Language
    {
        [Key]
        [Display(Name = "Язык")]
        public Int32 Id { get; set; }
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; } 
    }
}