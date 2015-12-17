//-----------------------------------------------------------------------
// Модель БД. Представляет информацию об изменчивой детализации книг
// интернет-магазина (количество, цена, книга.).
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookMarket.Models
{
    public class BookVariableInfo
    {
        [Key, ForeignKey("Book")]
        public Int32 Id { get; set; }
        public Int32 ProductCount { get; set; }
        public Decimal Price { get; set; } //Цена одного экземпляра книги

        public virtual Book Book { get; set; }
        public virtual ICollection<BasketItem> BasketItem { get; set; }
    }
}