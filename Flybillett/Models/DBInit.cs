using Flybillett.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Flybillett.Models
{
    public class DBInit : DropCreateDatabaseAlways<DBContext>
    {
        protected override void Seed(DBContext context)
        {
            var Flyreise1 = new Flyreise { fraBy = "Oslo", tilBy = "Bergen", dato = "22.10.2017", tid = "12:30", pris = "2650" };
            var Flyreise2 = new Flyreise { fraBy = "Oslo", tilBy = "Trondheim", dato = "21.10.2017", tid = "12:00", pris = "1250" };
            var Flyreise3 = new Flyreise { fraBy = "Oslo", tilBy = "Manchester", dato = "23.10.2017", tid = "13:00", pris = "1150" };
            var Flyreise4 = new Flyreise { fraBy = "Oslo", tilBy = "Manchester", dato = "21.10.2017", tid = "14:00", pris = "1450" };
            var Flyreise5 = new Flyreise { fraBy = "Oslo", tilBy = "Berlin", dato = "21.10.2017", tid = "14:00", pris = "1450" };
            var Flyreise6 = new Flyreise { fraBy = "Bergen", tilBy = "Oslo", dato = "22.10.2017", tid = "12:30", pris = "2350" };
            var Flyreise7 = new Flyreise { fraBy = "Bergen", tilBy = "Trondheim", dato = "21.10.2017", tid = "12:00", pris = "2250" };
            var Flyreise8 = new Flyreise { fraBy = "Bergen", tilBy = "Oslo", dato = "21.10.2017", tid = "13:00", pris = "2150" };
            var Flyreise9 = new Flyreise { fraBy = "Bergen", tilBy = "Trondheim", dato = "21.10.2017", tid = "14:00", pris = "1450" };
            var Flyreise10 = new Flyreise { fraBy = "Bergen", tilBy = "Oslo", dato = "21.10.2017", tid = "14:00", pris = "1450" };
            var Flyreise11 = new Flyreise { fraBy = "Bergen", tilBy = "Oslo", dato = "20.10.2017", tid = "12:30", pris = "2350" };
            var Flyreise12 = new Flyreise { fraBy = "Trondheim", tilBy = "Oslo", dato = "20.10.2017", tid = "12:00", pris = "2250" };
            var Flyreise13 = new Flyreise { fraBy = "Trondheim", tilBy = "Bergen", dato = "20.10.2017", tid = "13:00", pris = "2150" };
            var Flyreise14 = new Flyreise { fraBy = "Trondheim", tilBy = "Oslo", dato = "20.10.2017", tid = "14:00", pris = "1450" };
            var Flyreise15 = new Flyreise { fraBy = "Trondheim", tilBy = "Bergen", dato = "22.10.2017", tid = "14:00", pris = "1450" };
            context.Flyreise.Add(Flyreise1);
            context.Flyreise.Add(Flyreise2);
            context.Flyreise.Add(Flyreise3);
            context.Flyreise.Add(Flyreise4);
            context.Flyreise.Add(Flyreise5);
            context.Flyreise.Add(Flyreise6);
            context.Flyreise.Add(Flyreise7);
            context.Flyreise.Add(Flyreise8);
            context.Flyreise.Add(Flyreise9);
            context.Flyreise.Add(Flyreise10);
            context.Flyreise.Add(Flyreise11);
            context.Flyreise.Add(Flyreise12);
            context.Flyreise.Add(Flyreise13);
            context.Flyreise.Add(Flyreise14);
            context.Flyreise.Add(Flyreise15);
            base.Seed(context);
        }
    }
}