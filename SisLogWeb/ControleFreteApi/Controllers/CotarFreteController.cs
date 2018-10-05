using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleFreteApi.Domain.Interface;
using ControleFreteApi.Dto;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControleFreteApi.Controllers
{
    
    public class CotarFreteController : Controller
    {
        private ICotarFreteService _cotarFreteService;
        public CotarFreteController(ICotarFreteService cotarFreteService)
        {
            _cotarFreteService = cotarFreteService;
        }

        /// <summary>
        /// Calculo de cotações de frete
        /// </summary>
        /// <param name="cotacao"></param>
        /// <returns></returns>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("frete/CotarFrete")]
        [HttpPost]
        [ProducesResponseType(typeof(CotarFreteDto),200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(typeof(void), 400)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(void), 409)]
        public JsonResult CotarFrete([FromBody]CotarFreteDto cotacao)
        {
            return Json(_cotarFreteService.GetValorFrete(cotacao));
        }

        /// <summary>
        /// Teste de acesso sem autorização
        /// </summary>
        /// <param name="cotacao"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("frete/CotarFrete")]
        [HttpGet]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(typeof(void), 400)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(void), 409)]
        public JsonResult CotarFrete()
        {
            return Json("Teste sem autorização");
        }


    }
}