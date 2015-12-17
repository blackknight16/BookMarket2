//-----------------------------------------------------------------------
// Модель БД. Представляет информацию о корзине покупателя: общая стоимость 
// книг, цена доставки.
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BookMarket.Models
{
    public class Basket
    {
        [Key]
        public Int32 Id { get; set; }
        public Decimal TotalAmount { get; set; } //Цена книги * число экземпляров
        public Decimal DeliveryCost { get; set; }

        public Individual Individual { get; set; }
        public ICollection<BasketItem> BasketItems { get; set; } 
    }
}