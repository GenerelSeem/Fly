using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Web.Script.Serialization;
using Flybillett.Models;

namespace Flybillett.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
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
                    string funnetFlyrerise = alleFraBy.FirstOrDefault(fl => fl.Contains(f.fraBy));
                    if (funnetFlyrerise == null)
                    {
                        alleFraBy.Add(f.fraBy);
                    }
                }
                var jsonSerializer = new JavaScriptSerializer();
                return jsonSerializer.Serialize(alleFraBy);
            }
        }
        public string hentAlleTilBy()
        {
            using (var db = new DBContext())
            {
                List<Flyreise> alleFly = db.Flyreise.ToList();
                var alleTilBy = new List<string>();
                foreach (Flyreise f in alleFly)
                {
                    string funnetFlyrerise = alleTilBy.FirstOrDefault(fl => fl.Contains(f.tilBy));
                    if (funnetFlyrerise == null)
                    {
                        alleTilBy.Add(f.tilBy);
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

    }
}