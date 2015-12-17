//-----------------------------------------------------------------------
// Сервис корзины.
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BookMarket.DbInfrastructure;
using BookMarket.Models;
using BookMarket.Models.ViewModels;
using System.Data.Entity;

namespace BookMarket.Services
{
    public class BasketService : BaseService
    {
        //Валидация представления элемента корзины
        //Число заказанных товаров не должно быть <= 0 и больше фактического
        public bool BasketItemIsValid(BasketItemView basketItemView)
        {
            BookVariableInfo bookVariableInfo;

            bookVariableInfo = (BookVariableInfo)
                this._bookVariableInfoRepository.FindById(
                basketItemView.BookVariableInfoId);
            if (basketItemView.ItemCount > bookVariableInfo.ProductCount ||
                basketItemView.ItemCount <= 0)
                return false;

            return true;
        }

        //Подсчет числа экзмемпляров книг корзины
        private Int32 BasketItemCounting(BasketItem basketItem)
        {
            Int32 basketProductCount;
            IList<Int32> itemsCount;
            IList<BasketItem> allBasketItems;
            BasketItemRepository basketItemRepository;

            basketItemRepository = (BasketItemRepository)
                this._basketItemRepository;

            allBasketItems = basketItemRepository
                .FindAllByBasket((Int32)basketItem.BasketId);
            // Связь 1:1 BookVariableInfo и Book
            itemsCount = (from searchBasketItem in allBasketItems
                          where searchBasketItem.BookVariableInfoId ==
                                basketItem.BookVariableInfoId
                          select searchBasketItem.ItemCount).ToList<Int32>();

            return itemsCount.Sum();
        }

        //Добавление экземпляров книги в корзину покупателя
        //Должна быть транзакция
        public bool AddBookItem(Basket basket, BasketItem basketItem)
        {
            Int32 allBasketItemCount;
            Book book;
            BookVariableInfo bookVariableInfo, newBookVariableInfo;
            BasketRepository basketRepository;

            if (basket != null && basketItem != null)
            {
                if (basket.BasketItems == null)
                    basket.BasketItems = new List<BasketItem>();
                bookVariableInfo = (BookVariableInfo)
                    base._bookVariableInfoRepository.FindById(
                        basketItem.BookVariableInfoId);
                book = (Book)this._bookRepository.FindById(bookVariableInfo.Id);

                //Валидация. Общее число заказанного товара не должно быть >= имеющегося числа
                allBasketItemCount = BasketItemCounting(basketItem);
                if (allBasketItemCount + basketItem.ItemCount >
                    bookVariableInfo.ProductCount)
                    return false;
                //Добавление заказанной книги
                basketItem.BasketId = basket.Id;
                basketItem.Amount =
                    bookVariableInfo.Price * basketItem.ItemCount;
                base._basketItemRepository.Add(basketItem);

                //Обновление корзины
                basket.TotalAmount += basketItem.Amount;
                basketRepository = new BasketRepository();
                basketRepository.Edit(basket);

                return true;
            }
            else
            {
                throw new Exception("Корзина или элемент корзины не заданы!");
            }

            return false;
        }

        //Обновление экземпляров книги в корзине покупателя
        //Должна быть транзакция
        public bool UpdateBookItem(BasketItem newBasketItem)
        {
            Int32 allBasketItemCount;
            Basket basket;
            Book book;
            BookVariableInfo bookVariableInfo;
            BasketItem oldBasketItem;
            BasketRepository basketRepository;
            BasketItemRepository basketItemRepository;

            if (newBasketItem != null)
            {
                basketRepository = (BasketRepository)this._basketRepository;
                basketItemRepository = (BasketItemRepository)
                    base._basketItemRepository;
                bookVariableInfo = (BookVariableInfo)
                    base._bookVariableInfoRepository.FindById(
                    newBasketItem.BookVariableInfoId);
                book = (Book)this._bookRepository.FindById(bookVariableInfo.Id);
                basket = (Basket)this._basketRepository.FindById(
                    (Int32)newBasketItem.BasketId);

                oldBasketItem = (BasketItem)base._basketItemRepository
                    .FindById(newBasketItem.Id);

                //Валидация. Общее число заказанного товара не должно быть >= имеющегося числа
                allBasketItemCount = BasketItemCounting(newBasketItem);
                if (allBasketItemCount - oldBasketItem.ItemCount +
                    newBasketItem.ItemCount > bookVariableInfo.ProductCount)
                    return false;
                //
                //Обновление корзины
                basket.TotalAmount -= oldBasketItem.Amount;
                basket.TotalAmount +=
                    newBasketItem.ItemCount * bookVariableInfo.Price;
                basketRepository.Edit(basket);

                //Обновление заказанной книги
                newBasketItem.Amount =
                    bookVariableInfo.Price * newBasketItem.ItemCount;
                basketItemRepository.Edit(newBasketItem);

                return true;
            }
            else
            {
                throw new Exception("Элемент корзины не задан!");
            }

            return false;
        }

        //Удаление экземпляров книги в корзине покупателя
        //Должна быть транзакция
        public bool DeleteBasketItem(BasketItem basketItem)
        {
            Book book;
            BookVariableInfo bookVariableInfo;
            Basket basket;
            BasketItem oldBasketItem;
            BasketRepository basketRepository;
            BasketItemRepository basketItemRepository;

            if (basketItem != null)
            {
                basketRepository = (BasketRepository)this._basketRepository;
                basketItemRepository = (BasketItemRepository)
                    base._basketItemRepository;
                basket = (Basket)this._basketRepository.FindById(
                    (Int32)basketItem.BasketId);
                bookVariableInfo = (BookVariableInfo)
                    base._bookVariableInfoRepository.FindById(
                    basketItem.BookVariableInfoId);

                //Обновление корзины
                basket.TotalAmount -= basketItem.Amount;
                basketRepository.Edit(basket);

                //Удаление заказанной книги
                basketItemRepository.Delete(basketItem.Id);

                return true;
            }
            else
            {
                throw new Exception("Элемент корзины не задан!");
            }

            return false;
        }

