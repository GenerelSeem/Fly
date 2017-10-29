using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace DAL
{
    public interface IFlyRepository
    {
        List<Kunde> hentkunder();
        List<Flyreise> hentreiser();
        List<Flyreise> hentfraby();
        List<Flyreise> hentilby();
        List<Admin> hentadmin();
        bool nyKunde(Kunde kunde);
        bool nyFlyreise(Flyreise flyreise);
        bool slettKunde(int KundeId);
        bool slettBillett(int BillettId);
        bool slettFlyreise(int FlyreiseId);
        Kunde hentEnKunde(int KundeId);
        bool endreKunde(int id, Kunde innKunde);


    }
}
