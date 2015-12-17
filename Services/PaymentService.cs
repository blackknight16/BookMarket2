//-----------------------------------------------------------------------
// Сервис платежа магазина и Walletone.
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Web;
using System.Text;
using System.Security.Cryptography;
using BookMarket.Models;
using BookMarket.Models.ViewModels;
using BookMarket.RouteInfrastructure;
using BookMarket.PaymentInfrastructure;

namespace BookMarket.Services
{
    public class PaymentService : BaseService
    {
        //Добавление платежа магазина вместе с платежом WalletOne
        //Они добавляются вместе
        public Payment AddPayment(Payment payment, W1Payment w1Payment)
        {
            W1Payment dbW1Payment;
            Payment dbPayment;

            if (payment != null && w1Payment != null)
            {
                dbW1Payment = (W1Payment) this._w1PaymentRepository.Add(w1Payment);
                payment.Id = dbW1Payment.WMI_PAYMENT_NO;
                dbPayment = (Payment) this._paymentRepository.Add(payment);

                return dbPayment;
            }
            else throw new Exception("Payment не задан!");

            return null;
        }

        // Получает платеж по представлению
        public Payment GetPayment(PaymentView paymentView)
        {
            Payment payment;

            payment = new Payment()
            {
                Id = paymentView.Id,
                isPayed = paymentView.isPayed,
                ShopId = paymentView.ShopId
            };
            payment.Shop = (Shop)this._shopRepository.FindById(payment.ShopId);

            return payment;
        }

        // Создает платеж W1 по его представлению
        public W1Payment MakeW1Payment(W1PaymentView w1PaymentView)
        {
            W1Payment w1Payment;
            DateTime expiredDate;

            w1Payment = new W1Payment()
            {
                WMI_PAYMENT_NO = w1PaymentView.WMI_PAYMENT_NO,
                WMI_MERCHANT_ID = w1PaymentView.WMI_MERCHANT_ID,
                WMI_CURRENCY_ID = Convert.ToInt32(w1PaymentView.WMI_CURRENCY_ID),
                //Переводить ToBase64 не нужно, это делается в методе MakeDescription
                WMI_DESCRIPTION = w1PaymentView.WMI_DESCRIPTION,
                WMI_PAYMENT_AMOUNT = Convert.ToDecimal(
                    w1PaymentView.WMI_PAYMENT_AMOUNT, CultureInfo.InvariantCulture),
                WMI_FAIL_URL = w1PaymentView.WMI_FAIL_URL,
                WMI_SUCCESS_URL = w1PaymentView.WMI_SUCCESS_URL
            };
            //после дебага расскоментировать!
            if (w1PaymentView.WMI_EXPIRED_DATE == null ||
                w1Payment.WMI_EXPIRED_DATE == DateTime.MinValue)
            {
                //Срок истечения - 30 дней. Формат UTC(+0)
                expiredDate = DateTime.UtcNow;
                expiredDate = expiredDate.AddDays(SpecialConstants.EXPIRED_DAYS_COUNT);
                w1Payment.WMI_EXPIRED_DATE = expiredDate;
            }
            else w1Payment.WMI_EXPIRED_DATE = w1Payment.WMI_EXPIRED_DATE;
            //w1Payment.WMI_EXPIRED_DATE = new DateTime(2015, 11, 07, 12, 04, 38);

            //везде сигнутура вычисляется заново. Правильно ли?
            w1Payment.WMI_SIGNATURE = GetSignature(w1PaymentView.dictionary);

            return w1Payment;
        }

