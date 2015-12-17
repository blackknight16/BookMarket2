//-----------------------------------------------------------------------
// Контракт между всеми репозиториями, обязующими искать по Id, искать
// всех, добавлять, представлять список Name все записей.
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookMarket.DbInfrastructure;
using BookMarket.Models;
using System.Web.Mvc;

namespace BookMarket.Services
{
    public interface IDbModelRepository
    {
        object FindById(Int32 id);
        ModelToModel GetAll();
        object Add(object item);
        IList<string> GetNames();
    }

}