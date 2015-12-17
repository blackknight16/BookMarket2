//-----------------------------------------------------------------------
// Класс, создающий таблицы, а также служащий объектно-реляционной 
// ассоциацией для работы с БД. Он создает методы, запускающие 
// хранимые процедуры БД, позволяющие читать, изменять, создавать и 
// удалять записи БД.
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BookMarket.Models;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using CodeFirstStoreFunctions;
using System.Data.Entity.Core.EntityClient;
using System.Diagnostics;

namespace BookMarket.DbInfrastructure
{
    public class BookMarketDbContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BookVariableInfo> BookVariableInfoes { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookTag> BookTags { get; set; }
        public DbSet<BookType> BookTypes { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Individual> Individuals { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Street> Streets { get; set; }
        public DbSet<StreetType> StreetTypes { get; set; }
        public DbSet<W1Payment> W1Payments { get; set; }
        //public DbSet<T1> T1 { get; set; }
        //User
        public DbSet<UserProfile> UserProfile { get; set; }

        //protected static BookMarketDbContext _db = new BookMarketDbContext();

        public BookMarketDbContext()
            : base("BookMarketDbConnectionString")

        {

            Database.SetInitializer<BookMarketDbContext>(
                new MarketDbInitializer());

            //string log, log2;
            Database.Log = (string log) => Debug.Write(log);
        }
        

        public BookMarketDbContext(DbConnection dbConnection, bool contextOwnsConnection)
            //EntityConnection connection, bool contextOwnsConnection)
            //: base(connection, contextOwnsConnection)
            : base(dbConnection, contextOwnsConnection)
        {            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Add(
                new FunctionsConvention<BookMarketDbContext>("dbo"));
        }

        #region storeProcedures

        public ObjectResult<Author> AddAuthor (string lastName, string firstName)
        {
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));

            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<Author>("AddAuthor", lastNameParameter, firstNameParameter);
        }

        public ObjectResult<Basket> AddBasket(decimal totalAmount, decimal deliveryCost)
        {
            var totalAmountParameter = totalAmount != null ?
                new ObjectParameter("TotalAmount", totalAmount) :
                new ObjectParameter("TotalAmount", typeof(decimal));
            var deliveryCostParameter = deliveryCost != null ?
                new ObjectParameter("DeliveryCost", deliveryCost) :
                new ObjectParameter("DeliveryCost", typeof(decimal));

            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<Basket>("AddBasket", totalAmountParameter, deliveryCostParameter);
        }

        public ObjectResult<BasketItem> AddBasketItem(decimal amount, decimal itemCount, Int32 bookVariableInfoId, Int32? basketId, Int32? paymentId)
        {
            var amountParameter = amount != null ?
                new ObjectParameter("Amount", amount) :
                new ObjectParameter("Amount", typeof(decimal));
            var itemCountParameter = itemCount != null ?
                new ObjectParameter("ItemCount", itemCount) :
                new ObjectParameter("ItemCount", typeof(int));
            var bookVariableInfoParameter = bookVariableInfoId != null ?
                new ObjectParameter("BookVariableInfoId", bookVariableInfoId) :
                new ObjectParameter("BookVariableInfoId", typeof(int));
            var basketIdParameter = basketId != null ?
                new ObjectParameter("BasketId", basketId) :
                new ObjectParameter("BasketId", typeof(int));
            var paymentIdParameter = paymentId != null ?
                new ObjectParameter("PaymentId", paymentId) :
                new ObjectParameter("PaymentId", typeof(int));

            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<BasketItem>("AddBasketItem", amountParameter, 
                itemCountParameter, bookVariableInfoParameter, basketIdParameter, 
                paymentIdParameter);
        }

