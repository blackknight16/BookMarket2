//-----------------------------------------------------------------------
// Модель представления. Отображает общую информацию корзины.
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookMarket.Models;
using BookMarket.Models.ViewModels;
using BookMarket.Services;

namespace BookMarket.Models.ViewModels
{
    public class BasketView
    {
        public Int32 Id { get; set; }
        public Decimal TotalAmount { get; set; }
        public Decimal DeliveryCost { get; set; }

        public Individual Individual { get; set; }
        public IList<BasketItemView> BasketItemViews { get; set; }

        public BasketView()
        {
        }

        public BasketView(Basket basket)
        {
            IList<BasketItem> basketItems;
            IndividualRepository individualRepository;
            BasketItemRepository basketItemRepository;

            individualRepository = new IndividualRepository();
            basketItemRepository = new BasketItemRepository();

            this.Id = basket.Id;
            this.TotalAmount = basket.TotalAmount;
            this.DeliveryCost = basket.DeliveryCost;
            this.Individual = (Individual)
                individualRepository.FindById(this.Id);

            basketItems =
                basketItemRepository.FindAllByBasket(this.Id);
            this.BasketItemViews =
                (from basketItem in basketItems
                 select new BasketItemView(basketItem))
                 .ToList<BasketItemView>();
        }

    }
}