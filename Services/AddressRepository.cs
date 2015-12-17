//-----------------------------------------------------------------------
// Репозиторий адреса.
//-----------------------------------------------------------------------
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookMarket.DbInfrastructure;
using BookMarket.Models;

namespace BookMarket.Services
{
    public class AddressRepository : BaseRepository, IDbModelRepository
    {
        private BookMarketDbContext db;
        private SqlConnection conn;

        public AddressRepository() : base()
        {
            db = new BookMarketDbContext();
        }

        public ModelToModel GetAll()
        {
            ModelToModel mm;

            mm = new ModelToModel();

            mm.addresses = new List<Address>();
            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
                foreach (Address entry in db.GetAllAddresses())
                {
                    mm.addresses.Add(entry);
                }
            //}
            return mm;
        }

        public object Add(object item)
        {
            return null;
        }

        public object FindById(Int32 id)
        {
            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
                var items = db.FindAddressById(id);
                var item = items.FirstOrDefault();
                return item;
            //}
        }

        public IList<string> GetNames()
        {
            return null;
        }

    }
}