using MetroCuadrado.Pages;
using MetroCuadrado.Tests.Base;
using Microsoft.VisualBasic.CompilerServices;
using NUnit.Framework;
using System;

namespace MetroCuadrado.Tests
{
    public class MetroCuadradoTest : TestBase
    {
        static string[][] dataInput =
        {
            new string[] { "737717", "5 Años"} ,
            new string[] { "737717", "10 Años"},
            new string[] { "737717", "15 Años"},
            new string[] { "737717", "20 Años"},
            new string[] { "5000000", "5 Años"} ,
            new string[] { "5000000", "10 Años"},
            new string[] { "5000000", "15 Años"},
            new string[] { "5000000", "20 Años"},
        };
        [Test, Category("calculator")]
        [TestCaseSource("dataInput")]
        public void CalcularCredito(string ingresos, string plazo)
        {
            Page.Home.CuantoTePrestan(ingresos, plazo);
            var strInicial = Page.Home.GetCuotaInicial();
            var strValor = Page.Home.GetValorDelInmueble();
            var strPrestamo = Page.Home.GetMaximoPrestamo();
            int cuotaInicial = int.Parse(strInicial);
            int valorInmueble = int.Parse(strValor);
            int prestamo = int.Parse(strPrestamo);
            Console.WriteLine("Ingresos: "+Page.Home.GetIngreso());
            Console.WriteLine("Prestamo: " + strPrestamo);
            Console.WriteLine("Cuota Inicial: " + strInicial);
            Console.WriteLine("Valor Inmueble: " + strValor);

            Assert.AreEqual(ingresos, Page.Home.GetIngreso());
            Assert.AreEqual(cuotaInicial, Math.Round(0.3 * valorInmueble));
            Assert.AreEqual(prestamo, Math.Round(0.7 * valorInmueble));
            //Assert.AreEqual(ingresos, FORMULA DE NEGOCIO);
        }



    }
}