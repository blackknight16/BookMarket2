using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BookMarket.Models;
using BookMarket.Services;

namespace BookMarket.DbInfrastructure
{
    public partial class MarketDbInitializer
        //: DropCreateDatabaseAlways<BookMarketDbContext>
        : CreateDatabaseIfNotExists<BookMarketDbContext>
    {
        public override void InitializeDatabase(BookMarketDbContext dbContext)
        {
            base.InitializeDatabase(dbContext);

            //скрипты выполняются, только при создании бд
            if (MarketDbInitializer.DB_WAS_NOT_EXIST)// || _dbCounter == 0)
            {
                //Начало отсчета в W1Payments
                //- Убрать в publish
                dbContext.Database.ExecuteSqlCommand("DBCC CHECKIDENT ('W1Payments', RESEED, 122)");
                //-
                dbContext.Database.ExecuteSqlCommand(
                "USE [BookMarketDb]; " +
                "CREATE SEQUENCE[dbo].[BookSequence] " +
                "AS INT;");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[GetAllCities] AS " +
                "SELECT * " +
                "FROM [dbo].[Cities] ");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[GetAllBookVariableInfoes] AS  " +
                "SELECT * " +
                "FROM [dbo].[BookVariableInfoes];");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[GetAllIndividuals] AS  " +
                "SELECT * " +
                "FROM [dbo].[Individuals];");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[GetAllLanguages] AS  " +
                "SELECT * " +
                "FROM [dbo].[Languages];");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[GetAllPayments] AS  " +
                "SELECT * " +
                "FROM [dbo].[Payments];");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[GetAllPublishers] AS  " +
                "SELECT * " +
                "FROM [dbo].[Publishers];");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[GetAllShops] AS  " +
                "SELECT * " +
                "FROM [dbo].[Shops];");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[GetBookNames] AS  " +
                "SELECT [Name] " +
                "FROM [dbo].[Books];");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[GetBookTagNames] AS  " +
                "SELECT [Name] " +
                "FROM [dbo].[BookTags];");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[GetCityNames] AS  " +
                "SELECT [Name] " +
                "FROM [dbo].[Cities];");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[GetIndividualNames] AS  " +
                "SELECT [LastName] " +
                "FROM [dbo].[Individuals];");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[GetLanguageNames] AS  " +
                "SELECT [Name] " +
                "FROM [dbo].[Languages];");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[GetPublisherNames] AS  " +
                "SELECT [Name] " +
                "FROM [dbo].[Publishers];");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[GetShopNames] AS  " +
                "SELECT [Name] " +
                "FROM [dbo].[Shops];");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[GetUserProfileNames] AS  " +
                "SELECT [UserName] " +
                "FROM [dbo].[UserProfile];");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[AddAuthor] @LastName nvarchar(max), @FirstName nvarchar(max) AS  " +
                "INSERT INTO [dbo].[Authors]([LastName], [FirstName]) " +
                "OUTPUT [Inserted].* " +
                "VALUES(" +
                "(@LastName), (@FirstName));");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[AddBasket] @TotalAmount decimal(18,2), @DeliveryCost decimal(18,2) AS  " +
                "INSERT INTO [dbo].[Baskets]([TotalAmount], [DeliveryCost]) " +
                "OUTPUT [Inserted].* " +
                "VALUES(" +
                "(@TotalAmount), (@DeliveryCost));");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[AddBasketItem] @Amount decimal(18,2), @ItemCount int, @BookVariableInfoId int, @BasketId int, @PaymentId int AS  " +
                "INSERT INTO [dbo].[BasketItems]([Amount], [ItemCount], [BookVariableInfoId], [BasketId], [PaymentId])  " +
                "OUTPUT [Inserted].* " +
                "VALUES(" +
                "(@Amount), (@ItemCount), (@BookVariableInfoId), (@BasketId), (@PaymentId));");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[AddBook] @Name nvarchar(max), @Year int, @PageCount int, @ImageName nvarchar(max), @Description ntext, @LanguageId int AS  " +
                "INSERT INTO [dbo].[Books]([Name], [Year], [PageCount], [ImageName], [Description], [LanguageId])  " +
                "OUTPUT [Inserted].* " +
                "VALUES(" +
                "(@Name), (@Year), (@PageCount), (@ImageName), (@Description), (@LanguageId));");

                //return NULL!
                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[AddBookAuthor] @Book_Id int, @Author_Id int AS " +
                "declare @retorno int " +
                "INSERT INTO [dbo].[BookAuthors]([Book_Id], [Author_Id]) VALUES( " +
                "(@Book_Id), (@Author_Id)) " +
                "select @retorno;");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[AddBookTag] @Name nvarchar(max), @BookTypeId int AS  " +
                "INSERT INTO [dbo].[BookTags]([Name], [BookTypeId])   " +
                "OUTPUT [Inserted].* " +
                "VALUES( " +
                "(@Name), (@BookTypeId));");

                //return NULL!
                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[AddBookTagBook] @BookTag_Id int, @Book_Id int AS " +
                "declare @retorno int " +
                "INSERT INTO [dbo].[BookTagBooks]([BookTag_Id], [Book_Id]) VALUES( " +
                "(@BookTag_Id), (@Book_Id)) " +
                "select @retorno;");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[AddBookVariableInfo] @Id int, @ProductCount int, @Price decimal(18,2) AS  " +
                "INSERT INTO [dbo].[BookVariableInfoes]([Id], [ProductCount], [Price])  " +
                "OUTPUT [Inserted].* " +
                "VALUES( " +
                "(@Id), (@ProductCount), (@Price));");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[AddCity] @Name nvarchar(max) AS  " +
                "INSERT INTO [dbo].[Cities]([Name])  " +
                "OUTPUT [Inserted].* " +
                "VALUES( " +
                "(@Name));");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[AddIndividual] @BasketId int, @LastName nvarchar(max), @FirstName nvarchar(max), @MiddleName nvarchar(max) AS  " +
                "INSERT INTO [dbo].[Individuals]([Id], [LastName],[FirstName],[MiddleName])  " +
                "OUTPUT [Inserted].* " +
                "VALUES( " +
                "(@BasketId), (@LastName), (@FirstName), (@MiddleName));");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[AddLanguage] @Name nvarchar(max) AS  " +
                "INSERT INTO [dbo].[Languages]([Name]) " +
                "OUTPUT [Inserted].* " +
                "VALUES( " +
                "(@Name));");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[AddPayment] @W1PaymentId int, @isPayed bit, @ShopId int, @IndividualId int AS  " +
                "INSERT INTO [dbo].[Payments]([Id], [isPayed], [ShopId], [IndividualId]) " +
                "OUTPUT [Inserted].* " +
                "VALUES( " +
                "(@W1PaymentId), (@isPayed), (@ShopId), (@IndividualId));");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[AddPublisher] @Name nvarchar(max) AS  " +
                "INSERT INTO [dbo].[Publishers]([Name]) " +
                "OUTPUT [Inserted].* " +
                "VALUES( " +
                "(@Name));");

                //return NULL!
                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[AddPublisherBook] @Publisher_Id int, @Book_Id int AS " +
                "declare @retorno int " +
                "INSERT INTO [dbo].[PublisherBooks]([Publisher_Id], [Book_Id]) VALUES( " +
                "(@Publisher_Id), (@Book_Id)) " +
                "select @retorno;");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[AddW1Payment] @WMI_MERCHANT_ID nvarchar(max), @WMI_CURRENCY_ID int, @WMI_DESCRIPTION nvarchar(255), @WMI_EXPIRED_DATE datetime, @WMI_PAYMENT_AMOUNT decimal(18,2), @WMI_SIGNATURE varbinary(max) AS  " +
                "INSERT INTO [dbo].[W1Payments]([WMI_MERCHANT_ID], [WMI_CURRENCY_ID], [WMI_DESCRIPTION], [WMI_EXPIRED_DATE], [WMI_PAYMENT_AMOUNT], [WMI_SIGNATURE]) " +
                "OUTPUT [Inserted].* " +
                "VALUES( " +
                "(@WMI_MERCHANT_ID), (@WMI_CURRENCY_ID), (@WMI_DESCRIPTION), (@WMI_EXPIRED_DATE), (@WMI_PAYMENT_AMOUNT), (@WMI_SIGNATURE));");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[DeleteBasketItem] @Id int  AS  " +
                "declare @retorno int " +
                "DELETE " +
                "FROM [dbo].[BasketItems] " +
                "WHERE [Id] = (@Id) " +
                "select @retorno;");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[EditBasket] @Id int, @TotalAmount decimal(18,2), @DeliveryCost decimal(18,2) AS  " +
                "declare @retorno int " +
                "UPDATE [dbo].[Baskets] " +
                "SET [TotalAmount] = (@TotalAmount), " +
                "[DeliveryCost] = (@DeliveryCost) " +
                "WHERE [Id] = (@Id) " +
                "select @retorno;");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[EditBasketItem] @Id int, @Amount decimal(18,2), @ItemCount int, @BookVariableInfoId int, @BasketId int, @PaymentId int AS  " +
                "declare @retorno int " +
                "UPDATE [dbo].[BasketItems] " +
                "SET [Amount] = (@Amount), " +
                "[ItemCount] = (@ItemCount), " +
                "[BookVariableInfoId] = (@BookVariableInfoId), " +
                "[BasketId] = (@BasketId), " +
                "[PaymentId] = (@PaymentId) " +
                "WHERE [Id] = (@Id) " +
                "select @retorno;");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[EditPayment] @Id int, @isPayed bit, @ShopId int, @IndividualId int AS  " +
                "declare @retorno int " +
                "UPDATE [dbo].[Payments] " +
                "SET [isPayed] = (@isPayed), " +
                "[ShopId] = (@ShopId), " +
                "[IndividualId] = (@IndividualId) " +
                "WHERE [Id] = (@Id) " +
                "select @retorno;");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[EditBookVariableInfo] @BookId int, @ProductCount int, @Price decimal(18,2) AS  " +
                "declare @retorno int " +
                "UPDATE [dbo].[BookVariableInfoes] " +
                "SET [ProductCount] = (@ProductCount), " +
                "[Price] = (@Price) " +
                "WHERE [Id] = (@BookId) " +
                "select @retorno;");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[EditUserProfile] @UserId int, @Username nvarchar(max), @IndividualId int AS  " +
                "declare @retorno int " +
                "UPDATE [dbo].[UserProfile] " +
                "SET [UserName] = (@Username), " +
                "[IndividualId] = (@IndividualId) " +
                "WHERE [UserId] = (@UserId) " +
                "select @retorno;");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[EditW1Payment] @WMI_PAYMENT_NO int, @WMI_MERCHANT_ID nvarchar(max), @WMI_CURRENCY_ID int, @WMI_DESCRIPTION nvarchar(255), @WMI_EXPIRED_DATE datetime, @WMI_PAYMENT_AMOUNT decimal(18,2), @WMI_SIGNATURE varbinary(max) AS  " +
                "declare @retorno int " +
                "UPDATE [dbo].[W1Payments] " +
                "SET [WMI_MERCHANT_ID] = (@WMI_MERCHANT_ID), " +
                "[WMI_CURRENCY_ID] = (@WMI_CURRENCY_ID), " +
                "[WMI_DESCRIPTION] = (@WMI_DESCRIPTION), " +
                "[WMI_EXPIRED_DATE] = (@WMI_EXPIRED_DATE), " +
                "[WMI_PAYMENT_AMOUNT] = (@WMI_PAYMENT_AMOUNT), " +
                "[WMI_SIGNATURE] = (@WMI_SIGNATURE) " +
                "WHERE [WMI_PAYMENT_NO] = (@WMI_PAYMENT_NO) " +
                "select @retorno;");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[FindAddressById] @Id int AS  " +
                "SELECT *  " +
                "FROM [dbo].[Addresses] " +
                "WHERE [Id] = (@Id);");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[FindAllBasketItemsByBasket] @BasketId int  AS  " +
                "SELECT * " +
                "FROM [dbo].[BasketItems] " +
                "WHERE [BasketId] = (@BasketId);");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[FindAllShopsByCity] @CityId int AS  " +
                "SELECT * " +
                "FROM [dbo].[Shops] " +
                "WHERE [Id] IN (" +
                "SELECT [dbo].[Addresses].[Id] " +
                "FROM [dbo].[Addresses] " +
                "WHERE [dbo].[Addresses].[CityId] = (@CityId));");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[FindAuthorByFullName] @LastName nvarchar(max), @FirstName nvarchar(max) AS  " +
                "SELECT * " +
                "FROM [dbo].[Authors] " +
                "WHERE [LastName] = (@LastName) AND [FirstName] = (@FirstName);");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[FindAuthorById] @Id int AS  " +
                "SELECT * " +
                "FROM [dbo].[Authors] " +
                "WHERE [Id] = (@Id);");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[FindAuthorByLastName] @LastName nvarchar(max) AS  " +
                "SELECT * " +
                "FROM [dbo].[Authors] " +
                "WHERE [LastName] = (@LastName);");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[FindAllAuthorsByBook] @BookId int AS  " +
                "SELECT * " +
                "FROM [dbo].[Authors] " +
                "WHERE [Id] IN ( " +
                "SELECT [Author_Id] " +
                "FROM [dbo].[BookAuthors] " +
                "WHERE [Book_Id] IN ( " +
                "SELECT [dbo].[Books].[Id] " +
                "FROM [dbo].[Books] " +
                "WHERE [dbo].[Books].[Id] IN (@BookId)));");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[FindBasketById] @Id int AS  " +
                "SELECT * " +
                "FROM [dbo].[Baskets] " +
                "WHERE [Id] = (@Id);");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[FindBasketItemById] @Id int  AS  " +
                "SELECT * " +
                "FROM [dbo].[BasketItems] " +
                "WHERE [Id] = (@Id);");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[FindBasketItemsByPayment] @PaymentId int AS  " +
                "SELECT * " +
                "FROM [dbo].[BasketItems] " +
                "WHERE [PaymentId] IS NOT NULL AND " +
                "[PaymentId] = (@PaymentId);");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[FindBookById] @Id int AS  " +
                "SELECT * " +
                "FROM [dbo].[Books] " +
                "WHERE [Id] = (@Id);");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[FindBookTagById] @Id int AS  " +
                "SELECT * " +
                "FROM [dbo].[BookTags] " +
                "WHERE [Id] = (@Id);");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[FindBookTagsByBook] @BookId int AS  " +
                "SELECT * " +
                "FROM [dbo].[BookTags] " +
                "WHERE [Id] IN ( " +
                "SELECT [BookTag_Id] " +
                "FROM [dbo].[BookTagBooks] " +
                "WHERE [Book_Id] IN ( " +
                "SELECT [dbo].[Books].[Id] " +
                "FROM [dbo].[Books] " +
                "WHERE [dbo].[Books].[Id] IN (@BookId)));");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[FindBookTypeById] @Id int AS  " +
                "SELECT * " +
                "FROM [dbo].[BookTypes] " +
                "WHERE [Id] = (@Id);");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[FindBookVariableInfoByBookId] @Id int AS  " +
                "SELECT * " +
                "FROM [dbo].[BookVariableInfoes] " +
                "WHERE [Id] = ( " +
                "SELECT [dbo].[Books].[Id] " +
                "FROM [dbo].[Books] " +
                "WHERE [dbo].[Books].[Id] = (@Id)" +
                ");");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[FindBookVariableInfoById] @Id int AS  " +
                "SELECT * " +
                "FROM [dbo].[BookVariableInfoes] " +
                "WHERE [Id] = (@Id);");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[FindCityById] @Id int AS  " +
                "SELECT * " +
                "FROM [dbo].[Cities] " +
                "WHERE [Id] = (@Id);");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[FindIndividualById] @Id int AS  " +
                "SELECT * " +
                "FROM [dbo].[Individuals] " +
                "WHERE [Id] = (@Id);");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[FindIndividualByUserProfileName] @UserName nvarchar(max) AS  " +
                "SELECT * " +
                "FROM [dbo].[Individuals] " +
                "WHERE [Id] = ( " +
                "SELECT [UserId] " +
                "FROM [dbo].[UserProfile] " +
                "WHERE [UserName] = (@UserName));");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[FindLanguageById] @Id int AS  " +
                "SELECT * " +
                "FROM [dbo].[Languages] " +
                "WHERE [Id] = (@Id);");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[FindPaymentById] @Id int AS  " +
                "SELECT * " +
                "FROM [dbo].[Payments]" +
                "WHERE [Id] = (@Id);");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[FindPublisherById] @Id int AS  " +
                "SELECT * " +
                "FROM [dbo].[Publishers]" +
                "WHERE [Id] = (@Id);");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[FindPublishersByBook] @BookId int AS  " +
                "SELECT * " +
                "FROM [dbo].[Publishers] " +
                "WHERE [Id] IN ( " +
                "SELECT [Publisher_Id] " +
                "FROM [dbo].[PublisherBooks] " +
                "WHERE [dbo].[PublisherBooks].[Book_Id] IN ( " +
                "SELECT [dbo].[Books].[Id] " +
                "FROM [dbo].[Books] " +
                "WHERE [dbo].[Books].[Id] IN (@BookId)));");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[FindPublisherByName] @Name nvarchar(max) AS  " +
                "SELECT * " +
                "FROM [dbo].[Publishers] " +
                "WHERE [Name] = (@Name);");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[FindShopById] @Id int AS  " +
                "SELECT * " +
                "FROM [dbo].[Shops] " +
                "WHERE [Id] = (@Id);");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[FindStreetById] @Id int AS  " +
                "SELECT * " +
                "FROM [dbo].[Streets] " +
                "WHERE [Id] = (@Id);");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[FindStreetTypeById] @Id int AS  " +
                "SELECT * " +
                "FROM [dbo].[StreetTypes] " +
                "WHERE [Id] = (@Id);");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[FindUserProfileById] @Id int AS  " +
                "SELECT * " +
                "FROM [dbo].[UserProfile] " +
                "WHERE [UserId] = (@Id);");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[FindUserProfileByUserName] @UserName nvarchar(max) AS  " +
                "SELECT * " +
                "FROM [dbo].[UserProfile] " +
                "WHERE [UserName] = (@UserName);");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[FindW1PaymentById] @WMI_PAYMENT_NO int AS  " +
                "SELECT * " +
                "FROM [dbo].[W1Payments] " +
                "WHERE [WMI_PAYMENT_NO] = (@WMI_PAYMENT_NO);");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[GetAllAddresses] AS  " +
                "SELECT * " +
                "FROM [dbo].[Addresses];");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[GetAllAuthors]  AS  " +
                "SELECT * " +
                "FROM [dbo].[Authors];");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[GetAllBasketItems]  AS  " +
                "SELECT * " +
                "FROM [dbo].[BasketItems];");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[GetAllBaskets] AS  " +
                "SELECT * " +
                "FROM [dbo].[Baskets];");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[GetAllBooks] AS  " +
                "BEGIN " +
                "SELECT * " +
                "FROM [dbo].[Books] " +
                "END;");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[GetAllBooksByTagId] @TagId int, @FromVal int, @Increment int AS  " +
                "SELECT * " +
                "FROM[dbo].[Books] " +
                "WHERE[dbo].[Books].[Id] = ( " +
                "SELECT[Book_Id] " +
                "FROM[dbo].[BookTagBooks] " +
                "WHERE[Book_Id] = [dbo].[Books].[Id] AND[BookTag_Id] = (@TagId)) " +
                "ORDER BY[Id] " +
                "OFFSET(@FromVal) ROWS " +
                "FETCH NEXT(@Increment) ROWS ONLY; ");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[GetAllBooksCountByTagId] @TagId int, @Count int OUTPUT AS  " +
                "SET @Count = ( " +
                //"SELECT @Count = Count(*) " +
                "SELECT Count(*) " +
                "FROM[dbo].[Books] " +
                "WHERE[dbo].[Books].[Id] = ( " +
                "SELECT[Book_Id] " +
                "FROM[dbo].[BookTagBooks] " +
                "WHERE[Book_Id] = [dbo].[Books].[Id] AND[BookTag_Id] = ( " +
                "SELECT[dbo].[BookTags].[Id] " +
                "FROM[dbo].[BookTags] " +
                "WHERE[dbo].[BookTags].[Id] = (@TagId))) " +
                ") " +
                "select @Count;");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[GetAllBooksByTagName] @TagName nvarchar(max) AS  " +
                "SELECT * " +
                "FROM [dbo].[Books] " +
                "WHERE [dbo].[Books].[Id] = (" +
                "SELECT [Book_Id]" +
                "FROM [dbo].[BookTagBooks] " +
                "WHERE [Book_Id] = [dbo].[Books].[Id] AND [BookTag_Id] = ( " +
                "SELECT [dbo].[BookTags].[Id] " +
                "FROM [dbo].[BookTags] " +
                "WHERE [dbo].[BookTags].[Name] = (@TagName)));");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[GetAllBookTags] AS  " +
                "SELECT * " +
                "FROM [dbo].[BookTags];");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[GetAllBookTypes] AS  " +
                "SELECT * " +
                "FROM [dbo].[BookTypes];");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[GetAllStreets] AS  " +
                "SELECT * " +
                "FROM [dbo].[Streets];");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[GetBookTypeNames] AS  " +
                "SELECT [Name] " +
                "FROM [dbo].[BookTypes];");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[GetStreetNames] AS  " +
                "SELECT [Name] " +
                "FROM [dbo].[Streets];");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[GetStreetTypeNames] AS  " +
                "SELECT [Name] " +
                "FROM [dbo].[StreetTypes];");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[GetAllStreetTypes] AS  " +
                "SELECT * " +
                "FROM [dbo].[StreetTypes];");

                dbContext.Database.ExecuteSqlCommand(
                "CREATE PROCEDURE [dbo].[GetAllW1Payments] AS  " +
                "SELECT * " +
                "FROM [dbo].[W1Payments];");
            }
        }
    }
}