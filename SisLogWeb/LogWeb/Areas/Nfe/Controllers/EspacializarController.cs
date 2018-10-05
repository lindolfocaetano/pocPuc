using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using LogWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LogWeb.Areas.EspacializarNf.Controllers
{
    public class EspacializarController : Controller
    {
        [Area("Nfe")]
        public IActionResult Index()
        {
            //var client = new HttpClient();
            ////string url = "http://localhost:55764/Nfe/Espacializar";
            //var dados = client.GetStringAsync(url);
            //var valores = JsonConvert.DeserializeObject<NfeListaViewModel>(dados.Result);

            return View();

        }
    }
}