        public ObjectResult<Book> AddBook(string name, Int32 year, Int32 pageCount, 
            string imageName, string description, Int32 languageId)
        {
                var nameParameter = name != null ?
                    new ObjectParameter("Name", name) :
                    new ObjectParameter("Name", typeof(string));
                var yearParameter = year != null ?
                    new ObjectParameter("Year", year) :
                    new ObjectParameter("Year", typeof(Int32));
                var pageCountParameter = pageCount != null ?
                    new ObjectParameter("PageCount", pageCount) :
                    new ObjectParameter("PageCount", typeof(Int32));
                var imageNameParameter = imageName != null ?
                    new ObjectParameter("ImageName", imageName) :
                    new ObjectParameter("ImageName", typeof(string));
                var descriptionParameter = description != null ?
                    new ObjectParameter("Description", description) :
                    new ObjectParameter("Description", typeof(string));
                var languageIdParameter = languageId != null ?
                    new ObjectParameter("LanguageId", languageId) :
                    new ObjectParameter("LanguageId", typeof(Int32));

                return ((IObjectContextAdapter)this).ObjectContext
                    .ExecuteFunction<Book>("AddBook", nameParameter, yearParameter,
                    pageCountParameter, imageNameParameter, descriptionParameter,
                    languageIdParameter);
        }

        //must return NULL!
        public ObjectResult<Int32?> AddBookAuthor(Int32 book_Id, Int32 author_Id)
        {
            var book_IdParameter = book_Id != null ?
                new ObjectParameter("Book_Id", book_Id) :
                new ObjectParameter("Book_Id", typeof(Int32));
            var author_IdParameter = author_Id != null ?
                new ObjectParameter("Author_Id", author_Id) :
                new ObjectParameter("Author_Id", typeof(Int32));

            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<Int32?>("AddBookAuthor", book_IdParameter,
                author_IdParameter);
        }

        public ObjectResult<BookTag> AddBookTag(string name, Int32 bookTypeId)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
            var bookTypeIdParameter = bookTypeId != null ?
                new ObjectParameter("BookTypeId", bookTypeId) :
                new ObjectParameter("BookTypeId", typeof(int));

            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<BookTag>("AddBookTag", nameParameter,
                bookTypeIdParameter);
        }

        //must return NULL!
        public ObjectResult<Int32?> AddBookTagBook(Int32 bookTag_Id, Int32 book_Id)
        {
            var bookTag_IdParameter = bookTag_Id != null ?
                new ObjectParameter("BookTag_Id", bookTag_Id) :
                new ObjectParameter("BookTag_Id", typeof(Int32));
            var book_IdParameter = book_Id != null ?
                new ObjectParameter("Book_Id", book_Id) :
                new ObjectParameter("Book_Id", typeof(Int32));

            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<Int32?>("AddBookTagBook", bookTag_IdParameter,
                book_IdParameter );
        }

