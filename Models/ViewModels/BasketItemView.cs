//-----------------------------------------------------------------------
// Модель представления. Отображает информацию о заказанном элементе
// корзины.
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using BookMarket.Models;
using BookMarket.Services;

namespace BookMarket.Models.ViewModels
{
    public class BasketItemView
    {
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

        public BookVariableInfo BookVariableInfo { get; set; }
        public Book Book { get; set; }
        public Basket Basket { get; set; }
        public Payment Payment { get; set; }

        public BasketItemView()
        {
        }

        public BasketItemView(BasketItem basketItem)
        {
            BookRepository bookRepository;
            BookVariableInfoRepository bookVariableInfoRepository;
            BasketRepository basketRepository;
            PaymentRepository paymentRepository;

            bookRepository = new BookRepository();
            bookVariableInfoRepository = new BookVariableInfoRepository();
            basketRepository = new BasketRepository();
            paymentRepository = new PaymentRepository();

            this.Id = basketItem.Id;
            this.Amount = basketItem.Amount;
            this.BasketId = basketItem.BasketId;
            this.BookVariableInfoId = basketItem.BookVariableInfoId;
            this.ItemCount = basketItem.ItemCount;
            this.PaymentId = basketItem.PaymentId;

            this.BookVariableInfo = (BookVariableInfo)
                bookVariableInfoRepository.FindById(this.BookVariableInfoId);
            this.Book = (Book)bookRepository.FindById(this.BookVariableInfoId);
            if (this.BasketId != null)
                this.Basket = (Basket)basketRepository.FindById((Int32)this.BasketId);
            if (this.PaymentId != null)
                this.Payment = (Payment)paymentRepository.FindById((Int32)this.PaymentId);
        }

    }
}