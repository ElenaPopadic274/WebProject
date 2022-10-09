using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProj.Models;

namespace WebProj.Controllers
{
    public class HomeController : Controller
    {
        #region Index
        public ActionResult Index()
        {
            List<FitnesCentar> centri = (List<FitnesCentar>)HttpContext.Application["centri"];
            List<FitnesCentar> novi = new List<FitnesCentar>();
            foreach (FitnesCentar f in centri)
            {
                  novi.Add(f);    
            }
            List<FitnesCentar> zanrSort = novi.OrderBy(k => k.Naziv).ToList();
            ViewBag.Korisnik = Session["Korisnik"];
            return View(zanrSort);
        }
        #endregion

        #region Detalji
        public ActionResult Details(string id)
        {
            List<FitnesCentar> centri = (List<FitnesCentar>)HttpContext.Application["centri"];
            FitnesCentar f = new FitnesCentar();

            foreach (FitnesCentar fc in centri)
            {
                if (fc.Naziv == id)
                {
                    f = fc;
                    break;
                }
            }
            return View(f);

        }
        #endregion

        #region PrikaziGT
        public ActionResult PrikaziGT()
        {
            List<GrupniTrening> treninzi = (List<GrupniTrening>)HttpContext.Application["treninzi"];
            List<GrupniTrening> treninziSort = treninzi.OrderBy(k => k.DatumVremeTreninga).ToList();

            return View(treninziSort);
        }
        #endregion

        #region Komentar
        public ActionResult Komentar(string id)
        {
            //List<FitnesCentar> centri = (List<FitnesCentar>)HttpContext.Application["centri"];

            /*
            if (dat > DateTime.Now)
            {
                ViewBag.Messige = "NEMA KOMENTARE!";
                return View("Prikazi", centri);
            }
            */
           
            List<Komentar> komentari = (List<Komentar>)HttpContext.Application["komentari"];
            List<Komentar> noviKom = new List<Komentar>();

            foreach (Komentar k in komentari)
            {
                if (k.FitnesC.Naziv == id)
                {
                    noviKom.Add(k);
                }
            }
            return View("Komentar", noviKom);
        }

        public ActionResult DodajKomentar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DodajKomentar(Komentar k)
        {

            List<Komentar> komentarii = (List<Komentar>)HttpContext.Application["komentari"];
            komentarii.Add(k);
            //((Korisnik)Session["korisnik"]).centarTre.Add(gt);

            return RedirectToAction("Komentar");
        }
        #endregion

