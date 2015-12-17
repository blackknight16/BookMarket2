//-----------------------------------------------------------------------
// Модель БД. Представляет информацию о теге книги. 1 книга может иметь
// 1 и более тегов.
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BookMarket.Services;

namespace BookMarket.Models
{
    public class BookTag
    {
        [Key]
        public Int32 Id { get; set; }
        [Required]
        public string Name { get; set; }
        public Int32 BookTypeId { get; set; }

        public virtual BookType BookType { get; set; }
        public virtual ICollection<Book> Books { get; set; } 
    }
}