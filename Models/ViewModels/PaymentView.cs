//-----------------------------------------------------------------------
// Модель представления. Отображает данные платежа.
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BookMarket.Models;
using BookMarket.Models.ViewModels;
using BookMarket.Services;

namespace BookMarket.Models.ViewModels
{
    public class PaymentView
    {
        public Int32 Id { get; set; }
        public bool isPayed { get; set; }

        public Int32 ShopId { get; set; }
        public Int32 IndividualId { get; set; }

        public Shop Shop { get; set; }
        public Individual Individual { get; set; }
        public IList<BasketItem> BasketItems { get; set; }


        public PaymentView()
        {
        }

        public PaymentView(Payment payment)
        {
            ShopRepository shopRepository;
            BasketItemRepository basketItemRepository;
            IndividualRepository individualRepository;

            shopRepository = new ShopRepository();
            individualRepository = new IndividualRepository();
            basketItemRepository = new BasketItemRepository();

            this.Id = payment.Id;
            this.isPayed = payment.isPayed;
            this.ShopId = payment.ShopId;

            if (this.ShopId != null)
                this.Shop = (Shop)shopRepository.FindById(this.ShopId);

            this.IndividualId = payment.IndividualId;
            if (this.IndividualId != null)
                this.Individual = (Individual)
                    individualRepository.FindById(this.IndividualId);

            this.BasketItems = basketItemRepository.FindBasketItemsByPayment(
                this.Id);
        }
    }
}