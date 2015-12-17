//-----------------------------------------------------------------------
// Модель БД. Представляет информацию о географическом адресе.
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BookMarket.Models
{
    public class Address
    {
        [Key]
        public Int32 Id { get; set; }
        public Int32 House { get; set; }

        [Display(Name = "Город")]
        [Required(ErrorMessage = "Укажите город")]
        public Int32 CityId { get; set; }
        public Int32 StreetId { get; set; }

        public virtual City City { get; set; }
        public virtual Street Street { get; set; }
        public virtual Shop Shop { get; set; }
    }
}