        #region Pretrage i sortiranja vlasnika
        public ActionResult PretragaFitnesCentara(string pretraga, string apretraga, string donjagranicaotvaranja, string gornjagranicaotvaranja)
        {
            List<FitnesCentar> centri = (List<FitnesCentar>)HttpContext.Application["centri"];
            List<FitnesCentar> novi = new List<FitnesCentar>();
            List<FitnesCentar> pomoc = new List<FitnesCentar>();
            foreach (FitnesCentar f in centri)
            {
                 novi.Add(f);   
            }
            int broj = novi.Count;
            if (pretraga != "")
            {
                for (int i = 0; i < broj; i++)
                {
                    if (novi[i].Naziv.ToLower().IndexOf(pretraga.ToLower()) == -1)
                    {
                        novi.RemoveAt(i);
                        broj = novi.Count;
                        i--;

                    }
                }
            }
            broj = novi.Count;
            if (apretraga != "")
            {
                for (int i = 0; i < broj; i++)
                {
                    if (novi[i].Ulica.ToLower().IndexOf(apretraga.ToLower()) == -1)
                    {
                        novi.RemoveAt(i);
                        broj = novi.Count;
                        i--;

                    }
                }
            }

            broj = novi.Count;
            if (donjagranicaotvaranja != "")
            {
                int dt = int.Parse(donjagranicaotvaranja);
                for (int i = 0; i < broj; i++)
                {
                    if (dt >= novi[i].GodinaOtvaranja)
                    {
                        novi.RemoveAt(i);
                        broj = novi.Count;
                        i--;

                    }
                }

            }
            broj = novi.Count;
            if (gornjagranicaotvaranja != "")
            {
                int dt = int.Parse(gornjagranicaotvaranja);
                for (int i = 0; i < broj; i++)
                {
                    if (dt <= novi[i].GodinaOtvaranja)
                    {
                        novi.RemoveAt(i);
                        broj = novi.Count;
                        i--;

                    }
                }

            }
            return View("Index", novi);

        }
        [HttpPost]
        public ActionResult SortNaziv1()
        {
            List<FitnesCentar> centri = (List<FitnesCentar>)HttpContext.Application["centri"];
            List<FitnesCentar> novi = new List<FitnesCentar>();
            foreach (FitnesCentar f in centri)
            {
                novi.Add(f); 
            }
            List<FitnesCentar> nazivSort = novi.OrderByDescending(k => k.Naziv).ToList();
            return View("Index", nazivSort);

        }
        [HttpPost]
        public ActionResult SortNaziv2()
        {
            List<FitnesCentar> centri = (List<FitnesCentar>)HttpContext.Application["centri"];
            List<FitnesCentar> novi = new List<FitnesCentar>();
            foreach (FitnesCentar f in centri)
            {
                novi.Add(f);
            }

            List<FitnesCentar> nazivSort = novi.OrderBy(k => k.Naziv).ToList();
            return View("Index", nazivSort);

        }
        [HttpPost]
        public ActionResult SortAdresa1()
        {
            List<FitnesCentar> centri = (List<FitnesCentar>)HttpContext.Application["centri"];
            List<FitnesCentar> novi = new List<FitnesCentar>();
            foreach (FitnesCentar f in centri)
            {
                novi.Add(f);
            }
            List<FitnesCentar> nazivSort = novi.OrderByDescending(k => k.Ulica).ToList();
            return View("Index", nazivSort);

        }
        [HttpPost]
        public ActionResult SortAdresa2()
        {
            List<FitnesCentar> centri = (List<FitnesCentar>)HttpContext.Application["centri"];
            List<FitnesCentar> novi = new List<FitnesCentar>();
            foreach (FitnesCentar f in centri)
            {
                novi.Add(f);
            }
            List<FitnesCentar> nazivSort = novi.OrderBy(k => k.Ulica).ToList();
            return View("Index", nazivSort);

        }
        [HttpPost]
        public ActionResult SortGodinaOtvaranja1()
        {
            List<FitnesCentar> centri = (List<FitnesCentar>)HttpContext.Application["centri"];
            List<FitnesCentar> novi = new List<FitnesCentar>();
            foreach (FitnesCentar f in centri)
            {
                novi.Add(f);
            }
            List<FitnesCentar> godSort = novi.OrderByDescending(k => k.GodinaOtvaranja).ToList();
            return View("Index", godSort);
        }

        [HttpPost]
        public ActionResult SortGodinaOtvaranja2()
        {
            List<FitnesCentar> centri = (List<FitnesCentar>)HttpContext.Application["centri"];
            List<FitnesCentar> novi = new List<FitnesCentar>();
            foreach (FitnesCentar f in centri)
            {
                novi.Add(f);
            }
            List<FitnesCentar> godSort = novi.OrderBy(k => k.GodinaOtvaranja).ToList();
            return View("Index", godSort);
        }
        #endregion

        #region Trener, prikaz trenera
        public ActionResult Trener()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Trener(Korisnik korisnik)
        {

            List<Korisnik> korisnici = (List<Korisnik>)HttpContext.Application["korisnici"];
            korisnik.Uloga = Uloga.TRENER;
            foreach (Korisnik k in korisnici)
            {
                if (k.KorisnickoIme == korisnik.KorisnickoIme)
                {

                    return View("Treneri", korisnici);
                }

            }
            korisnici.Add(korisnik);
            Data.SaveUser(korisnik);


            return RedirectToAction("PrikazTrenera");
        }

        public ActionResult PrikazTrenera()
        {
            List<Korisnik> korisnici = (List<Korisnik>)HttpContext.Application["korisnici"];
            return View("Treneri", korisnici);
        }

        public ActionResult Blok(string id)
        {
            List<Korisnik> korisnici = (List<Korisnik>)HttpContext.Application["korisnici"];
            foreach (Korisnik item in korisnici)
            {
                if (item.KorisnickoIme == id)
                {
                    item.Blokiran = true;
                    return View("Treneri", korisnici);
                }
            }
            return View("Treneri", korisnici);
        }
        #endregion