        //Из-за Convert.ToBase64String тяжело контролировать лимит символов 
        //в 255, поэтому убрал.
        /*public string MakeDescription(Int32 basketId)
        {
            StringBuilder description;
            string result;
            Book book;
            BasketItem basketItem;
            IList<BasketItem> basketItems;
            BasketItemRepository basketItemRepository;
            Int32 stringLength;

            basketItemRepository = (BasketItemRepository)this._basketItemRepository;
            basketItems = basketItemRepository.FindAllByBasket(basketId);

            description = new StringBuilder();
            if (basketItems.Count > 0)
            {
                basketItem = basketItems.First();
                book = (Book)this._bookRepository.FindById(
                    basketItem.BookVariableInfoId);
                description.Append("Заказ: " + book.Name);
                for (Int32 i = 1; i < basketItems.Count; i++)
                {
                    description.Append("; ");
                    book = (Book)this._bookRepository.FindById(
                        basketItems[i].BookVariableInfoId);
                    description.Append(book.Name);
                }
            }

            result = Convert.ToBase64String(Encoding.UTF8.GetBytes(
               description.ToString() ) );
            //максимальная длина Description
            if (result.Length > 255)
            {
                stringLength = result.Length;
                result.Remove(255, stringLength - 255);
            }

            return result;
        }*/

        // Создает описание платежа W1
        //После результата строку можно извлечь через метод
        //Convert.FromBase64String. Наверное, в БД нужно было
        //хранить оригинальную строку?
        public string MakeDescription(Int32 basketId)
        {
            string description = "", result;
            IList<BasketItem> basketItems;
            BasketItemRepository basketItemRepository;

            basketItemRepository = (BasketItemRepository)this._basketItemRepository;
            basketItems = basketItemRepository.FindAllByBasket(basketId);

            if (basketItems.Count > 0)
            {
                description = basketItems.Count + " наименований.";
            }

            //максимальная длина Description не обрабатывается, 
            //но она не превысит 255 символов
            result = Convert.ToBase64String(Encoding.UTF8.GetBytes(
                "BASE64: " + description));

            return result;
        }

        //Вычисление двоичного представления MD5 хеш-суммы
        public byte[] GetSignature(Dictionary<string, string> dictionary)
        {
            StringBuilder signatureData;
            string message, signature;
            byte[] bytes, hash;
            SortedDictionary<string, string> sortedDictionary;

            sortedDictionary = new SortedDictionary<string, string>(dictionary);
            signatureData = new StringBuilder();
            foreach (string key in sortedDictionary.Keys)
            {
                signatureData.Append(sortedDictionary[key]);
            }
            // Формирование значения параметра WMI_SIGNATURE, путем 
            // вычисления отпечатка, сформированного выше сообщения, 
            // по алгоритму MD5 и представление его в Base64
            message = signatureData.ToString() + SpecialConstants.MERCHANT_KEY;
            bytes = Encoding.GetEncoding(1251).GetBytes(message);
            hash = new MD5CryptoServiceProvider().ComputeHash(bytes);

            return hash;
        }

        //Вычисление строкового представления MD5 хеш-суммы
        public string GetSignatureAsString(Dictionary<string, string> dictionary)
        {
            byte[] hash;
            string signature;

            hash = GetSignature(dictionary);
            signature = Convert.ToBase64String(hash);
            return signature;
        }

        // Создание ответа W1 о результе принятия сайтом данных покупки.
        public string MakeResponseToW1(string result, string description = "")
        {
            StringBuilder response;
            Encoding encoder;
            byte[] codeBytes;
            char[] chars;

            encoder = Encoding.GetEncoding(1251); //Нужна другая кодировка?
            response = new StringBuilder();
            response.Append("WMI RESULT=" + result.ToUpper());
            if (description != "")
            {
                codeBytes = new byte[encoder.GetByteCount(description)];
                encoder.GetBytes(description, 0, description.Length, codeBytes, 0);
                chars = encoder.GetChars(codeBytes);

                response.Append("&WMI_DESCRIPTION=" +
                    HttpUtility.UrlEncode(new string(chars)));
            }

            return response.ToString();
        }

