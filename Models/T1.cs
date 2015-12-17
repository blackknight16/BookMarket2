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
    public class T1
    {
        public Int32 Row { get; set; }
        [Key, DatabaseGenerated(]
        //[Required]
        public Int32 Id1 { get; set; }
        public string Name { get; set; }
        [Required]
        public Int32 Year { get; set; }
        [Required]
        public Int32 PageCount { get; set; }
        public string ImageName { get; set; }
        [Column(TypeName = "ntext")]
        public string Description { get; set; }
        [Required]
        public Int32 LanguageId { get; set; }
    }
}