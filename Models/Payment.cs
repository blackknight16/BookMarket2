//-----------------------------------------------------------------------
// Модель БД. Представляет данные оплаты товара. Отличается от W1Payment
// тем, что эти данные не передаются сайту WalletOne. Данные Payment
// необходимы для мониторинга оплаты заказов покупателями. Подразумевается,
// что администратор будет просматривать эту таблицу и проверять, какие
// заказы были оплачены. Если заказ оплачен, то он доставляется в 
// указанный магазин. Если заказ просрочен (W1Payment), то заказанные
// экземпляры книг пополняют каталог и пользователю не доставляются.
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BookMarket.Models
{
    public class Payment
    {
        [Key, ForeignKey("W1Payment")]
        public Int32 Id { get; set; }
        public bool isPayed { get; set; }

        public Int32 ShopId { get; set; }
        public Int32 IndividualId { get; set; }

        public virtual Shop Shop { get; set; }
        public virtual ICollection<BasketItem> BasketItems { get; set; }
        public virtual Individual Individual {get; set;}
        public virtual W1Payment W1Payment{get; set;}
    }
}