//-----------------------------------------------------------------------
// Модель БД. Представляет информацию о заказе экземпляров выбранной книги
// в магазине: цену всех экземпляров книги, число экземпляров книги,
// Id корзины, Id платежа, Id переменной информации книги. Важно заметить,
// что элемент корзины может быть отсоединен от корзины и присоединен к
// платежу. Гарантируется, что в любое время только 1 из этих 2 полей
// не NULL.
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BookMarket.Models
{
    //BasketItem может быть связан с корзиной до проведения оплаты. После оплаты
    //BasketItem открепляется от Basket и присоединяется к Payment
    public class BasketItem
    {
        [Key]
        public Int32 Id { get; set; }
        public Decimal Amount { get; set; } //Цена всех экземпляров книги
        [Display(Name = "Число экземпляров")]
        [Required(ErrorMessage = 
            "Укажите значение, большее 0 и не более общего числа экземпляров")]
        public Int32 ItemCount { get; set; }

        [ForeignKey("BookVariableInfo")]
        public Int32 BookVariableInfoId { get; set; }
        public Nullable<Int32> BasketId { get; set; }
        public Nullable<Int32> PaymentId { get; set; }

        public virtual BookVariableInfo BookVariableInfo { get; set; }
        public virtual Basket Basket { get; set; }
        public virtual Payment Payment { get; set; }
    }
}