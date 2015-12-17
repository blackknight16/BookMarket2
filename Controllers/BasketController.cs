//-----------------------------------------------------------------------
// Контроллер, связанный с редактированием корзини и оплатой заказанных
// товаров покупателем. 
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Text;
using System.Net;
using BookMarket.Models;
using BookMarket.Models.ViewModels;
using BookMarket.Services;
using BookMarket.RouteInfrastructure;

namespace BookMarket.Controllers
{
    public class BasketController : Controller
    {
        private IDbModelRepository _addressRepository = new AddressRepository();
        private IDbModelRepository _bookRepository = new BookRepository();
        private IDbModelRepository _bookVariableInfoRepository =
            new BookVariableInfoRepository();
        private IDbModelRepository _cityRepository = new CityRepository();
        private IDbModelRepository _userProfileRepository =
            new UserProfileRepository();
        private IDbModelRepository _basketRepository = new BasketRepository();
        private IDbModelRepository _basketItemRepository =
            new BasketItemRepository();
        private IDbModelRepository _individualRepository =
            new IndividualRepository();
        private IDbModelRepository _paymentRepository = new PaymentRepository();
        private IDbModelRepository _shopRepository = new ShopRepository();
        private IDbModelRepository _w1PaymentRepository =
            new W1PaymentRepository();

        public BasketController()
        {
        }

        public ActionResult Index()
        {
            BasketView basketView;
            BasketService basketService;

            if (User.Identity.IsAuthenticated)
            {
                basketService = new BasketService();
                basketView = new BasketView(
                    basketService.GetBasket(User.Identity.Name));
            }
            else return Content("Сначала авторизуйтейсь.");

            return View(basketView);
        }

        public ActionResult BuyBook(Int32 bookId)
        {
            BookVariableInfo bookVariableInfo;
            BookVariableInfoRepository bookVariableInfoRepository;
            BasketItemView basketItemView;
            BasketService basketService;
            Basket basket;

            if (User.Identity.IsAuthenticated)
            {
                bookVariableInfoRepository = (BookVariableInfoRepository)
                    this._bookVariableInfoRepository;
                basketService = new BasketService();

                bookVariableInfo = bookVariableInfoRepository.FindByBookId(bookId);
                basket = basketService.GetBasket(User.Identity.Name);
                basketItemView = new BasketItemView(
                    new BasketItem()
                {
                    BookVariableInfo = bookVariableInfo,
                    BookVariableInfoId = bookVariableInfo.Id,
                    Basket = basket,
                    BasketId = basket.Id
                });
            }
            else return Content("Сначала авторизуйтейсь.");

            return View(basketItemView);
        }

        [HttpPost]
        public ActionResult BuyBook(BasketItemView basketItemView)
        {
            bool isOk = true;
            BasketService basketService;
            Basket basket;
            BasketItem basketItem;
            UserProfile userProfile;
            Individual individual;

            if (basketItemView.BookVariableInfo == null)
                basketItemView.BookVariableInfo = (BookVariableInfo)
                    this._bookVariableInfoRepository
                    .FindById(basketItemView.BookVariableInfoId);
            if (ModelState.IsValid)
            {
                basketService = new BasketService();
                if (basketService.BasketItemIsValid(basketItemView))
                {
                    basketService = new BasketService();
                    //Извлечение BasketItem из BasketItemView
                    basketItem = basketService.GetBasketItem(
                        basketItemView);

                    basket = basketService.GetBasket(User.Identity.Name);
                    if (basketService.AddBookItem(basket, basketItem))
                        return RedirectToAction("Index");
                    else isOk = false;
                }
                else isOk = false;

                if (!isOk)
                    return Content(
                    "Укажите суммарное число экземпляров > 0 и <= общего числа.");
            }

            return View(basketItemView);
        }

        public ActionResult UpdateBasketItem(Int32 basketItemId)
        {
            BasketItem basketItem;
            BasketItemView basketItemView;

            basketItem = (BasketItem)this._basketItemRepository
                .FindById(basketItemId);
            basketItemView = new BasketItemView(basketItem);

            return View(basketItemView);
        }

