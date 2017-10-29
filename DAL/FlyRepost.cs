using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace DAL
{
    public class FlyRepost : DAL.IFlyRepository
    {
        public List<Kunde> hentkunder()
        {
            var db = new DBContext();
            List<Kunde> hentkunder = db.Kunde.Select(k => new Kunde()
            {
                KundeId = k.KundeId,
                Fornavn = k.Fornavn,
                Etternavn = k.Etternavn,
                Email = k.Email,
            }
            ).ToList();
            return hentkunder;

        }
        public List<Flyreise> hentreiser()
        {
            var db = new DBContext();
            List<Flyreise> hentreiser = db.Flyreise.Select(f => new Flyreise()
            {
                FlyreiseId = f.FlyreiseId,
                fraBy = f.fraBy,
                tilBy = f.tilBy,
                tid = f.tid,
                pris = f.pris,
            }
            ).ToList();
            return hentreiser;

        }
        public List<Flyreise> hentfraby()
        {
            var db = new DBContext();
            List<Flyreise> hentfraby = db.Flyreise.Select(f => new Flyreise()
            {

                fraBy = f.fraBy,

            }
            ).ToList();
            return hentfraby;
        }
        public List<Flyreise> hentilby()
        {
            var db = new DBContext();
            List<Flyreise> henttilby = db.Flyreise.Select(f => new Flyreise()
            {

                tilBy = f.tilBy,

            }
            ).ToList();
            return henttilby;
        }
        public List<Admin> hentadmin()
        {
            var db = new DBContext();
            List<Admin> hentadmin = db.Admin.Select(a => new Admin()
            {
                AdminId = a.AdminId,
                Bruker = a.Bruker,
                Passord = a.Passord,
            }
            ).ToList();
            return hentadmin;

        }
        public bool nyKunde(Kunde kunde)
        {
            var nyKunde = new Kunde()
            {
                KundeId = kunde.KundeId,
                Fornavn = kunde.Fornavn,
                Etternavn = kunde.Etternavn,
                Email = kunde.Email,
            };

            var db = new DBContext();
            try
            {
                if (Equals(null))
                    db.Kunde.Add(nyKunde);
                db.SaveChanges();
                return true;
            }
            catch (Exception feil)
            {
                return false;
            }
        }
        public bool nyFlyreise(Flyreise flyreise)
        {
            var nyFlyreise = new Flyreise()
            {
                FlyreiseId = flyreise.FlyreiseId,
                fraBy = flyreise.fraBy,
                tilBy = flyreise.tilBy,
                tid = flyreise.tid,
                pris = flyreise.pris,
            };

            var db = new DBContext();
            try
            {
                if (Equals(null))
                    db.Flyreise.Add(nyFlyreise);
                db.SaveChanges();
                return true;
            }
            catch (Exception feil)
            {
                return false;
            }
        }
        public bool slettKunde(int KundeId)
        {
            var db = new DBContext();
            try
            {
                Kunde slettKunde = db.Kunde.FirstOrDefault(k => k.KundeId == KundeId);
                db.Kunde.Remove(slettKunde);
                db.SaveChanges();
                return true;
            }
            catch (Exception feil)
            {
                return false;
            }
        }
        public bool slettBillett(int BillettId)
        {
            var db = new DBContext();
            try
            {
                Billett slettBillett = db.Billett.FirstOrDefault(b => b.BillettId == BillettId);
                db.Billett.Remove(slettBillett);
                db.SaveChanges();
                return true;
            }
            catch (Exception feil)
            {
                return false;
            }
        }
        public bool slettFlyreise(int FlyreiseId)
        {
            var db = new DBContext();
            try
            {
                Flyreise slettFlyreise = db.Flyreise.FirstOrDefault(f => f.FlyreiseId == FlyreiseId);
                db.Flyreise.Remove(slettFlyreise);
                db.SaveChanges();
                return true;
            }
            catch (Exception feil)
            {
                return false;
            }
        }
        public Kunde hentEnKunde(int KundeId)
        {
            var db = new DBContext();

            var enDbKunde = db.Kunde.FirstOrDefault(k => k.KundeId == KundeId);

            if (enDbKunde == null)
            {
                return null;
            }
            else
            {
                var utKunde = new Kunde()
                {
                    KundeId = enDbKunde.KundeId,
                    Fornavn = enDbKunde.Fornavn,
                    Etternavn = enDbKunde.Etternavn,
                    Email = enDbKunde.Email
                };
                return utKunde;
            }

        }
        public bool endreKunde(int id, Kunde innKunde)
        {
            var db = new DBContext();
            try
            {
                Kunde endreKunde = db.Kunde.FirstOrDefault(k => k.ID == id);
                endreKunde.Fornavn = innKunde.Fornavn;
                endreKunde.Etternavn = innKunde.Etternavn;
                endreKunde.Email = innKunde.Email;
                
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
