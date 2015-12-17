//-----------------------------------------------------------------------
// Модель БД. Представляет информацию о физическом магазине. В него
// доставляется товар, откуда впоследствии товар может быть передан
// заказчику товара.
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BookMarket.Models
{
    //Предполагается, что книги находятся на складе, 
//например в Москве, и доставляются в выбранный магазин 
//со склада по фиксированной цене (для всех книг) 
//за экземпляр
    public class Shop
    {
        [Key, ForeignKey("Address")]
        [Display(Name = "Магазин")]
        [Required(ErrorMessage = "Укажите магазин")]
        public Int32 Id { get; set; }
        public string Name { get; set; }
        public Decimal BookDeliveryCost { get; set; }
        public virtual Address Address { get; set; }
    }
}