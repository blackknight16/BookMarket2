//-----------------------------------------------------------------------
// Модель представления. Отображает данные платежа в WalletOne.
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BookMarket.RouteInfrastructure;
using BookMarket.Services;
using System.Text;

namespace BookMarket.Models.ViewModels
{
    public class W1PaymentView
    {
        [Display(Name = "Номер платежа")]
        public Int32 WMI_PAYMENT_NO { get; set; }
        //не const, так как нужна ссылка
        [Display(Name = "Id продавца")]
        public string WMI_MERCHANT_ID { get; set; }
        //не const, так как нужна ссылка
        [Display(Name = "Id валюты")]
        public string WMI_CURRENCY_ID { get; set; }
        [Display(Name = "Описание платежа (не более 255 символов)")]
        [StringLength(maximumLength: 255)]
        public string WMI_DESCRIPTION { get; set; }
        [Display(Name = "Дата истечения платежа")]
        public string WMI_EXPIRED_DATE { get; set; }
        [Display(Name = "Ссылка неудавшегося платежа")]
        public string WMI_FAIL_URL { get; set; } 
        [Display(Name = "Сумма платежа")]
        public string WMI_PAYMENT_AMOUNT { get; set; } //заполнить в контроллере
        [Display(Name = "MD5-подпись")]
        public string WMI_SIGNATURE { get; set; }
        [Display(Name = "Ссылка успешного платежа")]
        public string WMI_SUCCESS_URL { get; set; }
        
        public Dictionary<string, string> dictionary
        {
            get
            {
                Dictionary<string, string> dictionary;

                dictionary = new Dictionary<string, string>();
                dictionary.Add("WMI_CURRENCY_ID", this.WMI_CURRENCY_ID);
                dictionary.Add("WMI_DESCRIPTION", this.WMI_DESCRIPTION);
                dictionary.Add("WMI_EXPIRED_DATE", this.WMI_EXPIRED_DATE);
                dictionary.Add("WMI_FAIL_URL", this.WMI_FAIL_URL);
                dictionary.Add("WMI_MERCHANT_ID", this.WMI_MERCHANT_ID);
                dictionary.Add("WMI_PAYMENT_AMOUNT", this.WMI_PAYMENT_AMOUNT);
                dictionary.Add("WMI_PAYMENT_NO", Convert.ToString(this.WMI_PAYMENT_NO) );
                dictionary.Add("WMI_SUCCESS_URL", this.WMI_SUCCESS_URL);
                //dictionary.Add("submit", SpecialConstants.BASKET_PAY_SUBMIT_TEXT);
                    //специально не добавляю!
                    //dictionary.Add("WMI_SIGNATURE", this.WMI_SIGNATURE);
                return dictionary;
            }
        }

        public W1PaymentView()
        {
            PaymentService paymentService = new PaymentService();
            UrlGenerator urlGenerator;

            urlGenerator = new UrlGenerator();
            this.WMI_SUCCESS_URL = urlGenerator.GetSuccessPaymentUrl();
            this.WMI_FAIL_URL = urlGenerator.GetFailPaymentUrl();
        }
        
        public W1PaymentView(W1Payment w1Payment)
            : this()
        {
            PaymentService paymentService = new PaymentService();

            this.WMI_PAYMENT_NO = w1Payment.WMI_PAYMENT_NO;
            this.WMI_MERCHANT_ID = w1Payment.WMI_MERCHANT_ID;
            this.WMI_CURRENCY_ID = Convert.ToString(w1Payment.WMI_CURRENCY_ID);
            this.WMI_DESCRIPTION = w1Payment.WMI_DESCRIPTION;
            //Сейчас время в UTC+0, его не меняем
            this.WMI_EXPIRED_DATE = w1Payment.WMI_EXPIRED_DATE.ToString("s");
            this.WMI_PAYMENT_AMOUNT = string.Format(
                CultureInfo.InvariantCulture, "{0,2}", 
                w1Payment.WMI_PAYMENT_AMOUNT);
            this.WMI_SIGNATURE = 
                paymentService.GetSignatureAsString(this.dictionary);
        }
    }
}