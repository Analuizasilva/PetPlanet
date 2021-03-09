﻿using System.Diagnostics;
using System.Threading.Tasks;
using Business.Interfaces;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IClientBusinessObject clientBusinessObject;

        public HomeController(ILogger<HomeController> logger, IClientBusinessObject clientBusinessObject)
        {
            _logger = logger;
            this.clientBusinessObject = clientBusinessObject;
        }

        public async Task<IActionResult> Index()
        {
            var client = new Client { Name = "Ana Luiza", PhoneNumber = 1345 };

            var result = await clientBusinessObject.Create(client);
            return View();
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
