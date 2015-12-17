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
        private void PartialSeed8(BookMarketDbContext dbContext)
        {
            //Книги 6е продолжение
            defaultBooks.Add(new Book()
            {
                Name = "Microsoft SQL Server 2000. Наиболее полное руководство",
                PageCount = 1262,
                Year = 2005,
                ImageName = "mamaev-microsoft-sql-server-2000-naibolee-polnoe-rukovodstvo.jpg",
                Description = @"Книга ""Microsoft SQL Server 2000. Наиболее полное руководство"" - издание справочного характера, описывающее Microsoft SQL Server 2000, который входит в число самых действенных и известных систем управления базами данных. Рассматриваются различные возможности управления данными, использование индексов, системы безопасности и т.д. Рассказано о способах преобразования данных, обмена данными, средствах администрирования сервера, возможностях, предоставляемых в процессе разработки и сопровождения баз данных и соответствующих таблиц. Изложение дополняется наглядными примерами и рекомендациями, чрезвычайно полезными для практического изучения Microsoft SQL Server 2000 и работе в нем. Книга предназначена для всех, кто имеет дело с базами данных, а также интересуется устройством и принципами работы Microsoft SQL Server 2000.",
                LanguageId = LanguageService.RUSSIAN,
                Authors = new List<Author>()
                {
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Мамаев" && author.FirstName == "Е.")
                },
                Publishers = new List<Publisher>() { bhvPeterburg },
                BookTags = new List<BookTag>() { microsoftSQLServerTag, commonDbTag }
            });
            defaultBooks.Add(new Book()
            {
                Name = "Transact-SQL",
                PageCount = 576,
                Year = 2006,
                ImageName = "flenov-transact-sql.jpg",
                Description = @"В книге ""Transact-SQL"" детально рассмотрено применение языка Transact-SQL для манипуляции и администрирования СУБД Microsoft SQL Server. Отметим, что материал сопровождается множеством практических примеров, которые написаны самим автором. В данной книге уделено внимание вопросам использования Transact-SQL при совместном применении 1С и Microsoft SQL Server. На диске, прилагаемом к описываемой книге, Вы найдете тестовую базу данных, примеры запросов, дополнительную документацию, а также статьи автора, которые посвящены базам данных.",
                LanguageId = LanguageService.RUSSIAN,
                Authors = new List<Author>()
                {
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Фленов" && author.FirstName == "Михаил")
                },
                Publishers = new List<Publisher>() { bhvPeterburg },
                BookTags = new List<BookTag>() { microsoftSQLServerTag, commonDbTag }
            });
            defaultBooks.Add(new Book()
            {
                Name = "Технологии анализа данных. Data Mining, Visual Mining, Text Mining, OLAP, 2-ое издание",
                PageCount = 384,
                Year = 2007,
                ImageName = "barsegyan-metody-i-modeli-analiza-dannyh-olap-i.jpg",
                Description = @"Книга ""Технологии анализа данных. Data Mining, Visual Mining, Text Mining, OLAP"" является обновленным и дополненным, изданием пособия ""Модели и методы анализа данных. Data Mining и OLAP "". В ней описываются ключевые направления в сфере создания корпоративных систем: распределенный, интеллектуальный, оперативный, визуальный и текстовый анализ данных, а также здесь описываются алгоритмы и методы решения ключевых задач анализа: кластеризации, классификации и др. Следует отметить, что описание идеи всех методов дополняется примерами его использования. К книге прилагается диск, который содержит практическое пособие по интеллектуальному анализу данных, библиотеку алгоритмов Xelopes, стандарты Data Mining, а также соответствующее ПО.",
                LanguageId = LanguageService.RUSSIAN,
                Authors = new List<Author>()
                {
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Барсегян" && author.FirstName == "А."),
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Куприянов" && author.FirstName == "М."),
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Степаненко" && author.FirstName == "В."),
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Холод" && author.FirstName == "И.")
                },
                Publishers = new List<Publisher>() { bhvPeterburg },
                BookTags = new List<BookTag>() { microsoftSQLServerTag }
            });
            defaultBooks.Add(new Book()
            {
                Name = "SQL Server 2005 Analysis Services и MDX для профессионалов",
                PageCount = 848,
                Year = 2008,
                ImageName = "harinath-sql-server-2005-analysis-services-i-mdx-dlya-professionalov.jpg",
                Description = @"Книга ""SQL Server 2005 Analysis Services и MDX"" ориентирована на разработчиков, а также администраторов баз и хранилищ данных, которые заинтересованы в эффективном применении средств анализа в SQL Server 2005. Данная книга, которая написана работниками отдела разработки Analysis Services корпорации Microsoft, покажет Вам, как следует использовать Analysis Services вместе с другими элементами SQL Server для создания поистине полномасштабных и комплексных решений. Из описываемого издания Вы узнаете, как можно разрабатывать унифицированные модели измерений; как использовать Analysis Services с прочими элементами SQL Server 2005; как использовать разнообразные средства бизнес-аналитики и показатели эффективности; каким образом оптимизировать проекты, а также масштабировать Analysis Services для максимальной производительности; как применять MDX для формирования запросов к базам данных и реализации бизнес-анализа. Примеры, практические решения и технологии, которые рассмотрены в этой книге помогут программистам в их повседневной работе.",
                LanguageId = LanguageService.RUSSIAN,
                Authors = new List<Author>()
                {
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Харинатх" && author.FirstName == "Сивакумар"),
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Куинн" && author.FirstName == "Стивен")
                },
                Publishers = new List<Publisher>() { dialektika },
                BookTags = new List<BookTag>() { microsoftSQLServerTag, commonDbTag }
            });
            defaultBooks.Add(new Book()
            {
                Name = "Программирование баз данных Microsoft SQL Server 2005. Базовый курс",
                PageCount = 832,
                Year = 2007,
                ImageName = "viiera-programmirovanie-baz-dannyh-microsoft-sql.jpg",
                Description = @"Предложенная вам книга ""Программирование баз данных Microsoft SQL Server 2005. Базовый курс"" - наиболее полное собрание информации, касающейся первых этапов программирования баз данных в SQL Server 2005, предназначенная для начинающих и более опытных пользователей SQL Server. Данная книга зарекомендовала себя как авторитетный справочник, содержащий много полезной информации, которая будет интересна читателям еще долгое время после того, как они освоят все необходимые для успешной работы знания. Она была полностью переработана для версии SQL Server от 2005 года. В ней наиболее полно описывается система управления базами данных SQL Server 2005, начиная с самых основ. Каждая новая глава в этой книге основана на материале, описанном в предыдущей, поэтому переход на более сложные темы будет постепенным. Читатель, прочитавший эту книгу, будет полностью готов к самостоятельному использованию SQL Server 2005 в качестве программиста. После изучения данной книги вы по желанию можете перейти к изучению более сложной профессиональной литературы.
Перечислим некоторые темы, которые рассматриваются в книге: 
- Способы изготовления и изменения таблиц. 
- Разнообразные пользовательские функции и триггеры. 
- Средства написания сценариев, управления ключами, и работы с хранимыми процедурами. 
- Принципы работы со службами Integration Services и Reporting Services. 
- Методы программирования с использованием языка XML. 
- Различные вспомогательные средства языка SQL.",
                LanguageId = LanguageService.RUSSIAN,
                Authors = new List<Author>()
                {
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Виейра" && author.FirstName == "Роберт")
                },
                Publishers = new List<Publisher>() { williams },
                BookTags = new List<BookTag>() { microsoftSQLServerTag, commonDbTag }
            });
            defaultBooks.Add(new Book()
            {
                Name = "Microsoft SQL Server 2005 Analysis Services. OLAP и многомерный анализ данных",
                PageCount = 928,
                Year = 2007,
                ImageName = "berger-microsoft-sql-server-2005-analysis.jpg",
                Description = @"Фундаментальная монография разработчиков Microsoft SQL Server 2005 Analysis Services посвящена детальному описанию данной службы. Читатель познакомится с основными понятиями многомерного анализа данных, с использованием OLAP-сервера, и интеллектуальным анализом многомерных моделей данных. Рассмотрены язык MDX (Multidimensional Expressions - выражения со многими измерениями) - язык запросов к многомерным данным, алгоритмы доступа к данным, методы обработки данных. Введена концепция Unified Dimensional Model, UDM - единой многомерной модели. Для Analysis Services описаны алгоритмы управления ресурсами, в том числе управление памятью, создание качественных клиентских приложений. Приведён протокол XML/A, а также другие внутренние и внешние протоколы обмена данными. Показаны способы взаимодействия реляционных и многомерных баз данных. Отдельный раздел посвящён безопасности и администрированию Microsoft SOL Server 2005 Analysis Services.",
                LanguageId = LanguageService.RUSSIAN,
                Authors = new List<Author>()
                {
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Бергер" && author.FirstName == "А.")
                },
                Publishers = new List<Publisher>() { bhvPeterburg },
                BookTags = new List<BookTag>() { microsoftSQLServerTag, commonDbTag }
            });
            defaultBooks.Add(new Book()
            {
                Name = "Методы и модели анализа данных: OLAP и Data Mining",
                PageCount = 336,
                Year = 2004,
                ImageName = "barsegyan-metody-i-modeli-analiza-dannyh-olap-i.jpg",
                Description = @"Книга ""Методы и модели анализа данных: OLAP и Data Mining"" расскажет читателю о самых популярных направлениях в сфере разработки корпоративных систем, как то: организация хранилищ данных, оперативный (OLAP) и интеллектуальный анализ данных (Data Mining). Приведённые три направления описываются достаточно подробно для восприятия и последующего практического применения. В материале данного издания описываются методы и алгоритмы анализа данных, а также имеются иллюстрированные примеры их работы, что позволяет пользоваться книгой не только как учебником, но и в качестве практического руководства при создании программного обеспечения.",
                LanguageId = LanguageService.RUSSIAN,
                Authors = new List<Author>()
                {
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Барсегян" && author.FirstName == "А."),
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Куприянов" && author.FirstName == "М."),
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Степаненко" && author.FirstName == "В."),
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Холод" && author.FirstName == "И.")
                },
                Publishers = new List<Publisher>() { bhvPeterburg },
                BookTags = new List<BookTag>() { microsoftSQLServerTag, commonDbTag }
            });
            defaultBooks.Add(new Book()
            {
                Name = "Разработка реального приложения в среде клиент-сервер",
                PageCount = 198,
                Year = 2007,
                ImageName = "gurvits-razrabotka-realnogo-prilozheniya-v-srede.jpg",
                Description = @"В книге ""Разработка реального приложения в среде клиент - сервер"" приводится описание главных моментов проектирования реального приложения для работы с реляционными базами данных и работы с MS SQL Server (сервер) и MS Access (клиент). Предлагаемая книга является учебным пособием для решения курсового проекта. В ней находится множество различных вариантов заданий на проектирование. Данное издание найдёт своё применение у студентов и преподавателей ВУЗов.",
                LanguageId = LanguageService.RUSSIAN,
                Authors = new List<Author>()
                {
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Гурвиц" && author.FirstName == "Г.")
                },
                Publishers = new List<Publisher>() { dVGUPS },
                BookTags = new List<BookTag>() { microsoftSQLServerTag }
            });
            defaultBooks.Add(new Book()
            {
                Name = "Программирование для Microsoft SQL Server 2000 с использованием XML",
                PageCount = 320,
                Year = 2002,
                ImageName = "malkolm-programmirovanie-dlya-microsoft-sql.jpg",
                Description = @"Книга Грема Малкольма ""Программирование для Microsoft SQL Server 2000 с использованием XML"" является практическим руководством по разработке бизнес-приложений на основе XML и SQL Server. Здесь детально рассматриваются получение, вставка и сопоставление XML-данных с помощью популярных технологий XPath, XDR-схемы, язык XSL Transformation, HTTP и OLE DB и последних технологий. Размещенные в книге примеры показывают, как перенести значительные бизнес-процессы предприятия в Web с применением SQL Server и XML. В данном издании 9 глав и приложение, в котором описывается об основах языка XML персонально для администраторов СУБД SQL Server. Книга будет полезна всем, желающим обучиться с помощью XML интегрированию приложений и бизнес-процессов предприятий, которые сохраняют данные в БД SQL Server.",
                LanguageId = LanguageService.RUSSIAN,
                Authors = new List<Author>()
                {
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Малкольм" && author.FirstName == "Грэм")
                },
                Publishers = new List<Publisher>() { russkayaRedakciya },
                BookTags = new List<BookTag>() { microsoftSQLServerTag }
            });
            defaultBooks.Add(new Book()
            {
                Name = "Программирование баз данных Microsoft SQL Server 2005 для профессионалов",
                PageCount = 1072,
                Year = 2008,
                ImageName = "vieira-programmirovanie-baz-dannyh-microsoft-sql.jpg",
                Description = @"Книга Роберта Виейры ""Программирование баз данных Microsoft SQL Server 2005 для профессионалов"" поможет пользователю освоить самый большой и эффективный программный продукт. Изучив предлагаемую публикацию, читатель сможет понять все тонкости разработки высокопроизводительных систем и приложений, о способах защиты данных и быстрого доступа к данным. Второй том книги дополняет первое издание начальными сведениями о программировании, о которых мало написано в первом. Книга создана для опытных программистов, имевших дело с СУБД SQL Server с достаточным опытом в среде разработки программного обеспечения.",
                LanguageId = LanguageService.RUSSIAN,
                Authors = new List<Author>()
                {
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Виейра" && author.FirstName == "Роберт")
                },
                Publishers = new List<Publisher>() { williams, dialektika },
                BookTags = new List<BookTag>() { microsoftSQLServerTag, commonDbTag }
            });
            defaultBooks.Add(new Book()
            {
                Name = "Microsoft SQL Server 7.0: установка, управление, оптимизация",
                PageCount = 576,
                Year = 1998,
                ImageName = "artemov-microsoft-sql-server-7-ustanovka.jpg",
                Description = @"В книге Д. Артёмова, Г. Погульского, М. Альперович ""Microsoft SQL Server 7.0: установка, управление, эксплуатация, оптимизация"" описывается новейшая система управления базами данных корпорации - Microsoft SQL Server 7.0 и её сравнение со старыми версиями. Здесь пользователи смогут ознакомиться с установкой, переводом баз данных в новый формат хранения, графическим интерфейсом администратора, мастерами, которые выполняют основные административные задачи, новой моделью системы безопасности, объектной моделью SQL Server (SQL DMO), которая предоставляет доступ к объекту и административным компонентам сервера, новым программным интерфейсом доступа к данным ADO версии 2.0. Так же читатель сможет узнать о путях оптимизации запросов, принципах использования индексов и анализом производительности оптимизатора запросов. Данная книга будет полезна специалистам сферы информационных технологий, которые уже работали с предыдущей версией Microsoft SQL Server и другими СУБД. В этом издании 11 глав, словарь терминов, предметный указатель и множество иллюстраций.",
                LanguageId = LanguageService.RUSSIAN,
                Authors = new List<Author>()
                {
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Артемов" && author.FirstName == "Д."),
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Погульский" && author.FirstName == "Г.")
                },
                Publishers = new List<Publisher>() { russkayaRedakciya },
                BookTags = new List<BookTag>() { microsoftSQLServerTag, commonDbTag }
            });
            defaultBooks.Add(new Book()
            {
                Name = "Альманах программиста. Том 1. Microsoft ADO.NET, Microsoft SQL Server. Доступ к данным из приложений",
                PageCount = 400,
                Year = 2003,
                ImageName = "makmen-almanah-programmista-tom-1.jpg",
                Description = @"Эта книга рассматривает основы проектирования БД и работы с ними, раскрывая такие темы, как получения доступа к данным из разных приложений, Microsoft SQL Server и технологию получения доступа к данным в интерфейсе Microsoft ADO.NET. По сути книга является сборником полезных статей, которые публиковались в таких изданиях, как русская редакция журнала Magazine и Microsoft MSDN Library. В трех рубриках содержится около 20 тематических статей, раскрывающих все особенности работы с БД. Книга предназначена для тех, кто занимается проектированием баз данных профессионально, а также тем, кто не равнодушен к перспективным и современным ИТ.",
                LanguageId = LanguageService.RUSSIAN,
                Authors = new List<Author>()
                {
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Макмен" && author.FirstName == "Алекс"),
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Брукс" && author.FirstName == "Крис"),
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Басби" && author.FirstName == "Стив")
                },
                Publishers = new List<Publisher>() { russkayaRedakciya },
                BookTags = new List<BookTag>() { microsoftSQLServerTag }
            });
            defaultBooks.Add(new Book()
            {
                Name = "SQL Server 2005. Библия пользователя",
                PageCount = 1232,
                Year = 2008,
                ImageName = "nilsen-sql-server-2005-bibliya-polzovatelya.jpg",
                Description = @"Издание предлагает вам ознакомиться с наиболее полным из существующих описаний СУБД SQL Server 2005, включая не только старую информацию, но и обеспеченные пакетами SP1 и SP2 улучшения и дополнения. В книге вы сможете ознакомиться с входящими в Microsoft SQL Server 2005 службами и способами их интеграции с VB.NET и C#, являющимися языками программирования в среде NET Framework. Помимо этого, в книге содержится информация об обслуживании, администрировании и установке серверов SQL Server 2005, о многих основополагающих принципах информационной архитектуры СУБД. Здесь же давно множество примеров и советов, которые помогут резервировать данные и создавать план обслуживания серверов. Управление и доступ к аналитическим и оперативным данным открывается благодаря описаниям языка запросов MDX и T-SQL. Эта книга позволит вам ознакомиться с вопросами настройки и изменения производительности Microsoft SQL Server, а также освоить использование расширенных средств бизнес-аналитики.",
                LanguageId = LanguageService.RUSSIAN,
                Authors = new List<Author>()
                {
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Нильсон" && author.FirstName == "Пол")
                },
                Publishers = new List<Publisher>() { williams },
                BookTags = new List<BookTag>() { microsoftSQLServerTag, commonDbTag }
            });
            defaultBooks.Add(new Book()
            {
                Name = "Проектирование баз данных на SQL Server 7",
                PageCount = 560,
                Year = 2000,
                ImageName = "garbus-proektirovanie-baz-dannyh-na-sql-server-7.jpg",
                Description = @"Книга Джеффри Р. Гарбуса, Дэвида Ф. Паскузи, Энтони Т. Чанга ""Проектирование баз данных на SQL Server 7"" из серии ""Сертификационный экзамен - экстерном"" является удобной, сжатой, хорошо структурированным конспектом для подготовки к сдаче сертификационных экзаменов на звание Microsoft Certified Systems Engineer. Том ""Database Design on SQL Server 7 (экзамен 70 - 029)"" имеет в себе все необходимое для подготовки к экзаменам: фактический материал, типовые экзаменационные вопросы с разборами ответов и тесты для самопроверки. Так же здесь находятся советы по стратегии и тактике сдачи экзамена. Книги серии ""Сертификационный экзамен - экстерном"" - это ценное открытие для преподавателей, потому что их можно предложить своим учащимся как пособие для персонального обучения. Это издание может пригодиться и впоследствии, к примеру, чтоб найти и вспомнить нужные материалы.
Приведем несколько тем, вошедших в эту книгу: 
- сущности, атрибуты и отношения; 
- создание баз данных; 
- конфигурирование баз данных; 
- именование объектов SQL Server; 
- использование атрибутов; 
- команды select, insert, update, и delete; 
- конфигурирование сессий; 
- индексация баз данных; 
- правила, определения и виды; 
- транзакции и триггеры.
Книги серии ""Сертификационный экзамен - экстерном"" рекомендованы представительством корпорации ""Майкрософт"" в Москве в качестве учебного пособия для подготовки к экзаменам на звание MCSE.",
                LanguageId = LanguageService.RUSSIAN,
                Authors = new List<Author>()
                {
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Гарбус" && author.FirstName == "Джеффри"),
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Паскузи" && author.FirstName == "Дэвид"),
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Чанг" && author.FirstName == "Энтони")
                },
                Publishers = new List<Publisher>() { piter },
                BookTags = new List<BookTag>() { microsoftSQLServerTag, commonDbTag }
            });
            defaultBooks.Add(new Book()
            {
                Name = "Разработка приложений на основе Microsoft SQL Server 2005",
                PageCount = 880,
                Year = 2005,
                ImageName = "brast-razrabotka-prilozhenii-na-osnove-microsoft.jpg",
                Description = @"Книга Браста Эндрю Дж. и Форте С. ""Разработка приложений на основе Microsoft SQL Server 2005"" является практическим руководством по разработке приложений на основе Microsoft SQL Server 2005. В ней тщательно описана работа с сервером базы данных, таких как проектирование базы данных, программирование представлений, хранимых процедур, триггеров и функций на языке T-SQL, обеспечение безопасности, интеграция SQL Server и .NET CLR. Так же рассмотрены практические вопросы разработки приложений баз данных и возможности расширения функциональности с помощью таких технологий, как конечные точки HTTP, SQL Server Service Broker, SQL Server Notification Services, SQL Server Express Edition и SQL Server Everywhere Edition; описаны службы SQL Server Integration Services, Analysis Services и Reporting Services. Книга предназначена для разработчиков .NET-приложений баз данных и для желающих изучить возможности программирования Microsoft SQL Server 2005.",
                LanguageId = LanguageService.RUSSIAN,
                Authors = new List<Author>()
                {
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Браст" && author.FirstName == "Эндрю"),
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Форте" && author.FirstName == "С.")
                },
                Publishers = new List<Publisher>() { russkayaRedakciya },
                BookTags = new List<BookTag>() { microsoftSQLServerTag, commonDbTag }
            });
            defaultBooks.Add(new Book()
            {
                Name = "Профессиональное руководство по SQL Server. Структура и реализация",
                PageCount = 1056,
                Year = 2006,
                ImageName = "henderson-rukovodstvo-po-sql-server.jpg",
                Description = @"В книге ""Профессиональное руководство по SQL Server. Структура и реализация"" приводится описание SQL Server - очень распространенной сейчас системы управления базами данных. Достоинство этой книги в том, что здесь вы сможете почерпнуть полезную информацию об основных технологиях Windows, которые являются фундаментом программы SQL Server. Здесь подробно описываются все программные средства, которые применяются в SQL Server, и наглядно продемонстрировано то, как функционируют компоненты этой СУБД. Учебник предлагает вам комплексный подход к подаче информации о настройках, архитектуре и внутренней организации SQL Server, что может являться только прекрасным дополнением к справочным и официальным изданиям. Учебник рекомендуется всем пользователям SQL Server, поскольку может использоваться, как в качестве учебного, так и в качестве справочного пособия для тех, кто хочет получить более глубокие знания.",
                LanguageId = LanguageService.RUSSIAN,
                Authors = new List<Author>()
                {
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Хендерсон" && author.FirstName == "Кен")
                },
                Publishers = new List<Publisher>() { williams },
                BookTags = new List<BookTag>() { microsoftSQLServerTag, commonDbTag }
            });
            defaultBooks.Add(new Book()
            {
                Name = "Проектирование баз данных на SQL Server 2000",
                PageCount = 662,
                Year = 2003,
                ImageName = "devidson-proektirovanie-baz-dannyh.jpg",
                Description = @"В книге ""Проектирование баз данных на SQL Server 2000"" рассматривается проектирование баз данных с использованием программного обеспечения Microsoft SQL Server для профессионального проектирования. Автор книги использует собственный опыт в методах и подходах ко всем стадиям проектирования и разработки баз данных. Уделяется внимание вопросам логического проектирования - выбору структуры и основных характеристик баз данных, а так же физического проектирования, включая выбор программного обеспечения, написание программ, отладку. Обойдя стороной теоретические вопросы, автор опирается на результаты, полученные в процессе практических занятий. Материал иллюстрируется некоторыми примерами, позволяющими закрепить и лучше рассмотреть изложенный материал с разных сторон. Книга пригодится как специалистам по проектированию баз данных, так и инженерам, сталкивающихся в работе с той или иной БД, построенной на основе СУБД SQL Server 2000. Некоторые главы книги могут быть использованы при обучении студентов в ВУЗах по проектированию баз данных.",
                LanguageId = LanguageService.RUSSIAN,
                Authors = new List<Author>()
                {
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Дэвидсон" && author.FirstName == "Луис")
                },
                Publishers = new List<Publisher>() { binom, laboratoriyaZnanii },
                BookTags = new List<BookTag>() { microsoftSQLServerTag, commonDbTag }
            });
            defaultBooks.Add(new Book()
            {
                Name = "Oracle 11g. Основы",
                PageCount = 464,
                Year = 2009,
                ImageName = "greenval-staqovyaq-stern-oracle-11g-osnovy.jpg",
                Description = @"Просто и ясно объясняется, что такое реляционные базы данных вообще, и какими преимуществами перед своими аналогами обладают СУБД Oracle. Спрос на системы этой корпорации постоянно растет, выпускаются все новые и новые версии, каждая из которых имеет свои особенности. Настоящее руководство дает всеобъемлющее описание последней вышедшей модификации - Oracle Database 11g. Первые главы посвящаются организации структуры и архитектуры 11g, ее инсталляции, запуску и настройке. Потом объясняются механизмы безопасности, исследуются критерии оценки соответствия требованиям. Уделяется внимание многопользовательскому конкурентному доступу, хранилищу данных, распределенным базам данных, OLTP-системам, обеспечению высокой доступности, аппаратным архитектурам. В число последних входят кластеры, симметричные мультипроцессоры, Numa-системы и gird-вычисления.
Все описания иллюстрируются примерами. Книгу ""Oracle 11g. Основы"" Рика Гринвальда, Роберта Стаковьяка и Джонатана Стерна можно рекомендовать всем, кто раньше не использовал Oracle, и только планирует приступить к работе с этими системами. В то же время руководство вполне подойдет в качестве справочника и уже использующим эти системы специалистам.",
                LanguageId = LanguageService.RUSSIAN,
                Authors = new List<Author>()
                {
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Гринвальд" && author.FirstName == "Рик"),
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Стаковьяк" && author.FirstName == "Роберт"),
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Стерн" && author.FirstName == "Джонатан")
                },
                Publishers = new List<Publisher>() { simvolPlus },
                BookTags = new List<BookTag>() { oracleDbTag, commonDbTag }
            });
            defaultBooks.Add(new Book()
            {
                Name = "101 Oracle8i. Организация работы в сети",
                PageCount = 500,
                Year = 2001,
                ImageName = "tero-101-oracle8i-organizaciya-raboty-v-seti.jpg",
                Description = @"В книге ""101 Oracle8i. Организация работы в сети"" рассматриваются основные принципы построения сетей, осуществление взаимодействия компонентов сетевой архитектуры Oracle, подробно описано программное и аппаратное обеспечение, которое необходимо для организации успешного соединения компьютеров и баз данных. В книге предлагаются пошаговые инструкции по созданию и конфигурированию сети Oracle, при этом инструкция снабжена иллюстрациями снимков экранов. Для ознакомления приводятся общие сведения о протоколах Интернета и шифровании.
Данное издание было одобрено и рекомендовано самой корпорацией Oracle.",
                LanguageId = LanguageService.RUSSIAN,
                Authors = new List<Author>()
                {
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Терьо" && author.FirstName == "Марлен")
                },
                Publishers = new List<Publisher>() { lori },
                BookTags = new List<BookTag>() { oracleDbTag, commonDbTag }
            });
            defaultBooks.Add(new Book()
            {
                Name = "Oracle. Программирование на языке Java",
                PageCount = 512,
                Year = 2010,
                ImageName = "solomon-oracle-programmirovanie-na-yazyke-java.jpg",
                Description = @"Издание ""Oracle. Программирование на языке Java"" представляет собой одно из самых полных справочных руководств по созданию программных компонентов Java для баз данных Oracle.
Изучив предложенный материал, читатель сможет самостоятельно строить приложения из отдельных компонентов, при этом приложения будут обладать возможностью обращаться к другим объектам в среде Oracle. В книге осуществляется демонстрация того, как необходимо работать с моделями серверных компонентов CORBA и Enterprise JavaBeans (EJB) для распределенных вычислительных систем. Также подробно освещаются вопросы, связанные с процессом разработки компонентов EJB и CORBA, разработкой и внедрением компонентных приложений с помощью SQLJ и Java и SQLJ. Предлагаются пошаговые инструкции построения приложений JavaServer Page (JSP). Читатель узнает, каким образом создавать приложения БД, которые производят управление схемами объектно-реляционных и реляционных баз данных.
В книге раскрыты следующие темы:
- способы работы в распределенных вычислительных средах; 
- осуществление построения компонентов Enterprise JavaBeans и CORBA; 
- организациями управления транзакциями; 
- построение страницы JSP на основе компонентов JavaBeans, CORBA, EJB; 
- создание приложений баз данных с помощью сервлетов, страниц JSP, XML; 
- применение утилиты XML-SQL для проведения запросов и операций обновления.",
                LanguageId = LanguageService.RUSSIAN,
                Authors = new List<Author>()
                {
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Соломон" && author.FirstName == "Мартин"),
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Мориссо-Леруа" && author.FirstName == "Нирва"),
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Басу" && author.FirstName == "Джули")
                },
                Publishers = new List<Publisher>() { lori },
                BookTags = new List<BookTag>() { oracleDbTag, commonDbTag }
            });
            defaultBooks.Add(new Book()
            {
                Name = "Oracle9i. Программирование на языке PL/SQL",
                PageCount = 544,
                Year = 2004,
                ImageName = "urman-oracle9i-programmirovanie-na-yazyke-pl-sql.jpg",
                Description = @"Руководство ""Oracle9i. Программирование на языке PL/SQL"" предназначено для программистов, желающих освоить разработку надежных приложений PL/SQL. В книге рассмотрены основные возможности баз данных различных версий. Издание призвано обучить разработке, тестированию и отладке приложений PL/SQL в различных средах разработки. Рассмотрен синтаксис PL/SQL, дано описание переменным, типам данных, операциям, выражениям, управляющим структурам. Показано использование различных сред разработки и выполнения PL/SQL, применение возможностей многоуровневых конструкций Oracle9i.
Рассмотрены вопросы обеспечения согласованности данных при помощи инструкций управления транзакциями SQL, создания и применения функций, модулей и процедур, использования DML, триггеров для решения сложных ограницений данных. Объяснено применение курсоров для управления обработкой инструкций SQL и для многострочных запросов. Раскрыта тема использования развитых средств PL/SQL, таких как встроенных динамический SQL, внешние процедуры и объектные типы. Книга официально одобрена корпорацией Oracle.",
                LanguageId = LanguageService.RUSSIAN,
                Authors = new List<Author>()
                {
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Урман" && author.FirstName == "Скотт")
                },
                Publishers = new List<Publisher>() { lori },
                BookTags = new List<BookTag>() { oracleDbTag, commonDbTag }
            });
            defaultBooks.Add(new Book()
            {
                Name = "Oracle9iR2: разработка и эксплуатация хранилищ баз данных",
                PageCount = 584,
                Year = 2004,
                ImageName = "hobbs-oracle9ir2-razrabotka-i-ekspluataciya-hranilisch-baz-dannyh.jpg",
                Description = @"Книга ""Oracle9iR2: разработка и эксплуатация хранилищ баз данных"" посвящена особенностям использования хранилищ данных (WareHouse). Описаны принципы построения хранилищ на базе СУБД Oracle9i. Рассмотрены теоретические и практические вопросы проектирования хранилищ данных - одной из самых сложных отраслей программной инженерии. Она учитывает все существующие методологии проектирования программного обеспечения, но их выполнение затрудняется в связи с относительной молодостью данной сферы и нехваткой специалистов, работающих в ней. Книга может служить пособием для различных специалистов в области интернет-технологий, а также будет полезной аналитикам, маркетологам и другим использующим в своей работе хранилища данных специалистам.",
                LanguageId = LanguageService.RUSSIAN,
                Authors = new List<Author>()
                {
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Хоббс" && author.FirstName == "Лиллиан"),
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Хилсон" && author.FirstName == "Сьюзан"),
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Лоуенд" && author.FirstName == "Шилпа")
                },
                Publishers = new List<Publisher>() { kudicObraz },
                BookTags = new List<BookTag>() { oracleDbTag, commonDbTag }
            });
            defaultBooks.Add(new Book()
            {
                Name = "Oracle9i XML. Разработка приложений электронной коммерции с использованием технологии XML",
                PageCount = 476,
                Year = 2003,
                ImageName = "chang-oracle9i-xml-razrabotka-prilozheniy-elektronnoy-kommercii-s-ispolzovaniem-tehnologii-xml.jpg",
                Description = @"""Oracle9i XML. Разработка приложений электронной коммерции с использованием технологии XML"", написанная разработчиками XML-продуктов компании Oracle, посвящена разработке и развертыванию основанных на транзакциях межплатформных приложений Оrасlе9i с применением технологии XML. Данная технология является ныне промышленным стандартом описания данных при организации Интернет-торговли и интеграции приложений электронного бизнеса.
Книга направлена на обучение эффективному использованию всех достоинств инструментального пакета разработчика Oracle XML Developer Kit (XDK) с целью создания, просмотра, преобразования и управления ХМL-документов. Использование встроенных в Оrасlе9i и поддерживающих технологию XML функций наглядно иллюстрируется различными практическими примерами, описанными в книге. Благодаря данной книге читатель узнает о преимуществах ХМL-инфраструктуры Оrасlе9i и инструментального пакета разработчика Oracle XML Developer Kit и научится их использовать.
В книге описано, как пользоваться синтаксическими анализаторами, генераторами, процессами, программами просмотра и различными утилитами пакета XDK. Читатель научится разработке приложений Оrасlе9i с помощью Java XML-компонентов, эффективному применению новых функций XML SQL и PL/SQL, созданию и использованию приложений для OAS и Оrасlе9iAS, ориентированных на обработку транзакций. В книге рассмотрено, как управлять различными типами данных - текстовыми, звуковыми, графическими, видео - при помощи средства Oracle Text, описаны особенности разработки приложений электронного бизнеса, работающих в системе Web с использованием компонента Oracle E-Business XML Services и многое другое.",
                LanguageId = LanguageService.RUSSIAN,
                Authors = new List<Author>()
                {
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Чанг" && author.FirstName == "Бен"),
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Скардина" && author.FirstName == "Марк"),
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Киритцов" && author.FirstName == "Стефан")
                },
                Publishers = new List<Publisher>() { lori },
                BookTags = new List<BookTag>() { oracleDbTag, commonDbTag }
            });
            defaultBooks.Add(new Book()
            {
                Name = "Oracle. Основы стоимостной оптимизации",
                PageCount = 528,
                Year = 2007,
                ImageName = "lyuis-oracle-osnovy-stoimostnoy-optimizacii.jpg",
                Description = @"Книга одного из крупнейших в своей сфере специалистов Джонатана Льюиса ""Oracle. Основы стоимостной оптимизации"" посвящена наиболее часто используемым компонентам модели обработки данных Oracle, описанию работы оптимизатора с предоставленной ему статистикой и причинам, по которым его работа может разладиться. Будучи всего лишь фрагментом кода, содержащим модель обработки данных Oracle, стоимостный оптимизатор применяет эту модель к статистике по вашим данным и пытается эффективно преобразовать в исполняемый план созданный вами запрос. Но поскольку модель зачастую далека от совершенства, а статистика тоже не всегда идеальна, то получившийся план исполнения может оставлять желать лучшего. Располагая информацией о том, почему работа оптимизатора может разладиться, можно не только исправить отдельные операторы SQL, но и отрегулировать модель, создать более надежную статистику и тем самым полностью усовершенствовать проблемные области.",
                LanguageId = LanguageService.RUSSIAN,
                Authors = new List<Author>()
                {
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Льюис" && author.FirstName == "Дж.")
                },
                Publishers = new List<Publisher>() { piter },
                BookTags = new List<BookTag>() { oracleDbTag, commonDbTag }
            });
            defaultBooks.Add(new Book()
            {
                Name = "Введение в Oracle 10g",
                PageCount = 704,
                Year = 2006,
                ImageName = "perri-vvedenie-v-oracle-10g.jpg",
                Description = @"Самоучитель ""Введение в Oracle 10g"" Дж. Перри и Дж. Поста дает возможность ознакомиться с базовыми принципами работы системы управления базами данных Oracle, потренироваться в применении основных навыков и закрепить в памяти усвоенные знания. Предлагаемый материал подробно изложен и хорошо проиллюстрирован множеством примеров. Книга написана простым и доступным языком и будет удачным приобретением в первую очередь для людей, не имеющих большого опыта в общении с базами данных. К самоучителю прилагается словарь наиболее важных и часто используемых терминов, необходимых каждому, кто работает с различными системами управления базами данных. Книга рассчитана на широкий круг читателей, но может использоваться и в качестве учебного пособия для аспирантов и студентов, получающих образование в области информационных технологий.",
                LanguageId = LanguageService.RUSSIAN,
                Authors = new List<Author>()
                {
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Перри" && author.FirstName == "Джеймс"),
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Пост" && author.FirstName == "Джеральд")
                },
                Publishers = new List<Publisher>() { williams },
                BookTags = new List<BookTag>() { oracleDbTag, commonDbTag }
            });
            defaultBooks.Add(new Book()
            {
                Name = "Oracle PL/SQL для администраторов баз данных",
                PageCount = 496,
                Year = 2008,
                ImageName = "nanda-oracle-pl-sql-dlya-administratorov-baz-dannyh.jpg",
                Description = @"PL/SQL - это очень мощный процедурный язык компании Oracle, который является основой приложений, создаваемых на технологиях Oracle последние пятнадцать лет. Первоначально PL/SQL предназначался исключительно для разработчиков. Но на сегодняшний день он стал важным инструментом администрирования баз данных, поскольку непосредственная ответственность администраторов за высокую производительность баз данных повысилась, а отличия между разработчиками и администраторами шаг за шагом стираются. Издание ""Oracle PL/SQL для администраторов баз данных"" - это самая первая книга, в которой PL/SQL рассматривается со стороны администрирования. Следует отметить, что изложение ориентировано на версию программы 10g Release 2 и начинается с краткого обзора PL/SQL, которого будет достаточно для знакомства администратора БД с азами этого языка и последующего начала работы на нем. Затем в описываемой книге рассматриваются вопросы обеспечения безопасности, которые можно отнести к администрированию базы данных: контроль доступа на уровне строк, шифрование (описаны как обычные методы, так и инновационное прозрачное шифрование Oracle - TDE), генерация случайных значений и тщательный аудит (FGA). Особое внимание в книге уделено способам увеличения производительности базы данных, а также запросов за счет использования табличных функций и курсоров. В ней описывается применение планировщика Oracle, который даёт возможность настроить систематическое выполнение таких заданий, как сбор статистики и мониторинг базы данных.",
                LanguageId = LanguageService.RUSSIAN,
                Authors = new List<Author>()
                {
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Нанда" && author.FirstName == "Аруп"),
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Фейерштейн" && author.FirstName == "Стивен")
                },
                Publishers = new List<Publisher>() { simvolPlus },
                BookTags = new List<BookTag>() { oracleDbTag, commonDbTag }
            });
            defaultBooks.Add(new Book()
            {
                Name = "Секреты Oracle SQL",
                PageCount = 368,
                Year = 2003,
                ImageName = "mishra-sekrety-oracle-sql.jpg",
                Description = @"Издание ""Секреты Oracle SQL"" на множестве примеров раскрывает перед вами способы использования средств SQL для того, чтобы создавать не просто удобные, но и крайне эффективные сопровождения запросов в среде Oracle. Эта книга поможет вам строить эффективные запросы, которые будут работать с коллекциями и объектами, применять возможности CASE и DECODE для создания условной логики при формировании запросов SQL и использовать для создания оконных запросов многочисленные аналитические функции SQL. Помимо этого, вы сможете освоить сложные группирующие функции, использование ANSI-совместимого синтаксиса объединения, научитесь в полной мере использовать многочисленные конструкции SQL, среди которых всем известные группы, подзапросы, объединения и многое другое. Изучая информацию на страницах книги, вы не только станете более уверено создавать SQL-запросы, но, и повысите свою образованность в этой сфере, а, как следствие, и производительность. Научившись использовать в своей работе новые типы для дат и времени, обрабатывать иерархические данные, вы сможете, используя свойства Oracle SQL, решать вполне определенные задачи при помощи недоступных ранее приемов. Книга ""Секреты Oracle SQL"" предназначена для программистов на PL/SQL и Java-программистов, администраторов баз банных.",
                LanguageId = LanguageService.RUSSIAN,
                Authors = new List<Author>()
                {
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Мишра" && author.FirstName == "Санжей"),
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Бьюли" && author.FirstName == "Алан")
                },
                Publishers = new List<Publisher>() { simvolPlus },
                BookTags = new List<BookTag>() { oracleDbTag, commonDbTag }
            });
            defaultBooks.Add(new Book()
            {
                Name = "101: Oracle PL/SQL",
                PageCount = 350,
                Year = 2001,
                ImageName = "kristofer-allen-101-oracle-pl-sql.jpg",
                Description = @"Книга ""101 Oracle PL/SQL. Как написать мощные и гибкие программы на PL/SQL"" подробно и наглядно объясняет, такие темы, как использование SQL для работы с базой данных и автоматизацию сложнейших задач при помощи PL/SQL. Обучение происходит на конкретных примерах, поэтому при прочтении будут даваться некоторые практические задачи, помогающие закрепить и усвоить изученный материал. Автор пользуется принципом ""От простого - к сложному"", в связи с чем, вначале будут рассматриваться основные понятия, как ""столбец"", ""таблица"", ""строка"", ""запись"", ""поле"", а уже при дальнейшем изучении в книге обсуждается сохранение, извлечение и модификация данных, управление специальной программой SQL *Plus, написание программы на PL/SQL и создание SQL - функций. В процессе изучения учебника читатель научится созданию таблиц и индексов, ограничению баз данных; написанию SQL команд для выборки, обновления и вставки, удаления данных; написанию законченных процедур и функций PL/SQL; манипулированию данными; созданию пакетов PL/SQL; объявлению переменных с использованием различных привязанных типов; использованию событий (триггеров) для осуществления сложных бизнес-правил и поддержанию безопасности. Автор книги имеет сертификат специалиста по базам данных Oracle, а сам учебник одобрен руководством корпорации, как дающий все необходимые сведения для начала успешной и эффективной работы с SQL и PL/SQL.",
                LanguageId = LanguageService.RUSSIAN,
                Authors = new List<Author>()
                {
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Аллен" && author.FirstName == "Кристофер")
                },
                Publishers = new List<Publisher>() { lori },
                BookTags = new List<BookTag>() { oracleDbTag, commonDbTag }
            });
            defaultBooks.Add(new Book()
            {
                Name = "Oracle. Оптимизация производительности",
                PageCount = 464,
                Year = 2006,
                ImageName = "milsap-oracle-optimizatsiya-proizvoditel.jpg",
                Description = @"Книга ""Oracle. Оптимизация производительности"" посвящена такой важной и сложной теме как оптимизация производительности БД Oracle. Удачная настройка чаще является случайной, достигаемой методом проб и ошибок. Известные исследователи Oracle, Милсап и Хольт, предлагают вашему вниманию надёжный и чёткий метод обнаружения узких мест в производительности системы, помогающий определить причину проблемы. Суть метода заключается в использовании информации, получаемой от предоставленных Oracle инструментов, которые позволяют узнать какие запросы сколько времени требуют. Метод состоит из трех этапов: определяется операция, требующая оптимизации с точки зрения бизнеса; сбор данных расширенной трассировки SQL, которые относятся к этой операции и выяснение по этой информации причин больших затрат времени; поиск продуктивного способа повышения производительности операции. Авторы описывают применение метода и причины его эффективности. Предложенный метод также может помочь в оценке роста производительности при увеличении количества процессоров, мощности или наращивании оперативной памяти. Книга адресована разработчикам и администраторам БД Oracle.",
                LanguageId = LanguageService.RUSSIAN,
                Authors = new List<Author>()
                {
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Хольт" && author.FirstName == "Кэри")
                },
                Publishers = new List<Publisher>() { simvolPlus },
                BookTags = new List<BookTag>() { oracleDbTag, commonDbTag }
            });
           
        }
    }
}