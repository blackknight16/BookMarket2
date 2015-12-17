//-----------------------------------------------------------------------
// Сервис персональных данных покупателя.
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookMarket.Models;

namespace BookMarket.Services
{
    public class IndividualService : BaseService
    {
        //Добавление корзины и физ.лица, на которую он ссылается
        public Individual AddIndividual(Individual individual, UserProfile userProfile)
        {
            Basket dbBasket;
            Individual dbIndividual;
            UserProfileRepository userProfileRepository;

            userProfileRepository = new UserProfileRepository();
            //Добавляе корзину
            //Инициализируем явно для внимания
            dbBasket = (Basket)this._basketRepository.Add(new Basket()
            {
                TotalAmount = 0,
                DeliveryCost = 0
            });
            individual.Id = dbBasket.Id;

            //добавляем физ.лицо
            dbIndividual = (Individual) 
                this._individualRepository.Add(individual);
            individual.Id = dbIndividual.Id;
            //связываем пользователя с физ.лицом
            userProfile.IndividualId = individual.Id;
            userProfileRepository.Edit(userProfile);

            return individual;
        }
    }
}