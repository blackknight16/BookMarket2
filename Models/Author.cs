//-----------------------------------------------------------------------
// Модель БД. Представляет информацию об авторе.
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BookMarket.Models
{
    public class Author
    {
        [Key]
        public Int32 Id { get; set; }
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}