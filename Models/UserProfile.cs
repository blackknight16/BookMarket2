//-----------------------------------------------------------------------
// Модель БД. Представляет данные учетной записи пользователя на сайте.
// Это стандартная модель MVC4, которую я вынес в отдельный файл и 
// немного изменил.
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BookMarket.Models
{
    [Table("UserProfile")]
    public class UserProfile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [Required]
        [ConcurrencyCheck]
        public string UserName { get; set; }
        [ForeignKey("Individual")]
        public Nullable<Int32> IndividualId { get; set; }

        public virtual Individual Individual { get; set; }
    }
}