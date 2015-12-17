//-----------------------------------------------------------------------
// Репозиторий корзины.
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
    public class BasketRepository : BaseRepository, IDbModelRepository
    {
        private BookMarketDbContext db;
        private SqlConnection conn;

        public BasketRepository() : base() {
            db = new BookMarketDbContext();
        }

        public ModelToModel GetAll()
        {
            ModelToModel mm;

            mm = new ModelToModel();
            mm.baskets = new List<Basket>();
            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
                foreach (var entry in db.GetAllBaskets())
                    mm.baskets.Add(entry);
            //}
            return mm;
        }

        public object Add(object item)
        {
            Basket basket = (Basket)item;

            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
            return db.AddBasket(basket.TotalAmount, basket.DeliveryCost).First<Basket>();
            //}
            //return GetAll().baskets.Last();
        }

        public object FindById(Int32 id)
        {
            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
                var items = db.FindBasketById(id);
                var item = items.FirstOrDefault();
                return item;
            //}
        }

        public IList<string> GetNames()
        {
            return null;
        }

        public void Edit(Basket newBasket)
        {
            Basket oldBasket;

            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
                db.EditBasket(newBasket.Id, newBasket.TotalAmount,
                    newBasket.DeliveryCost);
            //}
        }
    }
}