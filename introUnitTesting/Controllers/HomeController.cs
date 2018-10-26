using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using introUnitTesting.Models;
using introUnitTesting.Services;

namespace introUnitTesting.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICalculator _calculator;

        public HomeController(ICalculator calculator)
        {
            _calculator = calculator ?? throw new ArgumentNullException(nameof(calculator));
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [HttpGet]
        public IActionResult Math()
        {
            var model = new MathOperation();
            return View(model);
        }

        [HttpPost]
        public IActionResult Math(MathOperation model)
        {
            var result = _calculator.Calculate(model.Operand1, model.Operand2, model.Operation);
            model.Result = result;
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}