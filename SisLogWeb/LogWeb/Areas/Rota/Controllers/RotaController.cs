using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using LogWeb.Areas.Map.Models;
using LogWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LogWeb.Areas.Map.Controllers
{
    [Area("Rota")]
    public class RotaController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {

            //var client = new HttpClient();
            //string result = client.GetAsync("http://localhost:50802/api/routing").Result.Content.ReadAsStringAsync().Result;
            //var teste = JArray.Parse(result);
            //var dados = new JsonDTO()
            //{
            //    Rotas = teste.Select(x => x.ToString())

            //};
            return View();
        }
        [HttpGet]
        public IActionResult List()
        {
            return View();
        }
        //public IActionResult Routeirizar()
        //{
        //    var client = new HttpClient();
        //    string result = client.GetAsync("http://localhost:55764/Nfe/Notas").Result.Content.ReadAsStringAsync().Result;
        //    NFe4ViewModel nf = JsonConvert.DeserializeObject<NFe4ViewModel>(result);
        //}
    }
}