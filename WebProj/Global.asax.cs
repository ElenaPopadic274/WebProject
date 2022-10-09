using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebProj.Models;

namespace WebProj
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            List<Korisnik> korisnici = Data.ReadKorisnik("~/App_Data/Vlasnik.txt");
            HttpContext.Current.Application["korisnici"] = korisnici;

            List<FitnesCentar> centri = Data.ReadFCentri("~/App_Data/FitnesCentri.txt");
            HttpContext.Current.Application["centri"] = centri;

            List<Komentar> komentari = Data.ReadKomentar("~/App_Data/Komentar.txt");
            HttpContext.Current.Application["komentari"] = komentari;

            List<GrupniTrening> treninzi = Data.ReadGrupniTrening("~/App_Data/GrupniTreninzi.txt");
            HttpContext.Current.Application["treninzi"] = treninzi;

            List<FitnesCentar> vlasnikcentri = Data.ReadFCentri("~/App_Data/FitnesCentri.txt");
            HttpContext.Current.Application["vlasnikfc"] = vlasnikcentri;

            List<GrupniTrening> trenertreninzi = Data.ReadGrupniTrening("~/App_Data/GrupniTreninzi.txt");
            HttpContext.Current.Application["trenergt"] = treninzi;

        }
    }
}
