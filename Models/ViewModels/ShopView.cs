//-----------------------------------------------------------------------
// Модель представления. Отображает данные физического магазина.
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using BookMarket.Models;
using BookMarket.Models.ViewModels;
using BookMarket.Services;

namespace BookMarket.Models.ViewModels
{
    public class ShopView
    {
        [Display(Name = "Магазин")]
        [Required(ErrorMessage = "Укажите магазин")]
        public Int32 Id { get; set; }
        public string Name { get; set; }
        public Decimal BookDeliveryCost { get; set; }

        public Address Address { get; set; }
        public City City { get; set; }
        public Street Street { get; set; }
        public StreetType StreetType { get; set; }

        public ShopView()
        {
        }

        public ShopView(Shop shop)
        {
            ShopRepository shopRepository;
            AddressRepository addressRepository;
            CityRepository cityRepository;
            StreetRepository streetRepository;
            StreetTypeRepository streetTypeRepository;

            shopRepository = new ShopRepository();
            addressRepository = new AddressRepository();
            cityRepository = new CityRepository();
            streetRepository = new StreetRepository();
            streetTypeRepository = new StreetTypeRepository();

            this.Id = shop.Id;
            this.Name = shop.Name;
            this.BookDeliveryCost = shop.BookDeliveryCost;
            this.Address = (Address)addressRepository.FindById(this.Id);
            this.City = (City)cityRepository.FindById(this.Address.CityId);
            this.Street = (Street)streetRepository.FindById(this.Address.StreetId);
            this.StreetType = (StreetType)
                streetTypeRepository.FindById(this.Street.StreetTypeId);

        }
    }
}