//-----------------------------------------------------------------------
// Инициализатор БД. Выполняет заполнение, редактирование таблиц и
// создает хранимые процедуры. Работает, как правило, при отсутствии БД
// в MSSQL Server.
// Класс разбит на несколько частей, так как возникают проблемы с 
// Resharper при большом файле.
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BookMarket.Models;
using BookMarket.Services;
using BookMarket.Controllers;

namespace BookMarket.DbInfrastructure
{
    public partial class MarketDbInitializer
        //: DropCreateDatabaseAlways<BookMarketDbContext>
        : CreateDatabaseIfNotExists<BookMarketDbContext>
    {
        public static bool DB_WAS_NOT_EXIST = false;
        private Int32 _dbCounter = ProductController._dbCounter;
        public static RegisterModel ADMIN_REGISTER_MODEL = new RegisterModel()
        {
            UserName = "admin",
            LastName = "Мулюков",
            FirstName = "Рустам",
            MiddleName = "Равилевич",
            Password = "walletone",
            ConfirmPassword = "walletone"
        };   

        IList<Publisher> defaultPublishers;
        IList<Language> defaultLanguages;
        IList<BookType> defaultBookTypes;
        IList<BookTag> defaultBookTags;
        IList<Author> defaultAuthors;
        IList<Book> defaultBooks;
        IList<BookVariableInfo> defaultBookVariableInfoes;
        IList<City> defaultCities;
        IList<Street> defaultStreets;
        IList<StreetType> defaultStreetTypes;
        IList<Address> defaultAddresses;
        IList<Shop> defaultShops;
        IList<UserProfile> defaultUserProfiles;
        IList<Individual> defaultIndividuals;
        Address address;
        Book newBook;
        BookVariableInfo bookVariableInfo;
        BookType bookType;
        BookTag ajaxTag, androidTag, aspNetTag, cDiesTag,
            commonDbTag, fDiesTag, haskellTag, iPhoneTag, javaTag,
            javascriptTag, microsoftSQLServerTag, mySQLTag, oracleDbTag,
            phpTag, postgreSQLTag, pythonTag,
            silverlightTag, windowsPhoneTag;
        Publisher piter, bhvPeterburg, bhvSanktPeterburg, kudicPress, ricSchola,
            russkayaRedakciya, williams, dialektika, dmkPress, gINFO,
            cambridgeAcadem, kudicObraz, lori, binom, laboratoriyaZnanii, bhv,
            simvolPlus, altLinux, solonPress, entrop, eksmo, folio, microsoftCorporation,
            internetUniversitetInformacionnihTechnologii, microsoftPress,
            noviiIzdatelskiiDom, naukaITechnika, ntPress, ridGrupp, aST, mIR,
            finansiIStatistica, mGTUImBaumana, geliosARV, dVGUPS, infraM,
            mashinostroenie, technosfera, izdatelstvoMGU, naukovaDumka, dialogMIFI,
            radianskaSchoola, nauka, nasledie, dialogSivir, logos, radioISvyas,
            gidDS, goryachayaLiniyaTelekom, triumf, diaSoftUP;
        Language rusLanguage, engLanguage;
        Publisher publisher;
        UserProfile userProfile;         

        protected override void Seed(BookMarketDbContext dbContext)
        {
            PartialSeed1(dbContext);
            PartialSeed2(dbContext);
            PartialSeed3(dbContext);
            PartialSeed4(dbContext);
            PartialSeed5(dbContext);
            PartialSeed6(dbContext);
            PartialSeed7(dbContext);
            PartialSeed8(dbContext);
            PartialSeed9(dbContext);
        }

        private void PartialSeed1(BookMarketDbContext dbContext)
        {
            defaultPublishers = new List<Publisher>();
            defaultPublishers.Add(new Publisher() { Name = "Питер" });
            defaultPublishers.Add(new Publisher() { Name = "БХВ-Петербург" });
            defaultPublishers.Add(new Publisher() { Name = "BHV - Санкт-Петербург" });
            defaultPublishers.Add(new Publisher() { Name = "Кудиц-Пресс" });
            defaultPublishers.Add(new Publisher() { Name = "РИЦ \"Школа\"" });
            defaultPublishers.Add(new Publisher() { Name = "Русская Редакция" });
            defaultPublishers.Add(new Publisher() { Name = "Вильямс" });
            defaultPublishers.Add(new Publisher() { Name = "Диалектика" });
            defaultPublishers.Add(new Publisher() { Name = "ДМК Пресс" });
            defaultPublishers.Add(new Publisher() { Name = "ГИНФО" });
            defaultPublishers.Add(new Publisher() { Name = "Cambridge Academ" });
            defaultPublishers.Add(new Publisher() { Name = "КУДИЦ-Образ" });
            defaultPublishers.Add(new Publisher() { Name = "Лори" });
            defaultPublishers.Add(new Publisher() { Name = "Бином" });
            defaultPublishers.Add(new Publisher() { Name = "Лаборатория знаний" });
            defaultPublishers.Add(new Publisher() { Name = "BHV" });
            defaultPublishers.Add(new Publisher() { Name = "Символ-Плюс" });
            defaultPublishers.Add(new Publisher() { Name = "Альт Линукс" });
            defaultPublishers.Add(new Publisher() { Name = "Интернет-университет информационных технологий" });
            defaultPublishers.Add(new Publisher() { Name = "СОЛОН-ПРЕСС" });
            defaultPublishers.Add(new Publisher() { Name = "Энтроп" });
            defaultPublishers.Add(new Publisher() { Name = "Новый издательский дом" });
            defaultPublishers.Add(new Publisher() { Name = "Эксмо" });
            defaultPublishers.Add(new Publisher() { Name = "Фолио" });
            defaultPublishers.Add(new Publisher() { Name = "Наука и техника" });
            defaultPublishers.Add(new Publisher() { Name = "НТ Пресс" });
            defaultPublishers.Add(new Publisher() { Name = "Рид Групп" });
            defaultPublishers.Add(new Publisher() { Name = "Microsoft Press" });
            defaultPublishers.Add(new Publisher() { Name = "Microsoft Corporation" });
            defaultPublishers.Add(new Publisher() { Name = "Финансы и статистика" });
            defaultPublishers.Add(new Publisher() { Name = "АСТ" });
            defaultPublishers.Add(new Publisher() { Name = "Мир" });
            defaultPublishers.Add(new Publisher() { Name = "МГТУ им. Н.Э. Баумана" });
            defaultPublishers.Add(new Publisher() { Name = "Гелиос АРВ" });
            defaultPublishers.Add(new Publisher() { Name = "ДВГУПС" });
            defaultPublishers.Add(new Publisher() { Name = "Машиностроение" });
            defaultPublishers.Add(new Publisher() { Name = "Инфра-М" });
            defaultPublishers.Add(new Publisher() { Name = "Техносфера" });
            defaultPublishers.Add(new Publisher() { Name = "Издательство МГУ" });
            defaultPublishers.Add(new Publisher() { Name = "Наукова думка" });
            defaultPublishers.Add(new Publisher() { Name = "Радянська школа" });
            defaultPublishers.Add(new Publisher() { Name = "Диалог-МИФИ" });
            defaultPublishers.Add(new Publisher() { Name = "Наука" });
            defaultPublishers.Add(new Publisher() { Name = "Наследие" });
            defaultPublishers.Add(new Publisher() { Name = "Диалог-Сибирь" });
            defaultPublishers.Add(new Publisher() { Name = "Радио и связь" });
            defaultPublishers.Add(new Publisher() { Name = "Логос" });
            defaultPublishers.Add(new Publisher() { Name = "ГИД ДС" });
            defaultPublishers.Add(new Publisher() { Name = "Горячая Линия-Телеком" });
            defaultPublishers.Add(new Publisher() { Name = "Триумф" });
            defaultPublishers.Add(new Publisher() { Name = "ДиаСофтЮП" });
            foreach (var element in defaultPublishers)
                dbContext.Publishers.Add(element);

            defaultLanguages = new List<Language>();
            defaultLanguages.Add(new Language() { Name = "Русский" });
            defaultLanguages.Add(new Language() { Name = "Английский" });
            foreach (var element in defaultLanguages)
                dbContext.Languages.Add(element);

            defaultBookTypes = new List<BookType>();
            defaultBookTypes.Add(new BookType() { Name = "Языки программирования" });
            defaultBookTypes.Add(new BookType() { Name = "Веб-программирование" });
            defaultBookTypes.Add(new BookType() { Name = "Программирование мобильных устройств" });
            defaultBookTypes.Add(new BookType() { Name = "Базы данных" });
            defaultBookTypes.Add(new BookType() { Name = "Разное" });
            foreach (var element in defaultBookTypes)
                dbContext.BookTypes.Add(element);

            defaultAuthors = new List<Author>();
            defaultAuthors.Add(new Author() { LastName = "Рихтер", FirstName = "Джеффри" });
            defaultAuthors.Add(new Author() { LastName = "Стиллмен", FirstName = "Э." });
            defaultAuthors.Add(new Author() { LastName = "Грин", FirstName = "Дж." });
            defaultAuthors.Add(new Author() { LastName = "Шапошников", FirstName = "Игорь" });
            defaultAuthors.Add(new Author() { LastName = "Мартынов", FirstName = "Н." });
            defaultAuthors.Add(new Author() { LastName = "Медведев", FirstName = "В." });
            defaultAuthors.Add(new Author() { LastName = "Купцевич", FirstName = "Ю." });
            defaultAuthors.Add(new Author() { LastName = "Агуров", FirstName = "Павел" });
            defaultAuthors.Add(new Author() { LastName = "Дэвис", FirstName = "Стефан" });
            defaultAuthors.Add(new Author() { LastName = "Сфер", FirstName = "Чак" });
            defaultAuthors.Add(new Author() { LastName = "Гарнаев", FirstName = "Андрей" });
            defaultAuthors.Add(new Author() { LastName = "Секунов", FirstName = "Николай" });
            defaultAuthors.Add(new Author() { LastName = "Уотсон", FirstName = "Карли" });
            defaultAuthors.Add(new Author() { LastName = "Нейгел", FirstName = "Кристиан" });
            defaultAuthors.Add(new Author() { LastName = "Педерсен", FirstName = "Якоб" });
            defaultAuthors.Add(new Author() { LastName = "Рид", FirstName = "Джон" });
            defaultAuthors.Add(new Author() { LastName = "Скиннер", FirstName = "Морган" });
            defaultAuthors.Add(new Author() { LastName = "Троелсен", FirstName = "Эндрю" });
            defaultAuthors.Add(new Author() { LastName = "Зиборов", FirstName = "Виктор" });
            defaultAuthors.Add(new Author() { LastName = "Герман", FirstName = "О." });
            defaultAuthors.Add(new Author() { LastName = "Герман", FirstName = "Ю." });
            defaultAuthors.Add(new Author() { LastName = "Нейгел", FirstName = "Кристиан" });
            defaultAuthors.Add(new Author() { LastName = "Ивьен", FirstName = "Билл" });
            defaultAuthors.Add(new Author() { LastName = "Глинн", FirstName = "Джей" });
            defaultAuthors.Add(new Author() { LastName = "Леве", FirstName = "Джувел" });
            defaultAuthors.Add(new Author() { LastName = "Ватсон", FirstName = "Бен" });
            defaultAuthors.Add(new Author() { LastName = "Мак-Дональд", FirstName = "Мэтью" });
            defaultAuthors.Add(new Author() { LastName = "Балена", FirstName = "Франческо" });
            defaultAuthors.Add(new Author() { LastName = "Димауро", FirstName = "Джузелле" });
            defaultAuthors.Add(new Author() { LastName = "Сошников", FirstName = "Дмитрий" });
            defaultAuthors.Add(new Author() { LastName = "Душкин", FirstName = "Р." });
            defaultAuthors.Add(new Author() { LastName = "Роганова", FirstName = "Н." });
            defaultAuthors.Add(new Author() { LastName = "Джонс", FirstName = "Саймон" });
            defaultAuthors.Add(new Author() { LastName = "Шилдт", FirstName = "Герберт" });
            defaultAuthors.Add(new Author() { LastName = "Дунаев", FirstName = "С." });
            defaultAuthors.Add(new Author() { LastName = "Хабибуллин", FirstName = "И." });
            defaultAuthors.Add(new Author() { LastName = "Шапошников", FirstName = "И." });
            defaultAuthors.Add(new Author() { LastName = "Баженова", FirstName = "И." });
            defaultAuthors.Add(new Author() { LastName = "Гери", FirstName = "Девид" });
            defaultAuthors.Add(new Author() { LastName = "Хорстманн", FirstName = "Кей" });
            defaultAuthors.Add(new Author() { LastName = "Блох", FirstName = "Джошуа" });
            defaultAuthors.Add(new Author() { LastName = "Пономарев", FirstName = "Вячеслав" });
            defaultAuthors.Add(new Author() { LastName = "Вебер", FirstName = "Джо" });
            defaultAuthors.Add(new Author() { LastName = "Кериевски", FirstName = "Джошуа" });
            defaultAuthors.Add(new Author() { LastName = "Холл", FirstName = "Марти" });
            defaultAuthors.Add(new Author() { LastName = "Браун", FirstName = "Лэрри" });
            defaultAuthors.Add(new Author() { LastName = "Лесневский", FirstName = "А." });
            defaultAuthors.Add(new Author() { LastName = "Смоленцев", FirstName = "Н." });
            defaultAuthors.Add(new Author() { LastName = "Хабибуллин", FirstName = "Ильдар" });
            defaultAuthors.Add(new Author() { LastName = "Давыдов", FirstName = "Станислав" });
            defaultAuthors.Add(new Author() { LastName = "Ефимов", FirstName = "Станислав" });
            defaultAuthors.Add(new Author() { LastName = "Ефимов", FirstName = "Алексей" });
            defaultAuthors.Add(new Author() { LastName = "Нильссон", FirstName = "Джимми" });
            defaultAuthors.Add(new Author() { LastName = "Шилдт", FirstName = "Герберт" });
            defaultAuthors.Add(new Author() { LastName = "Лутц", FirstName = "Марк" });
            defaultAuthors.Add(new Author() { LastName = "Бизли", FirstName = "Дэвид" });
            defaultAuthors.Add(new Author() { LastName = "Хахаев", FirstName = "И." });
            defaultAuthors.Add(new Author() { LastName = "Головатый", FirstName = "А." });
            defaultAuthors.Add(new Author() { LastName = "Каплан-Мосс", FirstName = "Д." });
            defaultAuthors.Add(new Author() { LastName = "Сегаран", FirstName = "Тоби" });
            defaultAuthors.Add(new Author() { LastName = "Форсье", FirstName = "Джефф" });
            defaultAuthors.Add(new Author() { LastName = "Биссекс", FirstName = "Пол" });
            defaultAuthors.Add(new Author() { LastName = "Чан", FirstName = "Уэсли" });
            defaultAuthors.Add(new Author() { LastName = "Саммерфилд", FirstName = "Марк" });
            defaultAuthors.Add(new Author() { LastName = "Гифт", FirstName = "Ноа" });
            defaultAuthors.Add(new Author() { LastName = "Джонс", FirstName = "Джереми" });
            defaultAuthors.Add(new Author() { LastName = "Сузи", FirstName = "Р." });
            defaultAuthors.Add(new Author() { LastName = "Петин", FirstName = "Виктор" });
            defaultAuthors.Add(new Author() { LastName = "Бенкен", FirstName = "Елена" });
            defaultAuthors.Add(new Author() { LastName = "Самков", FirstName = "Геннадий" });
            defaultAuthors.Add(new Author() { LastName = "Ленгсторф", FirstName = "Джейсон" });
            defaultAuthors.Add(new Author() { LastName = "Бибо", FirstName = "Бер" });
            defaultAuthors.Add(new Author() { LastName = "Кац", FirstName = "Иегуда" });
            defaultAuthors.Add(new Author() { LastName = "Эспозито", FirstName = "Дино" });
            defaultAuthors.Add(new Author() { LastName = "Крейн", FirstName = "Дейв" });
            defaultAuthors.Add(new Author() { LastName = "Паскарелло", FirstName = "Эрик" });
            defaultAuthors.Add(new Author() { LastName = "Даррен", FirstName = "Джеймс" });
            defaultAuthors.Add(new Author() { LastName = "Маклафлин", FirstName = "Бретт" });
            defaultAuthors.Add(new Author() { LastName = "Дари", FirstName = "Кристиан" });
            defaultAuthors.Add(new Author() { LastName = "Бринзаре", FirstName = "Богдан" });
            defaultAuthors.Add(new Author() { LastName = "Черчез-Тоза", FirstName = "Филип" });
            defaultAuthors.Add(new Author() { LastName = "Бусика", FirstName = "Михай" });
            defaultAuthors.Add(new Author() { LastName = "Фримен", FirstName = "Адам" });
            defaultAuthors.Add(new Author() { LastName = "Шпушта", FirstName = "Марио" });
            defaultAuthors.Add(new Author() { LastName = "Магдануров", FirstName = "Гайдар" });
            defaultAuthors.Add(new Author() { LastName = "Байдачный", FirstName = "С." });
            defaultAuthors.Add(new Author() { LastName = "Маленко", FirstName = "Д." });
            defaultAuthors.Add(new Author() { LastName = "Джонс", FirstName = "А." });
            defaultAuthors.Add(new Author() { LastName = "Сандерсон", FirstName = "Стивен" });
            defaultAuthors.Add(new Author() { LastName = "Пауэрс", FirstName = "Ларс" });
            defaultAuthors.Add(new Author() { LastName = "Снелл", FirstName = "Майк" });
            defaultAuthors.Add(new Author() { LastName = "Microsoft Corporation" });
            defaultAuthors.Add(new Author() { LastName = "Шорт", FirstName = "Скотт" });
            defaultAuthors.Add(new Author() { LastName = "Барнет", FirstName = "Марк" });
            defaultAuthors.Add(new Author() { LastName = "Фостер", FirstName = "Джеймс" });
            defaultAuthors.Add(new Author() { LastName = "Платт", FirstName = "Дэвид" });
            defaultAuthors.Add(new Author() { LastName = "Будилов", FirstName = "Вадим" });
            defaultAuthors.Add(new Author() { LastName = "Постолит", FirstName = "Анатолий" });
            defaultAuthors.Add(new Author() { LastName = "Просиз", FirstName = "Джеф" });
            defaultAuthors.Add(new Author() { LastName = "Джонсон", FirstName = "Гленн" });
            defaultAuthors.Add(new Author() { LastName = "Нортроп", FirstName = "Тони" });
            defaultAuthors.Add(new Author() { LastName = "Феррара", FirstName = "Алекс" });
            defaultAuthors.Add(new Author() { LastName = "Хэррон", FirstName = "Дэвид" });
            defaultAuthors.Add(new Author() { LastName = "Каслдайн", FirstName = "Эрл" });
            defaultAuthors.Add(new Author() { LastName = "Шарки", FirstName = "Крэйг" });
            defaultAuthors.Add(new Author() { LastName = "Флэнаган", FirstName = "Дэвид" });
            defaultAuthors.Add(new Author() { LastName = "Маккоу", FirstName = "Алекс" });
            defaultAuthors.Add(new Author() { LastName = "Закас", FirstName = "Николас" });
            defaultAuthors.Add(new Author() { LastName = "Моррисон", FirstName = "Майкл" });
            defaultAuthors.Add(new Author() { LastName = "Прохоренок", FirstName = "Николай" });
            defaultAuthors.Add(new Author() { LastName = "Дмитриева", FirstName = "Марина" });
            defaultAuthors.Add(new Author() { LastName = "Дронов", FirstName = "Владимир" });
            defaultAuthors.Add(new Author() { LastName = "Стефанов", FirstName = "Стоян" });
            defaultAuthors.Add(new Author() { LastName = "Чаффер", FirstName = "Джонатан" });
            defaultAuthors.Add(new Author() { LastName = "Шведберг", FirstName = "Карл" });
            defaultAuthors.Add(new Author() { LastName = "Рейсиг", FirstName = "Джон" });
            defaultAuthors.Add(new Author() { LastName = "Рева", FirstName = "О." });
            defaultAuthors.Add(new Author() { LastName = "Глушаков", FirstName = "С." });
            defaultAuthors.Add(new Author() { LastName = "Жакин", FirstName = "И." });
            defaultAuthors.Add(new Author() { LastName = "Хачиров", FirstName = "Т." });
            defaultAuthors.Add(new Author() { LastName = "Ньюман", FirstName = "Крис" });
            defaultAuthors.Add(new Author() { LastName = "Васвани", FirstName = "Викрам" });
            defaultAuthors.Add(new Author() { LastName = "Бейли", FirstName = "Линн" });
            defaultAuthors.Add(new Author() { LastName = "Моррисон", FirstName = "Майкл" });
            defaultAuthors.Add(new Author() { LastName = "Никсон", FirstName = "Робин" });
            defaultAuthors.Add(new Author() { LastName = "Леки-Томпсон", FirstName = "Эд" });
            defaultAuthors.Add(new Author() { LastName = "Айде-Гудман", FirstName = "Хьяо" });
            defaultAuthors.Add(new Author() { LastName = "Коув", FirstName = "Алек" });
            defaultAuthors.Add(new Author() { LastName = "Новицки", FirstName = "Стивен" });
            defaultAuthors.Add(new Author() { LastName = "Скляр", FirstName = "Д." });
            defaultAuthors.Add(new Author() { LastName = "Трахтенберг", FirstName = "Э." });
            defaultAuthors.Add(new Author() { LastName = "Суэринг", FirstName = "Стив" });
            defaultAuthors.Add(new Author() { LastName = "Конверс", FirstName = "Тим" });
            defaultAuthors.Add(new Author() { LastName = "Парк", FirstName = "Джойс" });
            defaultAuthors.Add(new Author() { LastName = "Кузнецов", FirstName = "Вадим" });
            defaultAuthors.Add(new Author() { LastName = "Самдянов", FirstName = "Игорь" });
            defaultAuthors.Add(new Author() { LastName = "Харрингтон", FirstName = "Джек" });
            defaultAuthors.Add(new Author() { LastName = "Колисниченко", FirstName = "Денис" });
            defaultAuthors.Add(new Author() { LastName = "Зандстра", FirstName = "Мэтт" });
            defaultAuthors.Add(new Author() { LastName = "Мерсер", FirstName = "Дэйв" });
            defaultAuthors.Add(new Author() { LastName = "Мерсер", FirstName = "Девид" });
            defaultAuthors.Add(new Author() { LastName = "Кент", FirstName = "Аллан" });
            defaultAuthors.Add(new Author() { LastName = "Новицки", FirstName = "Стивен" });
            defaultAuthors.Add(new Author() { LastName = "Скуайер", FirstName = "Дэн" });
            defaultAuthors.Add(new Author() { LastName = "Чой", FirstName = "Ван" });
            defaultAuthors.Add(new Author() { LastName = "Дэвис", FirstName = "Мишель" });
            defaultAuthors.Add(new Author() { LastName = "Филлипс", FirstName = "Джон" });
            defaultAuthors.Add(new Author() { LastName = "Зервас", FirstName = "Квентин" });
            defaultAuthors.Add(new Author() { LastName = "Стейнмец", FirstName = "Уильям" });
            defaultAuthors.Add(new Author() { LastName = "Вард", FirstName = "Брайн" });
            defaultAuthors.Add(new Author() { LastName = "Кузнецов", FirstName = "Вадим" });
            defaultAuthors.Add(new Author() { LastName = "Симдянов", FirstName = "Игорь" });
            defaultAuthors.Add(new Author() { LastName = "Ловэйн", FirstName = "Питер" });
            defaultAuthors.Add(new Author() { LastName = "Байдачный", FirstName = "С." });
            defaultAuthors.Add(new Author() { LastName = "Дейтел", FirstName = "П." });
            defaultAuthors.Add(new Author() { LastName = "Дейтел", FirstName = "Х." });
            defaultAuthors.Add(new Author() { LastName = "Дейтел", FirstName = "Э." });
            defaultAuthors.Add(new Author() { LastName = "Моргано", FirstName = "М." });
            defaultAuthors.Add(new Author() { LastName = "Хашими", FirstName = "С." });
            defaultAuthors.Add(new Author() { LastName = "Коматинени", FirstName = "С." });
            defaultAuthors.Add(new Author() { LastName = "Маклин", FirstName = "Д." });
            defaultAuthors.Add(new Author() { LastName = "Майер", FirstName = "Рето" });
            defaultAuthors.Add(new Author() { LastName = "Дэрси", FirstName = "Лорен" });
            defaultAuthors.Add(new Author() { LastName = "Кондер", FirstName = "Шейн" });
            defaultAuthors.Add(new Author() { LastName = "Голощапов", FirstName = "Алексей" });
            defaultAuthors.Add(new Author() { LastName = "Али", FirstName = "Махер" });
            defaultAuthors.Add(new Author() { LastName = "Пайлон", FirstName = "Д." });
            defaultAuthors.Add(new Author() { LastName = "Пайлон", FirstName = "Т." });
            defaultAuthors.Add(new Author() { LastName = "Марк", FirstName = "Дэйв" });
            defaultAuthors.Add(new Author() { LastName = "Наттинг", FirstName = "Джек" });
            defaultAuthors.Add(new Author() { LastName = "Ламарш", FirstName = "Джефф" });
            defaultAuthors.Add(new Author() { LastName = "Далримпл", FirstName = "Марк" });
            defaultAuthors.Add(new Author() { LastName = "Кнастер", FirstName = "Скотт" });
            defaultAuthors.Add(new Author() { LastName = "Здзиарски", FirstName = "Джонатан" });
            defaultAuthors.Add(new Author() { LastName = "Петзольд", FirstName = "Ч." });
            defaultAuthors.Add(new Author() { LastName = "Риккарди", FirstName = "Грег" });
            defaultAuthors.Add(new Author() { LastName = "Бейли", FirstName = "Линн" });
            defaultAuthors.Add(new Author() { LastName = "Новиков", FirstName = "Б." });
            defaultAuthors.Add(new Author() { LastName = "Добровская", FirstName = "Г." });
            defaultAuthors.Add(new Author() { LastName = "Наумов", FirstName = "А." });
            defaultAuthors.Add(new Author() { LastName = "Кириллов", FirstName = "В." });
            defaultAuthors.Add(new Author() { LastName = "Громов", FirstName = "Г." });
            defaultAuthors.Add(new Author() { LastName = "Глушаков", FirstName = "С." });
            defaultAuthors.Add(new Author() { LastName = "Ломотько", FirstName = "Д." });
            defaultAuthors.Add(new Author() { LastName = "Грабер", FirstName = "Мартин" });
            defaultAuthors.Add(new Author() { LastName = "Бьюли", FirstName = "Алан" });
            defaultAuthors.Add(new Author() { LastName = "Рудикова", FirstName = "Л." });
            defaultAuthors.Add(new Author() { LastName = "Молинаро", FirstName = "Энтони" });
            defaultAuthors.Add(new Author() { LastName = "Тиори", FirstName = "Т." });
            defaultAuthors.Add(new Author() { LastName = "Фрай", FirstName = "Дж." });
            defaultAuthors.Add(new Author() { LastName = "Фаро", FirstName = "Стефан" });
            defaultAuthors.Add(new Author() { LastName = "Паскаль", FirstName = "Лерми" });
            defaultAuthors.Add(new Author() { LastName = "Григорьев", FirstName = "Ю." });
            defaultAuthors.Add(new Author() { LastName = "Ревунков", FirstName = "Г." });
            defaultAuthors.Add(new Author() { LastName = "Саймон", FirstName = "Алан" });
            defaultAuthors.Add(new Author() { LastName = "Гарсиа-Молина", FirstName = "Гектор" });
            defaultAuthors.Add(new Author() { LastName = "Ульман", FirstName = "Джеффри" });
            defaultAuthors.Add(new Author() { LastName = "Уидом", FirstName = "Дженнифер" });
            defaultAuthors.Add(new Author() { LastName = "Гайдамакин", FirstName = "Н." });
            defaultAuthors.Add(new Author() { LastName = "Боуман", FirstName = "Дж." });
            defaultAuthors.Add(new Author() { LastName = "Эмерсон", FirstName = "С." });
            defaultAuthors.Add(new Author() { LastName = "Дарновски", FirstName = "М." });
            defaultAuthors.Add(new Author() { LastName = "Фиайли", FirstName = "Крис" });
            defaultAuthors.Add(new Author() { LastName = "Архангельский", FirstName = "А." });
            defaultAuthors.Add(new Author() { LastName = "Хернандес", FirstName = "Майкл" });
            defaultAuthors.Add(new Author() { LastName = "Вьескас", FirstName = "Джон" });
            defaultAuthors.Add(new Author() { LastName = "Бейли", FirstName = "Линн" });
            defaultAuthors.Add(new Author() { LastName = "Моррисон", FirstName = "Майкл" });
            defaultAuthors.Add(new Author() { LastName = "Никсон", FirstName = "Робин" });
            defaultAuthors.Add(new Author() { LastName = "Шварц", FirstName = "Барон" });
            defaultAuthors.Add(new Author() { LastName = "Зайцев", FirstName = "Петр" });
            defaultAuthors.Add(new Author() { LastName = "Ткаченко", FirstName = "Вадим" });
            defaultAuthors.Add(new Author() { LastName = "Заводны", FirstName = "Джереми" });
            defaultAuthors.Add(new Author() { LastName = "Ленц", FirstName = "Арьем" });
            defaultAuthors.Add(new Author() { LastName = "Боллинг", FirstName = "Дерек" });
            defaultAuthors.Add(new Author() { LastName = "Гольцман", FirstName = "Виктор" });
            defaultAuthors.Add(new Author() { LastName = "Кузнецов", FirstName = "Вадим" });
            defaultAuthors.Add(new Author() { LastName = "Симдянов", FirstName = "Игорь" });
            defaultAuthors.Add(new Author() { LastName = "Веллинг", FirstName = "Люк" });
            defaultAuthors.Add(new Author() { LastName = "Яргер", FirstName = "Ренди" });
            defaultAuthors.Add(new Author() { LastName = "Риз", FirstName = "Джордж" });
            defaultAuthors.Add(new Author() { LastName = "Кинг", FirstName = "Тим" });
            defaultAuthors.Add(new Author() { LastName = "Ульман", FirstName = "Ларри" });
            defaultAuthors.Add(new Author() { LastName = "Аткинсон", FirstName = "Леон" });
            defaultAuthors.Add(new Author() { LastName = "Дюбуа", FirstName = "Поль" });
            defaultAuthors.Add(new Author() { LastName = "Артеменко", FirstName = "Ю." });
            defaultAuthors.Add(new Author() { LastName = "Глушаков", FirstName = "Ломотько" });
            defaultAuthors.Add(new Author() { LastName = "Волоха", FirstName = "Александр" });
            defaultAuthors.Add(new Author() { LastName = "Мамаев", FirstName = "Е." });
            defaultAuthors.Add(new Author() { LastName = "Фленов", FirstName = "Михаил" });
            defaultAuthors.Add(new Author() { LastName = "Барсегян", FirstName = "А." });
            defaultAuthors.Add(new Author() { LastName = "Харинатх", FirstName = "Сивакумар" });
            defaultAuthors.Add(new Author() { LastName = "Куинн", FirstName = "Стивен" });
            defaultAuthors.Add(new Author() { LastName = "Виейра", FirstName = "Роберт" });
            defaultAuthors.Add(new Author() { LastName = "Бергер", FirstName = "А." });
            defaultAuthors.Add(new Author() { LastName = "Барсегян", FirstName = "А." });
            defaultAuthors.Add(new Author() { LastName = "Куприянов", FirstName = "М." });
            defaultAuthors.Add(new Author() { LastName = "Степаненко", FirstName = "В." });
            defaultAuthors.Add(new Author() { LastName = "Холод", FirstName = "И." });
            defaultAuthors.Add(new Author() { LastName = "Гурвиц", FirstName = "Г." });
            defaultAuthors.Add(new Author() { LastName = "Малкольм", FirstName = "Грэм" });
            defaultAuthors.Add(new Author() { LastName = "Артемов", FirstName = "Д." });
            defaultAuthors.Add(new Author() { LastName = "Погульский", FirstName = "Г." });
            defaultAuthors.Add(new Author() { LastName = "Макмен", FirstName = "Алекс" });
            defaultAuthors.Add(new Author() { LastName = "Брукс", FirstName = "Крис" });
            defaultAuthors.Add(new Author() { LastName = "Басби", FirstName = "Стив" });
            defaultAuthors.Add(new Author() { LastName = "Нильсон", FirstName = "Пол" });
            defaultAuthors.Add(new Author() { LastName = "Нильсон", FirstName = "Джимми" });
            defaultAuthors.Add(new Author() { LastName = "Гарбус", FirstName = "Джеффри" });
            defaultAuthors.Add(new Author() { LastName = "Паскузи", FirstName = "Дэвид" });
            defaultAuthors.Add(new Author() { LastName = "Чанг", FirstName = "Энтони" });
            defaultAuthors.Add(new Author() { LastName = "Браст", FirstName = "Эндрю" });
            defaultAuthors.Add(new Author() { LastName = "Форте", FirstName = "С." });
            defaultAuthors.Add(new Author() { LastName = "Хендерсон", FirstName = "Кен" });
            defaultAuthors.Add(new Author() { LastName = "Дэвидсон", FirstName = "Луис" });
            defaultAuthors.Add(new Author() { LastName = "Гринвальд", FirstName = "Рик" });
            defaultAuthors.Add(new Author() { LastName = "Стаковьяк", FirstName = "Роберт" });
            defaultAuthors.Add(new Author() { LastName = "Стерн", FirstName = "Джонатан" });
            defaultAuthors.Add(new Author() { LastName = "Терьо", FirstName = "Марлен" });
            defaultAuthors.Add(new Author() { LastName = "Соломон", FirstName = "Мартин" });
            defaultAuthors.Add(new Author() { LastName = "Мориссо-Леруа", FirstName = "Нирва" });
            defaultAuthors.Add(new Author() { LastName = "Басу", FirstName = "Джули" });
            defaultAuthors.Add(new Author() { LastName = "Урман", FirstName = "Скотт" });
            defaultAuthors.Add(new Author() { LastName = "Хоббс", FirstName = "Лилиан" });
            defaultAuthors.Add(new Author() { LastName = "Хилсон", FirstName = "Сьюзан" });
            defaultAuthors.Add(new Author() { LastName = "Лоуенд", FirstName = "Шилпа" });
            defaultAuthors.Add(new Author() { LastName = "Чанг", FirstName = "Бен" });
            defaultAuthors.Add(new Author() { LastName = "Скардина", FirstName = "Марк" });
            defaultAuthors.Add(new Author() { LastName = "Киритцов", FirstName = "Стефан" });
            defaultAuthors.Add(new Author() { LastName = "Льюис", FirstName = "Дж." });
            defaultAuthors.Add(new Author() { LastName = "Перри", FirstName = "Джеймс" });
            defaultAuthors.Add(new Author() { LastName = "Пост", FirstName = "Джеральд" });
            defaultAuthors.Add(new Author() { LastName = "Нанда", FirstName = "Аруп" });
            defaultAuthors.Add(new Author() { LastName = "Фейерштейн", FirstName = "Стивен" });
            defaultAuthors.Add(new Author() { LastName = "Мишра", FirstName = "Санжей" });
            defaultAuthors.Add(new Author() { LastName = "Бьюли", FirstName = "Алан" });
            defaultAuthors.Add(new Author() { LastName = "Аллен", FirstName = "Кристофер" });
            defaultAuthors.Add(new Author() { LastName = "Хольт", FirstName = "Кэри" });
            defaultAuthors.Add(new Author() { LastName = "Энсор", FirstName = "Дейв" });
            defaultAuthors.Add(new Author() { LastName = "Стивенсон", FirstName = "Йен" });
            defaultAuthors.Add(new Author() { LastName = "Фейерштейн", FirstName = "С." });
            defaultAuthors.Add(new Author() { LastName = "Прибыл", FirstName = "Б." });
            defaultAuthors.Add(new Author() { LastName = "МакДональд", FirstName = "Коннор" });
            defaultAuthors.Add(new Author() { LastName = "Луни", FirstName = "Кевин" });
            defaultAuthors.Add(new Author() { LastName = "Терьо", FirstName = "Марлен" });
            defaultAuthors.Add(new Author() { LastName = "эксперты TUSC" });
            defaultAuthors.Add(new Author() { LastName = "Генник", FirstName = "Д." });
            defaultAuthors.Add(new Author() { LastName = "Кайт", FirstName = "Том" });
            defaultAuthors.Add(new Author() { LastName = "Уорсли", FirstName = "Дж." });
            defaultAuthors.Add(new Author() { LastName = "Дрейк", FirstName = "Дж." });
            defaultAuthors.Add(new Author() { LastName = "Вирт", FirstName = "Никлаус" });
            defaultAuthors.Add(new Author() { LastName = "Яншин", FirstName = "В." });
            defaultAuthors.Add(new Author() { LastName = "Скиена", FirstName = "Стивен" });
            defaultAuthors.Add(new Author() { LastName = "Гагарина", FirstName = "Л." });
            defaultAuthors.Add(new Author() { LastName = "Колдаев", FirstName = "В." });
            defaultAuthors.Add(new Author() { LastName = "Левитин", FirstName = "Ананий" });
            defaultAuthors.Add(new Author() { LastName = "Окулов", FirstName = "С." });
            defaultAuthors.Add(new Author() { LastName = "Кормен", FirstName = "Томас" });
            defaultAuthors.Add(new Author() { LastName = "Лейзерсон", FirstName = "Чарльз" });
            defaultAuthors.Add(new Author() { LastName = "Ривест", FirstName = "Рональд" });
            defaultAuthors.Add(new Author() { LastName = "Штайн", FirstName = "Клиффорд" });
            defaultAuthors.Add(new Author() { LastName = "Красиков", FirstName = "И." });
            defaultAuthors.Add(new Author() { LastName = "Красикова", FirstName = "И." });
            defaultAuthors.Add(new Author() { LastName = "Порублев", FirstName = "И." });
            defaultAuthors.Add(new Author() { LastName = "Ставровский", FirstName = "А." });
            defaultAuthors.Add(new Author() { LastName = "Макконнелл", FirstName = "Дж." });
            defaultAuthors.Add(new Author() { LastName = "Лавров", FirstName = "С." });
            defaultAuthors.Add(new Author() { LastName = "Новиков", FirstName = "Ф." });
            defaultAuthors.Add(new Author() { LastName = "Воеводин", FirstName = "В." });
            defaultAuthors.Add(new Author() { LastName = "Афанасьевич", FirstName = "Донец" });
            defaultAuthors.Add(new Author() { LastName = "Зуселевич", FirstName = "Шор" });
            defaultAuthors.Add(new Author() { LastName = "Касаткин", FirstName = "Валентин" });
            defaultAuthors.Add(new Author() { LastName = "Фомичев", FirstName = "В." });
            defaultAuthors.Add(new Author() { LastName = "Хаггарти", FirstName = "Р." });
            defaultAuthors.Add(new Author() { LastName = "Кунцман", FirstName = "Ж." });
            defaultAuthors.Add(new Author() { LastName = "Криспин", FirstName = "Лайза" });
            defaultAuthors.Add(new Author() { LastName = "Грегори", FirstName = "Джанет" });
            defaultAuthors.Add(new Author() { LastName = "Винниченко", FirstName = "И." });
            defaultAuthors.Add(new Author() { LastName = "Дастин", FirstName = "Элфрид" });
            defaultAuthors.Add(new Author() { LastName = "Рэшка", FirstName = "Джефф" });
            defaultAuthors.Add(new Author() { LastName = "Джон", FirstName = "Пол" });
            defaultAuthors.Add(new Author() { LastName = "Котляров", FirstName = "В." });
            defaultAuthors.Add(new Author() { LastName = "Коликова", FirstName = "Т." });
            defaultAuthors.Add(new Author() { LastName = "Липаев", FirstName = "В." });
            defaultAuthors.Add(new Author() { LastName = "Тамре", FirstName = "Луиза" });
            defaultAuthors.Add(new Author() { LastName = "Макгрегор", FirstName = "Джон" });
            defaultAuthors.Add(new Author() { LastName = "Сайкс", FirstName = "Девид" });
            defaultAuthors.Add(new Author() { LastName = "Лэм", FirstName = "Чак" });
            defaultAuthors.Add(new Author() { LastName = "Карпов", FirstName = "Ю." });
            defaultAuthors.Add(new Author() { LastName = "Касперски", FirstName = "Крис" });
            defaultAuthors.Add(new Author() { LastName = "Рокко", FirstName = "Ева" });
            defaultAuthors.Add(new Author() { LastName = "Хамахер", FirstName = "К." });
            defaultAuthors.Add(new Author() { LastName = "Вранешич", FirstName = "З." });
            defaultAuthors.Add(new Author() { LastName = "Заки", FirstName = "С." });
            defaultAuthors.Add(new Author() { LastName = "Гербер", FirstName = "Ричард" });
            defaultAuthors.Add(new Author() { LastName = "Бик", FirstName = "Арт" });
            defaultAuthors.Add(new Author() { LastName = "Смит", FirstName = "Кевин" });
            defaultAuthors.Add(new Author() { LastName = "Ксинмин", FirstName = "Тиан" });
            defaultAuthors.Add(new Author() { LastName = "Самойлов", FirstName = "В." });
            defaultAuthors.Add(new Author() { LastName = "Серебряков", FirstName = "В." });
            defaultAuthors.Add(new Author() { LastName = "Галочкин", FirstName = "М." });
            defaultAuthors.Add(new Author() { LastName = "Лупин", FirstName = "С." });
            defaultAuthors.Add(new Author() { LastName = "Посыпкин", FirstName = "М." });
            defaultAuthors.Add(new Author() { LastName = "Форта", FirstName = "Бен" });
            defaultAuthors.Add(new Author() { LastName = "Сейбел", FirstName = "Питер" });
            defaultAuthors.Add(new Author() { LastName = "Форд", FirstName = "Нил" });
            defaultAuthors.Add(new Author() { LastName = "Найгард", FirstName = "Майкл" });
            defaultAuthors.Add(new Author() { LastName = "де Ора", FirstName = "Билл" });
            defaultAuthors.Add(new Author() { LastName = "Спинеллис", FirstName = "Диомидис" });
            defaultAuthors.Add(new Author() { LastName = "Гусиос", FirstName = "Геогиос" });
            defaultAuthors.Add(new Author() { LastName = "Орам", FirstName = "Энди" });
            defaultAuthors.Add(new Author() { LastName = "Уилсон", FirstName = "Грег" });
            defaultAuthors.Add(new Author() { LastName = "О'Халларон", FirstName = "Дэвид" });
            defaultAuthors.Add(new Author() { LastName = "Брайант", FirstName = "Рэндал" });
            defaultAuthors.Add(new Author() { LastName = "Кронрод", FirstName = "А." });
            defaultAuthors.Add(new Author() { LastName = "Опалева", FirstName = "Э." });
            defaultAuthors.Add(new Author() { LastName = "Самойленко", FirstName = "В." });
            defaultAuthors.Add(new Author() { LastName = "Гивоне", FirstName = "Д." });
            defaultAuthors.Add(new Author() { LastName = "Россер", FirstName = "Р." });
            defaultAuthors.Add(new Author() { LastName = "Несвижский", FirstName = "Всеволод" });
            defaultAuthors.Add(new Author() { LastName = "Кулаков", FirstName = "Владимир" });
            defaultAuthors.Add(new Author() { LastName = "Бернет", FirstName = "С." });
            defaultAuthors.Add(new Author() { LastName = "Пэйн", FirstName = "С." });
            defaultAuthors.Add(new Author() { LastName = "Запечников", FirstName = "С." });
            defaultAuthors.Add(new Author() { LastName = "Иванов", FirstName = "М." });
            defaultAuthors.Add(new Author() { LastName = "Щербаков", FirstName = "А." });
            defaultAuthors.Add(new Author() { LastName = "Домашев", FirstName = "А." });
            defaultAuthors.Add(new Author() { LastName = "Аграновский", FirstName = "А." });
            defaultAuthors.Add(new Author() { LastName = "Хади", FirstName = "Р." });
            defaultAuthors.Add(new Author() { LastName = "Осипян", FirstName = "В." });
            defaultAuthors.Add(new Author() { LastName = "Осипян", FirstName = "К." });
            defaultAuthors.Add(new Author() { LastName = "Шнайер", FirstName = "Брюс" });
            defaultAuthors.Add(new Author() { LastName = "Фомичев", FirstName = "В." });
            defaultAuthors.Add(new Author() { LastName = "Нечаев", FirstName = "В." });
            defaultAuthors.Add(new Author() { LastName = "Венбр", FirstName = "Мао" });
            defaultAuthors.Add(new Author() { LastName = "Вельшенбах", FirstName = "М." });
            defaultAuthors.Add(new Author() { LastName = "Смарт", FirstName = "Н." });
            defaultAuthors.Add(new Author() { LastName = "Панасенко", FirstName = "Сергей" });
            foreach (Author author in defaultAuthors)
                dbContext.Authors.Add(author);
            
            //Города
            defaultCities = new List<City>();
            defaultCities.Add(new City() { Name = "Оренбург" });
            defaultCities.Add(new City() { Name = "Екатеринбург" });
            foreach (City element in defaultCities)
                dbContext.Cities.Add(element);

            //Типы улиц
            defaultStreetTypes = new List<StreetType>();
            defaultStreetTypes.Add(new StreetType(){Name = "Улица"});
            defaultStreetTypes.Add(new StreetType(){Name = "Переулок"});
            foreach (StreetType element in defaultStreetTypes)
                dbContext.StreetTypes.Add(element);

            base.Seed(dbContext);
            dbContext.SaveChanges();
            // MarketDbInitializer2 for continue
        }
    }
}