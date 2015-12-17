//-----------------------------------------------------------------------
// Модель БД. Предназначена для хранения информации, которой обменивается
// сайт с WalletOne. Необходим непосредственно при оплате товаров.
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using BookMarket.RouteInfrastructure;

namespace BookMarket.Models
{
    [Table("W1Payments")]
    public class W1Payment
    {
        [Key]
        [Display(Name = "Номер платежа")]
        public Int32 WMI_PAYMENT_NO { get; set; }
        [Display(Name = "Id продавца")]
        public string WMI_MERCHANT_ID { get; set; }
        //не const, так как нужна ссылка
        [Display(Name = "Id валюты")]
        public Int32 WMI_CURRENCY_ID { get; set; }
        [Display(Name = "Описание платежа (не более 255 символов)")]
        [StringLength(maximumLength: 255)]
        public string WMI_DESCRIPTION { get; set; }
        [Display(Name = "Дата истечения платежа")]
        public DateTime WMI_EXPIRED_DATE { get; set; }
        [Display(Name = "Сумма платежа")]
        public decimal WMI_PAYMENT_AMOUNT { get; set; }
        [Display(Name = "MD5-подпись")]
        public byte[] WMI_SIGNATURE { get; set; }
        
        public virtual Payment Payment { get; set; }

        [NotMapped]
        public string WMI_FAIL_URL { get; set; }
        [NotMapped]
        public string WMI_SUCCESS_URL { get; set; }
        //POST данные //убрал

        public W1Payment()
        {
        }
    }
}