        //Получение элемента корзины по имени пользователя
        public Basket GetBasket(string userProfileName)
        {
            Basket basket;
            IList<BasketItem> basketItems;
            UserProfile userProfile;
            Individual individual;
            UserProfileRepository userProfileRepository;
            BasketItemRepository basketItemRepository;

            userProfileRepository = (UserProfileRepository)
                base._userProfileRepository;
            basketItemRepository = (BasketItemRepository)
                this._basketItemRepository;

            userProfile =
                userProfileRepository.FindByUserName(userProfileName);
            individual = (Individual)this._individualRepository.FindById(
                (Int32)userProfile.IndividualId);
            basket = (Basket)this._basketRepository.FindById(individual.Id);
            basketItems = basketItemRepository.FindAllByBasket(basket.Id);
            basket.BasketItems = basketItems; //наверное пропадет ссылка?

            return basket;
        }

        //Обновление корзины. Обновление переменной информации книги.
        //Необходимо рассчитать стоимость доставки, а также обновить
        //пересчитать книги.
        //Стоимость книг и стоимость доставки хранятся отдельно
        public Basket ShopProcessing(Basket basket, Shop shop)
        {
            List<BasketItem> basketItems;
            BookVariableInfo bookVariableInfo;
            Int32 allBasketItemCount, itemSum;
            BasketRepository basketRepository;
            BasketItemRepository basketItemRepository;
            BookVariableInfoRepository bookVariableInfoRepository;

            if (basket != null && shop != null)
            {
                basketRepository = (BasketRepository)
                    this._basketRepository;
                basketItemRepository = (BasketItemRepository)
                    this._basketItemRepository;
                bookVariableInfoRepository = (BookVariableInfoRepository)
                    this._bookVariableInfoRepository;

                basketItems = (List<BasketItem>)
                    basketItemRepository.FindAllByBasket(basket.Id);
                allBasketItemCount = (from item in basketItems
                                      select item.ItemCount).Sum();

                //Обновление книжной информации в БД
                var basketItemGroups = from item in basketItems
                                       group item by item.BookVariableInfoId
                                           into basketGroup
                                           select basketGroup;
                foreach (var groupp in basketItemGroups)
                {
                    bookVariableInfo = (BookVariableInfo)
                        this._bookVariableInfoRepository.FindById(groupp.Key);

                    itemSum = (from s in groupp.ToList()
                               select s.ItemCount).Sum();

                    bookVariableInfo.ProductCount -= itemSum;
                    bookVariableInfoRepository.Edit(bookVariableInfo);
                }
                //BaseService._db.SaveChanges();

                //Обновление корзины
                basket.DeliveryCost = shop.BookDeliveryCost * allBasketItemCount;
                basketRepository.Edit(basket);

                return basket;
            }
            else
            {
                throw new Exception("Корзина или магазин не заданы!");
            }
        }

        //Привязка элементов корзины покупателя к платежу и открепление их
        //от корзины.
        //payment должен быть известен БД или стоит его в ней найти по id?
        public void BasketToPaymentMigration(Basket basket, Payment payment)
        {
            IList<BasketItem> basketItems;
            BasketItemRepository basketItemRepository;

            if (basket != null && payment != null)
            {
                //прикрепление заказов к платежу
                basketItemRepository = (BasketItemRepository)this._basketItemRepository;
                basketItems = basketItemRepository.FindAllByBasket(basket.Id);

                foreach (BasketItem item in basketItems)
                {
                    item.PaymentId = payment.Id;
                    basketItemRepository.Edit(item);
                }

                //открепление заказов от корзины и ее очистка
                ClearBasket(basket);
            }
            else throw new Exception("Корзина или платеж не заданы!");
        }

        //Очистка корзины
        public void ClearBasket(Basket basket)
        {
            BasketRepository basketRepository;
            BasketItemRepository basketItemRepository;

            basketRepository = (BasketRepository)this._basketRepository;
            basketItemRepository = (BasketItemRepository)this._basketItemRepository;

            //удаление привязки корзины к ее элементам
            foreach (BasketItem item in basketItemRepository.FindAllByBasket(basket.Id))
            {
                item.BasketId = null;
                basketItemRepository.Edit(item);
            }

            basket.TotalAmount = 0;
            basket.DeliveryCost = 0;
            basketRepository.Edit(basket);
        }

        //Извлечение BasketItem из BasketItemView
        public BasketItem GetBasketItem(BasketItemView basketItemView)
        {
            BasketItem basketItem;
            BasketRepository basketRepository;
            BookVariableInfoRepository bookVariableInfoRepository;
            PaymentRepository paymentRepository;

            basketItem = new BasketItem()
            {
                Id = basketItemView.Id,
                Amount = basketItemView.Amount,
                BasketId = basketItemView.BasketId,
                BookVariableInfoId = basketItemView.BookVariableInfoId,
                ItemCount = basketItemView.ItemCount,
                PaymentId = basketItemView.PaymentId
            };

            basketItem.BookVariableInfo = (BookVariableInfo)
                this._bookVariableInfoRepository.FindById(
                basketItem.BookVariableInfoId);
            if (basketItem.BasketId != null)
                basketItem.Basket = (Basket)
                    this._basketRepository.FindById((Int32)basketItem.BasketId);
            if (basketItem.PaymentId != null)
                basketItem.Payment = (Payment)
                    this._paymentRepository.FindById((Int32)basketItem.PaymentId);

            return basketItem;
        }
    }
}