        //Заполнение но не добавление W1PaymentView в БД
        //W1Payment добавлять только через PaymentService!
        public W1Payment MakeW1Payment(W1Payment w1Payment)
        {
            IList<W1Payment> w1Payments;
            W1PaymentRepository w1PaymentRepository;
            DateTime expiredDate;
            W1PaymentView w1PaymentView;
            UrlGenerator urlGenerator;

            w1PaymentRepository = new W1PaymentRepository();
            urlGenerator = new UrlGenerator();

            //после дебага расскоментировать!
            //Срок истечения - 30 дней. Формат UTC(+0)
            if (w1Payment.WMI_EXPIRED_DATE == null || 
                w1Payment.WMI_EXPIRED_DATE == DateTime.MinValue)
            {
                expiredDate = DateTime.UtcNow;
                expiredDate = expiredDate.AddDays(SpecialConstants.EXPIRED_DAYS_COUNT);
                w1Payment.WMI_EXPIRED_DATE = expiredDate;
            }
            else w1Payment.WMI_EXPIRED_DATE = w1Payment.WMI_EXPIRED_DATE;
            //w1Payment.WMI_EXPIRED_DATE = new DateTime(2015, 11, 07, 12, 04, 38);

            w1Payment.WMI_SUCCESS_URL = urlGenerator.GetSuccessPaymentUrl();
            w1Payment.WMI_FAIL_URL = urlGenerator.GetFailPaymentUrl();

            w1Payment.WMI_MERCHANT_ID = SpecialConstants.WMI_MERCHANT_ID; //Id W1-кошелька
            w1Payment.WMI_CURRENCY_ID = SpecialConstants.WMI_CURRENCY_ID; //валюта - рубли

            w1Payments = w1PaymentRepository.GetAll().w1Payments;
            //Ключ. Начало отсчета нужно также синхронизировать с
            //MarketDbInitializer10.cs
            w1Payment.WMI_PAYMENT_NO = 
                (w1Payments.Count > 0 ? w1Payments.Last().WMI_PAYMENT_NO + 1
                : 122); //в publish установить 1

            w1PaymentView = new W1PaymentView(w1Payment);
            w1Payment.WMI_SIGNATURE = GetSignature(w1PaymentView.dictionary);

            return w1Payment;
        }

        //Check hash-sum
        public bool CheckSignature(Dictionary<string, string> formDictionary)
        {
            Int32 w1PaymentNo;
            SortedDictionary<string, string> sortedFormMd5Dictionary;
            StringBuilder strValues;
            string signature, message, tmpStr, decodedUrl;
            CodeUtils codeUtils;            
            byte[] bytes, hash;

            sortedFormMd5Dictionary = new SortedDictionary<string, string>(
                formDictionary);
            w1PaymentNo = Convert.ToInt32(sortedFormMd5Dictionary["WMI_PAYMENT_NO"]);

            //сигнатура не нужна в вычислении
            sortedFormMd5Dictionary.Remove("WMI_SIGNATURE");
            codeUtils = new CodeUtils();

            strValues = new StringBuilder();
            foreach (var key in sortedFormMd5Dictionary.Keys)
            {
                //Очень, очень важно расшифровать строку (UrlDecode). Так как входные
                //данные пришли из формы с атрибутом
                //this.Request.ContentType = "application/x-www-form-urlencoded"
                //Даже несмотря на то, что входные данные в charset = UTF-8
                decodedUrl = HttpUtility.UrlDecode(sortedFormMd5Dictionary[key]);
                strValues.Append(decodedUrl); 
            }
            //не забыли сделать конкатенацию секретного ключа
            message = strValues.ToString() + SpecialConstants.MERCHANT_KEY;
            //получили MD5-подпись всех(кроме signature) полей post-формы
            bytes = Encoding.GetEncoding(1251).GetBytes(message);
            hash = new MD5CryptoServiceProvider().ComputeHash(bytes);
            signature = Convert.ToBase64String(hash);

            if (signature == HttpUtility.UrlDecode(formDictionary["WMI_SIGNATURE"]))
                return true; //подписи совпали
            //либо отправитель злоумышленник, либо ошибка программиста
            else return false; 
        }

        public decimal DecimalCounting(params decimal[] values)
        {
            decimal result = values.Sum();

            return result;
        }
    }
}