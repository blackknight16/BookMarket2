using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookMarket.Models;
using System.Security.Principal;
using System.Web.Mvc;

namespace BookMarket.Services
{
    public class WebMoneyService : BaseService
    {
        public WebMoney Create(WebMoney webmoney, string username)
        {
            Individual individual;
            UserProfile userProfile;
            WebMoney dbWebMoney;
            UserProfileRepository userProfileRepository;

            if (webmoney != null)
            {
                userProfileRepository = new UserProfileRepository();
                userProfile = userProfileRepository.FindByUserName(username);

                if (userProfile.IndividualId != null)
                    webmoney.IndividualId = (Int32)userProfile.IndividualId;
                dbWebMoney = (WebMoney) this._webmoneyRepository.Add(webmoney);
                webmoney.Id = dbWebMoney.Id;
            }
            else throw new Exception("Элемент Webmoney не найден");

            return webmoney;
        }

        public bool IsContainsOnlyDigits(string sequence)
        {
            //char[] words;
            bool onlyDigits;

            onlyDigits = sequence.ToCharArray().All(w => w >= '0' && w <= '9');
            return onlyDigits;
                          
        }
    }
}