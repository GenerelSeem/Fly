using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Model;



using System.Web.Script.Serialization;
using Flybillett.Models;

namespace Flybillett.Controllers
{
    public class HomeController : Controller
    {
        private IFlyLogikk _FlyBLL;
        public HomeController()
        {
            _FlyBLL = new FlyLogikk();
        }
        public HomeController(IFlyLogikk stub)
        {
            _FlyBLL = stub;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Betaling()
        {
            return View();
        }
        public ActionResult Logginn()
        {
            return View();
        }
        public ActionResult Admin()
        {

            return View();
        }

        public string hentAlleFraBy()
        {
            using (var db = new DBContext())
            {
                List<Flyreise> alleFly = db.Flyreise.ToList();

                var alleFraBy = new List<string>();

                foreach (Flyreise f in alleFly)
                {
                    string funnetFlyreise = alleFraBy.FirstOrDefault(fl => fl.Contains(f.fraBy));
                    if (funnetFlyreise == null)
                    {
                        alleFraBy.Add(f.fraBy);
                    }
                }
                var jsonSerializer = new JavaScriptSerializer();
                return jsonSerializer.Serialize(alleFraBy);
            }
        }
        public string hentTilBy(string fraBy)
        {
            using (var db = new DBContext())
            {
                List<Flyreise> alleFly = db.Flyreise.ToList();
                var alleTilBy = new List<string>();
                foreach (Flyreise f in alleFly)
                {
                    if (f.fraBy == fraBy)
                    {
                        string funnetFlyreise = alleTilBy.FirstOrDefault(fl => fl.Contains(f.tilBy));
                        if (funnetFlyreise == null)
                        {
                            alleTilBy.Add(f.tilBy);
                        }
                    }
                }
                var jsonSerializer = new JavaScriptSerializer();
                return jsonSerializer.Serialize(alleTilBy);
            }
        }

        public string hentFlyreise(string fraBy, string tilBy)
        {
            using (var db = new DBContext())
            {
                List<Flyreise> alleFly = db.Flyreise.Where(
                  f => f.tilBy == tilBy && f.fraBy == fraBy).ToList();

                var jsonSerializer = new JavaScriptSerializer();
                return jsonSerializer.Serialize(alleFly);
            }
        }
        public string hentEmailKunde()
        {

            using (var db = new DBContext())
            {
                List<Kunde> alleKunder = db.Kunde.ToList();

                var alleKundeEmail = new List<string>();

                foreach (Kunde k in alleKunder)
                {
                    string funnetKundeEmail = alleKundeEmail.FirstOrDefault(kl => kl.Contains(k.Email));
                    if (funnetKundeEmail == null)
                    {
                        alleKundeEmail.Add(k.Email);
                    }
                }
                var jsonSerializer = new JavaScriptSerializer();
                return jsonSerializer.Serialize(alleKundeEmail);
            }
        }


        [HttpPost]
        public ActionResult Betaling(FormCollection betaltBillett)
        {
            try
            {
                using (var db = new DBContext())
                {
                    //var nyBillett = new Models.Billett();

                    //nyBillett.ReiseDato = betaltBillett["VelgDato"];                    
                    //db.Billett.Add(nyBillett);
                    //db.SaveChanges();

                    var nyFlyreise = new Model.Flyreise();
                    nyFlyreise.fraBy = betaltBillett["flyreise"];
                    nyFlyreise.tilBy = betaltBillett["flyreise"];
                    nyFlyreise.tid = betaltBillett["flyreise"];
                    nyFlyreise.pris = betaltBillett["flyreise"];
                    db.Flyreise.Add(nyFlyreise);
                    db.SaveChanges();

                    var nyKunde = new Model.Kunde();
                    nyKunde.Fornavn = betaltBillett["Fornavn"];
                    nyKunde.Etternavn = betaltBillett["Etternavn"];
                    nyKunde.Email = betaltBillett["Email"];
                    db.Kunde.Add(nyKunde);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            catch (Exception feil)
            {
                return View();
            }
        }

        public ActionResult endreKunde(int KundeId)

        {
            Kunde enKunde = _FlyBLL.hentEnKunde(KundeId);
            return View(enKunde);
        }
        public ActionResult Endre(int id, Kunde endreKunde)
        {
            bool endringOK = _FlyBLL.(id, endreKunde);
            if (endringOK)
            {
                return RedirectToAction("Liste");
            }
            return View();
        }



        public ActionResult SKunde(int KundeId)
        {
            using (var db = new DBContext())
            {
                try
                {
                    Model.Kunde slettKu = db.Kunde.Find(KundeId);
                    db.Kunde.Remove(slettKu);
                    db.SaveChanges();
                }
                catch (Exception feil)
                {
                    return View();
                    //skriv noe for feil
                }
                return RedirectToAction("Admin");

            }
        }
        [HttpPost]
        public ActionResult SlettKunde(int id, Kunde slettKunde)
        {
            bool slettOK = _FlyBLL.slettKunde(id);
            if (slettOK)
            {
                return RedirectToAction("Liste");
            }
            return View();
        }

        public ActionResult SBillett(int BillettId)
        {
            using (var db = new DBContext())
            {
                try
                {
                    Model.Billett slettBillett = db.Billett.Find(BillettId);
                    db.Billett.Remove(slettBillett);
                    db.SaveChanges();
                }
                catch (Exception feil)
                {
                    return View();
                    //skriv noe for feil
                }
                return RedirectToAction("Admin");

            }
        }

        public ActionResult SFlyreise(int FlyreiseID)
        {
            using (var db = new DBContext())
            {
                try
                {
                    Model.Flyreise slettFly = db.Flyreise.Find(FlyreiseID);
                    db.Flyreise.Remove(slettFly);
                    db.SaveChanges();
                }
                catch (Exception feil)
                {
                    return View();
                    //skriv noe for feil
                }
                return RedirectToAction("Admin");

            }
        }
        public ActionResult SlettFlyreiese(int id, Flyreise slettFlyreise)
        {
            bool slettOK = _FlyBLL.slettFlyreise(id);
            if (slettOK)
            {
                return RedirectToAction("Liste");
            }
            return View();
        }

        private static byte[] Hash(String Passord)
        {
            byte[] datainn, dataut;
            var algoritme = System.Security.Cryptography.SHA256.Create();
            datainn = System.Text.Encoding.ASCII.GetBytes(Passord);
            dataut = algoritme.ComputeHash(datainn);
            return dataut;
        }
    }
}