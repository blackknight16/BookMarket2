//-----------------------------------------------------------------------
// Репозиторий платежа магазина
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using BookMarket.DbInfrastructure;
using BookMarket.Models;
using System.Data.Entity;

namespace BookMarket.Services
{
    public class PaymentRepository : BaseRepository, IDbModelRepository
    {
        private BookMarketDbContext db;
        private SqlConnection conn;

        public PaymentRepository()
            : base() {
            db = new BookMarketDbContext();
        }

        public ModelToModel GetAll()
        {
            ModelToModel mm;

            mm = new ModelToModel();
            mm.payments = new List<Payment>();
            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
                foreach (var entry in db.GetAllPayments())
                    mm.payments.Add(entry);
            //}
            return mm;
        }

        //Сначала должен быть добавлен W1Payment, так как
        //payment.Id == w1Payment.Id
        public object Add(object item)
        {
            Payment payment = (Payment)item;

            payment.isPayed = false; //пока администратор не изменит на true

            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
            return db.AddPayment(payment.Id, payment.isPayed, //payment.WebMoneyId,
                    payment.ShopId, payment.IndividualId).First<Payment>();
            //}
            //return GetAll().payments.Last();
        }

        public object FindById(Int32 id)
        {
            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
                var items = db.FindPaymentById(id);
                var item = items.FirstOrDefault();
                return item;
            //}
        }

        public IList<string> GetNames()
        {
            return null;
        }

        //oldPayment и newPayment указывают на один и тот же экземпляр, но
        //для надежности оставлю обмен значений полей
        public void Edit(Payment newPayment)
        {
            Payment oldPayment;

            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
                db.EditPayment(newPayment.Id, newPayment.isPayed, 
                    newPayment.ShopId, newPayment.IndividualId);
            //}
        }


    }
}