using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LogWeb.Models;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Net.Http.Headers;
using Microsoft.Extensions.Caching.Memory;
using LogWeb.Helpers;

namespace LogWeb.Controllers
{
    public class HomeController : Controller
    {
        private IMemoryCache _cache;
        private ITokenCache _tokenCache;

        public HomeController(IMemoryCache cache,
            ITokenCache tokenCache)
        {
            _cache = cache;
            _tokenCache = tokenCache;
        }

        public IActionResult Index()
        {
            var client = new HttpClient();
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "OPS! Ainda estamos trabalhando aqui...";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Precisa falar conosco?";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