        [HttpPost]
        public ActionResult UpdateBasketItem(BasketItemView basketItemView)
        {
            bool isOk = true;
            BasketService basketService;
            Basket basket;
            BasketItem basketItem;
            UserProfile userProfile;
            Individual individual;

            if (basketItemView.BookVariableInfo == null)
                basketItemView.BookVariableInfo = (BookVariableInfo)
                    this._bookVariableInfoRepository
                    .FindById(basketItemView.BookVariableInfoId);

            if (ModelState.IsValid)
            {
                basketService = new BasketService();
                if (basketService.BasketItemIsValid(basketItemView))
                {
                    basketService = new BasketService();
                    //Извлечение BasketItem из BasketItemView
                    basketItem = basketService.GetBasketItem(
                        basketItemView);

                    if (basketService.UpdateBookItem(basketItem))
                        return RedirectToAction("Index");
                    else isOk = false;
                }
                else isOk = false;

                if (!isOk)
                    return Content(
                    "Укажите суммарное число экземпляров > 0 и <= общего числа.");
            }

            return View(basketItemView);
        }

        public ActionResult DeleteBasketItem(Int32 basketItemId)
        {
            BasketItem basketItem;
            BasketService basketService;

            basketItem = (BasketItem)this._basketItemRepository
                .FindById(basketItemId);

            basketService = new BasketService();
            basketService.DeleteBasketItem(basketItem);

            return RedirectToAction("Index");
        }

        public ActionResult ViewShops(IList<ShopView> shopViews)
        {
            CityRepository cityRepository;
            Basket basket;
            BasketService basketService;
            IList<Shop> shops;

            basketService = new BasketService();
            basket = basketService.GetBasket(User.Identity.Name);
            if (basket.BasketItems.Count > 0)
            {
                cityRepository = (CityRepository)this._cityRepository;
                ViewData["cityNames"] =
                    cityRepository.GetSelectItemList(
                        this._cityRepository.GetAll().cities);
            }
            else return Content("Сперва, сделайте заказ");

            if (shopViews == null)
            {
                shops = this._shopRepository.GetAll().shops;
                shopViews = (from shop in shops
                             select new ShopView(shop))
                             .ToList<ShopView>();
            }

            return View(shopViews);
        }

        public ActionResult SelectShop(Shop shop)
        {
            Basket basket;
            IList<Shop> shops;
            PaymentView paymentView;
            UrlGenerator urlGenerator;
            Payment payment, dbPayment;
            W1Payment w1Payment, dbW1Payment;
            W1PaymentView w1PaymentView;
            Individual individual;
            BasketService basketService;
            IndividualRepository individualRepository;
            PaymentRepository paymentRepository;
            PaymentService paymentService;

            //Необходимо вызвать UrlGenerator в любом Post-методе контроллера, 
            //иначе Request и Url поля не будут доступны. 
            //В будующем нужно исправить!
            urlGenerator = new UrlGenerator(this.Request, this.Url);

            basketService = new BasketService();
            paymentRepository = new PaymentRepository();
            paymentService = new PaymentService();
            individualRepository = new IndividualRepository();
            //----
            shop = (Shop)this._shopRepository.FindById(shop.Id); //для адреса

            basket = basketService.GetBasket(User.Identity.Name);

            //Вычитаем заказанныек книги из BookVariableInfo и 
            //обвновляем Basket
            basketService.ShopProcessing(basket, shop);
            shop.Address = (Address)this._addressRepository.FindById(shop.Id);
            //--
            //Создание платежной формы W1Payment
            individual = (Individual)individualRepository
                .FindIndividualByUserProfileName(User.Identity.Name);

            w1Payment = new W1Payment();
            w1Payment.WMI_PAYMENT_AMOUNT = paymentService.DecimalCounting(
                basket.TotalAmount, shop.BookDeliveryCost);
            w1Payment.WMI_DESCRIPTION = paymentService.MakeDescription(basket.Id);
            dbW1Payment = paymentService.MakeW1Payment(w1Payment);
            //добавление payment и w1Payment
            payment = new Payment()
            {
                Id = dbW1Payment.WMI_PAYMENT_NO,
                ShopId = shop.Id,
                IndividualId = individual.Id
            };
            dbPayment = paymentService.AddPayment(payment, w1Payment);
            payment.Id = dbPayment.Id;

            //Перемещение заказов из корзины в платеж и очистка корзины
            basketService.BasketToPaymentMigration(basket, payment);

            //-Создали представление для отображения w1Payment и передачи его в POST
            w1PaymentView = new W1PaymentView(dbW1Payment);//payment, basket);

            return RedirectToAction("BasketPay", w1PaymentView);//shop); //payment);
        }

