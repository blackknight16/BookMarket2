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
        private void PartialSeed2(BookMarketDbContext dbContext)
        {
            //----- Зависимые сущности
            defaultBookTags = new List<BookTag>();
            defaultBookTags.Add(new BookTag() { Name = "C#", BookTypeId = BookTypeService.PROGRAM_LANGUAGES });
            defaultBookTags.Add(new BookTag() { Name = "F#", BookTypeId = BookTypeService.PROGRAM_LANGUAGES });
            defaultBookTags.Add(new BookTag() { Name = "Haskell", BookTypeId = BookTypeService.PROGRAM_LANGUAGES });
            defaultBookTags.Add(new BookTag() { Name = "Java", BookTypeId = BookTypeService.PROGRAM_LANGUAGES });
            defaultBookTags.Add(new BookTag() { Name = "Python", BookTypeId = BookTypeService.PROGRAM_LANGUAGES });

            defaultBookTags.Add(new BookTag() { Name = "AJAX", BookTypeId = BookTypeService.WEB_PROGRAMMING });
            defaultBookTags.Add(new BookTag() { Name = "ASP(.NET)", BookTypeId = BookTypeService.WEB_PROGRAMMING });
            defaultBookTags.Add(new BookTag() { Name = "Javascript", BookTypeId = BookTypeService.WEB_PROGRAMMING });
            defaultBookTags.Add(new BookTag() { Name = "PHP", BookTypeId = BookTypeService.WEB_PROGRAMMING });
            defaultBookTags.Add(new BookTag() { Name = "Silverlight", BookTypeId = BookTypeService.WEB_PROGRAMMING });

            defaultBookTags.Add(new BookTag() { Name = "Android", BookTypeId = BookTypeService.MOBILE_PROGRAMMING });
            defaultBookTags.Add(new BookTag() { Name = "Iphone", BookTypeId = BookTypeService.MOBILE_PROGRAMMING });
            defaultBookTags.Add(new BookTag() { Name = "Windows Phone", BookTypeId = BookTypeService.MOBILE_PROGRAMMING });

            defaultBookTags.Add(new BookTag() { Name = "БД.Общее", BookTypeId = BookTypeService.DATA_BASES });
            defaultBookTags.Add(new BookTag() { Name = "MySQL", BookTypeId = BookTypeService.DATA_BASES });
            defaultBookTags.Add(new BookTag() { Name = "Microsoft SQL Server", BookTypeId = BookTypeService.DATA_BASES });
            defaultBookTags.Add(new BookTag() { Name = "Oracle Database", BookTypeId = BookTypeService.DATA_BASES });
            defaultBookTags.Add(new BookTag() { Name = "PostgreSQL", BookTypeId = BookTypeService.DATA_BASES });
            foreach (var element in defaultBookTags)
                dbContext.BookTags.Add(element);
            dbContext.SaveChanges();

            //Теги
            ajaxTag = dbContext.BookTags.Find(BookTagService.AJAX.Id);
            //algorithmsTag = dbContext.BookTags.Find(BookTagService.ALGORITHMS.Id);
            androidTag = dbContext.BookTags.Find(BookTagService.ANDROID.Id);
            aspNetTag = dbContext.BookTags.Find(BookTagService.ASP_NET.Id);
            cDiesTag = dbContext.BookTags.Find(BookTagService.C_DIES.Id);
            commonDbTag = dbContext.BookTags.Find(BookTagService.COMMON_DB.Id);
            //cryptographyTag = dbContext.BookTags.Find(BookTagService.CRYPTOGRAPHY.Id);
            fDiesTag = dbContext.BookTags.Find(BookTagService.F_DIES.Id);
            haskellTag = dbContext.BookTags.Find(BookTagService.HASKELL.Id);
            iPhoneTag = dbContext.BookTags.Find(BookTagService.IPHONE.Id);
            javaTag = dbContext.BookTags.Find(BookTagService.JAVA.Id);
            javascriptTag = dbContext.BookTags.Find(BookTagService.JAVASCRIPT.Id);
            //mathTag = dbContext.BookTags.Find(BookTagService.MATH.Id);
            microsoftSQLServerTag = dbContext.BookTags.Find(
                BookTagService.MICROSOFT_SQL_SERVER.Id);
            mySQLTag = dbContext.BookTags.Find(BookTagService.MYSQL.Id);
            oracleDbTag = dbContext.BookTags.Find(BookTagService.ORACLE_DB.Id);
            phpTag = dbContext.BookTags.Find(BookTagService.PHP.Id);
            postgreSQLTag = dbContext.BookTags.Find(BookTagService.POSTGRE_SQL.Id);
            /*projectMakingAndDevelopmentTag = dbContext.BookTags.Find(
                BookTagService.PROJECT_MAKING_AND_DEVELOPMENT.Id);*/
            pythonTag = dbContext.BookTags.Find(BookTagService.PYTHON.Id);
            silverlightTag = dbContext.BookTags.Find(BookTagService.SILVERLIGHT.Id);
            //testingTag = dbContext.BookTags.Find(BookTagService.TESTING.Id);
            windowsPhoneTag = dbContext.BookTags.Find(BookTagService.WINDOWS_PHONE.Id);
            //Издательства
            piter = dbContext.Publishers.Find(PublisherService.PITER);
            bhvPeterburg = dbContext.Publishers.Find(PublisherService.BHV_PETERBURG);
            bhvSanktPeterburg = dbContext.Publishers.Find(PublisherService.BHV_SANKT_PETERBURG);
            kudicPress = dbContext.Publishers.Find(PublisherService.KUDIC_PRESS);
            ricSchola = dbContext.Publishers.Find(PublisherService.RIC_SHCOLA);
            russkayaRedakciya = dbContext.Publishers.Find(PublisherService.RUSSKAYA_REDAKCIYA);
            williams = dbContext.Publishers.Find(PublisherService.WILLIAMS);
            dialektika = dbContext.Publishers.Find(PublisherService.DIALEKTIKA);
            dmkPress = dbContext.Publishers.Find(PublisherService.DMK_PRESS);
            gINFO = dbContext.Publishers.Find(PublisherService.GINFO);
            cambridgeAcadem = dbContext.Publishers.Find(PublisherService.CAMBRIDGE_ACADEM);
            kudicObraz = dbContext.Publishers.Find(PublisherService.KUDIC_OBRAZ);
            lori = dbContext.Publishers.Find(PublisherService.LORI);
            binom = dbContext.Publishers.Find(PublisherService.BINOM);
            laboratoriyaZnanii = dbContext.Publishers.Find(PublisherService.LABORATORIYA_ZNANII);
            bhv = dbContext.Publishers.Find(PublisherService.BHV);
            simvolPlus = dbContext.Publishers.Find(PublisherService.SIMVOL_PLUS);
            altLinux = dbContext.Publishers.Find(PublisherService.ALT_LINUX);
            internetUniversitetInformacionnihTechnologii = dbContext.Publishers.Find(
                PublisherService.INTERNET_UNIVERSITET_INFORMACIONNIH_TECHNOLOGII);
            solonPress = dbContext.Publishers.Find(PublisherService.SOLON_PRESS);
            entrop = dbContext.Publishers.Find(PublisherService.ENTROP);
            noviiIzdatelskiiDom = dbContext.Publishers.Find(
                PublisherService.NOVII_IZDATELSKII_DOM);
            eksmo = dbContext.Publishers.Find(PublisherService.EKSMO);
            folio = dbContext.Publishers.Find(PublisherService.FOLIO);
            naukaITechnika = dbContext.Publishers.Find(PublisherService.NAUKA_I_TECHNIKA);
            ntPress = dbContext.Publishers.Find(PublisherService.NT_PRESS);
            ridGrupp = dbContext.Publishers.Find(PublisherService.RID_GRUPP);
            microsoftPress = dbContext.Publishers.Find(PublisherService.MICROSOFT_PRESS);
            microsoftCorporation = dbContext.Publishers.Find(
                PublisherService.MICROSOFT_CORPORATION);
            finansiIStatistica = dbContext.Publishers.Find(
                PublisherService.FINANSI_I_STATISTICA);
            aST = dbContext.Publishers.Find(PublisherService.AST);
            mIR = dbContext.Publishers.Find(PublisherService.MIR);
            mGTUImBaumana = dbContext.Publishers.Find(PublisherService.MGTU_IM_BAUMANA);
            geliosARV = dbContext.Publishers.Find(PublisherService.GELIOS_ARV);
            dVGUPS = dbContext.Publishers.Find(PublisherService.DVGUPS);
            mashinostroenie = dbContext.Publishers.Find(PublisherService.MASHINOSTROENIE);
            infraM = dbContext.Publishers.Find(PublisherService.INFRA_M);
            technosfera = dbContext.Publishers.Find(PublisherService.TECHNOSFERA);
            izdatelstvoMGU = dbContext.Publishers.Find(PublisherService.IZDATELSTVO_MGU);
            naukovaDumka = dbContext.Publishers.Find(PublisherService.NAUKOVA_DUMKA);
            radianskaSchoola = dbContext.Publishers.Find(PublisherService.RADIANSKA_SCHOOLA);
            dialogMIFI = dbContext.Publishers.Find(PublisherService.DIALOG_MIFI);
            nauka = dbContext.Publishers.Find(PublisherService.NAUKA);
            dialogSivir = dbContext.Publishers.Find(PublisherService.DIALOG_SIVIR);
            radioISvyas = dbContext.Publishers.Find(PublisherService.RADIO_I_SVYAZ);
            logos = dbContext.Publishers.Find(PublisherService.LOGOS);
            gidDS = dbContext.Publishers.Find(PublisherService.GID_DS);
            goryachayaLiniyaTelekom = dbContext.Publishers.Find(
                PublisherService.GORYACHAYA_LINIYA_TELEKOM);
            triumf = dbContext.Publishers.Find(PublisherService.TRIUMF);
            diaSoftUP = dbContext.Publishers.Find(PublisherService.DIA_SOFT_UP);

            //Книги
            defaultBooks = new List<Book>();
            defaultBooks.Add(new Book()
            {
                Name = "CLR via C#. Программирование на платформе Microsoft " +
                       ".NET Framework 4.0 на языке C#, 3-е издание",
                PageCount = 928,
                Year = 2012,
                ImageName =
                    "rihter-clr-via-c-programmirovanie-na-platforme-microsoft-net-framework-4-0-na-yazyke-c.jpg",
                Description = @"Книга «CLR via C#. Программирование на платформе Microsoft .NET Framework 4.0 на языке C#» является мастер-классом и считается классическим учебником программирования, в котором содержится подробное описание языковой среды Microsoft .NET Framework 4.0. 
Третье издание подробно рассматривает функционирование и внутреннее устройство общеязыковой среды. Книга учит создавать надёжные приложения различной тематики и вида, используя платформы Microsoft Silverlight, Windows Presentation Foundation, ASP.NET и другие. Данное издание содержит обновления соответствующие принципу многоядерного программирования и платформе .NET Framework версии 4.0. 
Книга «CLR via C#. Программирование на платформе Microsoft .NET Framework 4.0 на языке C#» написана признанным экспертом Джеффри Рихтером, знающим своё дело в области программирования. Автор издания на протяжении долгих лет является членом команды разработчиков компании Microsoft и консультантом .net Framework, благодаря чему имеет многолетний опыт и необходимую базу знаний для обучения начинающих программистов.",
                LanguageId = LanguageService.RUSSIAN,
                Authors = new List<Author>()
                {
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Рихтер" && author.FirstName == "Джеффри")
                },
                Publishers = new List<Publisher>() { piter },
                BookTags = new List<BookTag>() { cDiesTag }
            });
            defaultBooks.Add(new Book()
            {
                Name = "Изучаем C#, 2-е издание",
                PageCount = 704,
                Year = 2012,
                ImageName = "stillmen-izuchaem-c-2-e-izdanie.jpg",
                Description = @"Самый лучший учебник по программированию - тот, который обучает тебя на практике. Так считают авторы учебника ""Изучаем Си#"", предлагая обучающий курс для начинающих, который не тратит время на унылое перечисление стандартов языка и академических понятий, а сразу на ""живых"" примерах показывают практическое применение Си#.
Для программной платформы .NET было создано множество языков, от видоизменённого Си++ до Visual Basic .NET, но исторически сложилось так, что лишь Си# получил всемирное признание у программистов. Взяв у своего прародителя Си максимально простой синтаксис, у своего ""кузена"" Си++ возможность работы с классами, Си# тем не менее является языком, совершенно отличным от обоих. Максимальная автоматизация распределения памяти, абстрагирование от ""железа"" (ведь работает программа, написанная на Си#, в виртуальной машине .NET, что обеспечивает максимальную одинаковость работы на совершенно разных компьютерах), внедрённая в язык ""защита от дурака"" позволяют программисту не тратить время и силы на сражение с ""утечками"", как при программировании на Си, а очень простой синтаксис позволяют компилировать программы порой в сотни раз быстрее, чем это происходит у Си++.
Большая часть литературы по Си#, однако, страдает излишней ""академичностью"", которая совершенно не поможет начинающему программисту, и раздражает профессинала, который просто решил освоить ещё один язык в придачу к имеющемуся багажу знаний. Учитывая этот недостаток, Эндрю Стиллмен и Дженнифер Грин создали это пособие, которое вместо сухого изложения синтаксиса постепенно, начиная от самых основ, на практических примерах показывает применение языка Си# для платформы .NET 4.0. В качестве среды разработки авторы книги ""Изучаем С#"" выбрали Visual Studio 2010, которая (в редакции Visual C# Express) бесплатно доступна для загрузки с серверов Microsoft.",
                LanguageId = LanguageService.RUSSIAN,
                Authors = new List<Author>()
                {
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Стиллмен" && author.FirstName == "Э."),
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Грин" && author.FirstName == "Дж."),
                },
                Publishers = new List<Publisher>() { piter },
                BookTags = new List<BookTag>() { cDiesTag }
            });
            defaultBooks.Add(new Book()
            {
                Name = "Web-сервисы Microsoft .NET",
                PageCount = 334,
                Year = 2002,
                ImageName = "shaposhnikov-web-servisy-microsoft-net.jpg",
                Description = @"Учебник будет содержать важную информацию по работе с Веб сервисами Microsoft .NET. Книга будет иметь массу примеров работы с Веб-сервивами и приемы создания новых проектов. Пособие гарантировано научит каждого, даже новичка применять эти знания на практике и использовать в работе с Веб-сайтами.
Книга будет содержать общие сведения о языках WSDL и SOAP, которые помогают осуществлять программирования разных сервисов и клиентских приложений. Учебник будет полон различными комментариями к примерам, что поможет быстро разобраться в работе с Веб-сервисами.
Учебник будет просто находкой для любого программиста, разработчика и также для администратора Веб-сайта. Изначально пособие покажет, как нужно создавать простейший сервис и как с ним дальше работать. Далее будет показано, как использовать на практике известные языки программирования WSDL и SOAP. Следующая глава книги будет посвящена базам данных и основной работе с ними. Пособие далее расскажет про основные приемы разработки различных сервисов и про поддержку пиринговых сетей. Отдельная тема будет посвящена распределенным приложениям и методам работы с ними.
Книга будет рассматривать основные методы работы и создания приложений на базе Веб-сервисов. Также пособие разъяснит все вопросы интеграции с серверами баз данных на основе известной технологии ADO.NET. Учебник подробно рассмотрит создание выше сказанных распределенных приложений и научит каждого читателя использовать все эти знания на практике и в работе.
Идеально использовать книгу каждому преподавателю в университете, ведь она поможет студентам быстро разобраться в теме Веб-программирования и создании Веб-сервисов. Все примеры помогут каждому студенту быстро войти в курс дела и запомнить все важные понятия. Интересные задачи и задания помогут без напряжения запомнить нужную информацию и в будущем легко ее использовать.
Книга «Web-сервисы Microsoft .NET» даст полную информацию каждому человеку про все методы работы с Веб-сервисами и поможет на основе всех знаний создавать новые проекты. Даже новичок сможет понять эту тему, ведь автор книги Игорь Шапошников очень просто и доступно излагает эту тематику. Он использует множество примеров из своей жизни и работы, что позволяет каждому получить важные знания и не допускать ошибок в этой сфере. Автор делает пособие максимально интересным, что помогает каждому легко изучить Веб-программирование и с удовольствием его использовать в создании новых проектов.",
                LanguageId = LanguageService.RUSSIAN,
                Authors = new List<Author>()
                {
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Шапошников" && author.FirstName == "Игорь")
                },
                Publishers = new List<Publisher>() { bhvPeterburg },
                BookTags = new List<BookTag>() { cDiesTag }
            });
            defaultBooks.Add(new Book()
            {
                Name = "C# для начинающих",
                PageCount = 304,
                Year = 2007,
                ImageName = "martynov-c-dlya-nachinayuschih.jpg",
                Description = @"Учебник представляет собой сборник лекций по информатики и основам программирования на C#, который могут использовать студенты, преподаватели, школьники, учителя, а также все, кто сталкивается в своей работе с компьютерными программами, интенсивно использующими элементы мультимедиа. Это могут быть приложения, решающие прикладные задачи по физике, математике, химии или каким-либо гуманитарным наукам.
Для более эффективного освоения курса желательно, чтобы у читателя уже имелись минимальные знания по информатики и основам программирования на C. Также рекомендуется прочесть предыдущий том автора - ""Информатика. С для начинающих"", Издательство ""КУДИЦ-ОБРАЗ"", Москва, 2006.
Дл практической работы можно пользоваться компиляторами Microsoft Visual С# NET (2003) и Microsoft Visual C# NET (2005), подробную информацию по которым можно найти в Приложении к настоящей книге Мартынова Н. Н. ""C# для начинающих"".",
                LanguageId = LanguageService.RUSSIAN,
                Authors = new List<Author>()
                {
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Мартынов" && author.FirstName == "Н.")
                },
                Publishers = new List<Publisher>() { kudicPress },
                BookTags = new List<BookTag>() { cDiesTag }
            });
            defaultBooks.Add(new Book()
            {
                Name = "Особенности объектно-ориентированного программирования на C++/CLI, C# и Java",
                PageCount = 444,
                Year = 2010,
                ImageName = "medvedev-osobennosti-obektno-orientirovannogo-programmirovaniya-na-c-cli-c-i-java.jpg",
                Description = @"В книге описаны основы синтаксиса и методика разработки приложений на нескольких объектно-ориентированных языках программирования: C++/CLI, C# и Java (J#). Особенностью изложенного в книге материала является параллельное сравнивание на конкретных примерах схожих языковых конструкций. Добавочно каждая из программ для более наглядного понимания взаимосвязи между объектами поясняется UML диаграммами.
Более детально рассмотрены такие сложные для самостоятельного изучения конструкции языка, как делегаты, события, потоки и их синхронизация. Подробно описаны особенности синтаксиса и использования в каждом из трех языков.
Книга Медведева В. И. ""Особенности объектно-ориентированного программирования на C++/CLI, C# и Java"" будет полезна для изучения преподавателям и студентам профильных ВУЗов, а также профессионалам, имеющих опыт программирования на C++ и желающих освоить разработку на других языках.",
                LanguageId = LanguageService.RUSSIAN,
                Authors = new List<Author>()
                {
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Медведев" && author.FirstName == "В.")
                },
                Publishers = new List<Publisher>() { ricSchola },
                BookTags = new List<BookTag>() { cDiesTag, javaTag }
            });
            defaultBooks.Add(new Book()
            {
                Name = "Альманах программиста. Том 3. Платформа 2003: Microsoft Windows Server 2003, Microsoft Internet Information Services 6.0, Microsoft Office System",
                PageCount = 320,
                Year = 2003,
                ImageName = "kupcevich-almanah-programmista-tom-3-platforma-2003-microsoft-windows-server",
                Description = @"В издании, предназначенном для интересующихся современными программными разработками и развитием продукции Microsoft, рассказывается о приложениях на платформе 2003. Информация собрана Ю. Купцевичем «из первых рук» – «Альманах программиста» создан на базе журналов, авторами которых являются сами разработчики и тестеры обсуждаемых приложений.",
                LanguageId = LanguageService.RUSSIAN,
                Authors = new List<Author>()
                {
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Купцевич" && author.FirstName == "Ю.")
                },
                Publishers = new List<Publisher>() { russkayaRedakciya },
                BookTags = new List<BookTag>() { cDiesTag }
            });
            defaultBooks.Add(new Book()
            {
                Name = "Практика программирования USB",
                PageCount = 624,
                Year = 2006,
                ImageName = "agurov-praktika-programmirovaniya-usb.jpg",
                Description = @"Данное пособие включает в себя всю необходимую информацию о создании USB-устройств - от написания программы для микроконтроллера (на примере микропроцессора AT89C5131), до разработки своего собственного WDM-драйвера. Кроме того, в пособии описан процесс создания драйверов для операционной системы Windows 2000 и Windows XP. В ходе изучения материала пользователи узнают, как пользоваться HID-классом, который позволит обходиться без разработки драйверов, как устроен класс CDC, работающий с USB как с COM-портом, рассмотрены функции Direct Input, Raw Input и Setup API.
Также пособие ""Практика программирования USB"", созданное Павлом Агуровым, содержит примеры программ на языках C, C# и Delphi, а сам автор на протяжении всего пособия дает множество практических советов. Кроме того, для удобства читателей, на прилагаемом компакт-диске содержатся все исходные коды описанных в пособии программ и драйверов.",
                LanguageId = LanguageService.RUSSIAN,
                Authors = new List<Author>()
                {
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Агуров" && author.FirstName == "Павел")
                },
                Publishers = new List<Publisher>() { bhvPeterburg },
                BookTags = new List<BookTag>() { cDiesTag }
            });
            defaultBooks.Add(new Book()
            {
                Name = "C# 2005 для \"чайников\"",
                PageCount = 576,
                Year = 2008,
                ImageName = "devis-sfer-c-2005-dlya-chaynikov.jpg",
                Description = @"Данная книга станет для вас прекрасным «учителем», с ее помощью каждый человек сможет ознакомиться с языком программирования С#, который используется для написания программ любой сложности. Прочитав книгу, вы ознакомитесь с особенностями данного языка программирования и сможете сами попробовать себя в новой сфере деятельности.
Вы желаете освоить с нуля язык программирования С#? Тогда данная книга была создана специально для вас. Она поможет вам попробовать себя в написании программ любой сложности. Книга будет полезной как для начинающих программистов, так и для тех, кто не понаслышке знаком с данным видом деятельности. Для тех, кто уж опробовал свои силы в других языках программирования, процесс освоения С# будет гораздо легче, но для освоения книги совершенно не обязательно иметь такой опыт.
Стефан Рэнди Дэвис и Чак Сфер в своей книге «C# 2005 для «чайников» знакомят своих читателей с типами, конструкциями, а также операторами языка C#, также они дают определенную базу знаний о ключевых концепциях объектно-ориентированного программирования, которые реализованы в данном языке. Стоит отметить тот факт, что данный язык в настоящее время считается одним из наиболее подходящих языков программирования, при помощи которого можно создавать разнообразные программы для Windows-среды.
Если вы твердо решили для себя освоить навыки программирования, то вам не стоит сомневаться, покупать данную книгу, или нет. С ее помощью вы легко и просто освоите нелегкое, но столь увлекательное дело, как написание программ. Пробуйте – и у вас все получится!",
                LanguageId = LanguageService.RUSSIAN,
                Authors = new List<Author>()
                {
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Дэвис" && author.FirstName == "Стефан"),
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Сфер" && author.FirstName == "Чак")
                },
                Publishers = new List<Publisher>() { williams },
                BookTags = new List<BookTag>() { cDiesTag }
            });
            defaultBooks.Add(new Book()
            {
                Name = "Самоучитель Visual Studio .NET 2003",
                PageCount = 682,
                Year = 2003,
                ImageName = "garnaev-samouchitel-visual-studio-net-2003.jpg",
                Description = @"Книга рассказывает, как нужно работать с различными приложениями на основе Visual Studio .NET и какими функциями она обладает. Пособие рассмотрит мощнейшие средства интеллектуальной Visual Studio .NET и покажет каждому читателю, как можно сделать процесс разработки гораздо проще. Учебник каждого научит быстрому программированию и конструкции приложений на Виндоус и Веб. Книга познакомит вас с основным типами переносных устройств и работой с графикой для приложений.
Пособие объяснит, какие приемы нужно использовать, чтобы сделать процесс программирования дешевле, и как можно будет быстрее создавать те или иные приложения для работы. Книга поможет каждому научиться разрабатывать свои собственные серверные компоненты и конструировать новые программы. Учебник покажет, как нужно работать с базами данных при помощи Visual Studio .NET.
Книга будет рассказывать, как можно легко сконструировать Веб-страницы и в будущем их аутентифицировать, или кэшировать. Все способы работы станут доступны каждому читателю, и уже после прочтения можно будет создавать собственные приложения с Visual Studio .NET. Пособие поможет каждому создавать свои справочные системы и покажет все приемы работы с ними.
Стоит обратить внимание, что учебник будет содержать более трехсот примеров, которые будут иметь подробное описание, полезные рисунки и таблицы для работы. Все это будет полезно и даст огромный опыт каждому программисту новичку и начинающему специалисту в сфере Visual Studio .NET.
Книга будет также содержать в себе полезные справочники по Visual Studio .NET, которые смогут ответить на любой вопрос читателя и помогут найти любой непонятный термин. Рекомендуется использовать пособие, как настольную книгу, которая всегда будет помогать в работе и помогать находить простые решения в любой ситуации.
Книга «Самоучитель Visual Studio .NET 2003» будет полезна для обучения студентов каждому профессиональному педагогу. Ведь все примеры и задачи помогут каждому студенту войти в курс дела и за короткий срок освоить все методы работы с Visual Studio .NET. Автор это шедевра — Андрей Гарнаев — писал на основе своих известных лекций, которые читались в Санкт-Петербургском университете и имели огромный успех. Поэтому пособие будет содержать максимально полезную и важную информацию, которая изложена в интересной и простой форме. Учебник будет незаменим для любого программиста, который хочет освоить Visual Studio .NET и успешно работать в этой сфере.",
                LanguageId = LanguageService.RUSSIAN,
                Authors = new List<Author>()
                {
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Гарнаев" && author.FirstName == "Андрей")
                },
                Publishers = new List<Publisher>() { bhvPeterburg },
                BookTags = new List<BookTag>() { cDiesTag }
            });
            defaultBooks.Add(new Book()
            {
                Name = "Самоучитель C#",
                PageCount = 576,
                Year = 2001,
                ImageName = "sekunov-samouchitel-c.jpg",
                Description = @"Книга будет целиком и полностью посвящена основному компонентно-ориентированному языку программирования для распределенных приложений C#. Пособие будет подробно рассказывать об основных сведениях и компонентах языка C#. Начинаться учебник будет с самых простых основ и первых терминов, которые должен знать каждый новичок. Поэтому самоучитель подойдет для человека с любым уровнем подготовки к программированию.
Учебник будет подробно рассматривать известнейшую среду для разработки новых приложений Microsoft Visual Studio.NET и научит всех ее функциям и методам работы с ней. Книга отдельную главу посвятит структуре программ на языке C# и в популярнейшей форме расскажет обо всех этапах компиляции. Вся информация будет максимально понятной даже обычному новичку и благодаря примерам ее можно будет быстро и эффективно запомнить.
Книга будет рассказывать об основах объединения компонентов, которые могут быть написаны на различных языках профессионального уровня. Пособие покажет, как можно реализовывать свой собственный пользовательский интерфейс и какими еще полезными свойствами будет обладать эта функция. Учебник наглядно покажет, как нужно обеспечивать безопасность своим приложениям и покажет на примерах основные способы работы с ними.
Пособие поможет каждому читателю в совершенстве освоить язык программирования C# и с высокой эффективностью использовать его в будущей работе. Благодаря множеству примеров и наглядных иллюстраций, даже новичок легко разберется во всех темах и сможет получить основные навыки программирования на известном языке C#.
Учебник рекомендуется использовать каждому программисту, независимо от уровня подготовки. Для новичков самоучитель поможет узнать всю базу про язык программирования C# и научит самым известным методам работы с новыми приложениями. А для специалиста книга поможет вспомнить основные навыки, ответит на вопросы, возникающие при работе, и будет очень полезной настольной книгой.
Книга «Самоучитель C#» поможет каждому читателю самостоятельно и без посторонней помощи изучить и запомнить все разделы и темы. Многочисленные задачи дадут понять каждому, какой материал нужно перечитать, а какой уже можно использовать в создании своего приложения. Автор самоучителя — Николай Секунов — мастерски выкладывает всю полученную информацию за период своей работы с языком С# и старается простыми методами пояснить все способы работы с новейшими приложениями.",
                LanguageId = LanguageService.RUSSIAN,
                Authors = new List<Author>()
                {
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Секунов" && author.FirstName == "Николай")
                },
                Publishers = new List<Publisher>() { bhvPeterburg },
                BookTags = new List<BookTag>() { cDiesTag }
            });
            defaultBooks.Add(new Book()
            {
                Name = "Язык программирования C# 2010 и платформа .NET 4, 5-е издание",
                PageCount = 1392,
                Year = 2011,
                ImageName = "troelsen-yazyk-programmirovaniya-c-2010-i-platforma-net-4.jpg",
                Description = @"Этот учебник будет просто незаменим для тех, кто хочет в совершенстве овладеть новым выпуском языка программирования C#. Ведь данная книга дает полную, нужную информацию, которая каждому специалисту пригодится для работы. В данном источнике вы найдете важнейшие инструкции по работе с переменными данными и научитесь их использовать на практике. А вот благодаря множеству примеров и полезным описаниям, вы с легкостью поймете суть работы с отладкой, выражениями и различными подобными функциями. Инструкции, которые будут приведены в данном пособии, помогут вам в совершенстве освоить работу с переменными, и дадут нужную базу, для создания новых приложений и программ. Это пособие даст каждому читателю опыт по написанию новых кодов, для использования их в полезных и нужных задачах.
Язык программирования C#, которому посвящена эта книга, позволит каждому создавать новые Windows-приложения и различные программы для работы. Вы сможете найти в этом пособии все интересующие темы для будущей работы в сфере программирования. Тут будет большой раздел, посвященный изучению языковых улучшений, а также всевозможных методов расширения. Каждый новичок подробно разберется в этом разделе, благодаря пошаговым инструкциям и наглядным примерам.
Эта книга позволит каждому человеку узнать полезную информацию про базовый синтаксис языка программирования C# 2010, а также про все переменные и важные выражения. Например, вы сможете узнать про известные лямбда-выражения и сможете научиться применять их на практике. Этот учебник также поможет каждому с легкостью понять язык ХМL со всеми его дополнениями. Не стоит забывать, что это пособие поможет каждому освоить приемы работы с WPF и WCF. Теперь все эти темы, которые раньше казались трудными, будут доступны в понимании любому новичку программирования. Более того, быстрое прочтение книги поможет даже специалисту этого дела освежить все знания и найти ответы на все затруднительные вопросы.
Книга «Visual C# 2010. Полный курс» является очень удобной, потому что будет начинаться с простых тем и терминов и постепенно переходить к более трудным. Так что тут можно даже без базы или с маленькой основой разобраться в трудных вещах и повысить свой уровень в сфере программирования. Авторы этого пособия — Карли Уотсон, Кристиан Нейгел, Якоб Хаммер Педерсен, Джон Д. Рид, Морган Скиннер — являются огромными профессионалами этого языка программирования и очень хорошими специалистами в этой сфере, так что они благодаря всему своему опыту и знаниям сложили сюда самую важную и полезную информацию. Так как каждый из них сталкивался с ошибками вначале, они сразу решили предупредить новичков, как нужно поступать, а как нет. Это позволит на первых этапах действовать правильно и не допускать просчетов в создании приложений и программ. Стоит отметить, что авторы сопроводили книгу максимально понятными инструкциями и примерами, которые помогут с легкостью понять каждую тему и попрактиковаться в различных задачах с помощью языка программирования Visual C# 2010.",
                LanguageId = LanguageService.RUSSIAN,
                Authors = new List<Author>()
                {
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Троелсен" && author.FirstName == "Эндрю")
                },
                Publishers = new List<Publisher>() { williams },
                BookTags = new List<BookTag>() { cDiesTag }
            });
            defaultBooks.Add(new Book()
            {
                Name = "Visual C# 2010. Полный курс",
                PageCount = 960,
                Year = 2010,
                ImageName = "uotson-neygel-hammer-visual-c-2010-polnyy-kurs.jpg",
                Description = @"Данный учебник будет полностью раскрывать все достоинства и всевозможные функции языка программирования С#, а также платформы .NET. Эта информация будет очень важна каждому специалисту в программировании и любому студенту, изучающему этот предмет. Любому читателю этого шедевра потом будет легко применять выученное на практике, и легко будет изучать платформу .NET.
В данном пособии вы найдете все интересующие темы, которые и появились в новой версии этой платформы. Каждый читатель найдет в этой книге все про среду Dynamic Language Runtime, которую сокращенно будут называть DLR. Каждый научиться работать в этой среде и узнает все ее полезные функции. Также это издание познакомит нас с расширенным описанием API-интерфейса Windows Presentation Foundation, который также будет иметь название WPF. Это будет одна из важных и интересных тем, которая, несомненно, привлечет внимание любого специалиста и начинающего студента.
Это пособие даст все полезные знания о библиотеке Task Parallel Library и раскроет все ее важнейшие функции. Также здесь мы сможем все узнать про технологию ADO.NET Entity Framework и попрактикуемся в работе с ней. Эти знания будут просто бесценны для каждого читателя. Более того, они будут изложены в простой, доступной форме и их будет легко запомнить и использовать на практике.
Книга «Язык программирования C# 2010 и платформа .NET 4» поможет каждому человеку увеличить свой уровень в сфере программирования и получить новые, полезные знания. Данное издание поможет использовать всю изученную информацию в будущей работе каждому специалисту. Автором этого произведения является Эндрю Троелсен и его можно легко назвать большим специалистом в этой сфере. Он долго изучал этот язык программирования и данную платформу, так что все его знания будут просто бесценны для каждого читателя. Он в легкой форме делиться с каждым своим опытом и рекомендует полезные советы, которые пригодятся каждому для работы с этими приложениями.
Рекомендуется прочитать эту книгу каждому студенту, который обучается вычислительной технике и хочет работать по специальности. Ведь это пособие выведет каждого на новый уровень и поможет в решении многих задач. Также этот учебник будет очень полезен для каждого специалиста в программном обеспечении для поднятия профессионального уровня и для получения новой информации.",
                LanguageId = LanguageService.RUSSIAN,
                Authors = new List<Author>()
                {
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Уотсон" && author.FirstName == "Карли"),
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Нейгел" && author.FirstName == "Кристиан"),
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Педерсен" && author.FirstName == "Якоб"),
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Рид" && author.FirstName == "Джон"),
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Скиннер" && author.FirstName == "Морган")
                },
                Publishers = new List<Publisher>() { williams },
                BookTags = new List<BookTag>() { cDiesTag }
            });
            defaultBooks.Add(new Book()
            {
                Name = "Visual C# 2010 на примерах",
                PageCount = 432,
                Year = 2011,
                ImageName = "ziborov-visual-c-2010-na-primerah.jpg",
                Description = @"Данная книга позволяет подробнейшим образом изучить принципы программирования на .NET Framework в среде известнейшего Microsoft Visual C# 2010. Этот справочник будет содержать в себе больше 120 примеров, которые у каждого человека вызывают явные вопросы. Теперь вы сможете получить все ответы на эти вопросы и самостоятельно разобраться в данной тематике.
Этот учебник покажет нам, как правильно обрабатывать все события мыши и клавиатуры, научит нас читать, или записывать нужные нам файлы, а также поможет в редактировании данных для будущей работы. Эта книга наглядно покажет, как нужно работать с технологиями LINQ и ADO.NET с использованием баз данных. Также из этого пособия каждый программист сможет узнать все про управление буфером обмена и про вывод и ввод нужных данных. Данный материал будет содержать всю информацию, которая поможет вам при работе с MS Word, AutoCAD, Excel, и MATLAB. После прочтения этой книги любой новичок сможет создавать собственные интерактивные приложения и разрабатывать WPF-приложения. Каждый сможет освоить работу Web-службы с помощью материала этого учебника.
Книга «Visual C# 2010 на примерах» будет настоящей находкой для любого программиста, а также для человека, которых хочет начать обучение в этой сфере. Специалист в Visual C# 2010 — Виктор Зиборов — на примерах своей работы обучает каждого читателя и показывает на практике, как использовать все эти знания. Материал этого пособия будет очень важен для любого профессионального педагога, которых хочет качественно объяснить эту тематику студентам. Даже для любого новичка этот учебник будет полезен, ведь тут вся информация будет идти от сложного к простому, что поможет постепенно получать нужные знания и разбираться в этой тематике. Стоит отметить, что эта книга будет содержать в комплекте компакт-диск, который будет неотъемлемой частью в подготовке к работе каждого человека. Ведь на нем будут содержаться важнейшие исходные коды, которые очень часто применяются для разработки новых приложений. Также этот диск будет включать в себя полезные примеры и задачи из этого учебника, которые помогут до конца разобраться в этой теме и закрепить полученные знания. Любой опытный программист может использовать эту книгу, как нужный справочник, для освежения своих знаний и для рассмотрения конкретных примеров для работы. А вот для новичка эта книга будет важнейшим пособием и помощником в освоении всего базового материала по теме Microsoft Visual C# 2010. Так что рекомендуется прочитать этот учебник каждому, кто собирается серьезно заниматься программированием.",
                LanguageId = LanguageService.RUSSIAN,
                Authors = new List<Author>()
                {
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Зиборов" && author.FirstName == "Виктор")
                },
                Publishers = new List<Publisher>() { bhvPeterburg },
                BookTags = new List<BookTag>() { cDiesTag }
            });
            defaultBooks.Add(new Book()
            {
                Name = "Программирование на Java и С# для студента",
                PageCount = 512,
                Year = 2005,
                ImageName = "german-programmirovanie-na-java-i-s-dlya-studenta.jpg",
                Description = @"Книга будет одним из важнейших инструментов в обучении основ программирования для каждого студента или просто для начинающего программиста. Здесь будет сделан акцент на двух важных языках программирования, с которыми должен ознакомиться каждый студент. Языки Java и С# будут подробно рассмотрены в этой книге, а также их будут сравнивать, выделяя плюсы и минусы обоих. Для создания сетевых приложений в наше время просто обязательно познать основы этих языков, поэтому авторы книги уделил им очень большое внимание. Также здесь каждый студент сможет узнать теорию и базу в сфере написании программ и этих языков. После этого вы здесь сможете найти массу примеров, задач, в которых наглядно показано, как использовать всю полученную информацию на практике.
Стоит отметить, что книга «Программирование на Java и С# для студента» будет содержать в себе много тестовых заданий и задач, которые будет предложено решить студенту. Это очень правильный подход, ведь после прочтения книги можно будет понять, что вы точно усвоили, а на что нужно обратить внимание в будущем. Также эти тесты помогут вам проверить себя, и в случае ошибок разобраться, какие разделы лучше перечитать повторно. Авторы книги О. В. Герман, Ю. О. Герман на основе своего опыта и знаний создали этот шедевр для начинающих и студентов, который поможет им в первых работах и научит самостоятельно писать программу на этих языках программирования. Эти авторы использовали максимально простой и понятных язык для изложения своих знаний, специально для того, чтобы человек мог сам, без помощи преподавателя разобраться в деталях этого материала. Масса примеров с подробным разбором, комментариями и определениями помогают человеку быстро войти в суть дела и начать самостоятельно писать программы и экспериментировать в этой сфере. А обучение основных языков Java и С# будет проходить ненавязчиво и эффективно, ведь все примеры будут показаны с использованием этих языков. Данная книга поможет каждому быстро и эффективно освоить данную тему и уже после первых глав начинать пробовать все знания на практике. После прочтения этой книги человек гарантированно будет разбираться в двух важных языках и в первые периоды уже сможет писать свои программы и пробовать создавать настоящие шедевры.",
                LanguageId = LanguageService.RUSSIAN,
                Authors = new List<Author>()
                {
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Герман" && author.FirstName == "О."),
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Герман" && author.FirstName == "Ю.")
                },
                Publishers = new List<Publisher>() { bhvPeterburg },
                BookTags = new List<BookTag>() { cDiesTag, javaTag }
            });
            defaultBooks.Add(new Book()
            {
                Name = "CLR via C#. Программирование на платформе Microsoft .NET Framework 2.0 на языке C#, 2-е издание",
                PageCount = 656,
                Year = 2008,
                ImageName = "rihter-clr-via-c-programmirovanie-na-platforme-microsoft-net-framework-2-0-na-yazyke-c.jpg",
                Description = @"В книге ""CLR via C#. Программирование на платформе Microsoft .NET Framework 2.0 на языке C#"" предлагается подробное описание принципов функционирования общеязыковой исполняющей среды CLR и ее внутреннего устройства. Полностью раскрывается система типов .NET Framework, а также разъясняются способы управления ими. К изучению предлагаются различные концепции программирования с непосредственным использованием библиотеки FCL. Концепции относятся ко всем языкам, которые ориентированы на работу с .NET Framework. Авторы книги значительное внимание уделяют обобщению, вопросам управления асинхронными операциями и синхронизации потоков. Книга будет интересна разработчикам практически любых видов приложений, созданных на платформе с .NET Framework: Web-сервисов, Windows Forms, Web Forms, консольных приложений и др.",
                LanguageId = LanguageService.RUSSIAN,
                Authors = new List<Author>()
                {
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Рихтер" && author.FirstName == "Джеффри")
                },
                Publishers = new List<Publisher>() { piter, russkayaRedakciya },
                BookTags = new List<BookTag>() { cDiesTag }
            });
            defaultBooks.Add(new Book()
            {
                Name = "C# 4.0 и платформа .NET 4 для профессионалов",
                PageCount = 1440,
                Year = 2011,
                ImageName = "neygel-c-4-0-i-platforma-net-4-dlya-professionalov.jpg",
                Description = @"Книга ""C# 4.0 и платформа .NET 4 для профессионалов"" раскрывает секреты в области разработки приложений с помощью NET Framework на языке C# 2010, которая осуществляется в среде .NET Framework 4 и более низких версиях. Книга отличается своей доступностью по изложению материала, содержит множество примеров и различных рекомендаций о том, как писать высококачественные программы. Первоначально дается общий анализ архитектуры .NET с целью получения базовых знаний и получения возможности начать писать управляемый код. Также рассказывается о самом языке программирования C# и различных сферах его применения.
Особенностью издания является наличие 10 дополнительных глав, которые размещены на компакт-диске. Здесь описываются технологии GDI+, предназначенной для построения приложения с улучшенной графикой; технологии .NET Remoting (используется для обеспечения связи между серверами и клиентами .NET); технологии Managed Add-In Framework, технологии Enterprise Services (применяется для создания служб, которые способны функционировать в фоновом режиме). Дополнительно можно получить сведения и о разработке VSTO, а также об использовании LINQ to SQL.
Данная книга позволит узнать:
- как писать приложения и различные службы Windows; 
- о применении ASP.NET 3.5 с целью создания веб-страниц; 
- способы создания веб-страниц; 
- как осуществлять манипулирование XML в коде C#; 
- методы использования ADO.NET для получения доступа к базам данных; 
- как осуществлять генерирование графических данных с помощью С#; 
- как наилучшим способом применять многочисленные дополнения C#; 
- как использовать язык LINQ для организации простой работы с базами данных XML и SQL Server.
Книга будет интересна для программистов различной квалификации, для студентов и преподавателей предметов, которые связаны с разработкой и программированием для .NET.",
                LanguageId = LanguageService.RUSSIAN,
                Authors = new List<Author>()
                {
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Нейгел" && author.FirstName == "Кристиан"),
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Ивьен" && author.FirstName == "Билл"),
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Глинн" && author.FirstName == "Джей"),
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Уотсон" && author.FirstName == "Карли"),
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Скиннер" && author.FirstName == "Морган")
                },
                Publishers = new List<Publisher>() { dialektika, williams },
                BookTags = new List<BookTag>() { cDiesTag }
            });
            defaultBooks.Add(new Book()
            {
                Name = "Создание служб Windows Communication Foundation",
                PageCount = 592,
                Year = 2008,
                ImageName = "leve-sozdanie-sluzhb-wcf.jpg",
                Description = @"Книга ""Создание служб Windows Communication Foundation"" посвящена объединенной платформе, предназначенной для разработки для Windows сервис-ориентированных приложений. Первая часть книги рассказывает о преимуществах применения сервис-ориентированной архитектуры, а далее уже на практических примерах показано, как используется Windows Communication Foundation. Значительное внимание уделяется всевозможным тонкостям и самым трудным моментам при создании СОА. Изучив предложенный материал, читатель сможет узнать, как осуществляется программирование при помощи WCF и на практике освоит все необходимые принципы проектирования. Ценность данной книги заключается в том, что она полностью основывается на опыте ее автора по разработке стратегии WCF, а также осуществлению взаимодействия с командной строкой.
 Издание ориентировано на архитекторов и разработчиков, которые стремятся освоить WCF или получить дополнительные сведения в данной области.",
                LanguageId = LanguageService.RUSSIAN,
                Authors = new List<Author>()
                {
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Леве" && author.FirstName == "Джувел")
                },
                Publishers = new List<Publisher>() { piter },
                BookTags = new List<BookTag>() { cDiesTag }
            });
            defaultBooks.Add(new Book()
            {
                Name = "Современная практика программирования на Microsoft Visual Basic и Visual C#",
                PageCount = 640,
                Year = 2006,
                ImageName = "balena-sovremennaya-praktika-programmirovaniya-na-microsoft-visual-basic-i-visual-c.jpg",
                Description = @" ""Современная практика программирования на Microsoft Visual Basic и Visual C#"" представляет собой профессиональное руководство, написанное известными программистами, и объединяет в себе богатый опыт разработчиков и консультантов по применению Visual Basic и Visual C#. Книга содержит практические рекомендации и эффективные методики программирования для существенного повышения уровня разработки программ. Детально описываются правила, их назначения, все преимущества и недостатки их применения, различные исключения из правил и существующие им альтернативы, а также практические примеры их применения. Благодаря передовым методикам, рассмотренным в книге, разработчики научатся писать безопасный, надежный и универсальный код, использовать все преимущества Microsoft .NET Framework, создавать эффективные программные решения, повышать продуктивность командной разработки путем согласования стилей и методов кодирования, создавать рациональные библиотеки классов и практичные иерархии объектов и т.д. Руководство предоставляет передовые методики работы с ресурсами, типами и структурами, сборками, полями, методами, свойствами, событиями, конструкторами, интерфейсами, числами и датами, исключениями, пользовательскими атрибутами, строками, наборами и массивами, памятью; с приложениями Windows Forms , Microsoft ASP .NET Web Forms, различными веб-сервисами, Microsoft ADO .NET; потоками и синхронизацией; компонентами, обеспечением безопасности, удаленным взаимодействием и др. Книга состоит из 33 глав и трех приложений и позволит специалисту значительно расширить свой программистский опыт и развить творческие способности в этой сфере.",
                LanguageId = LanguageService.RUSSIAN,
                Authors = new List<Author>()
                {
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Балена" && author.FirstName == "Франческо"),
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Димауро" && author.FirstName == "Джузеппе")
                },
                Publishers = new List<Publisher>() { russkayaRedakciya },
                BookTags = new List<BookTag>() { cDiesTag }
            });
            defaultBooks.Add(new Book()
            {
                Name = "Функциональное программирование на F#",
                PageCount = 192,
                Year = 2011,
                ImageName = "soshnikov-funkcionalnoe-programmirovanie-na-f.jpg",
                Description = @"Эта книга будет очень полезна для тех, кто в будущем хочет работать программистом и заниматься на протяжении жизни программированием. Ведь здесь описываются все основы функционального программирования, более того изучать эти основы придется на языке F#. Так как язык этот не старый, то им сразу заинтересовались начинающие программисты. Очень интересно одновременно изучать основы на этом языке и познавать его в деталях. Эта книга поможет каждому человеку за короткий период сделать язык F# своим инструментом в работе, что значительно упростит создание многих ваших проектов. Тем более если вы будете изучать нужную вам информацию на этом языке, то он очень быстро запомниться вместе с этой важной базой для программирования.
Теперь язык F# не является академическим языком, потому что его больше стали использовать на практике. В любой работе программиста этот язык будет неотъемлемым инструментом, так что эту книгу рекомендуется прочесть каждому, кто серьезно хочет работать в этой сфере. Автор этой книги — Дмитрий Сошников — является известным российским программистом. Его багаж знаний и опыта просто невозможно измерить. И все свои познания в сфере программирования и этого языка он выкладывает в книге «Функциональное программирование на F#». Автор этой книги пытается пробудить в читателе фантазию, чтобы обучение было интересным, и чтобы человек сам мог экспериментировать с языком F# и умел применять его на практике.
Огромное внимание стоит обратить на то, что автор не пытался делать книгу сильно научной и перегруженной сложными терминами. Наоборот, здесь очень много простых, базовых тем, которые будет интересно изучить читателю на языке F#. Из-за простоты этой книги, ее может понять абсолютно любой человек и без проблем освоить главный язык программирования. Важно отметить, что в книге есть много практических задач с объяснениями их решения. Все вопросы, на которые вы, возможно, не могли найти ответы, сразу станут доступными и понятными благодаря этой книге. Именно здесь каждый сможет научиться использовать все знания на практике, а также применять в своей работе. Все коды, которые будут в примерах, можно легко использовать и для создания собственного проекта, вместе с языком программирования F#.",
                LanguageId = LanguageService.RUSSIAN,
                Authors = new List<Author>()
                {
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Сошников" && author.FirstName == "Дмитрий")
                },
                Publishers = new List<Publisher>() { dmkPress },
                BookTags = new List<BookTag>() { fDiesTag }
            });
            defaultBooks.Add(new Book()
            {
                Name = "Справочник по языку Haskell",
                PageCount = 544,
                Year = 2008,
                ImageName = "dushkin-spravochnik-po-yazyku-haskell.jpg",
                Description = @"Что входит. В первой части описываются стандартные библиотеки, даются краткие описания синтаксиса, описываются способы применения языка для решения конкретных задач. Вторая часть содержит информацию о библиотеках, которые включаются в наиболее известные трансляторы GHC и HUGS 98.
""Справочник по языку Haskell"" Р. В. Душкина краток, лаконичен и довольно удобен, им без труда могут пользоваться и те, кто только начинает изучать функциональное программирование.",
                LanguageId = LanguageService.RUSSIAN,
                Authors = new List<Author>()
                {
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Душкин" && author.FirstName == "Р.")
                },
                Publishers = new List<Publisher>() { dmkPress },
                BookTags = new List<BookTag>() { haskellTag }
            });
            defaultBooks.Add(new Book()
            {
                Name = "14 занимательных эссе о языке Haskell и функциональном программировании",
                PageCount = 142,
                Year = 2011,
                ImageName = "dushkin-14-zanimatelnyh-esse-o-yazyke-haskell-i-funkcionalnom-programmirovanii.jpg",
                Description = @"Книга ""14 занимательных эссе о языке Haskell и функциональном программировании"" представляет собой сборник статей как увидевших свет в журнале ""Потенциал"" - научно-популярном журнале для общеобразовательных школ, так и неопубликованных.
Они расположены в порядке ""от простого – к сложному"" В первых статьях даются основы функционального программирования и базовые понятия. Далее логически последовательно излагаются функции и процедуры языка Haskell. Основной акцент сделан на практическое применение знаний - приемы алгоритмизации и программирования иллюстрируются конкретными примерами.
Написанная живым и доступным языком книга привлечет внимание тех. кто намерен заняться функциональным программированием: студентов, преподавателей, учащихся школ.",
                LanguageId = LanguageService.RUSSIAN,
                Authors = new List<Author>()
                {
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Душкин" && author.FirstName == "Р.")
                },
                Publishers = new List<Publisher>() { dmkPress },
                BookTags = new List<BookTag>() { haskellTag }
            });
            defaultBooks.Add(new Book()
            {
                Name = "Функциональное программирование",
                PageCount = 260,
                Year = 2002,
                ImageName = "roganova-funkcionalnoe-programmirovanie.jpg",
                Description = @"Учебное пособие ""Функциональное программирование"" предназначено для студентов ВУЗов. Оно может быть полезно всем тем, кто хочет углубить собственное представление о функциональных возможностях современных языков программирования. Данное издание знакомит читателя с директивным стилем программирования, при этом используя в виде языка программирования Haskell, сочетающий характерные черты чисто функционального языка с функциями объектно-ориентированного стиля программирования. Отметим, что изложение материала начинается с изложения азов функционального программирования, продолжается рассмотрением методов написания самых простых программ на языке Haskell, и заканчивается знакомством со средствами ввода, а также вывода информации. Особенностью этого пособия является тот факт, что рассматриваемый материал жестко не привязывается к определенной ОС. Приведенные в пособии программы работоспособны в двух самых популярных операционных системах: Windows и Linux.",
                LanguageId = LanguageService.RUSSIAN,
                Authors = new List<Author>()
                {
                    dbContext.Authors.ToList().Find(
                        author => author.LastName == "Роганова" && author.FirstName == "Н.")
                },
                Publishers = new List<Publisher>() { gINFO },
                BookTags = new List<BookTag>() { haskellTag }
            });
        }
    }
}