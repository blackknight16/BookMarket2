using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookMarket.Services;

namespace BookMarket.RouteInfrastructure
{
    public class W1ActionResult : ActionResult
    {
        private string htmlCode;

        public W1ActionResult(string html)
        {
            this.htmlCode = html;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.Write(
                this.htmlCode);
        }
    }
}