//-----------------------------------------------------------------------
// Модель БД. Важная модель, представляющая информацию о книге. Представляет
// название, год, число страниц, название изображения, описание, авторов,
// язык, переменную информацию книги, издетелей и теги.
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Web;

namespace BookMarket.Models
{
    public class Book
    {
        [Key]
        public Int32 Id { get; set; }
        public string Name { get; set; }
        public Int32 Year { get; set; }
        public Int32 PageCount { get; set; }
        public string ImageName { get; set; }
        [Column(TypeName = "ntext")]
        public string Description { get; set; }
        //public string Format { get; set; } // Единица измерения - милиметры (мм)
        //public string ISBN { get; set; }
        public Int32 LanguageId { get; set; }
        public virtual ICollection<Author> Authors { get; set; }
        public virtual Language Language { get; set; }
        public virtual BookVariableInfo BookVariableInfo { get; set; }
        public virtual ICollection<Publisher> Publishers { get; set; }
        public virtual ICollection<BookTag> BookTags { get; set; }
    }
}