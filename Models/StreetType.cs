//-----------------------------------------------------------------------
// Модель БД. Представляет вид улицы
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookMarket.Models
{
    public class StreetType
    {
        [Key]
        public Int32 Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Street> Streets { get; set; } 
    }
}