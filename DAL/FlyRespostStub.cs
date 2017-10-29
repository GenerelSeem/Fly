using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FlyRespostStub : DAL.IFlyRepository
    {
        public List<Kunde> hentkunder()
        {
            var kundeListe = new List<Kunde>();
            var Kunde1 = new Kunde { Fornavn = "Hans", Etternavn = "Olsen", Email = "olsen@mail.no" };
            var Kunde2 = new Kunde { Fornavn = "Peter", Etternavn = "Brende", Email = "brende@mail.no" };
            var Kunde3 = new Kunde { Fornavn = "Stig", Etternavn = "Hansen", Email = "hansen@mail.no" };
            kundeListe.Add(Kunde1);
            kundeListe.Add(Kunde2);
            kundeListe.Add(Kunde3);
            return kundeListe;

        }
        public List<Flyreise> hentreiser()
        {
            var reiseListe = new List<Flyreise>();
            var Flyreise1 = new Flyreise { fraBy = "Oslo", tilBy = "Bergen", tid = "12:30", pris = "650" };
            var Flyreise15 = new Flyreise { fraBy = "Bergen", tilBy = "Manchester", tid = "13:50", pris = "1350" };
            var Flyreise36 = new Flyreise { fraBy = "Trondheim", tilBy = "Madrid", tid = "16:30", pris = "1450" };
            reiseListe.Add(Flyreise1);
            reiseListe.Add(Flyreise15);
            reiseListe.Add(Flyreise36);
            return reiseListe;
        }
        public List<Flyreise> hentfraby()
        {
            var frabyListe = new List<Flyreise>();
            var fraby1 = new Flyreise { fraBy = "Oslo"};
            var fraby2 = new Flyreise { fraBy = "Bergen"};
            var fraby3 = new Flyreise { fraBy = "Trondheim"};
            frabyListe.Add(fraby1);
            frabyListe.Add(fraby2);
            frabyListe.Add(fraby3);
            return frabyListe;
        }
        public List<Flyreise> hentilby()
        {
            var tilbyListe = new List<Flyreise>();
            var tilby1 = new Flyreise { fraBy = "London" };
            var tilby2 = new Flyreise { fraBy = "Berlin" };
            var tilby3 = new Flyreise { fraBy = "Roma" };
            tilbyListe.Add(tilby1);
            tilbyListe.Add(tilby2);
            tilbyListe.Add(tilby3);
            return tilbyListe;
        }
        public List<Admin> hentadmin()
        {
            var adminList = new List<Admin>();
            var Admin1 = new Admin { Bruker = "admin", Passord = "admin" };
            adminList.Add(Admin1);
            return adminList;
        }
        public bool nyKunde(Kunde kunde)
        {
            if(kunde.Fornavn == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool nyFlyreise(Flyreise flyreise)
        {
            if(flyreise.FlyreiseId.Equals(null))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool slettKunde(int KundeId)
        {
            if (KundeId == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
