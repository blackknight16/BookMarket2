//-----------------------------------------------------------------------
// Репозиторий учетных записей пользователя интернет магазина.
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using BookMarket.DbInfrastructure;
using BookMarket.Models;

namespace BookMarket.Services
{
    public class UserProfileRepository : BaseRepository, IDbModelRepository
    {
        private BookMarketDbContext db;
        private SqlConnection conn;

        public UserProfileRepository()
            : base()
        {
            db = new BookMarketDbContext();
            //this.conn = new SqlConnection(SpecialConstants.CONNECTION_STRING);
            //this.db = new BookMarketDbContext(conn, true);
        }

        public ModelToModel GetAll()
        {
            return null;
        }

        public object Add(object item)
        {
            return null;
        }

        public object FindById(Int32 id)
        {
            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
                var items = db.FindUserProfileById(id);
                var item = items.FirstOrDefault();
                return item;
            //}
        }

        public UserProfile FindByUserName(string userName)
        {
            UserProfile item;

            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
                var items = db.FindUserProfileByUserName(userName).ToList();
                item = items.FirstOrDefault<UserProfile>();
                return item;
            //}
        }

        public IList<string> GetNames()
        {
            List<string> names;

            names = new List<string>();
            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
                foreach (var entry in db.GetUserProfileNames())
                    names.Add(entry);
            //}
            return names;
        }

        public void Edit(UserProfile newUserProfile)
        {
            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
                db.EditUserProfile(newUserProfile.UserId, newUserProfile.UserName,
                    newUserProfile.IndividualId);
            //}
        }
    }
}