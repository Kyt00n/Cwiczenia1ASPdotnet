using Cwiczenia1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Cwiczenia1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About()
        {
            ViewBag.Name = "Anna";
            ViewBag.Godzina = DateTime.Now.Hour;
            ViewBag.Powitanie = ViewBag.Godzina < 17 ? "Dzien Dobry" : "Dobry Wieczór";
            Dane[] osoby =
            {
                new Dane {Name= "Anna", Surname="Nowak"},
                new Dane {Name= "Olaf", Surname="Kowalski"},
                new Dane {Name= "Mike", Surname="Wazowski"},
                new Dane {Name= "Eryk", Surname="Olsza"}
            };
            return View(osoby);
        }
        public IActionResult UrodzinyForm()
        {
            return View();
        }
        public IActionResult Urodziny(Urodziny urodziny)
        {
            ViewBag.Powitanie = $"witaj {urodziny.Imie} {DateTime.Now.Year - urodziny.Rok} lat";
            return View(urodziny);
        }
        public IActionResult Kalkulator(Kalkulator kalkulator)
        {
            switch (kalkulator.Symbol)
            {
                case "+":
                    ViewBag.Wynik = kalkulator.firstNumber + kalkulator.secondNumber;
                    break;
                case "-":
                    ViewBag.Wynik = kalkulator.firstNumber - kalkulator.secondNumber;
                    break;
                case "*":
                    ViewBag.Wynik = kalkulator.firstNumber * kalkulator.secondNumber;
                    break;
                case "/":
                    if (kalkulator.secondNumber != 0)
                    {
                    ViewBag.Wynik = kalkulator.firstNumber / kalkulator.secondNumber;
                    }
                    else
                    {
                        ViewBag.Wynik = "dzielenie przez zero";
                    }
                    break;
                default:
                    ViewBag.Wynik = "";
                    break;
            }
            return View(kalkulator);
        }
        public IActionResult KalkulatorForm()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}