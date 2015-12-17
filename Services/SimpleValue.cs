//-----------------------------------------------------------------------
// Значение, отображающее человеко-машинное отображение информации.
// Предназначалось для тегов.
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookMarket.Services
{
    public class SimpleValue
    {
        public Int32 Id { get; set; }
        public string HumanName { get; set; }
        public string MachineName { get; set; }

        public SimpleValue()
        {
        }

        public SimpleValue(Int32 id, string humanName, string mashineName)
        {
            this.Id = id;
            this.HumanName = humanName;
            this.MachineName = mashineName;
        }
    }
}