        [HttpPost]
        public ActionResult _SearchCity(Address address)
        {
            ShopRepository shopRepository;
            IList<Shop> cityShops;
            IList<ShopView> cityShopViews;
            List<SelectListItem> cityShopListItems;
            City city;
            CityRepository cityRepository;

            cityRepository = (CityRepository)this._cityRepository;
            shopRepository = (ShopRepository)this._shopRepository;

            city = (City)this._cityRepository.FindById(address.CityId);
            cityShops = shopRepository.FindAllByCity(city.Id);
            cityShopListItems = shopRepository.GetSelectItemList(cityShops);
            cityShopViews = (from cityShop in cityShops
                             select new ShopView(cityShop))
                             .ToList<ShopView>();

            ViewData["cityShopNames"] = cityShopListItems;
            ViewData["cityNames"] =
                cityRepository.GetSelectItemList(
                this._cityRepository.GetAll().cities);

            ViewData["shops"] = this._shopRepository.GetAll().shops;

            return View("ViewShops", cityShopViews);
        }

        [HttpPost]
        public ActionResult _SearchShop(Shop shop)
        {
            Payment payment;
            Basket basket;
            BasketService basketService;

            shop = (Shop)this._shopRepository.FindById(shop.Id);
            ViewData["isShopSelected"] = true;
            shop.Address = (Address)this._addressRepository.FindById(shop.Id);

            return RedirectToAction("SelectShop", shop);
        }

        //Сначала в этом Action Пользователь вводил WMR, 
        //но теперь просто выводим данные о платеже
        public ActionResult BasketPay(W1PaymentView w1PaymentView)//Shop shop) //Payment payment)
        {
            return View(w1PaymentView);
        }

        //Метод, вызываемый при удачной оплате
        public W1ActionResult SuccessPayment()
        {
            PaymentService paymentService;
            string content;
            RequestWorking requestWorking;
            Dictionary<string, string> formFields;
            bool isAcceptedCheckSum = true;
            Payment payment;
            PaymentRepository paymentRepository;

            paymentService = new PaymentService();
            requestWorking = new RequestWorking();//this.Request);

            formFields = requestWorking.GetFormDictionary(this.Request.Form);

            //Поиск и обновление присланного платежа
            if (!formFields.ContainsKey("WMI_PAYMENT_NO"))
                return new W1ActionResult(paymentService.MakeResponseToW1("RETRY",
                    "Отсутствует параметр WMI_PAYMENT_NO"));
            if (!formFields.ContainsKey("WMI_PAYMENT_NO"))
                return new W1ActionResult(paymentService.MakeResponseToW1("RETRY",
                    "Отсутствует параметр WMI_PAYMENT_NO"));
            if (!formFields.ContainsKey("WMI_ORDER_STATE"))
                return new W1ActionResult(paymentService.MakeResponseToW1("RETRY",
                    "Отсутствует параметр WMI_ORDER_STATE"));
            if (formFields["WMI_ORDER_STATE"].ToUpper() != "ACCEPTED")
                return new W1ActionResult(paymentService.MakeResponseToW1("RETRY",
                        "Неверное состояние " + formFields["WMI_ORDER_STATE"]));


            //Наверное, сигнутура отключена в настройках
            if (formFields.ContainsKey("WMI_SIGNATURE"))
            {
                isAcceptedCheckSum = paymentService.CheckSignature(formFields);
                if (!isAcceptedCheckSum)
                    return new W1ActionResult(paymentService.MakeResponseToW1("RETRY",
                    "Неверная подпись " + formFields["WMI_SIGNATURE"]));
            }
            //OK, no comments
            //фиксируем
            paymentRepository = (PaymentRepository)this._paymentRepository;
            //связаны 1:1
            payment = (Payment)this._paymentRepository.FindById(
                Convert.ToInt32(formFields["WMI_PAYMENT_NO"]));
            payment.isPayed = true;
            paymentRepository.Edit(payment);

            return new W1ActionResult(paymentService.MakeResponseToW1("OK",
                    "Заказ #" + formFields["WMI_PAYMENT_NO"] + " оплачен!"));
        }

        //Метод, вызываемый при неудачной оплате
        public W1ActionResult FailPayment()
        {
            PaymentService paymentService;
            string content;

            paymentService = new PaymentService();
            //RETRY
            content = paymentService.MakeResponseToW1("RETRY",
                "Server is not availables temporary");
            return new W1ActionResult(content);
        }


    }
}
