using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProj.Models;

namespace WebProj.Controllers
{
    public class RegistracijaController : Controller
    {
        // GET: Registracija
        public ActionResult Index()
        {
            return View();
        }
        // GET: Registracija/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Registracija/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Registracija/Create
        [HttpPost]
        public ActionResult Create(Korisnik collection)
        {
            try
            {
                List<Korisnik> korisnici = (List<Korisnik>)HttpContext.Application["korisnici"];
                collection.Uloga = Uloga.POSETILAC;
                foreach (Korisnik k in korisnici)
                {
                    if (k.KorisnickoIme == collection.KorisnickoIme)
                    {
                        ViewBag.Message = "Korisnicko ime vec postoji !";
                        return View("Login");
                    }

                }
                if (!ModelState.IsValid)
                    return View("Create");

                korisnici.Add(collection);
                Data.SaveUser(collection);


                return RedirectToAction("Login");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(Korisnik k)
        {
            List<Korisnik> users = (List<Korisnik>)HttpContext.Application["korisnici"];
            Korisnik user = users.Find(u => u.KorisnickoIme.Equals(k.KorisnickoIme) && u.Lozinka.Equals(k.Lozinka));
            if (user.Blokiran == true)
            {
                ViewBag.Message = "Korisnik ne moze da se uloguje";
                return View("Login");
            }
            if (user == null)
            {
                ViewBag.Message = $"Korisnik sa datim kredencijalima ne postoji!";
                return View("Index");
            }

            Session["Korisnik"] = user;

            return RedirectToAction("Index", "Home");
        }


        public ActionResult Logout()
        {
            Session["Korisnik"] = null;


            return View("Login");

        }


        // GET: Registracija/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Registracija/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Registracija/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Registracija/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}