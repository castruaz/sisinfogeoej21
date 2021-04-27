using System;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Threading;
using System.IO;
using System.Collections.Generic;

namespace _43webscraping4_p
{
    class Program
    {
        static void Main(string[] args)
        {
            //Selenium1();
            Selenium2();
        }

        static void Selenium2() {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--disable-extensions"); // to disable extension
            options.AddArguments("--disable-notifications"); // to disable notification
            options.AddArguments("--disable-application-cache"); // to disable cache
            ChromeDriver driver = new ChromeDriver(options);
            driver.Url = "https://www.facebook.com/";
            driver.Manage().Window.Maximize();
            string email = "perfectkey999@gmail.com";
            string pass = "Uaz@2009@";
            IWebElement element = driver.FindElement(By.Id("email"));
            element.SendKeys(email);
            element = driver.FindElement(By.Id("pass"));
            element.SendKeys(pass);
            element = driver.FindElement(By.Name("login"));
            element.Click();
            Pausa();
            driver.Navigate().Back();


            // Hacer post
            // Pausa();
            // driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[1]/div[1]/div/div[2]/div/div/div[3]/div/div[2]/div/div/div/div[1]/div/div[1]/span")).Click();
                                         
            // Pausa();
            // element=driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[4]/div/div/div[1]/div/div[2]/div/div/div/form/div/div[1]/div/div/div/div[2]/div[1]/div[1]/div[1]/div/div/div/div/div[2]/div/div/div/div"));
            // element.Click();
            // element.SendKeys("Hola desde Selenium 3 \n");
            // Pausa();
            // driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[4]/div/div/div[1]/div/div[2]/div/div/div/form/div/div[1]/div/div/div/div[3]/div[2]/div")).Click();

            // // Hacer logout
            Pausa();
            element = driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[2]/div[4]/div[1]/span/div/div[1]/img"));
            element.Click();
            Pausa();
            element = driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[2]/div[4]/div[2]/div/div/div[1]/div[1]/div/div/div/div/div/div/div/div/div[1]/div/div[3]/div/div[5]/div"));
            element.Click();
             

            // Cerrar Navegador
            //Pausa();
            //driver.Close();
        }

        static void Pausa() {
            Thread.Sleep(2000);
        }


        static void Selenium1()
        {
            FirefoxDriver driver = new FirefoxDriver();

            driver.Url = "https://www.uaz.edu.mx";
            INavigation nav = driver.Navigate();
            
            Pausa();
            nav.GoToUrl("https://google.com");
            var element = driver.FindElement(By.XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[1]/div/div[2]/input"));
            element.Click();
            element.SendKeys("Selenium\n");
            Pausa();
            
            Screenshot captura = driver.GetScreenshot();
            captura.SaveAsFile("capturagoogle.png");

            Pausa();
            nav.Back();
            nav.Back();
            Pausa();
            var html = driver.PageSource;
            Console.WriteLine(html);
            File.WriteAllText("source.html",html);
           
            Pausa();
            nav.Forward();
            nav.Refresh();
            
            Pausa();
            driver.Close();
        }

        
    }
}