        #region DodajFitnesCentar
        public ActionResult DodajFitnesCentar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DodajFitnesCentar(FitnesCentar fc)
        {
            List<FitnesCentar> centri = (List<FitnesCentar>)HttpContext.Application["vlasnikfc"];
            centri.Add(fc);
            ((Korisnik)Session["korisnik"]).centarVla.Add(fc);


            return RedirectToAction("IspisiVlasnikove");
        }
        #endregion

        #region Vlasnikovi centri(ispis,izmena,brisanje)
        public ActionResult IspisiVlasnikove()
        {
            List<FitnesCentar> fc = (List<FitnesCentar>)HttpContext.Application["vlasnikfc"];
            return View(fc);
        }

        public ActionResult VlasnikoviFCIspis()
        {
            List<FitnesCentar> centri = ((Korisnik)Session["korisnik"]).centarVla;
            return View("IspisiVlasnikove", centri);
        }

        public ActionResult IzmeniFitnesCentar(string id)
        {
            List<FitnesCentar> centri = (List<FitnesCentar>)HttpContext.Application["vlasnikfc"];
            FitnesCentar fc = new FitnesCentar();
            foreach (FitnesCentar item in centri)
            {
                if (item.Naziv == id)
                {
                    fc = item;
                    return View(fc);
                }
            }
            return View();
            //return RedirectToAction("VlasnikoviFCIspis");
        }
        [HttpPost]
        public ActionResult IzmeniFitnesCentar(FitnesCentar fc)
        {
            List<FitnesCentar> centri = (List<FitnesCentar>)HttpContext.Application["centri"];
            for (int i = 0; i < centri.Count; i++)
            {
                if (fc.Naziv == centri[i].Naziv)
                {
                    //fc.Naziv = centri[i].Naziv;
                    centri[i] = fc;
                    return RedirectToAction("Index");
                }
            }
            centri.Add(fc);
            Data.SaveFC(fc);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int naz)
        {
            List<FitnesCentar> centri = (List<FitnesCentar>)HttpContext.Application["centri"];
            foreach (FitnesCentar item in centri)
            {
                if (item.logObrisan)
                {
                    continue;
                }
                else
                {
                    item.logObrisan = true;
                    centri.Remove(item);
                    return View("IspisiVlasnikove");

                }
            }
            return RedirectToAction("VlasnikoviFCIspis");


            /*
            if (dinner == null)
                return View("NotFound");

            dinnerRepository.Delete(dinner);
            dinnerRepository.Save();

            return View("Deleted");
            */
        }
        #endregion

        #region DodajGrupniTrening
        public ActionResult DodajTrening()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DodajTrening(GrupniTrening gt)
        {
            List<GrupniTrening> gtt = (List<GrupniTrening>)HttpContext.Application["treninzi"];
            List<GrupniTrening> treninzi = (List<GrupniTrening>)HttpContext.Application["trenergt"];
            gtt.Add(gt);
            treninzi.Add(gt);
            ((Korisnik)Session["korisnik"]).grupniTre.Add(gt);
            //((Korisnik)Session["korisnik"]).centarTre.Add(gt);

            return RedirectToAction("TreneroviGTIspis", treninzi);
        }
        #endregion

        #region IspisTrenerovihGrupnih
        public ActionResult IspisiTrenerove()
        {
            List<GrupniTrening> gt = (List<GrupniTrening>)HttpContext.Application["trenergt"];
            return View(gt);
        }

        public ActionResult TreneroviGTIspis()
        {
            List<GrupniTrening> treninzi = ((Korisnik)Session["korisnik"]).grupniTre;
            return View("IspisiTrenerove", treninzi);
        }

        public ActionResult IzmeniTGrupni(string naziv)
        {
            List<GrupniTrening> gt = (List<GrupniTrening>)HttpContext.Application["trenergt"];
            foreach (GrupniTrening item in gt)
            {
                if (item.Naziv == naziv)
                {
                    return View(item);
                }
            }
            return RedirectToAction("TreneroviGTIspis");
        }

