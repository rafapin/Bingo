using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Bingo.Models;

namespace Bingo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public List<Balota> Balotas = new List<Balota>();

        public class Balota
        {
            public int Number { get; set; }
            public int Status { get; set; }

        }
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public int Reset()
        {
            for(var i=1; i <= 75; i++)
            {
                Balotas.Add(new Balota { Number = 1, Status = 0 });
            }
            return 1;
        }
        public List<Balota> GetBalotas()
        {
            return Balotas;
        }

        public IActionResult Privacy()
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
