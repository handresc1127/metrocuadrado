using Framework.Selenium;
using OpenQA.Selenium;
using System.Runtime.InteropServices.ComTypes;

namespace MetroCuadrado.Pages
{
    public class HomePage
    {
        public readonly HomePageMap Map;

        public HomePage()
        {
            Map = new HomePageMap();
        }

        public void CuantoTePrestan(string ingresos, string plazo)
        {
            Map.IngresosMensuales.SendKeys(ingresos);
            new Select(Map.Plazo).SelectByText(plazo);
            Map.CalcularCredito.Click();
            Driver.Wait.Until(WaitConditions.ElementDisplayed(Map.Datos));
        }

        public string GetIngreso()
        {
            return Map.DatoIngreso.Text.Replace("$","").Replace(",", "").Trim();
        }
        public string GetMaximoPrestamo()
        {
            return Map.DatoMaxPrestamo.Text.Replace("$", "").Replace(",", "").Trim();
        }
        public string GetCuotaInicial()
        {
            return Map.DatoCuotaInicial.Text.Replace("$", "").Replace(",", "").Trim();
        }
        public string GetValorDelInmueble()
        {
            return Map.DatoValorInmueble.Text.Replace("$", "").Replace(",", "").Trim();
        }
    }

    public class HomePageMap
    {
        public Element IngresosMensuales => Driver.FindElement(By.Id("ingresosMensuales"), "Ingresos Mensuales");
        public Element Plazo => Driver.FindElement(By.CssSelector("[ng-model='termInYears']"), "Plazo");
        public Element CalcularCredito => Driver.FindElement(By.CssSelector(".btn.btn-upload.credito"), "Calcular Credito");
        public Element Datos => Driver.FindElement(By.ClassName("datos_superior"), "Datos Prestamo");
        public Element DatoIngreso => Driver.FindElement(By.XPath("//*[@class='datos_superior']//*[contains(.,'Con un ingreso mensual de:')]//dd"), "Dato de Ingresos");
        public Element DatoMaxPrestamo => Driver.FindElement(By.XPath("//*[@class='datos_superior']//*[contains(.,'Un banco puede prestarte')]//dd"), "Dato de Ingresos");
        public Element DatoCuotaInicial => Driver.FindElement(By.XPath("//*[@class='datos_superior']//*[contains(.,'Debe tener una cuota inicial')]//dd"), "Dato de Ingresos");
        public Element DatoValorInmueble => Driver.FindElement(By.XPath("//*[@class='datos_superior']//*[contains(.,'Puede comprar un inmueble de')]//dd"), "Dato de Ingresos");
    }
}
