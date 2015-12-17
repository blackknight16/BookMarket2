//-----------------------------------------------------------------------
// Выполняет работу генерации требуемого Url-страницы: успешного платежа,
// неуспешного платежа, адреса сайта.
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;//.RequestWrapper;

namespace BookMarket.RouteInfrastructure
{
    //Класс работы с адресами
    public class UrlGenerator
    {
        private static HttpRequestBase _basketRequest;
        private static UrlHelper _basketUrlHelper;

        private static string _wmi_success_url;
        private static string _wmi_fail_url;

        public UrlGenerator(){
        }

        //вызывать только в POST методах
        public UrlGenerator(HttpRequestBase basketRequest,
            UrlHelper basketUrlHelper)
        {
            UrlGenerator._basketRequest = basketRequest;
            UrlGenerator._basketUrlHelper = basketUrlHelper;
        }

        public string GetSuccessPaymentUrl()
        {
            UrlHelper urlForming, failUrl;
            string urlString;

            //должны ли аргументы быть null?
            if (_wmi_success_url == null)
            {
                UrlGenerator._wmi_success_url = GetRootUrl();
                UrlGenerator._wmi_success_url += UrlGenerator._basketUrlHelper.Action(
                    "SuccessPayment", "Basket");//, null);
            }

            return UrlGenerator._wmi_success_url;
        }

        public string GetFailPaymentUrl()
        {
            UrlHelper urlForming, failUrl;
            string urlString;

            if (UrlGenerator._wmi_fail_url == null)
            {
                //должны ли аргументы быть null?
                UrlGenerator._wmi_fail_url = GetRootUrl() + UrlGenerator._basketUrlHelper.Action(
                    "FailPayment", "Basket");
            }

            return UrlGenerator._wmi_fail_url;
        }

        public string GetRootUrl()
        {
            string url = UrlGenerator._basketRequest.Url.Scheme + "://" + UrlGenerator._basketRequest.Url.Authority;
            return url;
        }
    }
}