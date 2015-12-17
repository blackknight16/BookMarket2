//-----------------------------------------------------------------------
// Посредник перевода интерфейса из одной модели в другую.
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookMarket.Models;

namespace BookMarket.Services
{
    public class ModelToModel
    {
        public IList<Address> addresses { get; set; }
        public IList<Author> authors { get; set; }
        public IList<Basket> baskets { get; set; } 
        public IList<BasketItem> basketItems { get; set; } 
        public IList<Book> books { get; set; }
        public IList<BookTag> bookTags { get; set; }
        public IList<BookType> bookTypes { get; set; }
        public IList<BookVariableInfo> bookVariableInfoes { get; set; } 
        public IList<Individual> individuals { get; set; }
        public IList<Language> languages { get; set; }
        public IList<City> cities { get; set; } 
        public IList<Payment> payments { get; set; }
        public IList<Publisher> publishers { get; set; }
        public IList<Shop> shops { get; set; }
        public IList<Street> streets { get; set; }
        public IList<StreetType> streetTypes { get; set; }
        public IList<UserProfile> userProfile { get; set; } 
        public IList<W1Payment> w1Payments { get; set; }

        public ModelToModel()
        {
        }
    }
}