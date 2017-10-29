using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BLL;
using Model;

namespace BLL
{
    public class FlyLogikk : BLL.IFlyLogikk
    {
        private IFlyRepository _repository;
        public FlyLogikk()
        {
            _repository = new FlyRepost();
        }
        public FlyLogikk(IFlyRepository stub)
        {
            _repository = stub;
        }
            public List<Model.Kunde> hentkunder()
            {
            List<Model.Kunde> Kunder = _repository.hentkunder();
            return Kunder;
            }
            public List<Flyreise> hentreiser()
            {
            List<Flyreise> Flyreise = _repository.hentreiser();
            return Flyreise;
            }
            public List<Flyreise> hentfraby()
            {
            List<Flyreise> fraby= _repository.hentfraby();
            return fraby;
            }
            public List<Flyreise> hentilby()
            {
            List<Flyreise> tilby= _repository.hentilby();
            return tilby;
            }
            public List<Admin> hentadmin()
            {
            List<Admin> Admin = _repository.hentadmin();
            return Admin;
            }
            public bool nyKunde(Kunde kunde)
            {
            return _repository.nyKunde(kunde);
            
            }
            public bool nyFlyreise(Flyreise flyreise)
            {
            return _repository.nyFlyreise(flyreise);
            }
            public bool slettKunde(int KundeId)
            {
                return _repository.slettKunde(KundeId);
            }
        public bool slettBillett(int BillettId)
        {
            return _repository.slettBillett(BillettId);
        }
        public bool slettFlyreise(int FlyreiseId)
        {
            return _repository.slettFlyreise(FlyreiseId);
        }
        Kunde hentEnKunde(int KundeId)
        {
            return _repository.hentEnKunde(KundeId);
        }
        public bool endreKunde(int id, Kunde innKunde)
        {
            return _repository.endreKunde(id, innKunde);
        }

    }
}

