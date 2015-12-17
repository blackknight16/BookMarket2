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
        private void PartialSeed9(BookMarketDbContext dbContext)
        {
            //Книги 7е продолжение
            defaultBooks.Add(new Book()
            {
                Name = "Oracle. Проектирование баз данных",
                PageCount = 560,
                Year = 1999,
                ImageName = "ensor-oracle-proektirovanie-baz-dannyh.jpg",
                Description = @"В книге ""Oracle. Проектирование баз данных"" рассматриваются специфика разработки баз данных Oracle, которые считаются признаком хорошего качества и высокой производительности систем. Отдельное внимание автор уделил таким вопросам как модели данных, применение ключей и индексов, временных данных, денормализация. Также рассматривается разработка для специальных архитектур (клиент/сервер, распределение базы данных, параллельные вычисления) и хранилищ данных. Книга адресована разработчикам и проектировщикам баз данных.",
                LanguageId = LanguageService.RUSSIAN,
                Authors = new List<Author>()
                {
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Энсор" && author.FirstName == "Дейв"),
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Стивенсон" && author.FirstName == "Йен")
                },
                Publishers = new List<Publisher>() { bhv },
                BookTags = new List<BookTag>() { oracleDbTag, commonDbTag }
            });
            defaultBooks.Add(new Book()
            {
                Name = "Oracle PL/SQL для профессионалов",
                PageCount = 1024,
                Year = 2005,
                ImageName = "feiershtein-pribyl-oracle-pl-sql-dlya-pr.jpg",
                Description = @"Книга ""Oracle PL/SQL для профессионалов"" представляет собой полное руководство по языку PL/SQL, который является процедурным языковым расширением для SQL. Автор детально рассмотрел основы PL/SQL, технологию использования операторов и инструкций для доступа к реляционным базам данных, структуру программы, принципы работы с программными базами данных. Важное внимание автор уделил вопросам безопасности, воздействию объектных технологий на PL/SQL и интеграции XML и Java.",
                LanguageId = LanguageService.RUSSIAN,
                Authors = new List<Author>()
                {
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Фейерштейн" && author.FirstName == "С."),
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Прибыл" && author.FirstName == "Б.")
                },
                Publishers = new List<Publisher>() { piter },
                BookTags = new List<BookTag>() { oracleDbTag, commonDbTag }
            });
            defaultBooks.Add(new Book()
            {
                Name = "Oracle PL/SQL для профессионалов. Практические решения",
                PageCount = 560,
                Year = 2005,
                ImageName = "makdonald-oracle-pl-sql-dlya-professiona.jpg",
                Description = @"Книга ""Oracle PL/SQL для профессионалов. Практические решения"", написанная известным экспертом по Oracle, содержит много полезной информации по решению проблем, противоречащие общепринятое мнение. Представленная книга является не учебником по написанию кода на языке PL/SQL, а помощником в изучении хорошего программирования на PL/SQL. В книге рассматривается методы написания кода, который будет функционировать быстро и надёжно в многопользовательской среде с большой нагрузкой. Рассмотрено множество функциональных возможностей, доступных в PL/SQL, в том числе эффективная обработка реляционных и абстрактных данных, защита, триггеры, динамическое формирование HTML-страниц из СУБД и эффективные приёмы отладки. Авторы большую част книги посвятили рассмотрению функциональности, предоставляемых PL/SQL в том числе продуктивной обработке реляционных и абстрактных данных, защите, триггерам, динамическому формированию HTML-страниц из систему управления базами данных и эффективным приёмам отладки. Приведённые в книге примеры помогут понять всю мощь и функциональность, предоставляющие использование PL/SQL в проектах различного рода.",
                LanguageId = LanguageService.RUSSIAN,
                Authors = new List<Author>()
                {
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "МакДональд" && author.FirstName == "Коннор")
                },
                Publishers = new List<Publisher>() { diaSoftUP },
                BookTags = new List<BookTag>() { oracleDbTag, commonDbTag }
            });
            defaultBooks.Add(new Book()
            {
                Name = "Oracle9i. Настольная книга администратора",
                PageCount = 748,
                Year = 2004,
                ImageName = "luni-tero-oracle9i-nastolnaya-kniga-admi.jpg",
                Description = @"В книге ""Oracle9i. Настольная книга администратора"" нашлось место информации, которую невозможно обнаружить в любом другом подобном издании, она поможет придать гибкости, обезопасить и сделать более доступными интернет системы и системы электронного бизнеса, которые имеют решающее значение для выполнения ваших задач. Вы освоите установку и принципы сопровождения высокоэффективной базы данных, научитесь использовать все новые возможности Oracle9i. Авторами приводятся реальные примеры из практики.
Рассмотренные в книге темы: 
- Организация и управление базами данных с помощью Oracle9i Database Configuration Assistant 
- Мониторинг и конфигурирование пользовательских файлов, транзакций, запросов и памяти 
- Реализация сегментов отката и системно-управляемый откат 
- Перенос приложения и оперативный процесс изменения таблиц 
- Диагностика и оптимизация эффективности системы с помощью STATSPACK 
- Реализация процедур реального аудита и безопасности 
- Операции автоматического резервного копирования и восстановления с помощью RMAN 
- Реализация разделов для управления очень большими базами данных 
- Распределение вычислительной мощности и корпоративное использование данных на серверах с помощью Oracle Net 
- Использование служб Oracle9i/AS для придания гибкости, масштабируемости и доступности",
                LanguageId = LanguageService.RUSSIAN,
                Authors = new List<Author>()
                {
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Луни" && author.FirstName == "Кевин"),
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Терьо" && author.FirstName == "Марлен"),
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "эксперты TUSC")
                },
                Publishers = new List<Publisher>() { lori },
                BookTags = new List<BookTag>() { oracleDbTag, commonDbTag }
            });
            defaultBooks.Add(new Book()
            {
                Name = "Oracle SQL Plus. Карманный справочник, 2-издание",
                PageCount = 224,
                Year = 2004,
                ImageName = "gennik-oracle-sql-plus-karmannyi-spravoc.jpg",
                Description = @"В книге ""Oracle SQL Plus. Карманный справочник"" рассматриваются основания для решения задач при помощи SQL*Plus. Вы научитесь писать и выполнять файлы сценариев, применять механизмы администрирования SQL*Plus , получать информацию из баз данных, получать информацию из баз данных, запрашивать таблицы словарных данных, настраивать для своих целей среду SQL*Plus, генерировать и форматировать отчёты. Во втором издание справочника можно быстро находить нужную справочную информацию, что позволят эффективнее использовать SQL*Plus. В книге нашлось место для краткого описания всех форматов и синтаксиса любых элементов SQL*Plus, включая введённые в Oracle9i Release 2: функцию COALESCE, поисковые выражения CASE, объединения таблиц, многотабличные вставки и пр. Вкратце рассмотрены вопросы работы с SQL*Plus, настройки SQL-запросов, форматирования отчетов с помощью SQL*Plus. Помимо этого во втором издании опубликована информация по инструкциям SQL, которые часто применяются в SQL*Plus, включая INSERT, MERGE, UPDATE, DELETE, SELECT, а также по инструкциям управления транзакциями: COMMIT, SET TRANSACTION, SAVEPOINT, ROLLBACK.",
                LanguageId = LanguageService.RUSSIAN,
                Authors = new List<Author>()
                {
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Генник" && author.FirstName == "Д.")
                },
                Publishers = new List<Publisher>() { piter },
                BookTags = new List<BookTag>() { oracleDbTag, commonDbTag }
            });
            defaultBooks.Add(new Book()
            {
                Name = "Oracle для профессионалов (2 тома)",
                PageCount = 0,
                Year = 2003,
                ImageName = "kait-oracle-dlya-professionalov-1.jpg",
                Description = @"В книге ""Oracle для профессионалов"" доступным языком всесторонне рассмотрены основные особенности архитектуры СУБД Oracle, благодаря которым она отлична от других систем управления базами данных. Досконально рассматриваются проиллюстрированные многие примеры тех средств и особенностей Oracle, которые позволяют разрабатывать и использовать эффективные приложения для данного вида СУБД. Автор книги имеет большой стаж работы в среде СУБД Oracle, проектируя приложения и администрируя базы данных. Том Кайт много лет посвятил решению проблем, появляющихся у администраторов и разработчиков всего мира, при использовании СУБД Oracle. Начало изучения СУБД Oracle именно с этого издания – верный путь на пути к профессиональной разработке баз данных. Опытному разработчику приложений или администратору также не помешает ознакомиться с материалом книги и удостоверится в хорошем знании всех аспектов работы в СУБД Oracle и умении использовать весь её потенциал.",
                LanguageId = LanguageService.RUSSIAN,
                Authors = new List<Author>()
                {
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Кайт" && author.FirstName == "Том")
                },
                Publishers = new List<Publisher>() { diaSoftUP },
                BookTags = new List<BookTag>() { oracleDbTag, commonDbTag }
            });
            defaultBooks.Add(new Book()
            {
                Name = "PostgreSQL. Для профессионалов",
                PageCount = 496,
                Year = 2003,
                ImageName = "uorsli-postgresql-dlya-professionalov.jpg",
                Description = @"Несмотря на то, что, по сути это издание ориентировано на тех, кто знаком с PostgreSQL не понаслышке, в частности, для системных администраторов, которые выполняют техническое сопровождение серверов баз данных, она окажется полезной и тем, кто только начинает осваивать азы PostgreSQL. Поскольку PostgreSQL по сравнению со множеством других систем управления БД, отличается более широким выбором возможностей и высокой надежностью. В этом издании вы сможете ознакомиться с такими специфическими вопросами, как создание web-страничек на основе PostgreSQL или работа с БД в языке программирования Java. Помимо этого много внимание в книге уделяется и вопросам сопровождения и установки серверов баз данных на основе PostgreSQL. Книга поможет вам разобраться и со многими стандартными функциями вроде управления аккаунтами пользователей, восстановление и архивация БД, остановка или запуск сервера, создание новых БД и многое другое.",
                LanguageId = LanguageService.RUSSIAN,
                Authors = new List<Author>()
                {
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Уорсли" && author.FirstName == "Дж."),
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Дрейк" && author.FirstName == "Дж.")
                },
                Publishers = new List<Publisher>() { piter },
                BookTags = new List<BookTag>() { postgreSQLTag, commonDbTag }
            });

            foreach (var element in defaultBooks)
                dbContext.Books.Add(element);
            dbContext.SaveChanges();

            foreach (var book in defaultBooks)
                dbContext.BookVariableInfoes.Add(new BookVariableInfo()
                {
                    Book = book,
                    Price = 1.0M,//5.0M,
                    ProductCount = 5
                });
            dbContext.SaveChanges();

            //Улицы
            defaultStreets = new List<Street>();
            defaultStreets.Add(new Street()
            {
                Name = "Ленинская",
                StreetTypeId = StreetTypeService.ULICA
            });
            defaultStreets.Add(new Street()
            {
                Name = "Советская",
                StreetTypeId = StreetTypeService.ULICA
            });
            defaultStreets.Add(new Street()
            {
                Name = "Матросский",
                StreetTypeId = StreetTypeService.PEREULOK
            });
            defaultStreets.Add(new Street()
            {
                Name = "Антона Валека",
                StreetTypeId = StreetTypeService.ULICA
            });
            foreach (var element in defaultStreets)
                dbContext.Streets.Add(element);
            dbContext.SaveChanges();
            //Адреса и магазины
            //В каждом магазине цена доставки фиксирована. 1рубль за книгу.
            defaultAddresses = new List<Address>();
            defaultShops = new List<Shop>();
            address = new Address()
            {
               CityId = CityService.ORENBURG,
               StreetId = StreetService.SOVETSKAYA,
               House = 24
            };
            defaultAddresses.Add(address);
            defaultShops.Add(new Shop()
            {
                Name = "Фолиант",
                Address = address,
                BookDeliveryCost = 1
            });
            
            address = new Address()
            {
               CityId = CityService.ORENBURG,
               StreetId = StreetService.LENINSKAYA,
               House = 39
            };
            defaultAddresses.Add(address);
            defaultShops.Add(new Shop()
            {
                Name = "Читай-город",
                Address = address,
                BookDeliveryCost = 1
            });

            address = new Address()
            {
                CityId = CityService.ORENBURG,
                StreetId = StreetService.MATROSSKII,
                House = 12
            };
            defaultAddresses.Add(address);
            defaultShops.Add(new Shop()
            {
                Name = "Лабиринт",
                Address = address,
                BookDeliveryCost = 1
            });

            address = new Address()
            {
                CityId = CityService.EKATERINBURG,
                StreetId = StreetService.ANTONA_VALEKA,
                House = 12
            };
            defaultAddresses.Add(address);
            defaultShops.Add(new Shop()
            {
                Name = "Дом книги",
                Address = address,
                BookDeliveryCost = 1
            });
            foreach (var element in defaultAddresses)
                dbContext.Addresses.Add(element);
            foreach (var element in defaultShops)
                dbContext.Shops.Add(element);
            dbContext.SaveChanges();

            //Добавление админа
            /*defaultUserProfiles = new List<UserProfile>();
            userProfile = new UserProfile()
            {
                UserName = "Admin"
            };
            defaultUserProfiles.Add(userProfile);
            foreach(var element in defaultUserProfiles)
                dbContext.UserProfile.Add(element);

            defaultIndividuals = new List<Individual>();
            defaultIndividuals.Add(new Individual()
            {
                LastName = "Мулюков",
                FirstName = "Рустам",
                MiddleName = "Равилевич",
                Basket = new Basket(),
                UserProfiles = new List<UserProfile>{ userProfile }
            });
            foreach(var element in defaultIndividuals)
                dbContext.Individuals.Add(element);*/
            //dbContext.SaveChanges();
            
        }
    }
}