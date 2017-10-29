using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using System.Linq;
using Flybillett.Controllers;
using System.Collections.Generic;
using BLL;
using DAL;
using Model;

namespace Flybillett_testing
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Indexviewtest()
        {
            //arrange
            var controller = new HomeController(new FlyLogikk(new FlyRespositorytStub()));
            //act
            var resultat = (ViewResult)controller.Index();
            //assert
            Assert.AreEqual(resultat.ViewName, "");
        }
        public void Betalingviewtest()
        {
            //arrange
            var controller = new HomeController(new FlyLogikk(new FlyRespositorytStub()));
            //act
            var resultat = (ViewResult)controller.Betaling();
            //assert
            Assert.AreEqual(resultat.ViewName, "");
        }
        public void Adminviewtest()
        {
            //arrange
            var controller = new HomeController(new FlyLogikk(new FlyRespositorytStub()));
            //act
            var resultat = (ViewResult)controller.Admin();
            //assert
            Assert.AreEqual(resultat.ViewName, "");
        }
        public void Logginnviewtest()
        {
            //arrange
            var controller = new HomeController(new FlyLogikk(new FlyRespositorytStub()));
            var resultat = (ViewResult)controller.Logginn();
            //assert
            Assert.AreEqual(resultat.ViewName, "");
        }
        
        

        
        public void SlettKunde()
        {
            //arrange
            var controller = new HomeController(new FlyLogikk(new FlyRespositorytStub()));
            //act
            var actionResult = (ViewResult)controller.SKunde(1);
            var resultat = (List<Billett>)actionResult.Model;
            //assert
            Assert.AreEqual(actionResult.ViewName, "");
        }
        [TestMethod]
        public void SlettetKunde_funnet_Post()
        {
            //arrange
            var controller = new HomeController(new FlyLogikk(new FlyRespositorytStub()));
            var innKunde = new Kunde()
            {
                KundeId = 1,
                 Fornavn = "Hans",
                Etternavn = "Olsen",
                Email = "olsen@mail.no"
            };

            //act
            var actionResult = (RedirectToRouteResult)controller.SlettKunde(1, innKunde);
        
        }
        public void SlettFlyreise()
        {
            //arrange
            var controller = new HomeController(new FlyLogikk(new FlyRespositorytStub()));
            //act
            var actionResult = (ViewResult)controller.SFlyreise(1);
            var resultat = (List<Billett>)actionResult.Model;
            //assert
            Assert.AreEqual(actionResult.ViewName, "");
        }
        [TestMethod]
        public void SlettetFLyreise_funnet_Post()
        {
            //arrange
            var controller = new HomeController(new FlyLogikk(new FlyRespositorytStub()));
            var innFlyreise = new Flyreise()
            {
                FlyreiseId = 1,
                fraBy = "Oslo",
                tilBy = "Bergen",
                tid = "12:30",
                pris = "650" 
            };

            //act
            var actionResult = (RedirectToRouteResult)controller.SlettFlyreiese(1, innFlyreise);

        }
        public void SlettBillett()
        {
            //arrange
            var controller = new HomeController(new FlyLogikk(new FlyRespositorytStub()));
            //act
            var actionResult = (ViewResult)controller.SBillett(1);
            var resultat = (List<Billett>)actionResult.Model;
            //assert
            Assert.AreEqual(actionResult.ViewName, "");
        }
        public void Endre()
        {
            // Arrange
            var controller = new HomeController(new FlyLogikk(new FlyRespositorytStub()));

            // Act
            var actionResult = (ViewResult)controller.endreKunde(1);

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }
        [TestMethod]
        public void Endre_Ikke_Funnet_Ved_View()
        {
            // Arrange
            var controller = new HomeController(new FlyLogikk(new FlyRespositorytStub()));

            // Act
            var actionResult = (ViewResult)controller.endreKunde(1);
            var kundeResultat = (Kunde)actionResult.Model;

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
            Assert.AreEqual(kundeResultat.KundeId, 1);
        }
        [TestMethod]
        public void Endre_ikke_funnet_Post()
        {
            // Arrange
            var controller = new HomeController(new FlyLogikk(new FlyRespositorytStub()));
            var innKunde = new Kunde()
            {
                KundeId = 1,
                Fornavn = "Hans",
                Etternavn = "Olsen",
                Email = "olsen@mail.no"
            };

            // Act
            var actionResult = (ViewResult)controller.Endre(0, innKunde);

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }
        [TestMethod]
        public void Endre_feil_validering_Post()
        {
            // Arrange
            var controller = new HomeController(new FlyLogikk(new FlyRespositorytStub()));
            var innKunde = new Kunde();
            controller.ViewData.ModelState.AddModelError("feil", "ID = 0");

            // Act
            var actionResult = (ViewResult)controller.Endre(0, innKunde);

            // Assert
            Assert.IsTrue(actionResult.ViewData.ModelState.Count == 1);
            Assert.AreEqual(actionResult.ViewData.ModelState["feil"].Errors[0].ErrorMessage, "ID = 0");
            Assert.AreEqual(actionResult.ViewName, "");
        }
        [TestMethod]
        public void Endre_funnet()
        {
            // Arrange
            var controller = new HomeController(new FlyLogikk(new FlyRespositorytStub()));
            var innKunde = new Kunde()
            {
                KundeId = 1,
                Fornavn = "Hans",
                Etternavn = "Olsen",
                Email = "olsen@mail.no"
            };
            // Act
            var actionResultat = (RedirectToRouteResult)controller.Endre(1, innKunde);

            // Assert
            Assert.AreEqual(actionResultat.RouteName, "");
            Assert.AreEqual(actionResultat.RouteValues.Values.First(), "Liste");
        }
    }
}