        public ObjectResult<BookVariableInfo> AddBookVariableInfo(Int32 id, 
            Int32 productCount, decimal price)
        {
            var idParameter = id != null ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(Int32));
            var productCountParameter = productCount != null ?
                new ObjectParameter("ProductCount", productCount) :
                new ObjectParameter("ProductCount", typeof(Int32));
            var priceParameter = price != null ?
                new ObjectParameter("Price", price) :
                new ObjectParameter("Price", typeof(decimal));

            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<BookVariableInfo>("AddBookVariableInfo", idParameter, 
                productCountParameter, priceParameter);
        }

        public ObjectResult<City> AddCity(string name)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));

            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<City>("AddCity", nameParameter);
        }

        public ObjectResult<Individual> AddIndividual(Int32 basketId, string lastName,
            string firstName, string middleName)
        {
            var basketIdParameter = basketId != null ?
                new ObjectParameter("BasketId", basketId) :
                new ObjectParameter("BasketId", typeof(Int32));
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));
            var middleNameParameter = middleName != null ?
                new ObjectParameter("MiddleName", middleName) :
                new ObjectParameter("MiddleName", typeof(string));

            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<Individual>("AddIndividual", basketIdParameter,
                lastNameParameter, firstNameParameter, middleNameParameter);
        }

        public ObjectResult<Language> AddLanguage(string name)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));

            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<Language>("AddLanguage", nameParameter);
        }

        public ObjectResult<Payment> AddPayment(Int32 w1PaymentId, bool isPayed, 
            Int32 shopId, Int32 individualId)
        {
            var w1PaymentIdParameter = w1PaymentId != null ?
                new ObjectParameter("W1PaymentId", w1PaymentId) :
                new ObjectParameter("W1PaymentId", typeof(Int32));
            var isPayedParameter = isPayed != null ?
                new ObjectParameter("isPayed", isPayed) :
                new ObjectParameter("isPayed", typeof(bool));
            var shopIdParameter = shopId != null ?
                new ObjectParameter("ShopId", shopId) :
                new ObjectParameter("ShopId", typeof(Int32));
            var individualIdParameter = individualId != null ?
                new ObjectParameter("IndividualId", individualId) :
                new ObjectParameter("IndividualId", typeof(Int32));

            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<Payment>("AddPayment", w1PaymentIdParameter,
                isPayedParameter, shopIdParameter, individualIdParameter);
        }

        public ObjectResult<Publisher> AddPublisher(string name)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));

            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<Publisher>("AddPublisher", nameParameter);
        }

        //must return NULL!
        public ObjectResult<Int32?> AddPublisherBook(Int32 publisher_Id,
            Int32 book_Id)
        {
            var publisher_IdParameter = publisher_Id != null ?
                new ObjectParameter("Publisher_Id", publisher_Id) :
                new ObjectParameter("Publisher_Id", typeof(Int32));
            var book_IdParameter = book_Id != null ?
                new ObjectParameter("Book_Id", book_Id) :
                new ObjectParameter("Book_Id", typeof(Int32));

            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<Int32?>("AddPublisherBook", publisher_IdParameter,
                book_IdParameter);
        }
        
        /*public ObjectResult<Int32?> AddWebMoney(string wmr, Int32 individualId)
        {
            var wmrParameter = wmr != null ?
                new ObjectParameter("WMR", wmr) :
                new ObjectParameter("WMR", typeof(string));
            var individualIdParameter = individualId != null ?
                new ObjectParameter("IndividualId", individualId) :
                new ObjectParameter("IndividualId", typeof(Int32));

            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<Int32?>("AddWebMoney", wmrParameter,
                individualIdParameter);
        }*/

        public ObjectResult<W1Payment> AddW1Payment(//Int32 wmi_payment_no, 
            string wmi_merchant_id, Int32 wmi_currency_id, string wmi_description, 
            DateTime wmi_expired_date, decimal wmi_payment_amount, 
            byte[] wmi_signature)
        {
            /*var wmi_payment_noParameter = wmi_payment_no != null ?
                new ObjectParameter("WMI_PAYMENT_NO", wmi_payment_no) :
                new ObjectParameter("WMI_PAYMENT_NO", typeof(Int32));*/
            var wmi_merchant_idParameter = wmi_merchant_id != null ?
                new ObjectParameter("WMI_MERCHANT_ID", wmi_merchant_id) :
                new ObjectParameter("WMI_MERCHANT_ID", typeof(string));
            var wmi_currency_idParameter = wmi_currency_id != null ?
                new ObjectParameter("WMI_CURRENCY_ID", wmi_currency_id) :
                new ObjectParameter("WMI_CURRENCY_ID", typeof(Int32));
            var wmi_descriptionParameter = wmi_description != null ?
                new ObjectParameter("WMI_DESCRIPTION", wmi_description) :
                new ObjectParameter("WMI_DESCRIPTION", typeof(string));
            var wmi_expired_dateParameter = wmi_expired_date != null ?
                new ObjectParameter("WMI_EXPIRED_DATE", wmi_expired_date) :
                new ObjectParameter("WMI_EXPIRED_DATE", typeof(DateTime));
            var wmi_payment_amountParameter = wmi_payment_amount != null ?
                new ObjectParameter("WMI_PAYMENT_AMOUNT", wmi_payment_amount) :
                new ObjectParameter("WMI_PAYMENT_AMOUNT", typeof(decimal));
            var wmi_signatureParameter = wmi_signature != null ?
                new ObjectParameter("WMI_SIGNATURE", wmi_signature) :
                new ObjectParameter("WMI_SIGNATURE", typeof(byte[]));

            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<W1Payment>("AddW1Payment", //wmi_payment_noParameter,
                wmi_merchant_idParameter, wmi_currency_idParameter,
                wmi_descriptionParameter,
                wmi_expired_dateParameter, wmi_payment_amountParameter,
                wmi_signatureParameter
                );
        }

        public ObjectResult<Int32?> DeleteBasketItem(Int32 id)
        {
            var idParameter = id != null ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(Int32));

            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<Int32?>("DeleteBasketItem", idParameter);
        }

        public ObjectResult<Int32?> EditBasket(Int32 id, decimal totalAmount,
            decimal deliveryCost)
        {
            var idParameter = id != null ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(Int32));
            var totalAmountParameter = totalAmount != null ?
                new ObjectParameter("TotalAmount", totalAmount) :
                new ObjectParameter("TotalAmount", typeof(decimal));
            var deliveryCostParameter = deliveryCost != null ?
                new ObjectParameter("DeliveryCost", deliveryCost) :
                new ObjectParameter("DeliveryCost", typeof(decimal));

            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<Int32?>("EditBasket", idParameter,
                totalAmountParameter, deliveryCostParameter);
        }

        public ObjectResult<Int32?> EditBasketItem(Int32 id, decimal amount,
            Int32 itemCount, Int32 bookVariableInfoId, Int32? basketId, 
            Int32? paymentId)
        {
            var idParameter = id != null ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(Int32));
            var amountParameter = amount != null ?
                new ObjectParameter("Amount", amount) :
                new ObjectParameter("Amount", typeof(decimal));
            var itemCountParameter = itemCount != null ?
                new ObjectParameter("ItemCount", itemCount) :
                new ObjectParameter("ItemCount", typeof(Int32));
            var bookVariableInfoParameter = bookVariableInfoId != null ?
                new ObjectParameter("BookVariableInfoId", bookVariableInfoId) :
                new ObjectParameter("BookVariableInfoId", typeof(Int32));
            var basketIdParameter = basketId != null ?
                new ObjectParameter("BasketId", basketId) :
                new ObjectParameter("BasketId", typeof(Int32));
            var paymentIdParameter = paymentId != null ?
                new ObjectParameter("PaymentId", paymentId) :
                new ObjectParameter("PaymentId", typeof(Int32));

            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<Int32?>("EditBasketItem", idParameter,
                amountParameter, itemCountParameter, bookVariableInfoParameter,
                basketIdParameter, paymentIdParameter);
        }

        public ObjectResult<Int32?> EditPayment(Int32 id, bool isPayed, 
            Int32? shopId, Int32 individualId)
        {
            var idParameter = id != null ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(Int32));
            var isPayedParameter = isPayed != null ?
                new ObjectParameter("isPayed", isPayed) :
                new ObjectParameter("isPayed", typeof(bool));
            var shopIdParameter = shopId != null ?
                new ObjectParameter("ShopId", shopId) :
                new ObjectParameter("ShopId", typeof(Int32));
            var individualIdParameter = individualId != null ?
                new ObjectParameter("IndividualId", individualId) :
                new ObjectParameter("IndividualId", typeof(Int32));

            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<Int32?>("EditPayment", idParameter, 
                isPayedParameter, shopIdParameter, individualIdParameter);
        }

        public ObjectResult<Int32?> EditBookVariableInfo(
            Int32 bookId, Int32 productCount, decimal price)
        {
            var bookIdParameter = bookId != null ?
                new ObjectParameter("BookId", bookId) :
                new ObjectParameter("BookId", typeof(Int32));
            var productCountParameter = productCount != null ?
                new ObjectParameter("ProductCount", productCount) :
                new ObjectParameter("ProductCount", typeof(Int32));
            var priceParameter = price != null ?
                new ObjectParameter("Price", price) :
                new ObjectParameter("Price", typeof(decimal));

            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<Int32?>("EditBookVariableInfo",
                bookIdParameter, productCountParameter, priceParameter);
        }

        public ObjectResult<Int32?> EditUserProfile(Int32 userId, 
            string userName, Int32? individualId)
        {
            var userIdParameter = userId != null ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(Int32));
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
            var individualIdParameter = individualId != null ?
                new ObjectParameter("IndividualId", individualId) :
                new ObjectParameter("IndividualId", typeof(Int32));

            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<Int32?>("EditUserProfile", userIdParameter,
                userNameParameter, individualIdParameter);
        }

        public ObjectResult<Int32?> EditW1Payment(Int32 wmi_payment_no,
            string wmi_merchant_id, Int32 wmi_currency_id, string wmi_description,
            DateTime wmi_expired_date, decimal wmi_payment_amount,
            byte[] wmi_signature)
        {
            var wmi_payment_noParameter = wmi_payment_no != null ?
                new ObjectParameter("WMI_PAYMENT_NO", wmi_payment_no) :
                new ObjectParameter("WMI_PAYMENT_NO", typeof(Int32));
            var wmi_merchant_idParameter = wmi_merchant_id != null ?
                new ObjectParameter("WMI_MERCHANT_ID", wmi_merchant_id) :
                new ObjectParameter("WMI_MERCHANT_ID", typeof(string));
            var wmi_currency_idParameter = wmi_currency_id != null ?
                new ObjectParameter("WMI_CURRENCY_ID", wmi_currency_id) :
                new ObjectParameter("WMI_CURRENCY_ID", typeof(Int32));
            var wmi_descriptionParameter = wmi_description != null ?
                new ObjectParameter("WMI_DESCRIPTION", wmi_description) :
                new ObjectParameter("WMI_DESCRIPTION", typeof(string));
            var wmi_expired_dateParameter = wmi_expired_date != null ?
                new ObjectParameter("WMI_EXPIRED_DATE", wmi_expired_date) :
                new ObjectParameter("WMI_EXPIRED_DATE", typeof(DateTime));
            var wmi_payment_amountParameter = wmi_payment_amount != null ?
                new ObjectParameter("WMI_PAYMENT_AMOUNT", wmi_payment_amount) :
                new ObjectParameter("WMI_PAYMENT_AMOUNT", typeof(decimal));
            var wmi_signatureParameter = wmi_signature != null ?
                new ObjectParameter("WMI_SIGNATURE", wmi_signature) :
                new ObjectParameter("WMI_SIGNATURE", typeof(byte[]));

            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<Int32?>("EditW1Payment", wmi_payment_noParameter,
                wmi_merchant_idParameter,
                wmi_currency_idParameter, wmi_descriptionParameter,
                wmi_expired_dateParameter, wmi_payment_amountParameter,
                wmi_signatureParameter
                );
        }

        public ObjectResult<Address> FindAddressById(Int32 id)
        {
            var idParameter = id != null ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(Int32));

            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<Address>("FindAddressById", idParameter);
        }


        public ObjectResult<BasketItem> FindAllBasketItemsByBasket(Int32 basketId)
        {
            var basketIdParameter = basketId != null ?
                new ObjectParameter("BasketId", basketId) :
                new ObjectParameter("BasketId", typeof(Int32));

            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<BasketItem>("FindAllBasketItemsByBasket", 
                basketIdParameter);
        }

        public ObjectResult<Shop> FindAllShopsByCity(Int32 cityId)
        {
            var cityIdParameter = cityId != null ?
                new ObjectParameter("CityId", cityId) :
                new ObjectParameter("CityId", typeof(Int32));

            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<Shop>("FindAllShopsByCity", cityIdParameter);
        }

        public ObjectResult<Author> FindAuthorByFullName(string lastName,
            string firstName)
        {
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));

            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<Author>("FindAuthorByFullName", lastNameParameter,
                firstNameParameter);
        }

        public ObjectResult<Author> FindAuthorByLastName(string lastName)
        {
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));

            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<Author>("FindAuthorByLastName", 
                lastNameParameter);
        }

        public ObjectResult<Author> FindAuthorById(Int32 id)
        {
            var idParameter = id != null ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(Int32));

            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<Author>("FindAuthorById", idParameter);
        }

        public ObjectResult<Author> FindAllAuthorsByBook(Int32 bookId)
        {
            var bookIdParameter = bookId != null ?
                new ObjectParameter("BookId", bookId) :
                new ObjectParameter("BookId", typeof(Int32));

            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<Author>("FindAllAuthorsByBook", bookIdParameter);
        }

        public ObjectResult<Basket> FindBasketById(Int32 id)
        {
            var idParameter = id != null ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(Int32));

            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<Basket>("FindBasketById", idParameter);
        }

        public ObjectResult<BasketItem> FindBasketItemById(Int32 id)
        {
            var idParameter = id != null ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(Int32));

            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<BasketItem>("FindBasketItemById", idParameter);
        }

        public ObjectResult<BasketItem> FindBasketItemsByPayment(Int32 paymentId)
        {
            var paymentIdParameter = paymentId != null ?
                new ObjectParameter("PaymentId", paymentId) :
                new ObjectParameter("PaymentId", typeof(Int32));

            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<BasketItem>("FindBasketItemsByPayment", 
                paymentIdParameter);
        }

        public ObjectResult<Book> FindBookById(Int32 id)
        {
            var idParameter = id != null ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(Int32));

            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<Book>("FindBookById", idParameter);
        }

        public ObjectResult<BookTag> FindBookTagById(Int32 id)
        {
            var idParameter = id != null ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(Int32));

            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<BookTag>("FindBookTagById", idParameter);
        }

        public ObjectResult<BookTag> FindBookTagsByBook(Int32 bookId)
        {
            var bookIdParameter = bookId != null ?
                new ObjectParameter("BookId", bookId) :
                new ObjectParameter("BookId", typeof(Int32));

            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<BookTag>("FindBookTagsByBook", bookIdParameter);
        }

        public ObjectResult<BookType> FindBookTypeById(Int32 id)
        {
            var idParameter = id != null ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(Int32));

            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<BookType>("FindBookTypeById", idParameter);
        }

        public ObjectResult<BookVariableInfo> FindBookVariableInfoByBookId(
            Int32 id)
        {
            var idParameter = id != null ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(Int32));

            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<BookVariableInfo>(
                "FindBookVariableInfoByBookId", idParameter);
        }

        public ObjectResult<BookVariableInfo> FindBookVariableInfoById(
            Int32 id)
        {
            var idParameter = id != null ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(Int32));

            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<BookVariableInfo>(
                "FindBookVariableInfoById", idParameter);
        }

        public ObjectResult<City> FindCityById(Int32 id)
        {
            var idParameter = id != null ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(Int32));

            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<City>("FindCityById", idParameter);
        }

        public ObjectResult<Individual> FindIndividualById(Int32 id)
        {
            var idParameter = id != null ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(Int32));

            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<Individual>("FindIndividualById", idParameter);
        }

        public ObjectResult<Individual> FindIndividualByUserProfileName(string userName)
        {
            var userProfileNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));

            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<Individual>("FindIndividualByUserProfileName", 
                userProfileNameParameter);
        }

        public ObjectResult<Language> FindLanguageById(Int32 id)
        {
            var idParameter = id != null ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(Int32));

            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<Language>("FindLanguageById", idParameter);
        }

        public ObjectResult<Payment> FindPaymentById(Int32 id)
        {
            var idParameter = id != null ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(Int32));

            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<Payment>("FindPaymentById", idParameter);
        }

        public ObjectResult<Publisher> FindPublisherById(Int32 id)
        {
            var idParameter = id != null ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(Int32));

            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<Publisher>("FindPublisherById", idParameter);
        }

        public ObjectResult<Publisher> FindPublishersByBook(Int32 bookId)
        {
            var bookIdParameter = bookId != null ?
                new ObjectParameter("BookId", bookId) :
                new ObjectParameter("BookId", typeof(Int32));

            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<Publisher>("FindPublishersByBook", bookIdParameter);
        }

        public ObjectResult<Publisher> FindPublisherByName(string name)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));

            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<Publisher>("FindPublisherByName", 
                nameParameter);
        }

        public ObjectResult<Shop> FindShopById(Int32 id)
        {
            var idParameter = id != null ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(Int32));

            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<Shop>("FindShopById", idParameter);
        }

        public ObjectResult<StreetType> FindStreetTypeById(Int32 id)
        {
            var idParameter = id != null ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(Int32));

            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<StreetType>("FindStreetTypeById", idParameter);
        }

        public ObjectResult<UserProfile> FindUserProfileById(Int32 id)
        {
            var idParameter = id != null ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(Int32));

            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<UserProfile>("FindUserProfileById", 
                idParameter);
        }

        public ObjectResult<UserProfile> FindUserProfileByUserName(
            string userName)
        {
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));

            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<UserProfile>("FindUserProfileByUserName", 
                userNameParameter);
        }

        public ObjectResult<Address> GetAllAddresses()
        {
            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<Address>("GetAllAddresses");
        }

        public ObjectResult<Author> GetAllAuthors()
        {
            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<Author>("GetAllAuthors");
        }

        public ObjectResult<BasketItem> GetAllBasketItems()
        {
            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<BasketItem>("GetAllBasketItems");
        }

        public ObjectResult<Basket> GetAllBaskets()
        {
            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<Basket>("GetAllBaskets");
            //this.ExecuteFunction<Book>("GetAllBooks");
        }

        public ObjectResult<Book> GetAllBooks()
        {
            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<Book>("GetAllBooks");
        }

        /*public ObjectResult<Book> GetAllBooks()
        {
            var res = ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<Book>("GetAllBooks");
            res.ToList<Book>();
            return res;
        }*/

        public ObjectResult<Book> GetAllBooksByTagId(Int32 tagId, Int32 fromVal, Int32 increment)
        {
            var tagIdParameter = tagId != null ?
                new ObjectParameter("TagId", tagId) :
                new ObjectParameter("TagId", typeof(Int32));
            var fromValParameter = fromVal != null ?
                new ObjectParameter("FromVal", fromVal) :
                new ObjectParameter("FromVal", typeof(Int32));
            var incrementParameter = increment != null ?
                new ObjectParameter("Increment", increment) :
                new ObjectParameter("Increment", typeof(Int32));

            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<Book>("GetAllBooksByTagId", tagIdParameter,
                fromValParameter, incrementParameter);
        }

        public ObjectResult<Int32> GetAllBooksCountByTagId(Int32 tagId//, out ObjectParameter Count
            )
        {
            var tagIdParameter = tagId != null ?
                new ObjectParameter("TagId", tagId) :
                new ObjectParameter("TagId", typeof(Int32));
            var Count = new ObjectParameter("Count", typeof(Int32));

            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<Int32>("GetAllBooksCountByTagId", 
                tagIdParameter, Count);

            //res.ToList(); // без него не получим вых.параметр
            //countParameter1 = Convert.ToInt32(countParameter.Value);
            //var count2 = countParameter;
            //countParameter = Convert.ToInt32(countParameter.Value);

            //return res;
        }

        public ObjectResult<Book> GetAllBooksByTagName(string tagName)
        {
            var tagNameParameter = tagName != null ?
                new ObjectParameter("TagName", tagName) :
                new ObjectParameter("TagName", typeof(string));

            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<Book>("GetAllBooksByTagName", tagNameParameter);
        }

        public ObjectResult<BookTag> GetAllBookTags()
        {
            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<BookTag>("GetAllBookTags");
        }

        public ObjectResult<BookType> GetAllBookTypes()
        {
            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<BookType>("GetAllBookTypes");
        }

        public ObjectResult<BookVariableInfo> GetAllBookVariableInfoes()
        {
            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<BookVariableInfo>("GetAllBookVariableInfoes");
        }

        public ObjectResult<City> GetAllCities()
        {
            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<City>("GetAllCities");
        }

        public ObjectResult<Individual> GetAllIndividuals()
        {
            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<Individual>("GetAllIndividuals");
        }

        public ObjectResult<Language> GetAllLanguages()
        {
            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<Language>("GetAllLanguages");
        }

        public ObjectResult<Payment> GetAllPayments()
        {
            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<Payment>("GetAllPayments");
        }

        public ObjectResult<Publisher> GetAllPublishers()
        {
            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<Publisher>("GetAllPublishers");
        }

        public ObjectResult<Shop> GetAllShops()
        {
            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<Shop>("GetAllShops");
        }

        public ObjectResult<Street> GetAllStreets()
        {
            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<Street>("GetAllStreets");
        }

        public ObjectResult<Street> FindStreetById(Int32 id)
        {
            var idParameter = id != null ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(Int32));

            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<Street>("FindStreetById", idParameter);
        }

        public ObjectResult<W1Payment> FindW1PaymentById(Int32 wmi_payment_no)
        {
            var wmi_payment_noParameter = wmi_payment_no != null ?
                new ObjectParameter("WMI_PAYMENT_NO", wmi_payment_no) :
                new ObjectParameter("WMI_PAYMENT_NO", typeof(Int32));

            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<W1Payment>("FindW1PaymentById",
                wmi_payment_noParameter);
        }

        public ObjectResult<StreetType> GetAllStreetTypes()
        {
            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<StreetType>("GetAllStreetTypes");
        }

        public ObjectResult<W1Payment> GetAllW1Payments()
        {
            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<W1Payment>("GetAllW1Payments");
        }

        public ObjectResult<string> GetBookNames()
        {
            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<string>("GetBookNames");
        }

        public ObjectResult<string> GetBookTagNames()
        {
            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<string>("GetBookTagNames");
        }

        public ObjectResult<string> GetBookTypeNames()
        {
            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<string>("GetBookTypeNames");
        }

        public ObjectResult<string> GetCityNames()
        {
            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<string>("GetCityNames");
        }

        public ObjectResult<string> GetIndividualNames()
        {
            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<string>("GetIndividualNames");
        }

        public ObjectResult<string> GetLanguageNames()
        {
            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<string>("GetLanguageNames");
        }

        public ObjectResult<string> GetPublisherNames()
        {
            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<string>("GetPublisherNames");
        }

        public ObjectResult<string> GetShopNames()
        {
            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<string>("GetShopNames");
        }

        public ObjectResult<string> GetStreetNames()
        {
            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<string>("GetStreetNames");
        }

        public ObjectResult<string> GetStreetTypeNames()
        {
            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<string>("GetStreetTypeNames");
        }

        public ObjectResult<string> GetUserProfileNames()
        {
            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<string>("GetUserProfileNames");
        }

        /*public ObjectResult<> A()
        {
            var Parameter =  != null ?
                new ObjectParameter("", ) :
                new ObjectParameter("", typeof());
            var Parameter =  != null ?
                new ObjectParameter("", ) :
                new ObjectParameter("", typeof());
            var Parameter =  != null ?
                new ObjectParameter("", ) :
                new ObjectParameter("", typeof());

            return ((IObjectContextAdapter)this).ObjectContext
                .ExecuteFunction<>("", 
                );
        }*/

        #endregion
    }
}