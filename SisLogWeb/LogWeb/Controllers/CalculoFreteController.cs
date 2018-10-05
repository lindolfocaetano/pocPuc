using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using LogWeb.Models;
using LogWeb.Models.CalculoFrete;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SegurancaAPI.Models;

namespace LogWeb.Controllers
{

    [Route("[controller]/[action]")]
    public class CalculoFreteController : Controller
    {
        private string _token;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger _logger;
        


        public CalculoFreteController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;

        }

        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            var token = CheckToken();
            var client = new HttpClient();
            //var stringContent = new StringContent(token.Value, UnicodeEncoding.UTF8, "application/json");
            //stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var url = "http://localhost:64853/frete/v1/cidades";
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Value);
            var result = client.GetAsync(url).Result;
            IEnumerable<CidadeViewModel> cidades = JsonConvert.DeserializeObject<List<CidadeViewModel>>(result.Content.ReadAsStringAsync().Result);
            CotarFreteViewModel cotar = new CotarFreteViewModel
            {
                Cidades = cidades
            };

            return View(nameof(Index), cotar);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Cotar(CotarFreteViewModel cotacao)
        {
            var token = CheckToken();
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Value);

            var url = "http://localhost:64853/frete/CotarFrete";
            var urlCidades = "http://localhost:64853/frete/v1/Nomecidades";
            var idCidades = new List<string>
            {
                cotacao.IdCidadeorigem,cotacao.IdCidadeDestino
            };
            var stringIdCidades = new StringContent(JsonConvert.SerializeObject(idCidades), Encoding.UTF8, "application/json");
            var nmCidadesResponse = client.PostAsync(urlCidades, stringIdCidades).Result.Content.ReadAsStringAsync();

            var stringContent = new StringContent(JsonConvert.SerializeObject(cotacao), Encoding.UTF8, "application/json");
            var response = client.PostAsync(url, stringContent);
            ValorFreteViewModel cotacaoResult = JsonConvert.DeserializeObject<ValorFreteViewModel>(response.Result.Content.ReadAsStringAsync().Result);
            var nmCidades = JsonConvert.DeserializeObject<IEnumerable<CidadeViewModel>>(nmCidadesResponse.Result);

            cotacaoResult.CidadeDestino = nmCidades.FirstOrDefault(x => x.IdCidade == cotacaoResult.IdCidadeDestino).NmCidade;
            cotacaoResult.CidadeOrigem = nmCidades.FirstOrDefault(x => x.IdCidade == cotacaoResult.IdCidadeOrigem).NmCidade;
            
            return View("cotar", cotacaoResult);

        }

        private TokenModel CheckToken()
        {
            if (_token == null)
            {
                _token = GetToken();
            }
            var token = JsonConvert.DeserializeObject<TokenModel>(_token);
            try
            {
                var validaToken = new JwtSecurityTokenHandler().ReadToken(token.Value);
            }
            catch (Exception)
            {
                throw new Exception("token inválido");
            }
            return token;
        }

        private String GetToken()
        {
            var url = "https://localhost:44368/AccountExternal/Login";
            var client = new HttpClient();
            string t = "{\"Email\":\"sislog@gmail.com\",\"Password\":\"P@c2018\"}";
            var stringContent = new StringContent(t, UnicodeEncoding.UTF8, "application/json");
            stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = client.PostAsync(url, stringContent).Result;
            _token = response.Content.ReadAsStringAsync().Result;
            return _token;

        }
    }
}