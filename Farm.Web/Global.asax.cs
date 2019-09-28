using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using Farm.Data.Entities;
using Farm.Data.Interfaces;
using Farm.Data.Repository;
using Farm.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Farm.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
