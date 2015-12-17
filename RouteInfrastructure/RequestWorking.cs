//-----------------------------------------------------------------------
// Выполняет работу с запросом Request.
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace BookMarket.RouteInfrastructure
{
    //Класс работы с POST данными
    public class RequestWorking
    {
        public RequestWorking() { }
        
        //Получение обычного словаря для удобства работы
        public Dictionary<string, string> GetFormDictionary(
            System.Collections.Specialized.NameValueCollection nameValueCollection)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            string value;

            foreach(var key in nameValueCollection.Keys){
                value = nameValueCollection[key.ToString()];
                dictionary.Add(key.ToString(), value);
            }

            return dictionary;
        }

        //Из Request.Cookies
        public Dictionary<string, string> GetFormDictionary(
            HttpCookieCollection nameValueCollection)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            string value;

            foreach (var key in nameValueCollection.AllKeys)
            {
                value = nameValueCollection[key].Value;
                dictionary.Add(key, value);
            }

            return dictionary;
        }
    }
}