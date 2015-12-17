//-----------------------------------------------------------------------
// Специальные константы, так или иначе используемые при работе с сайтом.
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookMarket.Services
{
    public class SpecialConstants
    {
        //Ключи магазина
        public const string WMI_MERCHANT_ID = "135359380957"; //ид кошелька продавца
        //секретный ключ интернет-магазина
        public const string MERCHANT_KEY = "494a6876345c6f456c685f484d567a5455484772414d7456517b4e"; //секретный ключ сигнатуры
        public const string BASKET_PAY_SUBMIT_TEXT = "Перейти к оплате";
        public const Int32 WMI_CURRENCY_ID = 643; //рубли
        public const Int32 EXPIRED_DAYS_COUNT = 30; //число дней для истечения платежа
        public const string CONNECTION_STRING = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=BookMarketDb;Integrated Security=True;MultipleActiveResultSets=true";
    }
}