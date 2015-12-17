//-----------------------------------------------------------------------
// Репозиторий персональных данных покупателя.
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using BookMarket.DbInfrastructure;
using BookMarket.Models;

namespace BookMarket.Services
{
    public class IndividualRepository : BaseRepository, IDbModelRepository
    {
        private BookMarketDbContext db;
        private SqlConnection conn;

        public IndividualRepository() : base() {
            db = new BookMarketDbContext();
        }

        public ModelToModel GetAll()
        {
            ModelToModel mm;

            mm = new ModelToModel();
            mm.individuals = new List<Individual>();
            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
                foreach (var entry in db.GetAllIndividuals())
                    mm.individuals.Add(entry);
            //}

            return mm;
        }

        public object Add(object item)
        {
            Individual individual;
            UserProfile userProfileOld;

            individual = (Individual)item;
            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
            return db.AddIndividual(individual.Id, individual.LastName,
                    individual.FirstName, individual.MiddleName).First<Individual>();
            //}

            //return GetAll().individuals.Last();
        }

        public object FindById(Int32 id)
        {
            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
                var items = db.FindIndividualById(id);
                var item = items.FirstOrDefault();
                return item;
            //}
        }

        public object FindIndividualByUserProfileName(string userProfileName)
        {
            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
                var items = db.FindIndividualByUserProfileName(userProfileName);
                var item = items.FirstOrDefault();
                return item;
            //}
        }

        public IList<string> GetNames()
        {
            List<string> names;

            names = new List<string>();
            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
                foreach (var entry in db.GetIndividualNames())
                    names.Add(entry);
            //}
            return names;
        }
    }
}