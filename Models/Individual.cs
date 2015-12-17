//-----------------------------------------------------------------------
// Модель БД. Представляет персональные данные покупателя.
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BookMarket.Models
{
    public class Individual
    {
        [Key, ForeignKey("Basket")]
        public Int32 Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string MiddleName { get; set; }

        //Не получилось сделать связь 1:1
        public virtual ICollection<UserProfile> UserProfiles { get; set; }
        public virtual Basket Basket { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}