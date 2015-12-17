//-----------------------------------------------------------------------
// Предполагалось использовать эту форму, но не нашел ее применение.
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using BookMarket.Models;
using BookMarket.Models.ViewModels;
using BookMarket.Services;
using BookMarket.RouteInfrastructure;
using System.Text;

namespace BookMarket.PaymentInfrastructure
{
    //Класс не используется
    public class W1PaymentForm : IHttpHandler
    {
        private static SortedDictionary<string, string> _formField;

        public bool IsReusable
        {
            get
            {
                return true;
            }
        }

        public void SetFormFields(Dictionary<string, string> dictionary){
            W1PaymentForm._formField = 
                new SortedDictionary<string,string>(dictionary);
        }

        public void ProcessRequest(HttpContext context)
        {
            DateTime expiredDate;
            UrlGenerator urlGenerator;
            StringBuilder signatureData, output;
            string message, signature;
            byte[] bytes, hash;

            // Формирование сообщения, путем объединения значений формы, 
            // отсортированных по именам ключей в порядке возрастания и
            // добавление к нему "секретного ключа" интернет-магазина

            signatureData = new StringBuilder();
            foreach (string key in W1PaymentForm._formField.Keys)
            {
                signatureData.Append(W1PaymentForm._formField[key]);
            }

            // Формирование значения параметра WMI_SIGNATURE, путем 
            // вычисления отпечатка, сформированного выше сообщения, 
            // по алгоритму MD5 и представление его в Base64
            message = signatureData.ToString() + SpecialConstants.MERCHANT_KEY;
            bytes = Encoding.GetEncoding(1251).GetBytes(message);
            hash = new MD5CryptoServiceProvider().ComputeHash(bytes);
            signature = Convert.ToBase64String(hash);

            W1PaymentForm._formField.Add("WMI_SIGNATURE", signature);

            // Формирование платежной формы
            output = new StringBuilder();
            output.AppendLine("<form method=\"POST\" action=\"https://wl.walletone.com/checkout/checkout/Index\">");
            
            foreach (string key in W1PaymentForm._formField.Keys)
            {
                output.AppendLine(string.Format(
                    "{0}: <input name=\"{0} value=\"{1}\" />",
                    key, W1PaymentForm._formField[key]));
            }

            output.AppendLine("<input type=\"submit\" /></form>");

            context.Response.ContentType = "text/html; charset=UTF-8";
            context.Response.Write(output.ToString());
        }




    }
}