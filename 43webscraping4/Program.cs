using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System.IO;
 

namespace _43webscraping4
{
    class Program
    {
        static void Main(string[] args)
        {
            Selenum2(); 
        }

        static void Selenum2() { 
            ChromeOptions opciones = new ChromeOptions();
            opciones.AddArgument("--disable-notifications");
            ChromeDriver driver = new ChromeDriver(opciones);
            driver.Url="https://www.facebook.com";
            string email = "perfectkey999@gmail.com";
            string password = "Uaz@2009@";
            var elemento = driver.FindElement(By.Id("email"));
            elemento.SendKeys(email);
            driver.FindElement(By.Id("pass")).SendKeys(password);
            driver.FindElement(By.Name("login")).Click();
            driver.Navigate().Back();
            Pausa();
            //driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[1]/div[1]/div/div[2]/div/div/div[3]/div/div[2]/div/div/div/div[1]/div/div[1]/span")).Click();
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[2]/div[4]/div[1]/span/div/div[1]/img")).Click();
            Pausa();
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[2]/div[4]/div[2]/div/div[2]/div[1]/div[1]/div/div/div/div/div/div/div/div/div[1]/div/div[3]/div/div[5]/div/div[1]/div[2]/div/div/div/div/span")).Click();
            //driver.Close();
        }


        static void Selenum1() {
            FirefoxDriver driver = new FirefoxDriver();
            driver.Url = "https://www.uaz.edu.mx";
            //Pausa();
            var nav = driver.Navigate();
            nav.GoToUrl("https://google.com");
            driver.Manage().Window.Maximize();
            //Pausa();
            var elemento = driver.FindElement(By.Name("q"));
            elemento.Click();
            elemento.SendKeys("gorditas doña julia"+Keys.Return);
            Pausa();
            var captura = driver.GetScreenshot();
            captura.SaveAsFile("capturagoogle.png");
            nav.Back();
            nav.Back();
            Pausa();
            var html = driver.PageSource;
            Console.WriteLine(html);
            File.WriteAllText("codigofuente.html",html);
            Pausa();
            nav.Forward();
            nav.Refresh();
            Pausa();
            driver.Close();
        }

        static void Pausa() {
            Thread.Sleep(2000);
        }

    }
}
