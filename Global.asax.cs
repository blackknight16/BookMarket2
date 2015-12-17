using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;


using BookMarket.DbInfrastructure;
using BookMarket.Models;
using BookMarket.Models.ViewModels;
using BookMarket.Services;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using BookMarket.Controllers;
using BookMarket.Services;
using BookMarket.DbInfrastructure;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer;
using System.Data;

namespace BookMarket
{
    // Примечание: Инструкции по включению классического режима IIS6 или IIS7 
    // см. по ссылке http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            //флаг создания БД (наверное это плохо).
            //BookMarket.Controllers.ProductController._dbCounter = 0;


            //необходимо убрать _dbCounter из условия при развертывании 
            //приложения

            using (var context = new BookMarketDbContext())
            {
                string serverName, conString, dbName;
                Microsoft.SqlServer.Management.Smo.Server server;

                serverName = //"MSSQLLocalDb";
                    "(LocalDb)\\MSSQLLocalDb";
                server = new Microsoft.SqlServer.Management.Smo.Server(
                    //"BookMarketDbConnectionString");
                    serverName);
                dbName = "BookMarketDb";
                conString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Programs\\C#\\BookMarket\\BookMarket\\App_Data\\BookMarketDb.mdf;Initial Catalog=BookMarketDb;Integrated Security=True";
                Database db = new Database(server, dbName); //serverName);
                                                            //Выбор бд2
                                                            /*using(var con = new SqlConnection(conString))
                                                            {
                                                                con.Open();
                                                                DataTable databases = con.GetSchema("Databases");
                                                                foreach(DataRow database in databases.Rows)
                                                                {
                                                                    string databasesName = database.Field<string>(dbName);
                                                                    short dbId = database.Field<short>(0);
                                                                    //do something.
                                                                }
                                                            }
                                                            //
                                                            try {
                                                                db.Drop();
                                                            }
                                                            catch(Exception ex)
                                                            {
                                                            }*/

                //расскомментировать при создании       
                try
                {
                    //DropDb(); //Удаление БД
                }
                catch (Exception ex) { }

                //необходимо убрать _dbCounter из условия при развертывании 
                //приложения
                if (!context.Database.Exists() )//|| ProductController._dbCounter == 0)
                {
                    MarketDbInitializer.DB_WAS_NOT_EXIST = true;
                    ProductController._dbCounter++;
                    ((IObjectContextAdapter)context)
                        .ObjectContext.CreateDatabase();

                }
            }
        }

        private void DropDb()//string conString)//BookMarketDbContext context)
        {
            string queryString, conString;
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            conString = "Data Source = (LocalDB)\\MSSQLLocalDB; Integrated Security=True";
            using (var con = new SqlConnection(conString))
            {
                cmd.CommandText = @"drop database BookMarketDb";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                con.Open();

                reader = cmd.ExecuteReader();
            }

            //((IObjectContextAdapter)context)
            //        .ObjectContext.CreateQuery("")
        }
    }
}