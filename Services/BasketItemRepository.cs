//-----------------------------------------------------------------------
// Репозиторий  элемента корзины
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookMarket.DbInfrastructure;
using BookMarket.Models;
using System.Data.Entity;

namespace BookMarket.Services
{
    public class BasketItemRepository : BaseRepository, IDbModelRepository
    {
        private BookMarketDbContext db;
        private SqlConnection conn;

        public BasketItemRepository() : base() {
            db = new BookMarketDbContext();
        }

        public ModelToModel GetAll()
        {
            ModelToModel mm;

            mm = new ModelToModel();
            mm.basketItems = new List<BasketItem>();
            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
                foreach (var entry in db.GetAllBasketItems())
                    mm.basketItems.Add(entry);
            //}
            return mm;
        }

        public object Add(object item)
        {
            BasketItem oldBasketItem;

            oldBasketItem = (BasketItem)item;

            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
            return db.AddBasketItem(oldBasketItem.Amount, oldBasketItem.ItemCount,
                    oldBasketItem.BookVariableInfoId, oldBasketItem.BasketId,
                    oldBasketItem.PaymentId).First<BasketItem>();
            //}

            //return GetAll().basketItems.Last();
        }

        public object FindById(Int32 id)
        {
            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
                var items = db.FindBasketItemById(id);
                var item = items.FirstOrDefault();
                return item;
            //}
        }

        public IList<string> GetNames()
        {
            return null;
        }

        public void Edit(BasketItem newBasketItem)
        {
            BasketItem oldBasketItem;

            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
                db.EditBasketItem(newBasketItem.Id, newBasketItem.Amount,
                    newBasketItem.ItemCount, newBasketItem.BookVariableInfoId,
                    newBasketItem.BasketId, newBasketItem.PaymentId);
            //}
        }

        public void Delete(Int32 basketItemId) //BasketItem basketItem)
        {
            BasketItem oldBasketItem;

            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
                db.DeleteBasketItem(basketItemId);
            //}

        }

        public IList<BasketItem> FindAllByBasket(Int32 basketId)
        {
            IList<BasketItem> items;

            items = new List<BasketItem>();
            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
                foreach (var entry in db.FindAllBasketItemsByBasket(basketId))
                    items.Add(entry);
            //}

            return items;
        }

        public IList<BasketItem> FindBasketItemsByPayment(Int32 paymentId)
        {
            IList<BasketItem> items;

            items = new List<BasketItem>();
            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
                foreach (var entry in db.FindBasketItemsByPayment(paymentId))
                    items.Add(entry);
            //}

            return items;
        }
    }
}