        [HttpPost]
        public ActionResult IzmeniTGrupni(GrupniTrening gt)
        {
            List<GrupniTrening> grupni = (List<GrupniTrening>)HttpContext.Application["treninzi"];
            for (int i = 0; i < grupni.Count; i++)
            {
                if (gt.Naziv == grupni[i].Naziv)
                {
                    //fc.Naziv = centri[i].Naziv;
                    grupni[i] = gt;
                    return RedirectToAction("Index");
                }
            }
            grupni.Add(gt);
            Data.SaveGT(gt);
            return RedirectToAction("TreneroviGTIspis");
        }
        #endregion
 
        #region IzmenaKorisnika
        public ActionResult Izmena(string id)
        {
            List<Korisnik> korisnici = (List<Korisnik>)HttpContext.Application["korisnici"];
            Korisnik k = new Korisnik();
            foreach (Korisnik kor in korisnici)
            {
                if (kor.KorisnickoIme == id)
                {
                    k = kor;
                    return View(k);
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult Izmena(Korisnik k)
        {
            List<Korisnik> korisnici = (List<Korisnik>)HttpContext.Application["korisnici"];
            for (int i = 0; i < korisnici.Count; i++)
            {
                if (k.KorisnickoIme == korisnici[i].KorisnickoIme)
                {
                    k.Uloga = korisnici[i].Uloga;
                    korisnici[i] = k;
                    return RedirectToAction("Index");
                }
            }
            korisnici.Add(k);
            Data.SaveUser(k);
            return RedirectToAction("Index");
        }
        #endregion

        #region Listaj
        public ActionResult Listaj()
        {
            List<Rezervacija> rezervacije = ((Korisnik)Session["korisnik"]).rezervacija;
            return View(rezervacije);
        }
        #endregion

        #region Sortovi i Pretrage rezervacije, sortovi trenera

        public ActionResult PretraziRezervaciju(string pretraga)
        {
            List<Rezervacija> rez = ((Korisnik)Session["korisnik"]).rezervacija;
            List<Rezervacija> pomoc = new List<Rezervacija>();
            foreach (Rezervacija r in rez)
            {
                if (r.IdRezervacije == pretraga)
                {
                    pomoc.Add(r);
                    return View("Listaj", pomoc);
                }
            }
            return View("Listaj", rez);
        }
        [HttpPost]
        public ActionResult SortNazivGT1()
        {
            List<Rezervacija> rez = ((Korisnik)Session["korisnik"]).rezervacija;
            List<Rezervacija> rezSort = rez.OrderBy(k => k.Grupni.Naziv).ToList();
            return View("Listaj", rezSort);

        }
        [HttpPost]
        public ActionResult SortNazivGT2()
        {
            List<Rezervacija> rez = ((Korisnik)Session["korisnik"]).rezervacija;
            List<Rezervacija> rezSort = rez.OrderByDescending(k => k.Grupni.Naziv).ToList();
            return View("Listaj", rezSort);
        }
        [HttpPost]
        public ActionResult SortTipTreninga1()
        {
            List<Rezervacija> rez = ((Korisnik)Session["korisnik"]).rezervacija;
            List<Rezervacija> rezSort = rez.OrderBy(k => k.Grupni.TipTreninga).ToList();
            return View("Listaj", rezSort);

        }
        [HttpPost]
        public ActionResult SortTipTreninga2()
        {
            List<Rezervacija> rez = ((Korisnik)Session["korisnik"]).rezervacija;
            List<Rezervacija> rezSort = rez.OrderByDescending(k => k.Grupni.TipTreninga).ToList();
            return View("Listaj", rezSort);
        }
        [HttpPost]
        public ActionResult SortDVGT1()
        {
            List<Rezervacija> rez = ((Korisnik)Session["korisnik"]).rezervacija;
            List<Rezervacija> rezSort = rez.OrderBy(k => k.Grupni.DatumVremeTreninga).ToList();
            return View("Listaj", rezSort);
        }

        [HttpPost]
        public ActionResult SortDVGT2()
        {
            List<Rezervacija> rez = ((Korisnik)Session["korisnik"]).rezervacija;
            List<Rezervacija> rezSort = rez.OrderByDescending(k => k.Grupni.DatumVremeTreninga).ToList();
            return View("Listaj", rezSort);
        }
        #endregion

        #region Pretraga i sortiranje posetioca
        public ActionResult PretraziRezervisaneGT(string pretragag, string pretragat, string pretragaf)
        {
            List<GrupniTrening> treninzi = (List<GrupniTrening>)HttpContext.Application["treninzi"];
            List<GrupniTrening> novigt = new List<GrupniTrening>();
            List<GrupniTrening> pomocgt = new List<GrupniTrening>();
            foreach (GrupniTrening gt in treninzi)
            {
                novigt.Add(gt);
            }
            int broj = novigt.Count;
            if (pretragag != "")
            {
                for (int i = 0; i < broj; i++)
                {
                    if (novigt[i].Naziv.ToLower().IndexOf(pretragag.ToLower()) == -1)
                    {
                        novigt.RemoveAt(i);
                        broj = novigt.Count;
                        i--;

                    }
                }
            }
            broj = novigt.Count;
            if (pretragat != "")
            {
                for (int i = 0; i < broj; i++)
                {
                    if (novigt[i].TipTreninga.ToString().ToLower().IndexOf(pretragat.ToLower()) == -1)
                    {
                        novigt.RemoveAt(i);
                        broj = novigt.Count;
                        i--;

                    }
                }
            }
            broj = novigt.Count;
            if (pretragaf != "")
            {
                for (int i = 0; i < broj; i++)
                {
                    if (novigt[i].FCOdrzavanja.Naziv.ToLower().IndexOf(pretragaf.ToLower()) == -1)
                    {
                        novigt.RemoveAt(i);
                        broj = novigt.Count;
                        i--;

                    }
                }
            }
            return View("Listaj", treninzi);
        }
        #endregion

        #region Pretraga trenera
        public ActionResult PretraziTreneroveGT(string pretragan, string pretragat, string donjagranicaotvaranjagt, string gornjagranicaotvaranjagt)
        {
            //List<GrupniTrening> treninzi = (List<GrupniTrening>)HttpContext.Application["trenergt"];
            //List<GrupniTrening> treninzi = ((Korisnik)Session["korisnik"]).grupniTre;
            List<GrupniTrening> treninzi = (List<GrupniTrening>)HttpContext.Application["treninzi"];
            List<GrupniTrening> novigt = new List<GrupniTrening>();
            List<GrupniTrening> pomocgt = new List<GrupniTrening>();
            foreach (GrupniTrening gt in treninzi)
            {
                novigt.Add(gt);
            }
            int broj = novigt.Count;
            if (pretragan != "")
            {
                for (int i = 0; i < broj; i++)
                {
                    if (novigt[i].Naziv.ToLower().IndexOf(pretragan.ToLower()) == -1)
                    {
                        novigt.RemoveAt(i);
                        broj = novigt.Count;
                        i--;

                    }
                }
            }
            broj = novigt.Count;
            if (pretragat != "")
            {
                for (int i = 0; i < broj; i++)
                {
                    if (novigt[i].TipTreninga.ToString().ToLower().IndexOf(pretragat.ToLower()) == -1)
                    {
                        novigt.RemoveAt(i);
                        broj = novigt.Count;
                        i--;

                    }
                }
            }
            broj = novigt.Count;
            if (donjagranicaotvaranjagt != "")
            {
                int dt = int.Parse(donjagranicaotvaranjagt);
                for (int i = 0; i < broj; i++)
                {
                    if (dt >= novigt[i].FCOdrzavanja.GodinaOtvaranja)
                    {
                        novigt.RemoveAt(i);
                        broj = novigt.Count;
                        i--;

                    }
                }

            }
            broj = novigt.Count;
            if (gornjagranicaotvaranjagt != "")
            {
                int dt = int.Parse(gornjagranicaotvaranjagt);
                for (int i = 0; i < broj; i++)
                {
                    if (dt <= novigt[i].FCOdrzavanja.GodinaOtvaranja)
                    {
                        novigt.RemoveAt(i);
                        broj = novigt.Count;
                        i--;

                    }
                }

            }
            return RedirectToAction("TreneroviGTIspis", novigt);
        }

        [HttpPost]
        public ActionResult SortNazGT1()
        {
            List<GrupniTrening> treninzi = (List<GrupniTrening>)HttpContext.Application["trenergt"];
            //List<GrupniTrening> treninzi = ((Korisnik)Session["korisnik"]).grupniTre;
            //List<GrupniTrening> treninzi = (List<GrupniTrening>)HttpContext.Application["treninzi"];
            List<GrupniTrening> novi = new List<GrupniTrening>();
            foreach (GrupniTrening gt in treninzi)
            {
                novi.Add(gt);
            }
            List<GrupniTrening> nazivSort = novi.OrderByDescending(k => k.Naziv).ToList();
            return View("IspisiTrenerove", nazivSort);

        }
        [HttpPost]
        public ActionResult SortNazGT2()
        {
            List<GrupniTrening> treninzi = (List<GrupniTrening>)HttpContext.Application["treninzi"];
            List<GrupniTrening> novi = new List<GrupniTrening>();
            foreach (GrupniTrening gt in treninzi)
            {
                novi.Add(gt);
            }
            List<GrupniTrening> nazivSort = novi.OrderBy(k => k.Naziv).ToList();
            return View("IspisiTrenerove", nazivSort);
        }
        [HttpPost]
        public ActionResult SortTipTr1()
        {
            List<GrupniTrening> treninzi = (List<GrupniTrening>)HttpContext.Application["treninzi"];
            List<GrupniTrening> novi = new List<GrupniTrening>();
            foreach (GrupniTrening gt in treninzi)
            {
                novi.Add(gt);
            }
            List<GrupniTrening> tipSort = novi.OrderByDescending(k => k.TipTreninga).ToList();
            return View("IspisiTrenerove", tipSort);

        }
        [HttpPost]
        public ActionResult SortTipTr2()
        {
            List<GrupniTrening> treninzi = (List<GrupniTrening>)HttpContext.Application["treninzi"];
            List<GrupniTrening> novi = new List<GrupniTrening>();
            foreach (GrupniTrening gt in treninzi)
            {
                novi.Add(gt);
            }
            List<GrupniTrening> tipSort = novi.OrderBy(k => k.TipTreninga).ToList();
            return View("IspisiTrenerove", tipSort);
        }
        [HttpPost]
        public ActionResult SortDVG1()
        {

            List<GrupniTrening> treninzi = (List<GrupniTrening>)HttpContext.Application["treninzi"];
            List<GrupniTrening> novi = new List<GrupniTrening>();
            foreach (GrupniTrening gt in treninzi)
            {
                novi.Add(gt);
            }
            List<GrupniTrening> datSort = novi.OrderByDescending(k => k.DatumVremeTreninga).ToList();
            return View("IspisiTrenerove", datSort);
        }

        [HttpPost]
        public ActionResult SortDVG2()
        {
            //List<GrupniTrening> treninzi = ((Korisnik)Session["korisnik"]).grupniTre;
            List<GrupniTrening> treninzi = (List<GrupniTrening>)HttpContext.Application["treninzi"];
            List<GrupniTrening> novi = new List<GrupniTrening>();
            foreach (GrupniTrening gt in treninzi)
            {
                novi.Add(gt);
            }
            List<GrupniTrening> datSort = novi.OrderBy(k => k.DatumVremeTreninga).ToList();
            return View("IspisiTrenerove", datSort);
        }
        #endregion

        #region Rezervacija
        public ActionResult Rezervisi(string naziv)
        {
            List<GrupniTrening> treninzi = (List<GrupniTrening>)HttpContext.Application["treninzi"];
            List<Rezervacija> rezervacije = ((Korisnik)Session["korisnik"]).rezervacija;
            ViewBag.Korisnik = Session["korisnik"];
            GrupniTrening tr = new GrupniTrening();
            Rezervacija rez = new Rezervacija();

            foreach (GrupniTrening item in treninzi)
            {
                if (item.Naziv == naziv)
                {
                    //tr = item;
                    rez.IdRezervacije = ((Korisnik)Session["korisnik"]).KorisnickoIme + tr.Naziv;
                    rez.Posetilac = ((Korisnik)Session["korisnik"]).KorisnickoIme;
                    rez.Grupni = tr;
                    Data.SaveRezervacija(rez);
                    ((Korisnik)Session["korisnik"]).rezervacija.Add(rez);
                    return RedirectToAction("Listaj", rezervacije);
                }
            }
            return RedirectToAction("Listaj", rezervacije);
        }
        #endregion


    }
}
