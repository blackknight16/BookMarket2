//-----------------------------------------------------------------------
// Модель БД. Представляет информацию о городе.
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookMarket.Models
{
    public class City
    {
        [Key]
        public Int32 Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}