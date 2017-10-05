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
         
        
        public string hentAllefraBy()
        {
            using (var db = new DBContext())
            {
                List<Flyreise> alleFly = db.Flyreise.ToList();
                var allefraBy = new List<string>();
                foreach (Flyreise f in alleFly)
                {
                    string funnetFlyrerise = allefraBy.FirstOrDefault(fl => fl.Contains(f.fraBy));
                    if (funnetFlyrerise == null)
                    {
                        allefraBy.Add(f.fraBy);
                    }
                }
                var jsonSerializer = new JavaScriptSerializer();
                return jsonSerializer.Serialize(allefraBy);
            }
        }
        public string hentAlletilBy()
        {
            using (var db = new DBContext())
            {
                List<Flyreise> alleFly = db.Flyreise.ToList();
                var alletilBy = new List<string>();
                foreach (Flyreise f in alleFly)
                {
                    string funnetFlyrerise = alletilBy.FirstOrDefault(fl => fl.Contains(f.tilBy));
                    if (funnetFlyrerise == null)
                    {
                        alletilBy.Add(f.tilBy);
                    }
                }
                var jsonSerializer = new JavaScriptSerializer();
                return jsonSerializer.Serialize(alletilBy);
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