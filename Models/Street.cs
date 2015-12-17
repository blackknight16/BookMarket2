//-----------------------------------------------------------------------
// Модель БД. Представляет информацию об улице. На ней находится 
// физический магазин.
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookMarket.Models
{
    public class Street
    {
        [Key]
        public Int32 Id { get; set; }
        public string Name { get; set; }
        public Int32 StreetTypeId { get; set; }

        public virtual StreetType StreetType { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}