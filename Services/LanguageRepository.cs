//-----------------------------------------------------------------------
// Репозиторий языка
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using BookMarket.DbInfrastructure;
using BookMarket.Models;

namespace BookMarket.Services
{
    public class LanguageRepository : BaseRepository, IDbModelRepository
    {
        private BookMarketDbContext db;
        private SqlConnection conn;

        public LanguageRepository()
            : base()
        {
            db = new BookMarketDbContext();
        }

        public ModelToModel GetAll()
        {
            ModelToModel mm;

            mm = new ModelToModel();
            mm.languages = new List<Language>();
            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
                foreach (var entry in db.GetAllLanguages())
                    mm.languages.Add(entry);
            //}
            return mm;
        }

        public object Add(object item)
        {
            Language language = (Language)item;

            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
            return db.AddLanguage(language.Name).First<Language>();
            //}
            //return GetAll().languages.Last();
        }

        public object FindById(Int32 id)
        {
            //using (BookMarketDbContext db = new BookMarketDbContext())
            //{
                var items = db.FindLanguageById(id);
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
                foreach (var entry in db.GetLanguageNames())
                    names.Add(entry);
            //}
            return names;
        }

        public List<SelectListItem> GetSelectItemList(
            IList<Language> values
            )
        {
            Int32 i = 0;
            List<SelectListItem> items;
            IEnumerable<SelectListItem> selectList;

            items = new List<SelectListItem>();
            foreach (Language value in values)
            {
                items.Add(new SelectListItem
                {
                    Value = Convert.ToString(value.Id),
                    Text = value.Name
                });
                i++;
            }
            return items;
        }

    }
}