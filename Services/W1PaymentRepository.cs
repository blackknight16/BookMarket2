//-----------------------------------------------------------------------
// Репозиторий оплаты в WalletOne.
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using BookMarket.DbInfrastructure;
using BookMarket.Models;

namespace BookMarket.Services
{
    public class W1PaymentRepository : BaseRepository, IDbModelRepository
    {
        private BookMarketDbContext db;
        private SqlConnection conn;

        public W1PaymentRepository()
            : base()
        {
            db = new BookMarketDbContext();
            //conn = new SqlConnection(SpecialConstants.CONNECTION_STRING);
            //db = new BookMarketDbContext(conn, true);

            //this.conn = new EntityConnection("name=&quotBookMarketDbConnectionString&quot providerName =&quotSystem.Data.SqlClient&quot connectionString=&quotData Source = (LocalDB)\\MSSQLLocalDB;&quot");   //"BookMarketDbConnectionString");
            //this.conn = new EntityConnection("provider=System.Data.SqlClient");
            //this.conn = new SqlConnection("BookMarketDbConnectionString");

            //this.conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=BookMarketDb;Integrated Security=True;MultipleActiveResultSets=true");
            //this.db = new BookMarketDbContext(conn, true);
        }

        ~W1PaymentRepository()
        {
            //this.conn
            this.db.Dispose();
        }

        public ModelToModel GetAll()
        {
            ModelToModel mm;
            List<W1Payment> list;

            mm = new ModelToModel();

            mm.w1Payments = new List<W1Payment>();
            //using (this.db = new BookMarketDbContext())
            //{
                //foreach (W1Payment entry in this.db.GetAllW1Payments())
                //{
                    mm.w1Payments = this.db.GetAllW1Payments().ToList<W1Payment>();
                //}
            //}
            //this.db.Database.Connection
            //}
            return mm;
        }

        public object Add(object item)
        {
            W1Payment w1Payment = (W1Payment)item;

            //using (this.db)
            //{
            return this.db.AddW1Payment(
                    w1Payment.WMI_MERCHANT_ID,
                    w1Payment.WMI_CURRENCY_ID, w1Payment.WMI_DESCRIPTION,
                    w1Payment.WMI_EXPIRED_DATE, w1Payment.WMI_PAYMENT_AMOUNT,
                    w1Payment.WMI_SIGNATURE).First<W1Payment>();
               //this.db.Database
            //}
            //return this.GetAll().w1Payments.Last();
        }

        public object FindById(Int32 id)
        {
            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
                var items = this.db.FindW1PaymentById(id);
                var item = items.FirstOrDefault();
                return item;
            //}
        }

        public IList<string> GetNames()
        {
            return null;
        }

        public void Edit(W1Payment newW1Payment)
        {
            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
                this.db.EditW1Payment(newW1Payment.WMI_PAYMENT_NO,
                    newW1Payment.WMI_MERCHANT_ID, newW1Payment.WMI_CURRENCY_ID,
                    newW1Payment.WMI_DESCRIPTION, newW1Payment.WMI_EXPIRED_DATE,
                    newW1Payment.WMI_PAYMENT_AMOUNT, newW1Payment.WMI_SIGNATURE);
            //}
        }
        
    }
}