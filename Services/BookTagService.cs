//-----------------------------------------------------------------------
// Сервис тега книги.
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookMarket.Services
{
    // Содержит вспомогательные/манипулирующие_данными методы, а не только работу с собственными данными
    public class BookTagService
    {
        public static SimpleValue C_DIES = new SimpleValue(1, "C#", "C_Dies");
        public static SimpleValue F_DIES = new SimpleValue(2, "F#", "F_Dies");
        public static SimpleValue HASKELL = new SimpleValue(3, "Haskell", "Haskell");
        public static SimpleValue JAVA = new SimpleValue(4, "Java", "Java");
        public static SimpleValue PYTHON = new SimpleValue(5, "Python", "Python");
        public static SimpleValue AJAX = new SimpleValue(6, "AJAX", "Ajax");
        public static SimpleValue ASP_NET = new SimpleValue(7, "ASP(.NET)", "ASP_dot_Net");
        public static SimpleValue JAVASCRIPT = new SimpleValue(8, "Javascript", "Javascript");
        public static SimpleValue PHP = new SimpleValue(9, "PHP", "Php");
        public static SimpleValue SILVERLIGHT = new SimpleValue(10, "Silverlight", "Silverlight");
        public static SimpleValue ANDROID = new SimpleValue(11, "Android", "Android");
        public static SimpleValue IPHONE = new SimpleValue(12, "Iphone", "Iphone");
        public static SimpleValue WINDOWS_PHONE = new SimpleValue(13, "Windows Phone", "Windows_Phone");
        public static SimpleValue COMMON_DB = new SimpleValue(14, "БД.Общее", "CommonDb");
        public static SimpleValue MYSQL = new SimpleValue(15, "MySQL", "MySQL");
        public static SimpleValue MICROSOFT_SQL_SERVER = new SimpleValue(16, "Microsoft SQL Server", "Microsoft_SQL_Server");
        public static SimpleValue ORACLE_DB = new SimpleValue(17, "Oracle Database", "OracleDb");
        public static SimpleValue POSTGRE_SQL = new SimpleValue(18, "PostgreSQL", "PostgreSQL");
        /*public static SimpleValue ALGORITHMS = new SimpleValue(19, "Алгоритмы", "Algorithms");
        public static SimpleValue MATH = new SimpleValue(20, "Математика", "Math");
        public static SimpleValue CRYPTOGRAPHY = new SimpleValue(21, "Криптография", "Cryptography");
        public static SimpleValue TESTING = new SimpleValue(22, "Тестирование ПО", "Testing");
        public static SimpleValue PROJECT_MAKING_AND_DEVELOPMENT = new SimpleValue(23, "Проектирование и разработка ПО", "Project_Making_And_Development");*/

        //Коллекция всех возможных тегов книг
        private static List<SimpleValue> collection = new List<SimpleValue>()
            {
                C_DIES, F_DIES, HASKELL, JAVA, PYTHON, AJAX, ASP_NET,
                JAVASCRIPT, PHP, SILVERLIGHT, ANDROID, IPHONE,
                WINDOWS_PHONE, COMMON_DB, MYSQL, MICROSOFT_SQL_SERVER,
                ORACLE_DB, POSTGRE_SQL
            };

        BookTagService()
        {
        }

        public static SimpleValue FindById(Int32 id)
        {
            return collection.Find(tag => tag.Id == id);
        }
    }
}