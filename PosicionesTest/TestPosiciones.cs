using Microsoft.VisualStudio.TestTools.UnitTesting;
using PosicionesNegocio.Models;

namespace PosicionesTest
{
    [TestClass]
    public class TestPosiciones
    {
        [TestMethod]
        public void TestPosicionesUno()
        {
            ParamBusqueda oParam = new ParamBusqueda();
            oParam.Palabra = "JAVA";
            PosicionesNegocio.PosicionesManager PosicionesManager = new PosicionesNegocio.PosicionesManager();
            var model = PosicionesManager.TraerPosiciones(oParam);
        }

        [TestMethod]
        public void TestPosicionesDos()
        {
            ParamBusqueda oParam = new ParamBusqueda();
            oParam.Palabra = "TELEFE";
            PosicionesNegocio.PosicionesManager PosicionesManager = new PosicionesNegocio.PosicionesManager();
            var model = PosicionesManager.TraerPosiciones(oParam);
        }


        [TestMethod]
        public void TestPosicionesTres()
        {
            ParamBusqueda oParam = new ParamBusqueda();
            oParam.Palabra = "VIACOM";
            PosicionesNegocio.PosicionesManager PosicionesManager = new PosicionesNegocio.PosicionesManager();
            var model = PosicionesManager.TraerPosiciones(oParam);
        }


        [TestMethod]
        public void TestPosicionesCuatro()
        {
            ParamBusqueda oParam = new ParamBusqueda();
            oParam.Palabra = "TEST";
            PosicionesNegocio.PosicionesManager PosicionesManager = new PosicionesNegocio.PosicionesManager();
            var model = PosicionesManager.TraerPosiciones(oParam);
        }


        [TestMethod]
        public void TestPosicionesCinco()
        {
            ParamBusqueda oParam = new ParamBusqueda();
            oParam.Palabra = "NODE";
            PosicionesNegocio.PosicionesManager PosicionesManager = new PosicionesNegocio.PosicionesManager();
            var model = PosicionesManager.TraerPosiciones(oParam);
        }


        [TestMethod]
        public void TestPosicionesSeis()
        {
            ParamBusqueda oParam = new ParamBusqueda();
            oParam.Palabra = "tEleFE";
            PosicionesNegocio.PosicionesManager PosicionesManager = new PosicionesNegocio.PosicionesManager();
            var model = PosicionesManager.TraerPosiciones(oParam);
        }

        [TestMethod]
        public void TestPosicionesSiete()
        {
            ParamBusqueda oParam = new ParamBusqueda();
            oParam.Palabra = "";
            PosicionesNegocio.PosicionesManager PosicionesManager = new PosicionesNegocio.PosicionesManager();
            var model = PosicionesManager.TraerPosiciones(oParam);
        }

        [TestMethod]
        public void TestPosicionesOcho()
        {
            ParamBusqueda oParam = new ParamBusqueda();
            oParam.Palabra = "TELEFEVIACOMJAVA";
            PosicionesNegocio.PosicionesManager PosicionesManager = new PosicionesNegocio.PosicionesManager();
            var model = PosicionesManager.TraerPosiciones(oParam);
        }
    }
}
